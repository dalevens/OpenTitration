from numpy import array, arange, divide, where, flip, abs
from numpy.core.fromnumeric import prod, sum, transpose
from typing import List, Tuple, Generator, Any
from dataclasses import dataclass, field


def pk_to_k(pk) -> array:
    """Convert pK values to K values"""
    return array(10.0 ** (-array(pk)))


def closest_value(num: float, arr: array) -> float:
    """Returns the closest value to the number in the array."""
    return min(arr, key=lambda x: abs(x - num))


@dataclass
class Compound:
    name: str
    acidic: bool
    pKas: list

    def __post_init__(self):
        self.ks: array = array(10.0 ** (-array(self.pKas)))


@dataclass
class Titration:
    analyte: Compound
    titrant: Compound

    concentration_analyte: float
    concentration_titrant: float

    volume_analyte: float

    pKw: float = field(default=None)
    temp: float = field(default=25)
    precision: float = field(default=0.01)

    def __post_init__(self):
        """Important values to calculate after the initialization"""
        # Calculate the pKw
        if self.pKw is not None:  # If given a pKw
            self.kw = 10 ** (-self.pKw)
        else:  # If given a temperature
            self.kw = 10 ** (-self.temp_kw(self.temp))

        """These should be done when the calculations are required, not when the object is instantiated."""
        # Value ranges
        self.ph, self.hydronium, self.hydroxide = self.starting_phs()

        # Calculate the alpha values for the compounds at each pH
        self.alpha_analyte = self.alpha_values(k=self.analyte.ks, acid=self.analyte.acidic)
        self.alpha_titrant = self.alpha_values(k=self.titrant.ks, acid=self.titrant.acidic)

        # Calculate and trim the volumes.
        self.volume_titrant, self.phi = self.calculate_volume(self.titrant.acidic)
        self.ph_t, self.volume_titrant_t = self.trim_values(self.ph, self.volume_titrant)

    def starting_phs(self, min_ph: float = 0, max_ph: float = 14) -> Tuple[array, array, array]:
        """Returns a range of pH, hydronium concentration, and hydroxide concentrations"""

        if self.analyte.acidic:
            ph = arange(min_ph, max_ph + self.precision, step=self.precision)
        else:
            ph = arange(max_ph + self.precision, min_ph, step=-self.precision)

        h = 10 ** (-ph)
        oh = self.kw / h
        return ph, h, oh

    @staticmethod
    def temp_kw(temp: float) -> float:
        """Returns the pKw of water given a certain temperature in celsius."""

        # Quadratic approximation of the data for liquid water found here:
        # https://www.engineeringtoolbox.com/ionization-dissociation-autoprotolysis-constant-pKw-water-heavy-deuterium-oxide-d_2004.html
        # 0 <= T <= 95 C
        # R^2 = 0.9992
        a = 0.000128275
        b = -0.0406144
        c = 14.9368
        pKw = (a * temp ** 2) + (b * temp) + c
        return pKw

    @staticmethod
    def _scale_data(data: array, a: float) -> array:
        """abs normalization"""
        return a * (data / (1 + abs(data)))

    @staticmethod
    def scale_alphas(arr: array) -> array:
        """Scale the alpha values by its index in the sub-array"""
        new_arr = []
        for num, a in enumerate(arr.T):
            a *= num
            new_arr.append(a)

        return array(new_arr).T

    def alpha_values(self, k: array, acid: bool = True) -> array:
        """Finds the fraction of solution which each species of compound takes up at each pH."""
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

        if acid:
            return array(alphas)
        else:
            return flip(alphas, axis=0)

    def trim_values(self, *args: Any) -> Generator:
        """Returns the data ranges where the volume is non-trivial and non-absurd."""
        # Go until you are 1 past the last sub-reaction.
        limiter = len(self.analyte.pKas) + 1

        good_val_index = where((self.phi >= [0]) & (self.phi <= [limiter]))

        # Trim the values for every chosen data set
        rets = (arg[good_val_index] for arg in args)  # Add the trimmed dataset to the return variable

        return rets

    def calculate_volume(self, acid_titrant: bool) -> Tuple[List, List]:
        """Calculate the volume of titrant required to reach each pH value."""
        # Alpha values scaled by their index
        scaled_alphas_analyte = self.scale_alphas(self.alpha_analyte)
        scaled_alphas_titrant = self.scale_alphas(self.alpha_titrant)

        # Sum the scaled alpha values. Axis=1 forces the summation to occur for each individual [H+] value.
        summed_scaled_alphas_analyte = sum(scaled_alphas_analyte, axis=1)
        summed_scaled_alphas_titrant = sum(scaled_alphas_titrant, axis=1)

        # I found this written as delta somewhere, and thus it will be named.
        delta = self.hydronium - self.hydroxide

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


if __name__ == "__main__":
    # Get the data from the simulation_parameters file
    with open("simulation_parameters.txt", "r") as file:
        data = file.readlines()

    # Parsing analyte parameters
    analyte_name = str(data[1][5:-1])
    analyte_acidic = data[2][7:-1] == "True"
    analyte_pkas = list(map(float, data[3][5:-1].split(",")))

    # Parsing titrant parameters
    titrant_name = str(data[5][5:-1])
    titrant_acidic = not analyte_acidic
    titrant_pkas = list(map(float, data[6][5:-1].split(",")))

    # Parsing titration parameters
    concentration_analyte = float(data[8][22:-1])
    concentration_titrant = float(data[9][22:-1])
    volume_analyte = float(data[10][15:-1])
    temperature = float(data[11][5:-1] if data[11][5:-1] != "" else 25)  # 25 if the temperature is not given
    decimal_places = float(data[12][15:-1] if data[12][15:-1] != "" else 0.01)  # 0.01 if the decimal places not given

    # Make the required objects
    analyte = Compound(name=analyte_name, acidic=analyte_acidic, pKas=analyte_pkas)
    titrant = Compound(name=titrant_name, acidic=titrant_acidic, pKas=titrant_pkas)
    titr = Titration(analyte=analyte,
                     concentration_analyte=concentration_analyte,
                     titrant=titrant,
                     concentration_titrant=concentration_titrant,
                     volume_analyte=volume_analyte)

    titration_volumes = titr.volume_titrant_t
    titration_phs = titr.ph_t

    with open("simulation_results.txt", "w+") as file:
        for vol, ph in zip(titr.volume_titrant_t, titr.ph_t):
            file.write(f"{vol}, {ph}\n")
