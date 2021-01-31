import time
import sys
from numpy import array, arange, divide, where, flip, abs
from numpy.core.fromnumeric import prod, sum, transpose
from pandas import DataFrame
from scipy.interpolate import InterpolatedUnivariateSpline as IUS


def pk_to_k(pk):
    return array(10.0 ** (-array(pk)))


def closest_value(num, arr):
    """Returns the closest value to the number in the array."""
    return min(arr, key = lambda x: abs(x - num))


class Compound :
    def __init__(self, name, acidic, pKs, strong):
        self.name = name
        self.acidic = acidic
        self.pKs = pKs
        self.K = pk_to_k(pKs)
        self.strong = strong


class AcidBase :
    def __init__(self, analyte, titrant, precision=2, pKw=None, temp=None):
        self.analyte_is_acidic = analyte.acidic
        self.pk_analyte = analyte.pKs
        self.k_analyte = pk_to_k(analyte.K)
        self.titrant_acidity = titrant.acidic
        self.k_titrant = pk_to_k(titrant.K)
        self.pk_titrant = titrant.pKs

        self.aname = analyte.name
        self.tname = titrant.name

        if pKw is not None:
            self.kw = 10 **(-pKw)
        elif temp is not None:
            self.kw = 10 **(-self.get_kw(temp))
        else:
            self.kw = 10 **(-13.995)

        self.strong_analyte = analyte.strong
        self.strong_titrant = titrant.strong
        self.precision = 10 **-precision
        self.ph, self.hydronium, self.hydroxide = self.starting_phs()

    def starting_phs(self, min_ph= 0, max_ph= 14):
        ph = array(arange(min_ph, max_ph + self.precision, step = self.precision))
        h = 10 **(-ph.copy())
        oh = self.kw / h
        if self.analyte_is_acidic:
            return ph, h, oh
        else:
            return ph[::- 1], h[::- 1], oh[::- 1]

    @staticmethod
    def get_kw(temp):
        # if temp > 350 or temp < 0:
        #     print(
        #         "Warning! The Kw calculation loses accuracy near the end of the range 0C to 350C."
        #         "\nProceed with caution, or set a pKw value rather than a temperature."
        #     )

        # Variables for a quartic function found to have an R^2 > 0.9999 in Desmos for n=40 Kw values at different temps
        # This most likely works only on the range of data used: 0C to 350C
        a = 6.7179 * 10 ** -10
        b = -5.3141 * 10 ** -7
        c = 0.000199761
        d = -0.0421956
        f = 14.9376
        pKw = (a * temp ** 4) + (b * temp ** 3) + (c * temp ** 2) + (d * temp) + f
        return pKw


class Bjerrum(AcidBase):
    def __init__(self, analyte, titrant, precision, pKw=None, temp=None):

        super().__init__(analyte, titrant, precision, pKw, temp)

        self.alpha_analyte = self.alpha_values(k=analyte.K, acid=analyte.acidic)
        self.alpha_titrant = self.alpha_values(k=titrant.K, acid=titrant.acidic)

    @staticmethod
    def scale_alphas(arr):
        new_arr = []
        for num, a in enumerate(array(arr).T):
            a *= num
            new_arr.append(a)

        return array(new_arr).T

    def alpha_values(self, k, acid=True):
        # Convert the k values to a list to help with matrix transformations.
        k = array(k)

        # If the k values are for K_b, convert to K_a. --> K_1 = K_w / K_n , K_2 = K_w / K_(n-1)
        if not acid:
            k = self.kw / flip(k)

        # The functionality of an acid or base can be determined by the number of dissociation constants it has.
        n = len(k)

        # Get the values for the [H+]^n power
        h_vals = array([self.hydronium ** i for i in range(n, -1, -1)])

        # Get the products of the k values.
        k_vals = [prod(k[0:x]) for x in range(n + 1)]

        # Prod and Sum the h and k values
        denoms_arr = h_vals.T * k_vals  # Product of the sub-elements of the denominator
        denoms = sum(denoms_arr, axis=1)  # Sum of the sub-elements of the denominator

        # Do the outermost alpha value calculation
        alphas = divide(denoms_arr.T, denoms).T  # Divide and re-transpose

        if not acid:
            return flip(alphas, axis=0)
        else:
            return array(alphas)

    def write_alpha_data(self, title="Alpha Value Data", file_headers=False, species_names=None):
        # Initialize the dataframe with the ph values
        data_dict = {"pH": self.ph}

        # Add the alpha values for each analyte species
        if species_names is None:  # If names are not specified, just use generics.
            for num, alpha in enumerate(transpose(self.alpha_analyte)):
                data_dict[f"alpha{num}"] = alpha
        else:  # If names are specified, use them.
            for num, alpha in enumerate(transpose(self.alpha_analyte)):
                try:
                    data_dict[species_names[num]] = alpha
                except IndexError:
                    raise ValueError("You have not supplied enough species names!")

        # Make and write the data frame to a csv
        data = DataFrame(data_dict)
        data.to_csv(f"{title}.csv", index=False, header=file_headers)


class Titration(Bjerrum):
    """
    A class which defines a titration and predominance curve based on the used analyte and titrant.
    """

    def __init__(
        self,
        analyte,
        titrant,
        volume_analyte,
        concentration_analyte,
        concentration_titrant,
        precision=2,
        pKw=None,
        temp=None,
    ):
        super().__init__(analyte, titrant, precision, pKw, temp)

        # Analyte information
        self.concentration_analyte = concentration_analyte
        self.volume_analyte = volume_analyte
        self.ka_values = analyte.K

        # Titrant Information
        self.concentration_titrant = concentration_titrant
        self.kt_values = titrant.K

        # Calculate the respective titrant values for each pH
        self.volume_titrant, self.phi = self.calculate_volume(self.titrant_acidity)

        # Trimmed values for gui plot
        self.ph_t, self.volume_titrant_t = self.trim_values(self.ph, self.volume_titrant)

    def trim_values(self, *args):
        # Go until you are 1 past the last sub-reaction.
        limiter = len(self.k_analyte) + 1

        good_val_index = where((self.phi >= 0) & (self.phi <= limiter))

        # Trim the values for every chosen data set
        rets = (arg[good_val_index] for arg in args)  # Add the trimmed dataset to the return variable

        return rets

    def calculate_volume(self, acid_titrant):

        # Alpha values scaled by their index
        scaled_alphas_analyte = self.scale_alphas(self.alpha_analyte)
        scaled_alphas_titrant = self.scale_alphas(self.alpha_titrant)

        # Sum the scaled alpha values. Axis=1 forces the summation to occur for each individual [H+] value.
        # Since strong acids/bases fully dissociate, they only appear in their pure form, thus, their alpha values = 1
        # The alpha values are calculated to be almost exactly 1 anyways, but letting it calculate as normal breaks the
        #  calculation
        if self.strong_analyte:
            summed_scaled_alphas_analyte = array([1])
        else:
            summed_scaled_alphas_analyte = sum(scaled_alphas_analyte, axis=1)

        if self.strong_titrant:
            summed_scaled_alphas_titrant = array([1])
        else:
            summed_scaled_alphas_titrant = sum(scaled_alphas_titrant, axis=1)

        delta = self.hydronium - self.hydroxide  # I found this written as delta somewhere, and thus it will be named.

        # Conditional addition or subtraction based on the titrant.
        if acid_titrant:
            numerator = summed_scaled_alphas_analyte + (delta / self.concentration_analyte)
            denominator = summed_scaled_alphas_titrant - (delta / self.concentration_titrant)
        else:
            numerator = summed_scaled_alphas_analyte - (delta / self.concentration_analyte)
            denominator = summed_scaled_alphas_titrant + (delta / self.concentration_titrant)

        # Solve for the volume
        phi = numerator / denominator
        volume = phi * self.volume_analyte * self.concentration_analyte / self.concentration_titrant
        return volume, phi

    def write_titration_data(self, title="Titration Curve Data", file_headers=False):
        # Make dataframe.
        pH, volume = self.trim_values(self.ph, self.volume_titrant)
        data = DataFrame({"volume": volume, "pH": pH})

        # Write to a csv.
        data.to_csv(f"{title}.csv", index=False, header=file_headers)

    def find_buffer_points(self):
        pH, volume = self.trim_values(self.ph, self.volume_titrant)
        pKas = array(self.pk_analyte)
        # All the volumes where the pH equals pKa
        volume_indices = []
        for pKa in pKas:
            places = where(pH == closest_value(pKa, pH))[0][0]
            volume_indices.append(places)

        return volume[volume_indices], pKas

    def find_equiv_points(self):
        pH, volume, phi = self.trim_values(self.ph, self.volume_titrant, self.phi)
        points = []
        for i in range(1, len(self.pk_analyte) + 1):
            closest = closest_value(i, phi)
            points.append(where(phi == closest)[0][0])

        return list(volume[points]), list(pH[points])

    def deriv(self, degree):
        pH, volume = self.trim_values(self.ph, self.volume_titrant)

        # An object which makes splines
        spline_maker = IUS(volume, pH)

        # An object which calculates the derivative of those splines
        deriv_function = spline_maker.derivative(n=degree)

        # Calculate the derivative at all of the splines
        d = deriv_function(volume)

        return volume, d

    @staticmethod
    def _scale_data(data, a):
        """abs normalization"""
        return a * (data / (1 + abs(data)))

    def write_analysis_data(self, title="Analysis Data", file_headers=False):
        # Make dataframe.
        pH, volume = self.trim_values(self.ph, self.volume_titrant)
        volumeD1, deriv1 = self.deriv(1)
        volumeD2, deriv2 = self.deriv(2)
        volumeEq, pHEq = self.find_equiv_points()
        volumeBf, pHBf = self.find_buffer_points()

        analysis_row_labels = [
            *[f"eq pt {n}" for n in range(1, len(volumeEq) + 1)],
            *[f"bf pt {n}" for n in range(1, len(volumeBf) + 1)],
        ]

        analysis_volumes = [*[n for n in volumeEq], *[n for n in volumeBf]]
        analysis_pHs = [*[n for n in pHEq], *[n for n in pHBf]]

        while len(analysis_row_labels) < len(deriv1):
            analysis_row_labels.append(None)
            analysis_volumes.append(None)
            analysis_pHs.append(None)

        data = DataFrame(
            {
                "volume": volume,
                "1st Derivative": deriv1,
                "2nd Derivative": deriv2,
                " ": [" " for _ in range(len(deriv1))],
                "Analysis": analysis_row_labels,
                "Volume at Point": analysis_volumes,
                "pH at Point": analysis_pHs,
            }
        )

        # Write to a csv.
        data.to_csv(f"{title}.csv", index=False, header=True)