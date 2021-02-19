using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Titration_Analyzer
{
    public class molarcalc
    {
        private Dictionary<string, double> atomlist = new Dictionary<string, double>();
        private double molarsum { get; set; }

        public molarcalc()
        {
            atomlist.Add("H", 1.0079);
            atomlist.Add("He", 4.0026);
            atomlist.Add("Li", 6.941);
            atomlist.Add("Be", 9.0122);
            atomlist.Add("B", 10.811);
            atomlist.Add("C", 12.0107);
            atomlist.Add("N", 14.0067);
            atomlist.Add("O", 15.9994);
            atomlist.Add("F", 18.9984);
            atomlist.Add("Ne", 20.1797);
            atomlist.Add("Na", 22.9897);
            atomlist.Add("Mg", 24.305);
            atomlist.Add("Al", 26.9815);
            atomlist.Add("Si", 28.0855);
            atomlist.Add("P", 30.9738);
            atomlist.Add("S", 32.065);
            atomlist.Add("Cl", 35.453);
            atomlist.Add("K", 39.0983);
            atomlist.Add("Ar", 39.948);
            atomlist.Add("Ca", 40.078);
            atomlist.Add("Sc", 44.9559);
            atomlist.Add("Ti", 47.867);
            atomlist.Add("V", 50.9415);
            atomlist.Add("Cr", 51.9961);
            atomlist.Add("Mn", 54.938);
            atomlist.Add("Fe", 55.845);
            atomlist.Add("Ni", 58.6934);
            atomlist.Add("Co", 58.9332);
            atomlist.Add("Cu", 63.546);
            atomlist.Add("Zn", 65.39);
            atomlist.Add("Ga", 69.723);
            atomlist.Add("Ge", 72.64);
            atomlist.Add("As", 74.9216);
            atomlist.Add("Se", 78.96);
            atomlist.Add("Br", 79.904);
            atomlist.Add("Kr", 83.8);
            atomlist.Add("Rb", 85.4678);
            atomlist.Add("Sr", 87.62);
            atomlist.Add("Y", 88.9059);
            atomlist.Add("Zr", 91.224);
            atomlist.Add("Nb", 92.9064);
            atomlist.Add("Mo", 95.94);
            atomlist.Add("Tc", 98);
            atomlist.Add("Ru", 101.07);
            atomlist.Add("Rh", 102.9055);
            atomlist.Add("Pd", 106.42);
            atomlist.Add("Ag", 107.8682);
            atomlist.Add("Cd", 112.411);
            atomlist.Add("In", 114.818);
            atomlist.Add("Sn", 118.71);
            atomlist.Add("Sb", 121.76);
            atomlist.Add("I", 126.9045);
            atomlist.Add("Te", 127.6);
            atomlist.Add("Xe", 131.293);
            atomlist.Add("Cs", 132.9055);
            atomlist.Add("Ba", 137.327);
            atomlist.Add("La", 138.9055);
            atomlist.Add("Ce", 140.116);
            atomlist.Add("Pr", 140.9077);
            atomlist.Add("Nd", 144.24);
            atomlist.Add("Pm", 145);
            atomlist.Add("Sm", 150.36);
            atomlist.Add("Eu", 151.964);
            atomlist.Add("Gd", 157.25);
            atomlist.Add("Tb", 158.9253);
            atomlist.Add("Dy", 162.5);
            atomlist.Add("Ho", 164.9303);
            atomlist.Add("Er", 167.259);
            atomlist.Add("Tm", 168.9342);
            atomlist.Add("Yb", 173.04);
            atomlist.Add("Lu", 174.967);
            atomlist.Add("Hf", 178.49);
            atomlist.Add("Ta", 180.9479);
            atomlist.Add("W", 183.84);
            atomlist.Add("Re", 186.207);
            atomlist.Add("Os", 190.23);
            atomlist.Add("Ir", 192.217);
            atomlist.Add("Pt", 195.078);
            atomlist.Add("Au", 196.9665);
            atomlist.Add("Hg", 200.59);
            atomlist.Add("Tl", 204.3833);
            atomlist.Add("Pb", 207.2);
            atomlist.Add("Bi", 208.9804);
            atomlist.Add("Po", 209);
            atomlist.Add("At", 210);
            atomlist.Add("Rn", 222);
            atomlist.Add("Fr", 223);
            atomlist.Add("Ra", 226);
            atomlist.Add("Ac", 227);
            atomlist.Add("Pa", 231.0359);
            atomlist.Add("Th", 232.0381);
            atomlist.Add("Np", 237);
            atomlist.Add("U", 238.0289);
            atomlist.Add("Am", 243);
            atomlist.Add("Pu", 244);
            atomlist.Add("Cm", 247);
            atomlist.Add("Bk", 247);
            atomlist.Add("Cf", 251);
            atomlist.Add("Es", 252);
            atomlist.Add("Fm", 257);
            atomlist.Add("Md", 258);
            atomlist.Add("No", 259);
            atomlist.Add("Rf", 261);
            atomlist.Add("Lr", 262);
            atomlist.Add("Db", 262);
            atomlist.Add("Bh", 264);
            atomlist.Add("Sg", 266);
            atomlist.Add("Mt", 268);
            atomlist.Add("Rg", 272);
            atomlist.Add("Hs", 277);
        }

        public double FindMolarMass(string atoms)
        {
            molarsum = 0;

            var splitelements = new SplitString();

            var formulasplit = splitelements.SplitCapitalLetters(atoms);

            foreach(var element in formulasplit)
            {
                bool multipliercheck = element.Any(char.IsDigit);

                if (multipliercheck == true)
                {
                    try
                    {
                        var multipliernumber = splitelements.SplitNumbersFromLetters(element);

                        molarsum += atomlist[multipliernumber[0]] * Convert.ToDouble(multipliernumber[1]);
                    }

                    catch (System.Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    try
                    {
                        molarsum += atomlist[element];
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"No match for the element '{element}' was found", "Error: Failed to Match Formula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } 
            }
            
            return molarsum;
        }
           
    }
}
