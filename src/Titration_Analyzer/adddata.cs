using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Titration_Analyzer
{
    public partial class Form1
    {
        public class adddata
        {
            private List<double> deltavolume = new List<double>();
            private List<double> averagevolume = new List<double>();
            private List<double> deltaPH = new List<double>();
            private List<double> PhDerivative = new List<double>();
            private List<double> SecondDerivative = new List<double>();
            public List<double> derivativepeaks = new List<double>();
            private List<double> tempsecondderivative = new List<double>();
            private List<double> tempaveragevolume = new List<double>();
            public List<double> equivalencepoints = new List<double>();
            public List<double> equivalencepointPH = new List<double>();
            public List<double> pKavolumes = new List<double>();
            public List<double> PKavalues = new List<double>();

            private int storedPHlength { get; set; }

            private int PHderivcount { get; set; }
            public Series PhDat = new Series();
            public Series PhDeriv = new Series();
            public Series importantpoints = new Series();
            public Series PhSecondDeriv = new Series();
            private string filepath = string.Empty;
            public bool finishprocessing;
            
            public string ImportedPHdata { get; set; }
            OpenFileDialog openfiledialog = new OpenFileDialog();

            public adddata()
            {
                PhDat.Name = "Titration";
                PhDat.ChartType = SeriesChartType.Line;
                PhDat.BorderWidth = titrationdatastorage.linethickness;
                PhDeriv.Name = "1st Derivative";
                PhDeriv.ChartType = SeriesChartType.Line;
                PhDeriv.BorderWidth = titrationdatastorage.linethickness;
                PhSecondDeriv.ChartType = SeriesChartType.Line;
                PhSecondDeriv.BorderWidth = titrationdatastorage.linethickness;
                PhSecondDeriv.Name = "2nd Derivative";
                importantpoints.Name = "Intercepts";
                importantpoints.ChartType = SeriesChartType.Point;
                importantpoints.MarkerSize = 8;
                importantpoints.Font = new System.Drawing.Font(titrationdatastorage.interceptlabelstext, titrationdatastorage.interceptlabelssize, System.Drawing.FontStyle.Bold);
           
            }

            public void AssessData()
            {

                var initialcheck = titrationdatastorage.titrationstorage[0].Split(',');

                if(initialcheck.Count() > 2)
                {
                    DialogResult excessdata = MessageBox.Show("There are more than two rows in your dataset, this application will only process the first two. Do you wish to proceed?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (excessdata == DialogResult.Yes)
                    {
                        finishprocessing = false;
                    }
                    else
                    {
                        finishprocessing = true;
                        goto Exit;
                    }
                }
                else if(initialcheck.Count() < 2)
                {
                    finishprocessing = true;
                    goto Exit;
                }

                SplitString lettercheck = new SplitString();

                
                if (lettercheck.Checkletters(initialcheck[0]) || lettercheck.Checkletters(initialcheck[1]) == true)
                {
                    DialogResult excessdata = MessageBox.Show("Your data is in the incorrect format. Reveiw the help file for further instructions", "Error: Incorrect Data Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    finishprocessing = true;
                    goto Exit;
                }
                else
                {
                    finishprocessing = false;
                }

                try
                {
                    foreach (string datapoint in titrationdatastorage.titrationstorage)
                    {
                        var checkposition = datapoint.Split(',');
                        if (Convert.ToDouble(checkposition[1]) > 15)
                        {
                            MessageBox.Show("Your PH and Volume values are swapped and will automatically be switched to the correct format", "Warning: Change of Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ChangePosition();
                            break;
                        }
                        else
                        {
                           
                        }
                    }
                }
                catch (Exception)
                {
                    finishprocessing = true;
                    MessageBox.Show("Invalid Data Entry", "Error: Invalid Column Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    goto Exit;
                    throw;
                }

            Exit:;

            }

            private void ChangePosition()
            {
                List<string> reversedPHvolume = new List<string>();

                foreach(string reverseddata in titrationdatastorage.titrationstorage)
                {
                    var reverseddatatosplit = reverseddata.Split(',');
                    reversedPHvolume.Add(reverseddatatosplit[1] + ',' + reverseddatatosplit[0]);
                }

                titrationdatastorage.titrationstorage.Clear();
                
                titrationdatastorage.titrationstorage.AddRange(reversedPHvolume);
                
            }

            public void findgreatest()
            {
                var passes = titrationdatastorage.hplus;
                double[] max_values = new double[passes]; 
                var tempderivativelist = new List<double>(PhDerivative);
                titrationdatastorage.unkown = "";

                for (int i = 0; i < passes; i++)
                {
                    double greatestderivative = 0;

                    if(titrationdatastorage.isbase == false)
                    {
                        greatestderivative = tempderivativelist.Max();
                    }
                    else if(titrationdatastorage.isbase == true)
                    {
                        greatestderivative = tempderivativelist.Min();
                    }

                    max_values[i] = greatestderivative;
                    var volumeindex = tempderivativelist.IndexOf(greatestderivative);
                    derivativepeaks.Add(greatestderivative);

                    equivalencepoints.Add(GetEquivalence());
                    equivalencepointPH.Add(LinearInterpolatePHeq(equivalencepoints[i]));
                    

                    var iterationsetting = titrationdatastorage.iterationsetting;
                    var itbegin = iterationsetting * (-1);

                    try
                    {
                        for (int n = itbegin; n < iterationsetting + 1; n++)
                        {

                            tempderivativelist[volumeindex + n] = 0;

                            tempsecondderivative[volumeindex + n] = 0;

                            tempaveragevolume[volumeindex + n] = 0;

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Not enough data for entry", "Error: Incomplete dataset", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                }

                equivalencepoints.Sort();

                pKavolumes.Add(equivalencepoints[0]/2);

                switch (passes)
                {
                    case 2:
                        pKavolumes.Add(equivalencepoints[0] + ((equivalencepoints[1] - equivalencepoints[0])/2));
                        break;
                    case 3:
                        pKavolumes.Add(equivalencepoints[0] + ((equivalencepoints[1] - equivalencepoints[0]) / 2));
                        pKavolumes.Add(equivalencepoints[1] + ((equivalencepoints[2] - equivalencepoints[1]) / 2));
                        break;
                }

               
                for (int y = 0; y < passes; y++)
                {
                    PKavalues.Add(GetPKA(pKavolumes[y]));
                    titrationdatastorage.unkown += Convert.ToString(PKavalues[y]) + ",";
                }
         
                if (titrationdatastorage.isbase == false)
                {
                    equivalencepointPH.Sort();
                    PKavalues.Sort();
                }
                else if (titrationdatastorage.isbase == true)
                {
                    equivalencepointPH.Sort();
                    equivalencepointPH.Reverse();
                    PKavalues.Sort();
                    PKavalues.Reverse();
                }
  
            }

            public void FindGreatestManual()
            {
                titrationdatastorage.unkown = "";

                var passes = titrationdatastorage.hplus;

                List<double> tempsecondderivativerangeone = new List<double>(SecondDerivative);
                List<double> tempsecondderivativerangetwo = new List<double>(SecondDerivative);
                List<double> tempsecondderivativerangethree = new List<double>(SecondDerivative);
                List<double> tempaveragevolumeone = new List<double>(tempaveragevolume);
                List<double> tempaveragevolumetwo = new List<double>(tempaveragevolume);
                List<double> tempaveragevolumethree = new List<double>(tempaveragevolume);
        
                List<List<double>> tempsecondderivs = new List<List<double>>();
                List<List<double>> tempaveragevolumecoll = new List<List<double>>();


                int itemplaceone = 0;
                int itemplacetwo = 0;
                double rangevalue = 0;
                int titrationsize = titrationdatastorage.titrationstorage.Count;


                for(int i = 0; i < titrationsize; i++)
                {
                    var rangeequal = titrationdatastorage.titrationstorage[i].Split(',');
                    
                    if (titrationdatastorage.rangetype == "Volume")
                    {
                        rangevalue = Convert.ToDouble(rangeequal[0]);
                    }
                    else if (titrationdatastorage.rangetype == "pH")
                    {
                        rangevalue = Convert.ToDouble(rangeequal[1]);
                    }

                    if(rangevalue > titrationdatastorage.rangeone)
                    {
                        itemplaceone = i;
                        break;
                    }
                }

               
                tempsecondderivativerangeone.RemoveRange(itemplaceone, tempsecondderivativerangeone.Count - itemplaceone);
                tempaveragevolumeone.RemoveRange(itemplaceone, tempaveragevolumeone.Count - itemplaceone);
                tempsecondderivativerangetwo.RemoveRange(0, itemplaceone);
                tempaveragevolumetwo.RemoveRange(0, itemplaceone);
                tempsecondderivs.Add(tempsecondderivativerangeone);
                tempaveragevolumecoll.Add(tempaveragevolumeone);

                rangevalue = 0;

                switch (titrationdatastorage.hplus)
                {
                    case 2:

                        tempsecondderivs.Add(tempsecondderivativerangetwo);
                        tempaveragevolumecoll.Add(tempaveragevolumetwo);
                        break;
                    case 3:
                        for(int i = itemplaceone; i < titrationsize; i++)
                        {
                            var rangeequal = titrationdatastorage.titrationstorage[i].Split(',');

                            if (titrationdatastorage.rangetype == "Volume")
                            {
                                rangevalue = Convert.ToDouble(rangeequal[0]);
                            }
                            else if (titrationdatastorage.rangetype == "pH")
                            {
                                rangevalue = Convert.ToDouble(rangeequal[1]);
                          
                            }

                            if (rangevalue > titrationdatastorage.rangetwo)
                            {
                                itemplacetwo = i;
                                break;
                            }
                        }
                        
                        tempsecondderivativerangetwo.RemoveRange(itemplacetwo - itemplaceone, tempsecondderivativerangetwo.Count - (itemplacetwo-itemplaceone));
                        tempaveragevolumetwo.RemoveRange(itemplacetwo - itemplaceone, tempaveragevolumetwo.Count - (itemplacetwo - itemplaceone));

                        tempsecondderivativerangethree.RemoveRange(0, itemplacetwo);
                        tempaveragevolumethree.RemoveRange(0, itemplacetwo);


                        tempsecondderivs.Add(tempsecondderivativerangetwo);
                        tempsecondderivs.Add(tempsecondderivativerangethree);

                        tempaveragevolumecoll.Add(tempaveragevolumetwo);
                        tempaveragevolumecoll.Add(tempaveragevolumethree);
                        
                        break;

                    default:
                        break;
                }

                for(int i = 0; i < passes; i++)
                {
                    equivalencepoints.Add(GetEquivalenceManual(tempsecondderivs[i], tempaveragevolumecoll[i]));
                    equivalencepointPH.Add(LinearInterpolatePHeq(equivalencepoints[i]));
                }

                pKavolumes.Add(equivalencepoints[0] / 2);

                switch (passes)
                {
                    case 2:
                        pKavolumes.Add(equivalencepoints[0] + ((equivalencepoints[1] - equivalencepoints[0]) / 2));
                        break;
                    case 3:
                        pKavolumes.Add(equivalencepoints[0] + ((equivalencepoints[1] - equivalencepoints[0]) / 2));
                        pKavolumes.Add(equivalencepoints[1] + ((equivalencepoints[2] - equivalencepoints[1]) / 2));
                        break;
                }

                for (int y = 0; y < passes; y++)
                {
                    PKavalues.Add(GetPKA(pKavolumes[y]));
                    titrationdatastorage.unkown += Convert.ToString(PKavalues[y]) + ",";
                }

            }

            public void DataStore()
            {
                titrationdatastorage.completedataset.Clear();

                var titrationdatacount = titrationdatastorage.titrationstorage.Count;

                for(int i = 0; i < titrationdatacount - 2; i++)
                {
                    titrationdatastorage.completedataset.Add(titrationdatastorage.titrationstorage[i] + "," + PhDerivative[i] + "," + SecondDerivative[i]);
                }

               titrationdatastorage.completedataset.Add(titrationdatastorage.titrationstorage[titrationdatacount - 2] + "," + PhDerivative[titrationdatacount - 2]);
                
               titrationdatastorage.completedataset.Add(titrationdatastorage.titrationstorage[titrationdatacount-1]);


            }
            public Series Graphdata()
            {
                foreach (string dat in titrationdatastorage.titrationstorage)
                {
                    dat.Trim();

                    var numericaldata = dat.Split(',');

                    PhDat.Points.AddXY(Convert.ToDouble(numericaldata[0]), Convert.ToDouble(numericaldata[1]));

                }
                titrationdatastorage.grapheddata = true;
                return PhDat;

            }

            private double maxfirstderiv { get; set; }
            private double minfirstderiv { get; set; }

            private double maxsecondderiv { get; set; }
            private double minsecondderiv { get; set; }
            public double NormalizeValue(double normalizeme, double max, double min)
            {
                var normallized = ((normalizeme - min) / (max - min));

                return normallized;

            }

            public Series AddPoints()
            {
                int pointcount = 0;

                for(int i = 0; i < titrationdatastorage.hplus; i++)
                {
                    importantpoints.Points.AddXY(equivalencepoints[i], equivalencepointPH[i]);
                    importantpoints.Points[i].Label = "Eq " + (i+1);
                    importantpoints.Points[i].LabelForeColor = Color.Red;
                    importantpoints.Points[i].Color = Color.Black;
                    pointcount++;

                }

                for(int i = 0; i < titrationdatastorage.hplus; i++)
                {
                    importantpoints.Points.AddXY(pKavolumes[i], PKavalues[i]);

                    if (titrationdatastorage.isbase == false)
                    {
                        importantpoints.Points[i + pointcount].Label = "pKa " + (i + 1);
                    }
                    else if(titrationdatastorage.isbase == true)
                    {
                        importantpoints.Points[i + pointcount].Label = "pKb " + (i + 1);
                    }
                    
                    importantpoints.Points[i + pointcount].LabelForeColor = Color.Blue;
                    importantpoints.Points[i + pointcount].Color = Color.BlueViolet;
                }

                return importantpoints;
            }

            public Series Derivative()
            {
                storedPHlength = titrationdatastorage.titrationstorage.Count;

                for(int i = 1; i < storedPHlength; i++)
                {
                    var xandyPH = titrationdatastorage.titrationstorage[i - 1].Split(',');
                    var xandyPhaddtwo = titrationdatastorage.titrationstorage[i].Split(',');

                    var xone = Convert.ToDouble(xandyPH[0]);
                    var yone = Convert.ToDouble(xandyPH[1]);
                    var xtwo = Convert.ToDouble(xandyPhaddtwo[0]);
                    var ytwo = Convert.ToDouble(xandyPhaddtwo[1]);

                    deltavolume.Add(xtwo - xone);
                    deltaPH.Add(ytwo - yone);
                    averagevolume.Add((xtwo + xone) / 2);
                    tempaveragevolume.Add((xtwo + xone) / 2);

                    PhDerivative.Add( (ytwo - yone) / (xtwo - xone));
                    

                }
                var firstderivcount = PhDerivative.Count;
                maxfirstderiv = PhDerivative.Max();
                minfirstderiv = PhDerivative.Min();
                
                for (int y = 0; y < firstderivcount; y++)
                {
                    PhDeriv.Points.AddXY(averagevolume[y], NormalizeValue((PhDerivative[y]), maxfirstderiv, minfirstderiv)* titrationdatastorage.normy1);
                }

                titrationdatastorage.graphderiv = true;
                return PhDeriv;
            }

            public Series Secondderivative()
            {
                PHderivcount = PhDerivative.Count;
                
                for(int i = 1; i < PHderivcount; i++)
                {
                    SecondDerivative.Add((PhDerivative[i] - PhDerivative[i - 1]) / (averagevolume[i] - averagevolume[i - 1]));
                    tempsecondderivative.Add((PhDerivative[i] - PhDerivative[i - 1]) / (averagevolume[i] - averagevolume[i - 1]));


                }

                var secondderivcount = SecondDerivative.Count;
                maxsecondderiv = SecondDerivative.Max();
                minsecondderiv = SecondDerivative.Min();

                for(int y = 0; y < secondderivcount; y++)
                {
                    PhSecondDeriv.Points.AddXY(averagevolume[y], (NormalizeValue((SecondDerivative[y]), maxsecondderiv, minsecondderiv) * titrationdatastorage.normy2) + titrationdatastorage.offset);
                }
               
                return PhSecondDeriv;
            }

            public double LinearInterpolatePHeq(double equivalencevol)
            {
                var PHnumberposition = titrationdatastorage.titrationstorage.Count;
                var upperbound = "";
                var lowerbound = "";
                var equivvol = equivalencevol;

                for (int i = 1; i < PHnumberposition; i++)
                {
                    var splitpkavolume = titrationdatastorage.titrationstorage[i].Split(',');
                    var pkavolumeone = Convert.ToDouble(splitpkavolume[0]);

                    if (pkavolumeone == equivvol)
                    {
                        return Convert.ToDouble(splitpkavolume[1]);
                    }
                    else if (!(pkavolumeone < equivvol))
                    {
                        upperbound = titrationdatastorage.titrationstorage[i];
                        lowerbound = titrationdatastorage.titrationstorage[i - 1];
                        break;
                    }
                }

                var PHlinearupper = upperbound.Split(',');
                var PHlinearlower = lowerbound.Split(',');

                var xtwo = Convert.ToDouble(PHlinearupper[0]);
                var ytwo = Convert.ToDouble(PHlinearupper[1]);
                var xone = Convert.ToDouble(PHlinearlower[0]);
                var yone = Convert.ToDouble(PHlinearlower[1]);

                var linearinterpolatedPHequiv = (yone + ((equivvol - xone) * ((ytwo - yone) / (xtwo - xone))));



                return Math.Round(linearinterpolatedPHequiv, 4);

            }
            public double getmaxvolume()
            {
                var finalcount = titrationdatastorage.titrationstorage.Count;
                var maxvolumestring = titrationdatastorage.titrationstorage[finalcount - 1].Split(',');
                if(titrationdatastorage.rangetype == "pH")
                {
                    return Convert.ToDouble(maxvolumestring[1]);
                }
                else if(titrationdatastorage.rangetype == "Volume")
                {
                    return Convert.ToDouble(maxvolumestring[0]);
                }
                else
                {
                    return 0;
                }
                
            }
            public double GetEquivalenceManual(List<double> secondderivative, List<double> averagevolume)
            {
                double minimumderiv = secondderivative.Min(); //y2
                double maximumderiv = secondderivative.Max(); //y1
                int minimumvolumenum = secondderivative.IndexOf(minimumderiv);
                double minimumvolume = averagevolume[minimumvolumenum]; //x2
                int maximumvolumenum = secondderivative.IndexOf(maximumderiv);
                double maximumvolume = averagevolume[maximumvolumenum]; //x1

                double slopeM = ((minimumderiv - maximumderiv) / ((minimumvolume - maximumvolume)));

                double equivalncepointintercept = (((maximumvolume * slopeM) - maximumderiv) / slopeM);

                return equivalncepointintercept;
            }
            
            public double GetEquivalence()
            {
                double minimumderiv = tempsecondderivative.Min(); //y2
                double maximumderiv = tempsecondderivative.Max(); //y1
                int minimumvolumenum = tempsecondderivative.IndexOf(minimumderiv);
                double minimumvolume = tempaveragevolume[minimumvolumenum]; //x2
                int maximumvolumenum = tempsecondderivative.IndexOf(maximumderiv);
                double maximumvolume = tempaveragevolume[maximumvolumenum]; //x1

                double slopeM = ((minimumderiv - maximumderiv) / ((minimumvolume - maximumvolume)));

                double equivalncepointintercept = (((maximumvolume * slopeM) - maximumderiv) / slopeM);
                
                return equivalncepointintercept;

            }

            public double GetPKA(double equivalence)
            {
                var pkavolume = (equivalence);
                var PHnumberposition = titrationdatastorage.titrationstorage.Count;
                var upperbound = "";
                var lowerbound = "";

                for (int i = 1; i < PHnumberposition; i++)
                {
                    var splitpkavolume = titrationdatastorage.titrationstorage[i].Split(',');
                    var pkavolumeone = Convert.ToDouble(splitpkavolume[0]);

                    if(pkavolumeone == pkavolume)
                    {
                        return Convert.ToDouble(splitpkavolume[1]);
                    }
                    else if(!(pkavolumeone < pkavolume))
                    {
                        upperbound = titrationdatastorage.titrationstorage[i];
                        lowerbound = titrationdatastorage.titrationstorage[i - 1];
                        break;
                    }
                }

                var PKalinearupper = upperbound.Split(',');
                var PKalinearlower = lowerbound.Split(',');

                var xtwo = Convert.ToDouble(PKalinearupper[0]);
                var ytwo = Convert.ToDouble(PKalinearupper[1]);
                var xone = Convert.ToDouble(PKalinearlower[0]);
                var yone = Convert.ToDouble(PKalinearlower[1]);

                var linearinterpolatedpka = (yone + ((pkavolume - xone) * ((ytwo - yone) / (xtwo - xone))));

                return Math.Round(linearinterpolatedpka, 4);
            }

            public void importandstore()
            {

                using (openfiledialog)
                {
                    openfiledialog.InitialDirectory = @"C:\";
                    openfiledialog.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
                    openfiledialog.FilterIndex = 1;
                    openfiledialog.RestoreDirectory = true;

                    if (openfiledialog.ShowDialog() == DialogResult.OK)
                    {
                        filepath = openfiledialog.FileName;

                        titrationdatastorage.titrationstorage = File.ReadAllLines(filepath).ToList();
                        finishprocessing = false;
                    }
                    else
                    {
                        finishprocessing = true;
                    }

                   
                }
            }
        }
    }
}
