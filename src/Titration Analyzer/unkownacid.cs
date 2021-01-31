using System;
using System.Collections.Generic;
using System.Linq;

namespace Titration_Analyzer
{
    public class unkownacid
    {
        private Dictionary<string, string> monoproticacid = new Dictionary<string, string>();
        private Dictionary<string, string> diproticacidone = new Dictionary<string, string>();
        private Dictionary<string, string> triproticacidone = new Dictionary<string, string>();
        private bool AcidorBase;
        public double percentmatch { get; set; }

        public unkownacid(int H, bool acidorbase)
        {
            AcidorBase = acidorbase;

            switch (H)
            {
                case 1:
                    monoproticacid.Add("Hydronium ion", "0");
                    monoproticacid.Add("Iodic", "0.8");
                    monoproticacid.Add("Sulfuric (2)", "1.92");
                    monoproticacid.Add("Chlorous", "1.96");
                    monoproticacid.Add("Chloroacetic", "2.85");
                    monoproticacid.Add("Hydrofluoric", "3.14");
                    monoproticacid.Add("Nitrous", "3.39");
                    monoproticacid.Add("Formic", "3.75");
                    monoproticacid.Add("Lactic", "3.86");
                    monoproticacid.Add("Benzoic", "4.19");
                    monoproticacid.Add("Hydrazoic", "4.72");
                    monoproticacid.Add("Acetic", "4.75");
                    monoproticacid.Add("Propionic", "4.87");
                    monoproticacid.Add("Pyridinium ion", "5.25");
                    monoproticacid.Add("Hydrosulfuric", "7");
                    monoproticacid.Add("Hypochlorous", "7.53");
                    monoproticacid.Add("Hypobromous", "8.7");
                    monoproticacid.Add("Hydrocyanic", "9.21");
                    monoproticacid.Add("Boric (1)", "9.23");
                    monoproticacid.Add("Ammonium ion", "9.25");
                    monoproticacid.Add("Phenol", "9.8");
                    monoproticacid.Add("Hypoiodous", "10.7");
                    monoproticacid.Add("Hydrogen peroxide", "11.62");
                    monoproticacid.Add("Water", "14");
                    break;
                case 2:
                    diproticacidone.Add("Oxalic", "1.23,4.19");
                    diproticacidone.Add("Sulfurous", "1.81,6.91");
                    diproticacidone.Add("Maleic", "1.89,6.23");
                    diproticacidone.Add("Malonic", "2.85,5.7");
                    diproticacidone.Add("o-Phthalic", "2.95,5.41");
                    diproticacidone.Add("Tartric", "3.04,4.37");
                    diproticacidone.Add("Fumaric", "3.05,4.49");
                    diproticacidone.Add("Malic", "3.46,5.1");
                    diproticacidone.Add("Ascorbic", "4.1,11.8");
                    diproticacidone.Add("Succinic", "4.21,5.64");
                    diproticacidone.Add("Carbonic", "6.37,10.32");
                    break;
                case 3:
                    triproticacidone.Add("Phosphoric", "2.12,7.21,12.32/12.66");
                    triproticacidone.Add("Arsenic", "2.3,7.1,9.22/11.53");
                    triproticacidone.Add("Citric", "3.08,4.74,5.4");
                    break;
                default:
                    break;
            }

        }

        public double GetpKa(double pkb)
        {
            return 14 - pkb;
        }

        public string DetermineUnkown(string acidPKa, int acidtype)
        {
            double closestmatchdifference = 14;
            string closestmatch = "";
            double firstdifference = 0;
            double seconddifference = 0;
            double firstequiv = 0;
            double secondequiv = 0;
            double thirddifference = 0;
            double thirdequiv = 0;

            var splitunkownstring = acidPKa.Split(',').ToList();
            splitunkownstring.Remove("");
            splitunkownstring.Sort();

            switch (acidtype)
            {
                case 1:

                    foreach (KeyValuePair<string, string> acidentry in monoproticacid)
                    {
                        double acidvalue = 0;

                        if (AcidorBase == true)
                        {
                            acidvalue = GetpKa(Convert.ToDouble(acidentry.Value));
                        }
                        else if (AcidorBase == false)
                        {
                            acidvalue = Convert.ToDouble(acidentry.Value);
                        }

                        if (Math.Abs(acidvalue - Convert.ToDouble(splitunkownstring[0])) < closestmatchdifference)
                        {
                            closestmatchdifference = Math.Abs(acidvalue - Convert.ToDouble(splitunkownstring[0]));
                            closestmatch = acidentry.Key;
                        }
                    }
                    percentmatch = Math.Round((1 - ((closestmatchdifference) / Convert.ToDouble(splitunkownstring[0]))) * 100);
                    break;
                case 2:

                    foreach (KeyValuePair<string, string> acidentry in diproticacidone)
                    {
                        var acidentries = acidentry.Value.Split(',');
                        Array.Sort(acidentries);

                        double firstacidpka = 0;
                        double secondacidpka = 0;

                        if (AcidorBase == true)
                        {
                            firstacidpka = GetpKa(Convert.ToDouble(acidentries[0]));
                            secondacidpka = GetpKa(Convert.ToDouble(acidentries[1]));
                        }
                        else if (AcidorBase == false)
                        {
                            firstacidpka = Convert.ToDouble(acidentries[0]);
                            secondacidpka = Convert.ToDouble(acidentries[1]);
                        }

                        var firstunkownpka = Convert.ToDouble(splitunkownstring[0]);
                        var secondunkownpka = Convert.ToDouble(splitunkownstring[1]);

                        if (Math.Abs(firstacidpka - firstunkownpka) + Math.Abs(secondacidpka - secondunkownpka) < closestmatchdifference)
                        {
                            closestmatchdifference = Math.Abs(firstacidpka - firstunkownpka) + Math.Abs(secondacidpka - secondunkownpka);
                            closestmatch = acidentry.Key;
                            firstdifference = Math.Abs(firstacidpka - firstunkownpka);
                            seconddifference = Math.Abs(secondacidpka - secondunkownpka);
                            firstequiv = firstunkownpka;
                            secondequiv = secondunkownpka;
                        }
                    }
                    percentmatch = Math.Round((((1 - (firstdifference / firstequiv)) + (1 - (seconddifference / secondequiv))) / 2) * 100);
                    break;


                case 3:
                    foreach (KeyValuePair<string, string> acidentry in triproticacidone)
                    {
                        var acidentries = acidentry.Value.Split(',');
                        //Array.Sort(acidentries);

                        double firstacidpka = 0;
                        double secondacidpka = 0;

                        if (AcidorBase == true)
                        {
                            firstacidpka = GetpKa(Convert.ToDouble(acidentries[0]));
                            secondacidpka = GetpKa(Convert.ToDouble(acidentries[1]));
                        }
                        else if (AcidorBase == false)
                        {
                            firstacidpka = Convert.ToDouble(acidentries[0]);
                            secondacidpka = Convert.ToDouble(acidentries[1]);
                        }


                        var thirdacidpka = new List<string>();

                        if (acidentries[2].Contains('/'))
                        {
                            thirdacidpka = acidentries[2].Split('/').ToList();
                        }
                        else
                        {
                            thirdacidpka.Add(acidentries[2]);
                        }

                        var firstunkownpka = Convert.ToDouble(splitunkownstring[0]);
                        var secondunkownpka = Convert.ToDouble(splitunkownstring[1]);
                        var thirdunkownpka = Convert.ToDouble(splitunkownstring[2]);

                        foreach (string acid in thirdacidpka)
                        {
                            double acidorbaseentry = 0;

                            if (AcidorBase == true)
                            {
                                acidorbaseentry = GetpKa(Convert.ToDouble(acid));
                            }
                            else if (AcidorBase == false)
                            {
                                acidorbaseentry = Convert.ToDouble(acid);
                            }

                            if (Math.Abs(firstacidpka - firstunkownpka) + Math.Abs(secondacidpka - secondunkownpka) + Math.Abs(acidorbaseentry - thirdunkownpka) < closestmatchdifference)
                            {
                                closestmatchdifference = Math.Abs(firstacidpka - firstunkownpka) + Math.Abs(secondacidpka - secondunkownpka);
                                closestmatch = acidentry.Key;
                                firstdifference = Math.Abs(firstacidpka - firstunkownpka);
                                seconddifference = Math.Abs(secondacidpka - secondunkownpka);
                                thirddifference = Math.Abs(acidorbaseentry - thirdunkownpka);
                                firstequiv = firstunkownpka;
                                secondequiv = secondunkownpka;
                                thirdequiv = thirdunkownpka;
                            }
                        }



                    }
                    percentmatch = Math.Round((((1 - (firstdifference / firstequiv)) + (1 - (seconddifference / secondequiv)) + (1 - (thirddifference / thirdequiv))) / 3) * 100);
                    break;

                default:
                    break;
            }

            return closestmatch;
        }
    }


}
