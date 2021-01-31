using System;

namespace Titration_Analyzer
{
    public partial class Form1
    {
        public class concentration
        {
            public double ReturnConcentration(string equivalence, string titrantconc, string molarratio, string analytevolume, string dilutonfact)
            {
                var splitPhandPka = equivalence.Split(',');

                var ratiosplit = molarratio.Split(':');

                var molerationum = Convert.ToDouble(ratiosplit[1]) / Convert.ToDouble(ratiosplit[0]);

                var acidconcentration = Convert.ToDouble(splitPhandPka[1]);

                return (((acidconcentration * Convert.ToDouble(titrantconc) * molerationum) * (1 / Convert.ToDouble(analytevolume))) * Convert.ToDouble(dilutonfact));

            }

            public double TitrantConcentration(string molarmass, string mass, string volume)
            {
                return (Convert.ToDouble(mass) / Convert.ToDouble(molarmass)) / (Convert.ToDouble(volume) / 1000);
            }

            public double MolarRatio(string molarratio)
            {
                var ratiosplit = molarratio.Split(':');

                return Convert.ToDouble(ratiosplit[1]) / Convert.ToDouble(ratiosplit[0]);
            }
        }
    }
}
