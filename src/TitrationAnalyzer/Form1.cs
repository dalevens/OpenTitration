using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Titration_Analyzer
{
    public partial class Form1 : Form
    {
        public static class titrationdatastorage
        {
            
            public static List<string> titrationstorage = new List<string>();
            public static List<string> completedataset = new List<string>();
            public static List<double> equivalencepoints = new List<double>();
            public static int normy1;
            public static int normy2;
            public static int offset;
            public static int hplus;
            public static string unkown;
            public static bool isbase;
            public static string knownpka;
            public static string unkownacidorbaseidentity;
            public static bool formulamatch;
            public static bool titrationanalyzed;
            public static string storedtitrationconcentration;

            //Simulator Settings
            public static string pyscript;
            public static bool StrongAcidorBase;
            public static string analytepkavalues;
            public static double a_vol_Global;
            public static double a_conc_Global;
            public static double t_conc_Global;
            public static string titrantformula;
            public static double maxvolume;
            public static double resolution;
            public static string pythonpath;
            public static string custompKa;
            public static bool custompKaselect;
            public static string customanalyteacid;
            public static string customanalyteacidwithmatch;
            public static string acidanalytewithoutmatch;
            public static string customanalyteacidpKa;
            public static double temperature;

            public static List<double> simPhLs = new List<double> { };
            public static List<double> simVolLs = new List<double> { };
            public static Series simulationdata = new Series();

            //For determination of pka from acid library
            public static string acidchosenname;
            public static string acidchosenpka;
            public static bool issingleacid;
            public static List<string> acidpkavalues = new List<string>();
            public static List<string> acidfind = new List<string>();

            //Calculation Settings
            public static string solvemethod;
            public static string rangetype;
            public static double rangeone;
            public static double rangetwo { get; set; }
            public static double maxPH;
            public static double maxVolume;
            public static bool maxminfail;
            public static double temprangeone;
            public static double temprangetwo;
            public static bool customsensitivityselect;
            
            //Graph Settings
            public static int iterationsetting;
            public static int linethickness;
            public static string interceptlabelstext;
            public static int interceptlabelssize;
            public static int xaxisgraphsize;
            public static int yaxisgraphsize;
            public static string xaxislabeltext;
            public static string yaxislabeltext;
            public static string titrationcolor;
            public static string firstderivativecolor;
            public static string secondderivativecolor;
            public static string simulationcolor;
            public static string titrationstyle;
            public static string firstderivstyle;
            public static string secondderivstyle;
            public static string simulatedstyle;

            //PDF settings
            public static int margins;
            public static double spacing;
            public static int headersize;
            public static string headerfont;
            public static string resultsfont;
            public static int resultssize;

            //Flags to determine data processing
            public static bool grapheddata;
            public static bool graphderiv;
        }
        
        public static string acidbase;
        public static string pkapkb;
        
        public Form1()
        {
            InitializeComponent();
            
            NormY1.Text = "6";
            NormY2.Text = "4";
            OffsetY2.Text = "2";
            acidbase = "Acid";
            pkapkb = "pKa";
            hplusnum.Text = Convert.ToString(Properties.Settings.Default.HPlus);

            titrationdatastorage.isbase = false;
            titrationdatastorage.titrationanalyzed = false;

            //Simulator Settings
            titrationdatastorage.resolution = Properties.Settings.Default.Resolution;
            titrationdatastorage.StrongAcidorBase = Properties.Settings.Default.StrongAcidorBase;
            titrationdatastorage.custompKaselect = Properties.Settings.Default.CustompKaselect;
            titrationdatastorage.pythonpath = Application.StartupPath + @"\titration_simulator.exe";
            titrationdatastorage.temperature = Properties.Settings.Default.Temperature;

            //Calc Settings
            titrationdatastorage.rangeone = Properties.Settings.Default.Range1;
            titrationdatastorage.rangetwo = Properties.Settings.Default.Range2;
            titrationdatastorage.rangetype = Properties.Settings.Default.RangeType;
            titrationdatastorage.iterationsetting = Properties.Settings.Default.Iterationsetting;
            titrationdatastorage.solvemethod = Properties.Settings.Default.SolveMethod;
            titrationdatastorage.customsensitivityselect = Properties.Settings.Default.ManualSensitivity;
            //Chart settings
            titrationdatastorage.hplus = Properties.Settings.Default.HPlus;
            titrationdatastorage.linethickness = Properties.Settings.Default.linethickness;
            titrationdatastorage.interceptlabelstext = Properties.Settings.Default.interceptlabelstext;
            titrationdatastorage.interceptlabelssize = Properties.Settings.Default.interceptlabelssiz;
            titrationdatastorage.xaxisgraphsize = Properties.Settings.Default.xaxisgraphsize;
            titrationdatastorage.yaxisgraphsize = Properties.Settings.Default.yaxisgraphsize;
            titrationdatastorage.xaxislabeltext = Properties.Settings.Default.xaxislabeltext;
            titrationdatastorage.yaxislabeltext = Properties.Settings.Default.yaxislabeltext;
            titrationdatastorage.titrationcolor = Properties.Settings.Default.TitrationColor;
            titrationdatastorage.firstderivativecolor = Properties.Settings.Default.OneDerivColor;
            titrationdatastorage.secondderivativecolor = Properties.Settings.Default.TwoDerivColor;
            titrationdatastorage.simulationcolor = Properties.Settings.Default.SimulatorColor;
            titrationdatastorage.titrationstyle = Properties.Settings.Default.SimulatedStyle;
            titrationdatastorage.firstderivstyle = Properties.Settings.Default.OneDerivStyle;
            titrationdatastorage.secondderivstyle = Properties.Settings.Default.TwoDerivStyle;
            titrationdatastorage.simulatedstyle = Properties.Settings.Default.SimulatedStyle;
            

            //PDF settings
            titrationdatastorage.margins = Properties.Settings.Default.margins;
            titrationdatastorage.spacing = Properties.Settings.Default.spacing;
            titrationdatastorage.headersize = Properties.Settings.Default.headersize;
            titrationdatastorage.headerfont = Properties.Settings.Default.headerfont;
            titrationdatastorage.resultsfont = Properties.Settings.Default.resultsfont;
            titrationdatastorage.resultssize = Properties.Settings.Default.resultssize;

            titrationdatastorage.grapheddata = false;
            titrationdatastorage.graphderiv = false;
    }
        public adddata addeddata;
        public void ChangeGraph()
        {
            chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font(titrationdatastorage.yaxislabeltext, titrationdatastorage.yaxisgraphsize, System.Drawing.FontStyle.Bold);
            chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font(titrationdatastorage.xaxislabeltext, titrationdatastorage.xaxisgraphsize, System.Drawing.FontStyle.Bold);
            
        }

        public void findacid()
        {
            var acidobject = new acids();

            acidobject.acidlookup(formula.Text);

            if (titrationdatastorage.issingleacid == false)
            {
                AcidSelect newform = new AcidSelect(this);
                titrationdatastorage.custompKaselect = false;
                Properties.Settings.Default.CustompKaselect = false;
                newform.Show();
            }
            else if(titrationdatastorage.formulamatch == false)
            {
                titrationdatastorage.custompKaselect = true;
                Properties.Settings.Default.CustompKaselect = true;
                Settings settingsform = new Settings(this, 3);
                settingsform.Show();
            }
            else
            {
                titrationdatastorage.custompKaselect = false;
                Properties.Settings.Default.CustompKaselect = false;
            }

        }

        private double unkownacidmatch(List<double> experimentalpkavalues)
        {

            var Exppkavaluescount = experimentalpkavalues.Count;

            var pkaknown = baseacidpkaconverter(titrationdatastorage.knownpka, false);

            var pkaknownlist = pkaknown.Split(',');

            var knownpkacount = pkaknownlist.Length;

            double aciddifference = 0;

            if (Exppkavaluescount != knownpkacount)
            {
                goto Exit;
            }

            for(int i = 0; i < Exppkavaluescount; i++)
            {
                var pkanumber = experimentalpkavalues[i];
                var determinedpka = Convert.ToDouble(pkaknownlist[i]);
                aciddifference += Math.Abs((determinedpka - pkanumber)) / determinedpka;
                //aciddifference += pkanumber / determinedpka;
            }

            return (aciddifference / Exppkavaluescount)*100;

        Exit:
            {
                return -1;
            }

        }

        public void ChangeSeries()
        {
            if(titrationdatastorage.grapheddata == true)
            {
                addeddata.PhDat.BorderWidth = titrationdatastorage.linethickness;
            }
            
                
            if(titrationdatastorage.graphderiv == true)
            {
                addeddata.PhDeriv.BorderWidth = titrationdatastorage.linethickness;

                addeddata.PhSecondDeriv.BorderWidth = titrationdatastorage.linethickness;

                addeddata.importantpoints.Font = new System.Drawing.Font(titrationdatastorage.interceptlabelstext, titrationdatastorage.interceptlabelssize, System.Drawing.FontStyle.Bold);
            }

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void determinealternativerange(int protonation)
        {
            var maxvol = titrationdatastorage.maxvolume;

            if(protonation == 2)
            {
                titrationdatastorage.temprangeone = Math.Round((maxvol / 2));
            }
            else if(protonation == 3)
            {
                titrationdatastorage.temprangeone = Math.Round((maxvol / 3));
                titrationdatastorage.temprangetwo = Math.Round((maxvol / 3) * 2);
            }
        }

        private string roundcheck(double concentrationnumber)
        {
            var stringreturn = "";

            if(concentrationnumber >= 0 && concentrationnumber < 0.01)
            {
                stringreturn = concentrationnumber.ToString("0.000E0");
            }
            else
            {
                stringreturn = Convert.ToString(Math.Round(concentrationnumber, 4));
            }

            return stringreturn;
        }

        private void analyze_click(object sender, EventArgs e)
        {
            var molestring = formula.Text;
            var molarformula = new molarcalc();

            if (formula.Text == "")
            {
                MessageBox.Show("You have left the formula empty");
            }
            else
            {
                Molarmass.Text = Convert.ToString(molarformula.FindMolarMass(molestring));
            }

            if(MolarRatio.Text == "")
            {
                MolarRatio.Text = "1:1";
            }

            if(dilutionfactor.Text == "")
            {
                dilutionfactor.Text = "1";
            }
            
            var importdata = new adddata();
            
            addeddata = importdata;

            chart1.Series.Clear();

            if(titrationdatastorage.titrationstorage == null)
            {
                MessageBox.Show("No titration data has been imported");
            }

            try
            {
                chart1.Series.Add(importdata.Graphdata());
            }
            catch (Exception)
            {
                MessageBox.Show("The data is not in the correct format. For a guide to how to format your data, please reveiw the usermanual.", "Error: Failure to Import Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            titrationdatastorage.normy1 = Convert.ToInt32(NormY1.Text);
            titrationdatastorage.normy2 = Convert.ToInt32(NormY2.Text);
            titrationdatastorage.offset = Convert.ToInt32(OffsetY2.Text);
            titrationdatastorage.hplus = Convert.ToInt32(hplusnum.Text);

            //Code to do with charting of data

            try
            {
                chart1.Series.Add(importdata.Derivative());
            }
            catch (Exception)
            {
                MessageBox.Show("No data exists to be analyzed", "Error: Failure to Compute Derivative", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            chart1.Series.Add(importdata.Secondderivative());
            Equivalence.Items.Clear();
            PKA.Items.Clear();
            Concentration.Items.Clear();

            var maxvolume = importdata.getmaxvolume();
            titrationdatastorage.maxvolume = maxvolume;

            determinealternativerange(titrationdatastorage.hplus);

            if (importdata.baseoracidcheck() == true && Base.Checked == false)
            {
                DialogResult acidorbase = MessageBox.Show("Your data appears to be an acid to base titrant, would you like to switch to base analysis mode?", "", MessageBoxButtons.YesNo);

                if (acidorbase == DialogResult.Yes)
                {
                    Hplus.Text = "OH-";
                    PkaLabel.Text = "pKa";
                    acidbase = "Base";
                    pkapkb = "pKa";
                    knownanal.Checked = false;

                    if (knownanal.Checked == true)
                    {
                        unkownacidlabel.Text = "Known Base";
                    }
                    else
                    {
                        unkownacidlabel.Text = "Unknown Base";
                    }

                    titrationdatastorage.isbase = true;
                    Base.Checked = true;
                }
                else
                {

                }
            }
            else if(importdata.baseoracidcheck() == false && Base.Checked == true)
            {
                DialogResult acidorbase = MessageBox.Show("Your data appears to be an base to acid titrant, would you like to switch to acid analysis mode?", "", MessageBoxButtons.YesNo);

                if (acidorbase == DialogResult.Yes)
                {
                    Hplus.Text = "H+";
                    PkaLabel.Text = "pKa";
                    acidbase = "Acid";
                    pkapkb = "pKa";
                    knownanal.Checked = false;

                    if (knownanal.Checked == true)
                    {
                        unkownacidlabel.Text = "Known Acid";
                    }
                    else
                    {
                        unkownacidlabel.Text = "Unknown Acid";
                    }

                    titrationdatastorage.isbase = false;
                    Base.Checked = false;
                }
                else
                {

                }
            }

        rerun:
            {

            }

            if(titrationdatastorage.solvemethod == "Automatic")
            {
                try
                {
                    importdata.findgreatest();
                    
                }
                catch (Exception)
                {
                    if (importdata.parseddatarun == false)
                    {
                        importdata.parseddatarun = true;
                        importdata.ParseData(2.5);
                        goto rerun;
                    }
                    else
                    {
                        MessageBox.Show("Insufficient data points. Adjust the peak sensitivity, or try switching to the manual range mode.", "Error: Insufficient Datapoints", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        importdata.parseddatarun = false;
                        goto Finish;
                    }

                }
            }
            else if(titrationdatastorage.solvemethod == "Manual Range")
            {
                if (titrationdatastorage.hplus == 2)
                {
                    if(maxvolume < titrationdatastorage.rangeone)
                    {
                        MessageBox.Show("Your chosen value for the " + titrationdatastorage.rangetype.ToLower() + " range exceeds the maximum value. An automatic value was assigned for this analysis.", "Error: Manual Input Exceeded Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        titrationdatastorage.rangeone = titrationdatastorage.temprangeone;
                        Properties.Settings.Default.Range1 = titrationdatastorage.temprangeone;
                    }

                    if (titrationdatastorage.rangeone == 0)
                    {
                        MessageBox.Show("Non-zero numbers are needed for the manual range calculation mode. An automatic value was assigned for this analysis.", "Error: Manual Input With 0 As Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        titrationdatastorage.rangeone = titrationdatastorage.temprangeone;
                        Properties.Settings.Default.Range1 = titrationdatastorage.temprangeone;
                    }
                }
                else if (titrationdatastorage.hplus == 3)
                {
                    if(maxvolume < titrationdatastorage.rangeone || maxvolume < titrationdatastorage.rangetwo)
                    {
                        MessageBox.Show("Your chosen value for the " + titrationdatastorage.rangetype.ToLower() + " range exceeds the maximum value. An automatic value was assigned for this analysis.", "Error: Manual Input Exceeded Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        titrationdatastorage.rangeone = titrationdatastorage.temprangeone;
                        Properties.Settings.Default.Range1 = titrationdatastorage.temprangeone;
                        titrationdatastorage.rangetwo = titrationdatastorage.temprangetwo;
                        Properties.Settings.Default.Range2 = titrationdatastorage.temprangetwo;
                    }

                    if(titrationdatastorage.rangeone == 0 || titrationdatastorage.rangetwo == 0)
                    {
                        MessageBox.Show("Non-zero numbers are needed for the manual range calculation mode. An automatic value was assigned for this analysis.", "Error: Manual Input With 0 As Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        titrationdatastorage.rangeone = titrationdatastorage.temprangeone;
                        Properties.Settings.Default.Range1 = titrationdatastorage.temprangeone;
                        titrationdatastorage.rangetwo = titrationdatastorage.temprangetwo;
                        Properties.Settings.Default.Range2 = titrationdatastorage.temprangetwo;
                    }
                }

                try
                {
                    importdata.FindGreatestManual();
                }
                catch (Exception)
                {
                    if(importdata.parseddatarun == false)
                    {
                        importdata.parseddatarun = true;
                        importdata.ParseData(2);
                        goto rerun;
                    }
                    else
                    {
                        MessageBox.Show("Insufficient data points to analyze your data.", "Error: Insufficient Datapoints", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        importdata.parseddatarun = false;
                        goto Finish;
                    }
                    
                }

                if(titrationdatastorage.maxminfail == true)
                {
                    var rangetype = "";

                    if(titrationdatastorage.rangetype == "volume")
                    {
                        rangetype = "mL";
                    }
                    else
                    {
                        rangetype = "PH";
                    }

                    if(titrationdatastorage.hplus == 2)
                    {
                        MessageBox.Show("No maximum could be found from " + titrationdatastorage.rangeone + rangetype + ", Try picking a new manual range closer to the values in between the equivalence points in settings.", "Error: Maximum Value Could Not Be Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if(titrationdatastorage.hplus == 3)
                    {
                        MessageBox.Show("No maximum could be found from " + titrationdatastorage.rangeone + rangetype + " and " + titrationdatastorage.rangetwo +  rangetype + ", Try picking a new manual range closer to the values in between the equivalence points in settings.", "Error: Maximum Values Could Not Be Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    goto Finish;
                }
  
            }

            chart1.Series.Add(importdata.AddPoints());

            ChangeSeries();

            titrationdatastorage.equivalencepoints.Clear();

            var pkavalues = new List<Double>();

            for(int i = 0; i < titrationdatastorage.hplus; i++)
            {
                var equivalencedetermin = Math.Round(importdata.equivalencepoints[i], 4);
                titrationdatastorage.equivalencepoints.Add(equivalencedetermin);
                Equivalence.Items.Add(Convert.ToString(i+1) + "# " + Convert.ToString(equivalencedetermin) + "mL, " + Convert.ToString(Math.Round(importdata.equivalencepointPH[i], 4)));
                pkavalues.Add(importdata.PKavalues[i]);
                PKA.Items.Add(Convert.ToString(i+1) + "# " + Convert.ToString(importdata.PKavalues[i]));
            }

            Equivalence.Text = Convert.ToString(Math.Round(importdata.equivalencepoints[0], 4)) + "mL," + Convert.ToString(Math.Round(importdata.equivalencepointPH[0], 4));
            PKA.Text = Convert.ToString(importdata.PKavalues[0]);

            var unkownaciddetermin = new unkownacid(titrationdatastorage.hplus, titrationdatastorage.isbase);

            titrationdatastorage.unkownacidorbaseidentity = unkownaciddetermin.DetermineUnkown(titrationdatastorage.unkown, titrationdatastorage.hplus) + " (" + Convert.ToString(unkownaciddetermin.percentmatch) + "% Error)";

            if(knownanal.Checked == false)
            {
                unkownacid.Text = titrationdatastorage.unkownacidorbaseidentity;
            }
            else
            {
          
                if(unkownacid.Text == "")
                {
                    unkownacid.Text = Convert.ToString(unkownacid.Items[0]);
                }

                if (unkownacid.Text == titrationdatastorage.customanalyteacid)
                {
                    titrationdatastorage.knownpka = titrationdatastorage.customanalyteacidpKa;
                }
                else if (unkownacid.Text == titrationdatastorage.customanalyteacidwithmatch)
                {
                    unkownacid.Text = titrationdatastorage.acidanalytewithoutmatch;
                    titrationdatastorage.knownpka = unkownaciddetermin.knowngetpKa(titrationdatastorage.hplus, unkownacid.Text);
                }
                else
                {
                    titrationdatastorage.knownpka = unkownaciddetermin.knowngetpKa(titrationdatastorage.hplus, unkownacid.Text);
                }   

                var knownacidpercent = unkownacidmatch(pkavalues);

                if(knownacidpercent != -1)
                {
                    titrationdatastorage.acidanalytewithoutmatch = unkownacid.Text;
                    titrationdatastorage.customanalyteacidwithmatch = unkownacid.Text + " (" + Convert.ToString(Math.Round(knownacidpercent, 1)) + "%) match";
                    unkownacid.Text += " (" + Convert.ToString(Math.Round(knownacidpercent, 1)) + "% Error)";

                }
                
            }

            titrationdatastorage.analytepkavalues = unkownaciddetermin.acidorbasevalues;

            var concentrationdetermin = new concentration();

            int concentrationnum = 1;

            if (Concknown.Checked == false)
            {
                try
                {
                    TitConc.Text = roundcheck(concentrationdetermin.TitrantConcentration(Molarmass.Text, mass.Text, Volumetit.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Not all the proper fields are filled out in the correct format", "Error: Failure to Compute Concentration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Concknown.Checked == true)
            {
                TitConc.Text = roundcheck(Convert.ToDouble(TitConc.Text));
            }

            try
            {
                foreach (var equiv in importdata.equivalencepoints)
                {
                    var concentrationfigure = roundcheck(concentrationdetermin.ReturnConcentration(equiv, TitConc.Text, MolarRatio.Text, volumeanal.Text, dilutionfactor.Text));
                    Concentration.Items.Add(concentrationnum + "# " + concentrationfigure);
                    concentrationnum++;
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Not all the proper fields are filled out in the correct format", "Error: Failure to Compute Concentration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Concentration.Text = roundcheck(concentrationdetermin.ReturnConcentration(importdata.equivalencepoints[0], TitConc.Text, MolarRatio.Text, volumeanal.Text, dilutionfactor.Text));

            titrationdatastorage.storedtitrationconcentration = TitConc.Text;

            importdata.DataStore();

            titrationdatastorage.a_vol_Global = Convert.ToDouble(volumeanal.Text);
            titrationdatastorage.a_conc_Global = Convert.ToDouble(Concentration.Text);
            titrationdatastorage.t_conc_Global = Convert.ToDouble(TitConc.Text);
            titrationdatastorage.titrantformula = formula.Text;

            Derivcheck.Checked = true;
            Interceptpoints.Checked = true;
            derivative2.Checked = true;
            Simulate.Enabled = true;
            Simulate.ForeColor = Color.Black;

            titrationdatastorage.titrationanalyzed = true;

            chart1.ChartAreas[0].AxisX.RoundAxisValues();

        Finish:;
            
        }

        private void Import(object sender, EventArgs e)
        {
            Equivalence.Items.Clear();
            PKA.Items.Clear();
            titrationdatastorage.titrationanalyzed = false;

            if (knownanal.Checked == false)
            {
                Concentration.Items.Clear();
                unkownacid.Text = "";
            }

            Equivalence.Text = "";
            PKA.Text = "";
            Concentration.Text = "";

            var importdata = new adddata();

            addeddata = importdata;

            try
            {
                importdata.importandstore();
            }
            catch (Exception)
            {
                MessageBox.Show("Another program is using this dataset. Please close the file and try again.");
                goto Finish;
            }

            

            if(importdata.finishprocessing == true)
            {
                goto Finish;
            }
            else
            {
                
                importdata.AssessData();
            }

            chart1.Series.Clear();

            titrationdatastorage.normy1 = Convert.ToInt32(NormY1.Text);
            titrationdatastorage.normy2 = Convert.ToInt32(NormY2.Text);
            titrationdatastorage.offset = Convert.ToInt32(OffsetY2.Text);

            //Code to do with charting of data

            ChangeGraph();

            if(importdata.finishprocessing == true)
            {
                goto Finish;
            }
            else
            {
                chart1.Series.Add(importdata.Graphdata());
            }
                

            chart1.ChartAreas[0].RecalculateAxesScale();

            Titrationcheck.Checked = true;

            chart1.ChartAreas[0].AxisX.RoundAxisValues();

        Finish:
            if(importdata.finishprocessing == true)
            {
                titrationdatastorage.titrationstorage.Clear();
                MessageBox.Show("Unable to graph data");
            }
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Titrationcheck.Checked == true)
                {
                    this.chart1.Series[0].Enabled = true;
                }
                else
                {
                    this.chart1.Series[0].Enabled = false;
                }

                chart1.ChartAreas[0].RecalculateAxesScale();
            }
            catch (Exception)
            {

            }
            
        }

        private void Derivcheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Derivcheck.Checked == true)
                {
                    this.chart1.Series[1].Enabled = true;

                }
                else
                {
                    this.chart1.Series[1].Enabled = false;
                }

                chart1.ChartAreas[0].RecalculateAxesScale();

            }
            catch (Exception)
            {

            }
        }

        private void InterceptCheck(object sender, EventArgs e)
        {
            try
            {
                if (Interceptpoints.Checked == true)
                {
                    this.chart1.Series[3].Enabled = true;
                }
                else
                {
                    this.chart1.Series[3].Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void Textexport(StreamWriter sw)
        {
            sw.WriteLine("------//Titrant//------" + "\n");
            sw.WriteLine("Molecule: " + formula.Text + "\n");
            sw.WriteLine("Molar Mass: " + Molarmass.Text + "m/z" + "\n");
            sw.WriteLine("Mass: " + mass.Text + "g" + "\n");
            sw.WriteLine("Volume: " + Volumetit.Text + "mL" + "\n");
            sw.WriteLine("Concentration: " + TitConc.Text + "mol/L" + "\n");
            sw.WriteLine("Molar Ratio: " + MolarRatio.Text + " - acid:base" + "\n");
            sw.WriteLine("------//Analyte//------" + "\n");
            sw.WriteLine("Volume: " + volumeanal.Text + "mL" + "\n");
            sw.WriteLine("Dilution Factor: " + dilutionfactor.Text + "x" + "\n");
            sw.WriteLine("------//Results//------" + "\n");

            var knownorunkown = "";

            if (knownanal.Checked == true)
            {
                knownorunkown = "Known";
            }
            else
            {
                knownorunkown = "Unknown";
            }

            switch (titrationdatastorage.hplus)
            {
                case 1:
                    sw.WriteLine("Monoprotic " + acidbase + "\n");
                    break;
                case 2:
                    sw.WriteLine("Diprotic" + acidbase + "\n");
                    break;
                case 3:
                    sw.WriteLine("Triprotic" + acidbase + "\n");
                    break;
                default:
                    break;
            }

            foreach (var equiv in Equivalence.Items)
            {
                sw.WriteLine("Equivalence Point: " + equiv.ToString() + "\n");
            }

            foreach (var conc in Concentration.Items)
            {
                sw.WriteLine(knownorunkown + " " + acidbase + "Concentration: " + conc.ToString() + "mol/L" + "\n");
            }

            foreach (var pka in PKA.Items)
            {
                sw.WriteLine(knownorunkown + " " + acidbase + " " + pkapkb + ": " + pka.ToString() + "\n");
            }

            sw.WriteLine(knownorunkown + " " + acidbase +": " + unkownacid.Text + "\n");
            sw.WriteLine("Volume(mL),PH,Y',Y''");

            foreach (string data in titrationdatastorage.completedataset)
            {
                sw.WriteLine(data);
            }

            var simulationsize = titrationdatastorage.simPhLs.Count;

            if(simulationsize != 0)
            {
                sw.WriteLine("\n");
                sw.WriteLine("Simulated Data" + "\n");
                sw.WriteLine("Volume(mL),PH" + "\n");

                for (int i = 0; i < simulationsize; i++)
                {
                    var datapoint = Convert.ToString(titrationdatastorage.simVolLs[i]) + "," + Convert.ToString(titrationdatastorage.simPhLs[i]);
                    sw.WriteLine(datapoint);
                }
            }

        }

        private void PDFexporter(PdfDocument documentobject, string filepath, string directory)
        {
            PdfPage page = documentobject.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont(titrationdatastorage.resultsfont, titrationdatastorage.resultssize, XFontStyle.Regular);
            XFont fontcaption = new XFont(titrationdatastorage.headerfont, titrationdatastorage.headersize, XFontStyle.Bold);
            XFont GraphCaption = new XFont("Times New Roman", 16, XFontStyle.Bold);
            var spacing = titrationdatastorage.spacing * titrationdatastorage.headersize;
            var indent = titrationdatastorage.margins;
            var knownorunkown = "";

            if(knownanal.Checked == true)
            {
                knownorunkown = "Known";
            }
            else
            {
                knownorunkown = "Unknown";
            }

            gfx.DrawString("------//Titrant//------", fontcaption, XBrushes.Black, new XRect(indent, spacing, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Molecule: " + formula.Text, font, XBrushes.Black, new XRect(indent, spacing*2, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Molar Mass: " + Molarmass.Text + "m/z", font, XBrushes.Black, new XRect(indent, spacing*3, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Mass: " + mass.Text + "g", font, XBrushes.Black, new XRect(indent, spacing * 4, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Volume: " + Volumetit.Text + "mL", font, XBrushes.Black, new XRect(indent, spacing * 5, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Concentration: " + TitConc.Text + "mol/L", font, XBrushes.Black, new XRect(indent, spacing * 6, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Molar Ratio: " + MolarRatio.Text + " - acid:base", font, XBrushes.Black, new XRect(indent, spacing * 7, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("------//Analyte//------", fontcaption, XBrushes.Black, new XRect(indent, spacing * 8, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Volume: " + volumeanal.Text + "mL", font, XBrushes.Black, new XRect(indent, spacing * 9, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Dilution Factor: " + dilutionfactor.Text + "x", font, XBrushes.Black, new XRect(indent, spacing * 10, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("------//Results//------", fontcaption, XBrushes.Black, new XRect(indent, spacing * 11, page.Width, page.Height), XStringFormats.TopLeft);
            
            switch (titrationdatastorage.hplus)
            {
                case 1:
                    gfx.DrawString("Monoprotic " + acidbase, font, XBrushes.Black, new XRect(indent, spacing * 12, page.Width, page.Height), XStringFormats.TopLeft);
                    break;
                case 2:
                    gfx.DrawString("Diprotic " + acidbase, font, XBrushes.Black, new XRect(indent, spacing * 12, page.Width, page.Height), XStringFormats.TopLeft);
                    break;
                case 3:
                    gfx.DrawString("Triprotic " + acidbase, font, XBrushes.Black, new XRect(indent, spacing * 12, page.Width, page.Height), XStringFormats.TopLeft);
                    break;
                default:
                    break;
            }

            int pagesize = 13;

            foreach (var equiv in Equivalence.Items)
            {
                gfx.DrawString("Equivalence Point: " + equiv.ToString(), font, XBrushes.Black, new XRect(indent, spacing * pagesize, page.Width, page.Height), XStringFormats.TopLeft);
                pagesize++;
            }

            foreach (var conc in Concentration.Items)
            {
                gfx.DrawString(knownorunkown + " " + acidbase + " Concentration: " + conc.ToString() + "mol/L", font, XBrushes.Black, new XRect(indent, spacing * pagesize, page.Width, page.Height), XStringFormats.TopLeft);
                pagesize++;
            }

            foreach (var pka in PKA.Items)
            {
                gfx.DrawString(knownorunkown + " " + acidbase + " " +  pkapkb + ": " + pka.ToString(), font, XBrushes.Black, new XRect(indent, spacing * pagesize, page.Width, page.Height), XStringFormats.TopLeft);
                pagesize++;
            }

            gfx.DrawString(knownorunkown + " " + acidbase + ": " + unkownacid.Text, font, XBrushes.Black, new XRect(indent, spacing*(pagesize + 1), page.Width, page.Height), XStringFormats.TopLeft);

            var dateandtime = DateTime.UtcNow.ToString("MMddyyyy");

            chart1.SaveImage(directory + "\\" + dateandtime + "tempchartOTV2.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);

            XImage graph = XImage.FromFile(directory + "\\" + dateandtime + "tempchartOTV2.png");

            var aspectratio = graph.PointWidth / page.Width;

            gfx.DrawImage(graph, 0, spacing * (pagesize + 5), graph.PointWidth/aspectratio, graph.PointHeight/aspectratio);

            gfx.DrawString("Volume (mL) vs. PH", GraphCaption, XBrushes.Black, new XRect(0, spacing * (pagesize + 4), page.Width, page.Height), XStringFormats.TopCenter);

            graph.Dispose();

            File.Delete(directory + "\\" + dateandtime + "tempchartOTV2.png");

            PdfPage page2 = documentobject.AddPage();
            XGraphics gfx2 = XGraphics.FromPdfPage(page2);

            gfx2.DrawString("Volume(mL),PH,Y',Y''", fontcaption, XBrushes.Black, new XRect(indent, spacing, page.Width, page.Height), XStringFormats.TopLeft);

            var pagesize2 = 2;
            var pagenumber = 2;

            foreach (string data in titrationdatastorage.completedataset)
            {
                var maxpagesize = spacing * pagesize2;
                
                if(maxpagesize >= 800)
                {
                    var newpage = documentobject.AddPage();
                    gfx2 = XGraphics.FromPdfPage(newpage);
                    pagesize2 = 2;
                    pagenumber++;
                }

                gfx2.DrawString(data, font, XBrushes.Black, new XRect(indent, spacing*pagesize2, page.Width, page.Height), XStringFormats.TopLeft);
                pagesize2++;
            }

            var simulationlength = titrationdatastorage.simVolLs.Count;

            if(simulationlength != 0)
            {
                var simulatedpage = documentobject.AddPage();
                gfx2 = XGraphics.FromPdfPage(simulatedpage);

                gfx2.DrawString("Simulated Data", fontcaption, XBrushes.Black, new XRect(indent, spacing, page.Width, page.Height), XStringFormats.TopLeft);

                gfx2.DrawString("Volume (mL), PH", fontcaption, XBrushes.Black, new XRect(indent, spacing * 2, page.Width, page.Height), XStringFormats.TopLeft);

                var pagesize3 = 3;

                pagenumber += 1;

                for (int i = 0; i < simulationlength; i++)
                {
                    var maxpagesize = spacing * pagesize3;
                    var datapoint = Convert.ToString(titrationdatastorage.simVolLs[i]) + "," + Convert.ToString(titrationdatastorage.simPhLs[i]);

                    if (maxpagesize >= 800)
                    {
                        var newpage = documentobject.AddPage();
                        gfx2 = XGraphics.FromPdfPage(newpage);
                        pagesize3 = 2;
                        pagenumber++;
                    }

                    gfx2.DrawString(datapoint, font, XBrushes.Black, new XRect(indent, spacing * pagesize3, page.Width, page.Height), XStringFormats.TopLeft);
                    pagesize3++;
                }

            }

            documentobject.Save(filepath);

            Process.Start(filepath);

        }

        private void Export(object sender, EventArgs e)
        {
            SaveFileDialog exportdata = new SaveFileDialog();
            
            exportdata.Filter = "Text File|*.txt|PDF files (*.pdf)|*.pdf|Save Graph (*.png)|*.png";
            exportdata.Title = "Export Titration Data";


            if(exportdata.ShowDialog() == DialogResult.OK)
            {
                var filename = exportdata.FileName;
                var fileextension = Path.GetExtension(filename);
                var fullfilepath = Path.GetFullPath(filename);
                var filepath = Path.GetDirectoryName(filename);
                
                
                exportdata.CheckFileExists = true;

                if(fileextension == ".txt")
                {
                    using (StreamWriter sw = new StreamWriter(exportdata.FileName))
                    {
                        Textexport(sw);
                    }
                }
                else if(fileextension == ".pdf")
                {
                    PdfDocument titrationdatasheet = new PdfDocument();
                    PDFexporter(titrationdatasheet, fullfilepath, filepath);
                }
                else if(fileextension == ".png")
                {
                    chart1.SaveImage(Path.GetFullPath(filename), System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
                
            }
        }

        private void secondselect(object sender, EventArgs e)
        {
            try
            {
                if (derivative2.Checked == true)
                {
                    this.chart1.Series[2].Enabled = true;
                }
                else
                {
                    this.chart1.Series[2].Enabled = false;
                }

                chart1.ChartAreas[0].RecalculateAxesScale();

            }
            catch (Exception)
            {

            }
        }

        private void knownconcentrationcheck(object sender, EventArgs e)
        {
            mass.Text = "";
            Volumetit.Text = "";
            //TitConc.Text = "";

            if(Concknown.Checked == true)
            {
                mass.BackColor = Color.Beige;
                Volumetit.BackColor = Color.Beige;
                mass.ReadOnly = true;
                Volumetit.ReadOnly = true;
            }
            else
            {
                mass.BackColor = Color.White;
                Volumetit.BackColor = Color.White;
                mass.ReadOnly = false;
                Volumetit.ReadOnly = false;
            }
           
        }
        private void baseselect(object sender, EventArgs e)
        {
            if (Base.Checked == true)
            {
                titrationdatastorage.isbase = true;

                Hplus.Text = "OH-";
                PkaLabel.Text = "pKa";
                acidbase = "Base";
                pkapkb = "pKa";

                if(knownanal.Checked == true)
                {
                    unkownacidlabel.Text = "Known Base";

                    var knownbase = new unkownacid(titrationdatastorage.hplus, titrationdatastorage.isbase);

                    unkownacid.Items.Clear();

                    var acidlist = new List<string>(knownbase.acidlist(titrationdatastorage.hplus));

                    foreach(string baseitem in acidlist)
                    {
                        unkownacid.Items.Add(baseitem);
                    }

                    unkownacid.Text = acidlist[0];

                }
                else
                {
                    unkownacidlabel.Text = "Unknown Base";
                }
                
                
            }
            else
            {
                titrationdatastorage.isbase = false;

                Hplus.Text = "H+";
                PkaLabel.Text = "pKa";
                acidbase = "Acid";
                pkapkb = "pKa";

                if(knownanal.Checked == true)
                {
                    unkownacidlabel.Text = "Known Acid";

                    var knownacid = new unkownacid(titrationdatastorage.hplus, titrationdatastorage.isbase);

                    unkownacid.Items.Clear();

                    var acidlist = new List<string>(knownacid.acidlist(titrationdatastorage.hplus));

                    foreach (string aciditem in acidlist)
                    {
                        unkownacid.Items.Add(aciditem);
                    }

                    unkownacid.Text = acidlist[0];

                }
                else
                {
                    unkownacidlabel.Text = "Unknown Acid";
                }
               
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings settingsform = new Settings(this);
            settingsform.hplustrans += new EventHandler(Proton_DataAvailable);
            settingsform.Show();
        }

        private bool formfillcheck()
        {

            if(titrationdatastorage.custompKaselect == true)
            {
                if (titrationdatastorage.custompKa == null)
                {
                    Settings settingsform = new Settings(this, 3);
                    MessageBox.Show("The setting for a custom defined pKa has been selected, but no values have been inputed.", "Error: Missing Simulation Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    settingsform.Show();
                    goto Exit;
                }

                var pkacheck = titrationdatastorage.custompKa.Split(',');

                double placeholder = 0;

                

                foreach(string pkavalue in pkacheck)
                {
                    if( double.TryParse(pkavalue, out placeholder) == false)
                    {
                        Settings settingsform = new Settings(this, 3);
                        MessageBox.Show("The input value '" + pkavalue  +"' Is invalid. Please check your input and try again", "Error: Missing Simulation Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        settingsform.Show();
                        goto Exit;
                    }
                }


            }
            else
            {
                if(titrationdatastorage.acidchosenpka == "")
                {
                    Settings settingsform = new Settings(this, 3);
                    titrationdatastorage.custompKaselect = true;
                    MessageBox.Show("The option for a custom pKa is not selected, yet there is no match in the library for the titrant. Please either input a new titrant or specify the Pka value(s)", "Error: Missing Simulation Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    settingsform.Show();
                    goto Exit;
                }
            }

            

            if (titrationdatastorage.titrantformula == "")
            {
                MessageBox.Show("The formula for the titrant is required for the simulation", "Error: Missing Simulation Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto Exit;
            }

            if (titrationdatastorage.maxvolume == 0)
            {
                MessageBox.Show("The volume for the simulation has not been specified", "Error: Missing Simulation Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto Exit;
            }

            if (titrationdatastorage.a_conc_Global == 0)
            {
                MessageBox.Show("The concentration of the analyte is missing", "Error: Missing Simulation Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto Exit;
            }

            if(titrationdatastorage.a_vol_Global == 0)
            {
                MessageBox.Show("Please fill out the volume for the analyte", "Error: Missing Simulation Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                goto Exit;
            }

            if(titrationdatastorage.t_conc_Global == 0)
            {
                MessageBox.Show("Please fill out the concentration for the titrant", "Error: Missing Simulation Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto Exit;
            }

            return true;

        Exit:
            {
                return false;
            }
            
        }

        void Proton_DataAvailable(object sender, EventArgs e)
        {
            Settings proton = sender as Settings;
            if (proton != null)
            {
                hplusnum.Text = proton.hplusstatetransfer;
            }
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            linkLabel1.LinkColor = Color.Red;
        }

        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            linkLabel1.LinkColor = Color.Black;
        }

        private void linkLabel2_MouseHover(object sender, EventArgs e)
        {
            linkLabel2.LinkColor = Color.Red;
        }

        private void linkLabel2_MouseLeave(object sender, EventArgs e)
        {
            linkLabel2.LinkColor = Color.Black;
        }

        private void Initiallize_Help(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\OpenTitration V2 User Manual.pdf");
            }
            catch (Exception)
            {
                MessageBox.Show("Help file could not be found");

                OpenFileDialog findhelpfile = new OpenFileDialog();

                using (findhelpfile)
                {
                    findhelpfile.InitialDirectory = @"C:\";
                    findhelpfile.Filter = "PDF files (*.pdf)|*.pdf";
                    findhelpfile.RestoreDirectory = true;
                    
                   
                    if (findhelpfile.ShowDialog() == DialogResult.OK)
                    {
                        var filename = findhelpfile.FileName;
                        var fullfilepath = Path.GetFullPath(filename);
                        System.Diagnostics.Process.Start(fullfilepath);
                    }
                    else
                    {
                        
                    }
                }
            }
        }

        private void change_protination(object sender, EventArgs e)
        {
            titrationdatastorage.hplus = Convert.ToInt32(hplusnum.Text);
            Properties.Settings.Default.HPlus = Convert.ToInt32(hplusnum.Text);

            if(hplusnum.Text == "1" && titrationdatastorage.solvemethod == "Manual Range")
            {
                Properties.Settings.Default.SolveMethod = "Automatic";
                titrationdatastorage.solvemethod = "Automatic";
            }
            
            if (knownanal.Checked == true)
            {
                unkownacid.Items.Clear();
                var knownacid = new unkownacid(titrationdatastorage.hplus, titrationdatastorage.isbase);

                var aciditems = knownacid.acidlist(titrationdatastorage.hplus);

                foreach (var item in aciditems)
                {
                    unkownacid.Items.Add(item);
                }
                unkownacid.Text = unkownacid.Items[0].ToString();
            }
            else
            {
                unkownacid.Text = "";
                unkownacid.Items.Clear();
            }
        }

        public void change_graph_settings()
        {

            ChangeGraph();

            try
            {
                chart1.Series[0].Color = Color.FromName(titrationdatastorage.titrationcolor);
                chart1.Series[0].BorderWidth = titrationdatastorage.linethickness;
                
                if(titrationdatastorage.titrationstyle == "Line")
                {
                    chart1.Series[0].BorderDashStyle = ChartDashStyle.Solid;
                    chart1.Series[0].ChartType = SeriesChartType.Line;
                }
                else if(titrationdatastorage.titrationstyle == "Dash")
                {
                    chart1.Series[0].BorderDashStyle = ChartDashStyle.Dash;
                    chart1.Series[0].ChartType = SeriesChartType.Line;
                }
                else if(titrationdatastorage.titrationstyle == "Points")
                {
                    chart1.Series[0].ChartType = SeriesChartType.Point;
                }
            }
            catch (Exception)
            {

            }

            try
            {
                chart1.Series[1].Color = Color.FromName(titrationdatastorage.firstderivativecolor);
                chart1.Series[1].BorderWidth = titrationdatastorage.linethickness;

                if (titrationdatastorage.firstderivstyle == "Line")
                {
                    chart1.Series[1].BorderDashStyle = ChartDashStyle.Solid;
                    chart1.Series[1].ChartType = SeriesChartType.Line;
                }
                else if (titrationdatastorage.firstderivstyle == "Dash")
                {
                    chart1.Series[1].BorderDashStyle = ChartDashStyle.Dash;
                    chart1.Series[1].ChartType = SeriesChartType.Line;
                }
                else if (titrationdatastorage.firstderivstyle == "Points")
                {
                    chart1.Series[1].ChartType = SeriesChartType.Point;
                }
            }
            catch (Exception)
            {

            }

            try
            {
                chart1.Series[2].Color = Color.FromName(titrationdatastorage.secondderivativecolor);
                chart1.Series[2].BorderWidth = titrationdatastorage.linethickness;

                if (titrationdatastorage.secondderivstyle == "Line")
                {
                    chart1.Series[2].BorderDashStyle = ChartDashStyle.Solid;
                    chart1.Series[2].ChartType = SeriesChartType.Line;
                }
                else if (titrationdatastorage.secondderivstyle == "Dash")
                {
                    chart1.Series[2].BorderDashStyle = ChartDashStyle.Dash;
                    chart1.Series[2].ChartType = SeriesChartType.Line;
                }
                else if (titrationdatastorage.secondderivstyle == "Points")
                {
                    chart1.Series[2].ChartType = SeriesChartType.Point;
                }
            }
            catch (Exception)
            {

            }

            try
            {
                chart1.Series[3].Font = new System.Drawing.Font(titrationdatastorage.interceptlabelstext, titrationdatastorage.interceptlabelssize, System.Drawing.FontStyle.Bold);

            }
            catch (Exception)
            {

            }

            try
            {
                chart1.Series[4].Color = Color.FromName(titrationdatastorage.simulationcolor);
                chart1.Series[4].BorderWidth = titrationdatastorage.linethickness;

                if (titrationdatastorage.simulatedstyle == "Line")
                {
                    chart1.Series[4].BorderDashStyle = ChartDashStyle.Solid;
                    chart1.Series[4].ChartType = SeriesChartType.Line;
                }
                else if (titrationdatastorage.simulatedstyle == "Dash")
                {
                    chart1.Series[4].BorderDashStyle = ChartDashStyle.Dash;
                    chart1.Series[4].ChartType = SeriesChartType.Line;
                }
                else if (titrationdatastorage.simulatedstyle == "Points")
                {
                    chart1.Series[4].ChartType = SeriesChartType.Point;
                }
            }
            catch (Exception)
            {

            }
        }

        private void simulator_parameters(StreamWriter sw, bool acidic, string pkaanalyte, string pkatitrant, double conc_anal, double conc_titrant, double volume_anal, double temp, double resolution)
        {
            sw.WriteLine("ANALYTE");
            sw.WriteLine("name=" + formula.Text);
            sw.WriteLine("acidic=" + acidic);
            sw.WriteLine("pkas=" + pkaanalyte);
            sw.WriteLine("TITRANT");
            sw.WriteLine("name=" + unkownacid.Text);
            sw.WriteLine("pkas=" + pkatitrant);
            sw.WriteLine("TITRATION");
            sw.WriteLine("concentration_analyte=" + conc_anal);
            sw.WriteLine("concentration_titrant=" + conc_titrant);
            sw.WriteLine("volume_analyte=" + volume_anal);
            sw.WriteLine("temp=" + temp);
            sw.WriteLine("decimal_places=" + resolution);
        }

        private void graph_simdata()
        {
            if (chart1.Series.Contains(titrationdatastorage.simulationdata) == true)
            {
                chart1.Series.Remove(titrationdatastorage.simulationdata);
            }
            else
            {
                
            }
           
            titrationdatastorage.simulationdata.Points.Clear();

            var simulationlength = titrationdatastorage.simPhLs.Count;

            titrationdatastorage.simulationdata.Name = "Simulation";
            titrationdatastorage.simulationdata.BorderWidth = titrationdatastorage.linethickness;
            titrationdatastorage.simulationdata.Color = Color.FromName(titrationdatastorage.simulationcolor);

            if (titrationdatastorage.simulatedstyle == "Line")
            {
                titrationdatastorage.simulationdata.ChartType = SeriesChartType.Line;
                titrationdatastorage.simulationdata.BorderDashStyle = ChartDashStyle.Solid;
            }
            else if (titrationdatastorage.simulatedstyle == "Dash")
            {
                titrationdatastorage.simulationdata.ChartType = SeriesChartType.Line;
                titrationdatastorage.simulationdata.BorderDashStyle = ChartDashStyle.Dash;
            }
            else if (titrationdatastorage.simulatedstyle == "Points")
            {
                titrationdatastorage.simulationdata.ChartType = SeriesChartType.Point;
            }

            for (int i = 0; i < simulationlength; i++)
            {
                titrationdatastorage.simulationdata.Points.AddXY(titrationdatastorage.simVolLs[i], titrationdatastorage.simPhLs[i]);
            }

            chart1.Series.Add(titrationdatastorage.simulationdata);
           
        }
        private void simulate()
        {
            SimulatedSeries.Checked = true;
            SimulatedSeries.Enabled = true;
            SimulatedSeries.ForeColor = Color.Black;

            // Variables for titrant and analyte being base or acid
            bool a_acidic = !titrationdatastorage.isbase;
            bool t_acidic = titrationdatastorage.isbase;

            //collected pKa variables for unkown. Only will work if analysis of regular titration data has been completed.

            string a_pK = "";

            //This allows the acid to choose their own unkown if they happen to know it for the titration.
            if(knownanal.Checked == false)
            {
                a_pK = baseacidpkaconverter(titrationdatastorage.analytepkavalues, false);
            }
            else
            {
                if(titrationdatastorage.knownpka == "")
                {
                    var aciddetermine = new unkownacid(titrationdatastorage.hplus, titrationdatastorage.isbase);

                    try
                    {
                        var knownpKa = aciddetermine.knowngetpKa(titrationdatastorage.hplus, unkownacid.Text);
                        titrationdatastorage.knownpka = baseacidpkaconverter(knownpKa, false);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Acid or base is specified as known. Make sure to pick the acid or base identity", "Error: Failure to simulate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
                else
                {
                    if (unkownacid.Text == titrationdatastorage.customanalyteacid)
                    {
                        titrationdatastorage.knownpka = baseacidpkaconverter(titrationdatastorage.customanalyteacidpKa, false);
                    }
                    else if(unkownacid.Text == titrationdatastorage.customanalyteacidwithmatch)
                    {
                        titrationdatastorage.knownpka = baseacidpkaconverter(titrationdatastorage.knownpka, false);
                    }
                    else
                    {
                        var aciddetermine = new unkownacid(titrationdatastorage.hplus, titrationdatastorage.isbase);
                        titrationdatastorage.knownpka = baseacidpkaconverter(aciddetermine.knowngetpKa(titrationdatastorage.hplus, unkownacid.Text), false);
                    }
                    
                }

                a_pK = titrationdatastorage.knownpka;
            }
            

            string t_pK = "";

            try
            {
                if (titrationdatastorage.custompKaselect == false)
                {
                    //Linked from the internal dictionary
                    t_pK = baseacidpkaconverter(titrationdatastorage.acidchosenpka, true);
                }
                else if (titrationdatastorage.custompKaselect == true)
                {
                    //Defined by the user
                    t_pK = baseacidpkaconverter(titrationdatastorage.custompKa, true);
                }
            }
            catch (Exception)
            {
                
            }

            //The data needed will only be loaded once the titration data of the origonal sample
            //Has been successfully analyzed.

            double a_vol = titrationdatastorage.a_vol_Global;
            double a_conc = titrationdatastorage.a_conc_Global;
            double t_conc = titrationdatastorage.t_conc_Global;

            //Here is the volume that the simulated data should be generated to. From 0 to the max
            //Of the origonal titration data.

            double simulationvolume = titrationdatastorage.maxvolume;

            //Here is a setting that allows you to set what data points are calculated for the simulator

            double resolution = titrationdatastorage.resolution;

            // Create Process Info
   
            double temperature = titrationdatastorage.temperature;

            //This creates the input script for the simulator
            using (StreamWriter sw = new StreamWriter("simulation_parameters.txt"))
            {
                simulator_parameters(sw, a_acidic, a_pK, t_pK, a_conc, t_conc, a_vol, temperature, resolution);
            }

            Process simulation = new Process();
            simulation.StartInfo.FileName = titrationdatastorage.pythonpath;
            simulation.EnableRaisingEvents = true;
            simulation.Start();
            simulation.WaitForExit();

            string[] results = System.IO.File.ReadAllLines(Application.StartupPath + @"\simulation_results.txt");

            foreach(string datapoint in results)
            {
                datapoint.Replace(" ", string.Empty);
                var splitresults = datapoint.Split(',');
                titrationdatastorage.simPhLs.Add(Convert.ToDouble(splitresults[1]));
                titrationdatastorage.simVolLs.Add(Convert.ToDouble(splitresults[0]));
            }

        }
        private void Formula_TextChanged(object sender, EventArgs e)
        {
            Molarmass.Text = "";

        }

        private void Simulation(object sender, EventArgs e)
        {

            //This makes sure that all the information for the simulator has been filled in. Returns boolean to see if true or false.
            var informationfilled = formfillcheck();
            var simulationfailed = false;


            if (informationfilled == false)
            {
                goto ExitSim;
            }

            try
            {
                titrationdatastorage.simPhLs.Clear();
                titrationdatastorage.simVolLs.Clear();
                simulate();
            }
            catch (Exception)
            {
                MessageBox.Show("The simulation failed, please check your settings.", "Error: Failure to simulate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                simulationfailed = true;
            }

            if(titrationdatastorage.simVolLs.Count == 0 && simulationfailed == false)
            {
                MessageBox.Show("The simulation failed, please check your settings.", "Error: Failure to simulate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto ExitSim;
            }

            graph_simdata();

            chart1.ChartAreas[0].AxisX.RoundAxisValues();

        ExitSim:
            {

            }

        }

        private void Simgraph(object sender, EventArgs e)
        {
            try
            {
                if (SimulatedSeries.Checked == true)
                {
                    this.chart1.Series[4].Enabled = true;
                }
                else
                {
                    this.chart1.Series[4].Enabled = false;
                }

                chart1.ChartAreas[0].RecalculateAxesScale();

            }
            catch (Exception)
            {

            }
        }

        private void known_acid(object sender, EventArgs e)
        {
            
            if(knownanal.Checked == true)
            {
                if(Base.Checked == true)
                {
                    unkownacidlabel.Text = "Known Base";
                }
                else
                {
                    unkownacidlabel.Text = "Known Acid";
                }
                

                var knownacid = new unkownacid(titrationdatastorage.hplus, titrationdatastorage.isbase);

                var aciditems = knownacid.acidlist(titrationdatastorage.hplus);

                addacid.Enabled = true;

                if (titrationdatastorage.customanalyteacid != null)
                {
                    if(unkownacid.Items.Contains(titrationdatastorage.customanalyteacid) == false)
                    {
                        unkownacid.Items.Add(titrationdatastorage.customanalyteacid);
                    }
                    
                }

                foreach (var item in aciditems)
                {
                    unkownacid.Items.Add(item);
                }
                
                unkownacid.SelectedIndex = 0;
            }
            else
            {
                if(Base.Checked == true)
                {
                    unkownacidlabel.Text = "Unknown Base";
                }
                else
                {
                    unkownacidlabel.Text = "Unknown Acid";
                }
                
                unkownacid.Text = titrationdatastorage.unkownacidorbaseidentity;
                addacid.Enabled = false;
                unkownacid.Items.Clear();
            }

        }

        public void customacidadd()
        {
            var knownacidcheck = titrationdatastorage.customanalyteacid;

            if ((string)unkownacid.Items[0] == knownacidcheck)
            {
                unkownacid.Items.Remove(knownacidcheck);

            }

            unkownacid.Text = titrationdatastorage.customanalyteacid;
        }

        private void add_acid(object sender, EventArgs e)
        {


            knownacidadd acidicaddition = new knownacidadd(this);
            acidicaddition.Show();
        }

        private void unkownacid_MouseClick(object sender, MouseEventArgs e)
        {
            if(knownanal.Checked == true)
            {
                if (titrationdatastorage.customanalyteacid != null)
                {
                    if (unkownacid.Items.Contains(titrationdatastorage.customanalyteacid) == false)
                    {
                        unkownacid.Items.Insert(0, titrationdatastorage.customanalyteacid);
                    }

                }
            }

        }

        private void formula_Leave(object sender, EventArgs e)
        {
            titrationdatastorage.acidchosenpka = "";

            if(formula.Text == "")
            {

            }
            else
            {
                try
                {
                    findacid();
                }
                catch (Exception)
                {
                    titrationdatastorage.custompKaselect = true;
                    Properties.Settings.Default.CustompKaselect = true;
                    Settings settingsform = new Settings(this, 3);
                    MessageBox.Show("No match could be found for selected titrant. Please check your formula or enter in pKa values manually in the settings.", "Error: Failure to find titrant acid from formula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    settingsform.Show();
                }
            }

        }

        private void TitConc_Leave(object sender, EventArgs e)
        {
            if(Concknown.Checked == true)
            {
                var titrationconcentrationstore = "";

                if (titrationdatastorage.titrationanalyzed == true)
                {
                    titrationconcentrationstore = titrationdatastorage.storedtitrationconcentration;
                }

                if (TitConc.Text == "0")
                {
                    TitConc.Text = titrationconcentrationstore;
                    goto Exit;
                }

                try
                {
                    if (Convert.ToDouble(TitConc.Text) < 0)
                    {
                        MessageBox.Show("Concentration cannot be less than zero", "Error: Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TitConc.Text = titrationconcentrationstore;
                        goto Exit;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Concentration of the titration must be a number", "Error: Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TitConc.Text = titrationconcentrationstore;
                    goto Exit;
                }

                if (titrationdatastorage.titrationanalyzed == true)
                {
                    var concentrationdetermin = new concentration();

                    int concentrationnum = 1;

                    Concentration.Items.Clear();
                    Concentration.Text = "";

                    if (Concknown.Checked == false)
                    {

                        TitConc.Text = roundcheck(concentrationdetermin.TitrantConcentration(Molarmass.Text, mass.Text, Volumetit.Text));

                    }
                    else if (Concknown.Checked == true)
                    {
                        TitConc.Text = roundcheck(Convert.ToDouble(TitConc.Text));
                    }

                    try
                    {
                        foreach (var equiv in titrationdatastorage.equivalencepoints)
                        {
                            var concentrationfigure = roundcheck(concentrationdetermin.ReturnConcentration(equiv, TitConc.Text, MolarRatio.Text, volumeanal.Text, dilutionfactor.Text));
                            Concentration.Items.Add(concentrationnum + "# " + concentrationfigure);
                            concentrationnum++;
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Not all the proper fields are filled out in the correct format", "Error: Failure to Compute Concentration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    titrationdatastorage.a_conc_Global = Convert.ToDouble(roundcheck(concentrationdetermin.ReturnConcentration(titrationdatastorage.equivalencepoints[0], TitConc.Text, MolarRatio.Text, volumeanal.Text, dilutionfactor.Text)));
                    titrationdatastorage.t_conc_Global = Convert.ToDouble(TitConc.Text);

                    Concentration.Text = roundcheck(concentrationdetermin.ReturnConcentration(titrationdatastorage.equivalencepoints[0], TitConc.Text, MolarRatio.Text, volumeanal.Text, dilutionfactor.Text));
                    titrationdatastorage.storedtitrationconcentration = TitConc.Text;
                }
            }
          
        Exit:
            {

            }
        }

        private string baseacidpkaconverter(string input, bool titrant)
        {
             var pkavaluessplit = input.Split(',');
      
            List<double> pkavalues = new List<double>();
            var pkastring = "";
            bool titrantoranalyte;


            if(titrant == true)
            {
                titrantoranalyte = !titrationdatastorage.isbase;
            }
            else
            {
                titrantoranalyte = titrationdatastorage.isbase;
            }

            foreach(string value in pkavaluessplit)
            {
                pkavalues.Add(Convert.ToDouble(value));
            }

            if (titrantoranalyte == true)
            {
                pkavalues.Sort();
                pkavalues.Reverse();
            }
            else if (titrantoranalyte == false)
            {
                pkavalues.Sort();
            }

            var pkanumber = pkavalues.Count;

            foreach(double pkavalue in pkavalues)
            {
                if(pkavalue == pkavalues[pkanumber - 1])
                {
                    pkastring += Convert.ToString(pkavalue);
                }
                else
                {
                    pkastring += Convert.ToString(pkavalue) + ",";
                }
                
            }

            return pkastring;
        }

        private void firstderivativegraphchange(object sender, EventArgs e)
        {
            
            Derivcheck.Checked = true;

            try
            {
                string series = "1st Derivative";

                if(chart1.Series.IsUniqueName(series) == false)
                {
                    foreach (DataPoint normalvalue in chart1.Series[1].Points)
                    {
                        double[] editedvariable = new double[1];

                        editedvariable[0] = Convert.ToDouble(normalvalue.YValues[0]) * (Convert.ToDouble(NormY1.SelectedItem) / Convert.ToDouble(titrationdatastorage.normy1));

                        normalvalue.YValues[0] = editedvariable[0];
                    }

                    chart1.Series["1st Derivative"].Enabled = false;
                    chart1.Series["1st Derivative"].Enabled = true;

                    chart1.ChartAreas[0].RecalculateAxesScale();

                }

            }
            catch (Exception)
            {

            }

            titrationdatastorage.normy1 = Convert.ToInt32(NormY1.SelectedItem);
            
        }

        private void SecondDerivativeGraphChange(object sender, EventArgs e)
        {

            derivative2.Checked = true;

            try
            {
                string series = "2nd Derivative";

                if (chart1.Series.IsUniqueName(series) == false)
                {
                    foreach (DataPoint normalvalue in chart1.Series[2].Points)
                    {
                        double[] editedvariable = new double[1];

                        editedvariable[0] = (Convert.ToDouble(normalvalue.YValues[0]) - Convert.ToDouble(OffsetY2.SelectedItem)) * (Convert.ToDouble(NormY2.SelectedItem) / Convert.ToDouble(titrationdatastorage.normy2));

                        normalvalue.YValues[0] = (editedvariable[0] + Convert.ToDouble(OffsetY2.SelectedItem));
                    }

                    chart1.Series["2nd Derivative"].Enabled = false;
                    chart1.Series["2nd Derivative"].Enabled = true;

                    chart1.ChartAreas[0].RecalculateAxesScale();

                }

            }
            catch (Exception)
            {

            }

            titrationdatastorage.normy2 = Convert.ToInt32(NormY2.SelectedItem);
        }

        private void SecondDerivativeOffsetChange(object sender, EventArgs e)
        {

            derivative2.Checked = true;

            try
            {
                string series = "2nd Derivative";

                if (chart1.Series.IsUniqueName(series) == false)
                {
                    foreach (DataPoint normalvalue in chart1.Series[2].Points)
                    {
                        double[] editedvariable = new double[1];

                        editedvariable[0] = Convert.ToDouble(normalvalue.YValues[0]) + (Convert.ToDouble(OffsetY2.SelectedItem) - Convert.ToDouble(titrationdatastorage.offset));

                        normalvalue.YValues[0] = editedvariable[0];
                    }

                    chart1.Series["2nd Derivative"].Enabled = false;
                    chart1.Series["2nd Derivative"].Enabled = true;

                    chart1.ChartAreas[0].RecalculateAxesScale();

                }

            }
            catch (Exception)
            {

            }

            titrationdatastorage.offset = Convert.ToInt32(OffsetY2.SelectedItem);
        }
    }
    }

