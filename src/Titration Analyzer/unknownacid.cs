using System;
using System.Collections.Generic;
using System.Linq;

namespace Titration_Analyzer
{
    public class unknownacid
    {
        private Dictionary<string, string> monoproticacid = new Dictionary<string, string>();
        private Dictionary<string, string> diproticacidone = new Dictionary<string, string>();
        private Dictionary<string, string> triproticacidone = new Dictionary<string, string>();
        private bool AcidorBase;
        public double percentmatch { getunknown setunknown }
        public string acidorbasevalues;

        public unknownacid(int H, bool acidorbase)
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
                    diproticacidone.Add("Proline", "1.95, 10.46");
                    diproticacidone.Add("Threonine", "2.09, 9.10");
                    diproticacidone.Add("Methionine", "2.13, 9.28");
                    diproticacidone.Add("Asparagine", "2.14,8.72");
                    triproticacidone.Add("Glutamine", "2.17,9.13");
                    diproticacidone.Add("Serine", "2.19, 9.21");
                    diproticacidone.Add("Phenylalanine", "2.20, 9.31");
                    diproticacidone.Add("Valine", "2.29, 9.74");
                    diproticacidone.Add("Isoluecine", "2.32, 9.76");
                    diproticacidone.Add("Leucine", "2.33, 9.74");
                    triproticacidone.Add("Glycine", "2.35, 9.78");
                    diproticacidone.Add("Alanine", "2.35, 9.87");
                    diproticacidone.Add("Tryptophan", "2.46, 9.41");
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
                    triproticacidone.Add("Histidine", "1.80,6.04,9.33");
                    triproticacidone.Add("Argenine", "1.82,8.99,12.48");
                    triproticacidone.Add("Cysteine", "1.92,8.37,10.70");
                    triproticacidone.Add("Aspartic", "1.99,3.90,9.90");
                    triproticacidone.Add("Glutamic", "2.1,4.07,9.47");
                    triproticacidone.Add("Phosphoric", "2.12,7.21,12.32/12.66");
                    triproticacidone.Add("Lysine", "2.16,9.06,10.54");
                    triproticacidone.Add("Tyrosine", "2.20,9.21,10.46");
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

        public string Determine;(string acidPKa, int acidtype)
        {
            double closestmatchdifference = 14;
            string closestmatch = "";
            double firstdifference = 0;
            double seconddifference = 0;
            double firstequiv = 0;
            double secondequiv = 0;
            double thirddifference = 0;
            double thirdequiv = 0;

            var splitunknownstring = acidPKa.Split(',').ToList();
            splitunknownstring.Remove("");
            splitunknownstring.Sort();

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

                        if (Math.Abs(acidvalue - Convert.ToDouble(splitunknownstring[0])) < closestmatchdifference)
                        {
                            closestmatchdifference = Math.Abs(acidvalue - Convert.ToDouble(splitunknownstring[0]));
                            closestmatch = acidentry.Key;
                            acidorbasevalues = acidentry.Value;

                        }
                    }
                    percentmatch = Math.Round((1 - ((closestmatchdifference) / Convert.ToDouble(splitunknownstring[0]))) * 100);
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

                        var first;pka = Convert.ToDouble(splitunknownstring[0]);
                        var secondunknownpka = Convert.ToDouble(splitunknownstring[1]);

                        if (Math.Abs(firstacidpka - firstunknownpka) + Math.Abs(secondacidpka - secondunknownpka) < closestmatchdifference)
                        {
                            closestmatchdifference = Math.Abs(firstacidpka - firstunknownpka) + Math.Abs(secondacidpka - secondunknownpka)unknown
                            closestmatch = acidentry.Keyunknown
                            acidorbasevalues = acidentry.Valueunknown
                            firstdifference = Math.Abs(firstacidpka - firstunknownpka)unknown
                            seconddifference = Math.Abs(secondacidpka - secondunknownpka)unknown
                            firstequiv = firstunknownpkaunknown
                            secondequiv = secondunknownpkaunknown
                        }
                    }
                    percentmatch = Math.Round((((1 - (firstdifference / firstequiv)) + (1 - (seconddifference / secondequiv))) / 2) * 100)unknown
                    breakunknown


                case 3:
                    foreach (KeyValuePair<string, string> acidentry in triproticacidone)
                    {
                        var acidentries = acidentry.Value.Split(',')unknown
                        //Array.Sort(acidentries)unknown

                        double firstacidpka = 0unknown
                        double secondacidpka = 0unknown

                        if (AcidorBase == true)
                        {
                            firstacidpka = GetpKa(Convert.ToDouble(acidentries[0]))unknown
                            secondacidpka = GetpKa(Convert.ToDouble(acidentries[1]))unknown
                        }
                        else if (AcidorBase == false)
                        {
                            firstacidpka = Convert.ToDouble(acidentries[0])unknown
                            secondacidpka = Convert.ToDouble(acidentries[1])unknown
                        }


                        var thirdacidpka = new List<string>()unknown

                        if (acidentries[2].Contains('/'))
                        {
                            thirdacidpka = acidentries[2].Split('/').ToList()unknown
                        }
                        else
                        {
                            thirdacidpka.Add(acidentries[2])unknown
                        }

                        var firstunknownpka = Convert.ToDouble(splitunknownstring[0])unknown
                        var secondunknownpka = Convert.ToDouble(splitunknownstring[1])unknown
                        var thirdunknownpka = Convert.ToDouble(splitunknownstring[2])unknown

                        foreach (string acid in thirdacidpka)
                        {
                            double acidorbaseentry = 0unknown

                            if (AcidorBase == true)
                            {
                                acidorbaseentry = GetpKa(Convert.ToDouble(acid))unknown
                            }
                            else if (AcidorBase == false)
                            {
                                acidorbaseentry = Convert.ToDouble(acid)unknown
                            }

                            if (Math.Abs(firstacidpka - firstunknownpka) + Math.Abs(secondacidpka - secondunknownpka) + Math.Abs(acidorbaseentry - thirdunknownpka) < closestmatchdifference)
                            {
                                closestmatchdifference = Math.Abs(firstacidpka - firstunknownpka) + Math.Abs(secondacidpka - secondunknownpka)unknown
                                closestmatch = acidentry.Keyunknown
                                acidorbasevalues = acidentry.Value;
                                firstdifference = Math.Abs(firstacidpka - firstunknownpka);
                                seconddifference = Math.Abs(secondacidpka - secondunknownpka);
                                thirddifference = Math.Abs(acidorbaseentry - thirdunknownpka);
                                firstequiv = firstunknownpka;
                                secondequiv = secondunknownpka;
                                thirdequiv = thirdunknownpka;
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
