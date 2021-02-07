using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Titration_Analyzer
{
    public partial class Form1 : Form
    {

        public static class titrationdatastorage
        {


            public static List<string> titrationstorage = new List<string>();
            public static List<string> completedataset = new List<string>();
            public static int normy1;
            public static int normy2;
            public static int offset;
            public static int hplus;
            public static string unkown;
            public static bool isbase;

            //Simulator Settings
            public static bool StrongAcidorBase;
            public static string pkavalues;
            public static double a_vol_Global;
            public static double a_conc_Global;
            public static double t_conc_Global;
            public static double maxvolume;
            public static double resolution;
            public static string defaultpythonpath;
            public static string pythonpath;


            //Calculation Settings
            public static string solvemethod;
            public static string rangetype;
            public static double rangeone;
            public static double rangetwo { get; set; }

            //Graph Settings
            public static int iterationsetting;
            public static int linethickness;
            public static string interceptlabelstext;
            public static int interceptlabelssize;
            public static int xaxisgraphsize;
            public static int yaxisgraphsize;
            public static string xaxislabeltext;
            public static string yaxislabeltext;

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

            //Simulator Settings
            titrationdatastorage.resolution = Properties.Settings.Default.Resolution;
            titrationdatastorage.StrongAcidorBase = Properties.Settings.Default.StrongAcidorBase;

            titrationdatastorage.defaultpythonpath = Application.StartupPath + @"\python_env\Scripts\python.exe";

            //This determines if the default path has been selected, or another path is to be selected.

            if (Properties.Settings.Default.CustomPythonPath == false)
            {
                Properties.Settings.Default.PythonPath = titrationdatastorage.defaultpythonpath;
                titrationdatastorage.pythonpath = titrationdatastorage.defaultpythonpath;
            }
            else
            {
                titrationdatastorage.pythonpath = Properties.Settings.Default.PythonPath;
            }

            //Calc Settings
            titrationdatastorage.rangeone = Properties.Settings.Default.Range1;
            titrationdatastorage.rangetwo = Properties.Settings.Default.Range2;
            titrationdatastorage.rangetype = Properties.Settings.Default.RangeType;
            titrationdatastorage.iterationsetting = Properties.Settings.Default.Iterationsetting;
            titrationdatastorage.solvemethod = Properties.Settings.Default.SolveMethod;

            //Chart settings
            titrationdatastorage.hplus = Properties.Settings.Default.HPlus;
            titrationdatastorage.linethickness = Properties.Settings.Default.linethickness;
            titrationdatastorage.interceptlabelstext = Properties.Settings.Default.interceptlabelstext;
            titrationdatastorage.interceptlabelssize = Properties.Settings.Default.interceptlabelssiz;
            titrationdatastorage.xaxisgraphsize = Properties.Settings.Default.xaxisgraphsize;
            titrationdatastorage.yaxisgraphsize = Properties.Settings.Default.yaxisgraphsize;
            titrationdatastorage.xaxislabeltext = Properties.Settings.Default.xaxislabeltext;
            titrationdatastorage.yaxislabeltext = Properties.Settings.Default.yaxislabeltext;

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

        public void ChangeSeries()
        {
            if (titrationdatastorage.grapheddata == true)
            {
                addeddata.PhDat.BorderWidth = titrationdatastorage.linethickness;
            }


            if (titrationdatastorage.graphderiv == true)
            {
                addeddata.PhDeriv.BorderWidth = titrationdatastorage.linethickness;

                addeddata.PhSecondDeriv.BorderWidth = titrationdatastorage.linethickness;

                addeddata.importantpoints.Font = new System.Drawing.Font(titrationdatastorage.interceptlabelstext, titrationdatastorage.interceptlabelssize, System.Drawing.FontStyle.Bold);
            }



        }

        private void findpython()
        {
            String username = Environment.UserName;

            String pythondirectory = "C:\\Users\\" + username + "\\AppData\\Local\\Programs\\Python\\";

            String[] pythondirectories = Directory.GetDirectories(pythondirectory);

            String StoredPythonEXEdirectory = "";

            foreach (string direct in pythondirectories)
            {
                var testingpythondirectory = direct + "\\python.exe";

                if (File.Exists(testingpythondirectory) == true)
                {
                    StoredPythonEXEdirectory = testingpythondirectory;
                    break;
                }
            }

            if (StoredPythonEXEdirectory == "")
            {
                MessageBox.Show("Python.exe could not be found");
            }
            else
            {
                MessageBox.Show("Your python directory is: " + StoredPythonEXEdirectory);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

            if (MolarRatio.Text == "")
            {
                MolarRatio.Text = "1:1";
            }

            if (dilutionfactor.Text == "")
            {
                dilutionfactor.Text = "1";
            }

            var importdata = new adddata();

            addeddata = importdata;

            chart1.Series.Clear();

            if (titrationdatastorage.titrationstorage == null)
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

            if (titrationdatastorage.solvemethod == "Automatic")
            {
                try
                {
                    importdata.findgreatest();

                }
                catch (Exception)
                {
                    MessageBox.Show("Insufficient data points. Adjust the peak sensitivity, or try switching to the manual range mode.", "Error: Insufficient Datapoints", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    goto Finish;
                }
            }
            else if (titrationdatastorage.solvemethod == "Manual Range")
            {
                //var maxvolume = importdata.getmaxvolume();

                if (maxvolume < titrationdatastorage.rangeone || maxvolume < titrationdatastorage.rangetwo)
                {
                    MessageBox.Show("Your chosen value for the " + titrationdatastorage.rangetype.ToLower() + " range exceeds the maximum value. An automatic value was assigned for this analysis.", "Error: Manual Input Exceeded Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (titrationdatastorage.hplus == 2)
                    {
                        titrationdatastorage.rangeone = maxvolume / 2;
                        Properties.Settings.Default.Range1 = maxvolume / 2;
                    }
                    else if (titrationdatastorage.hplus == 3)
                    {
                        titrationdatastorage.rangeone = maxvolume / 3;
                        Properties.Settings.Default.Range1 = maxvolume / 3;
                        titrationdatastorage.rangetwo = (maxvolume / 3) * 2;
                        Properties.Settings.Default.Range2 = (maxvolume / 3) * 2;
                    }
                }
                if (titrationdatastorage.rangeone == 0 || titrationdatastorage.rangetwo == 0)
                {
                    MessageBox.Show("Non-zero numbers are needed for the manual range calculation mode. An automatic value was assigned for this analysis.", "Error: Manual Input With 0 As Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (titrationdatastorage.hplus == 2)
                    {
                        titrationdatastorage.rangeone = maxvolume / 2;
                        Properties.Settings.Default.Range1 = maxvolume / 2;
                    }
                    else if (titrationdatastorage.hplus == 3)
                    {
                        titrationdatastorage.rangeone = maxvolume / 3;
                        Properties.Settings.Default.Range1 = maxvolume / 3;
                        titrationdatastorage.rangetwo = (maxvolume / 3) * 2;
                        Properties.Settings.Default.Range2 = (maxvolume / 3) * 2;
                    }
                }
                importdata.FindGreatestManual();
            }

            chart1.Series.Add(importdata.AddPoints());

            ChangeSeries();

            for (int i = 0; i < titrationdatastorage.hplus; i++)
            {
                Equivalence.Items.Add(Convert.ToString(i + 1) + "# " + Convert.ToString(Math.Round(importdata.equivalencepoints[i], 4)) + "mL, " + Convert.ToString(Math.Round(importdata.equivalencepointPH[i], 4)));
                PKA.Items.Add(Convert.ToString(i + 1) + "# " + Convert.ToString(importdata.PKavalues[i]));
            }

            Equivalence.Text = Convert.ToString(Math.Round(importdata.equivalencepoints[0], 4)) + "mL," + Convert.ToString(Math.Round(importdata.equivalencepointPH[0], 4));
            PKA.Text = Convert.ToString(importdata.PKavalues[0]);

            var unkownaciddetermin = new unkownacid(titrationdatastorage.hplus, titrationdatastorage.isbase);

            titrationdatastorage.pkavalues = unkownaciddetermin.acidorbasevalues;

            unkownacid.Text = unkownaciddetermin.DetermineUnkown(titrationdatastorage.unkown, titrationdatastorage.hplus) + " (" + Convert.ToString(unkownaciddetermin.percentmatch) + "%) match";

            var concentrationdetermin = new concentration();

            int concentrationnum = 1;

            try
            {
                foreach (var equiv in importdata.equivalencepoints)
                {
                    if (Concknown.Checked == false)
                    {
                        TitConc.Text = Convert.ToString(Math.Round(concentrationdetermin.TitrantConcentration(Molarmass.Text, mass.Text, Volumetit.Text), 4));
                        Concentration.Items.Add(concentrationnum + "# " + Convert.ToString(concentrationdetermin.ReturnConcentration(equiv, TitConc.Text, MolarRatio.Text, volumeanal.Text, dilutionfactor.Text)));
                        concentrationnum++;
                    }
                    else if (Concknown.Checked == true)
                    {
                        Concentration.Items.Add(concentrationnum + "# " + Convert.ToString(concentrationdetermin.ReturnConcentration(equiv, TitConc.Text, MolarRatio.Text, volumeanal.Text, dilutionfactor.Text)));
                        concentrationnum++;
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Not all the proper fields are filled out in the correct format", "Error: Failure to Compute Concentration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Concentration.Text = Convert.ToString(Math.Round(concentrationdetermin.ReturnConcentration(importdata.equivalencepoints[0], TitConc.Text, MolarRatio.Text, volumeanal.Text, dilutionfactor.Text), 4));



            importdata.DataStore();

            titrationdatastorage.a_vol_Global = Convert.ToDouble(volumeanal.Text);
            titrationdatastorage.a_conc_Global = Convert.ToDouble(Concentration.Text);
            titrationdatastorage.t_conc_Global = Convert.ToDouble(TitConc.Text);

            Derivcheck.Checked = true;
            Interceptpoints.Checked = true;
            derivative2.Checked = true;
            Simulate.Enabled = true;
            Simulate.ForeColor = Color.Black;

        Finish:;


        }

        private void Import(object sender, EventArgs e)
        {
            Equivalence.Items.Clear();
            PKA.Items.Clear();
            Concentration.Items.Clear();

            Equivalence.Text = "";
            PKA.Text = "";
            Concentration.Text = "";
            unkownacid.Text = "";

            var importdata = new adddata();

            addeddata = importdata;

            importdata.importandstore();



            if (importdata.finishprocessing == true)
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

            if (importdata.finishprocessing == true)
            {
                goto Finish;
            }
            else
            {
                chart1.Series.Add(importdata.Graphdata());
            }


            chart1.ChartAreas[0].RecalculateAxesScale();

            Titrationcheck.Checked = true;

        Finish:
            if (importdata.finishprocessing == true)
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
                sw.WriteLine("Unkown " + acidbase + "Concentration: " + conc.ToString() + "mol/L" + "\n");
            }

            foreach (var pka in PKA.Items)
            {
                sw.WriteLine("Unkown " + acidbase + " " + pkapkb + ": " + pka.ToString() + "\n");
            }

            sw.WriteLine("Unkown " + acidbase + ": " + unkownacid.Text + "\n");
            sw.WriteLine("Volume(mL),PH,Y',Y''");

            foreach (string data in titrationdatastorage.completedataset)
            {
                sw.WriteLine(data);
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

            gfx.DrawString("------//Titrant//------", fontcaption, XBrushes.Black, new XRect(indent, spacing, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Molecule: " + formula.Text, font, XBrushes.Black, new XRect(indent, spacing * 2, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Molar Mass: " + Molarmass.Text + "m/z", font, XBrushes.Black, new XRect(indent, spacing * 3, page.Width, page.Height), XStringFormats.TopLeft);
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
                gfx.DrawString("Unkown " + acidbase + " Concentration: " + conc.ToString() + "mol/L", font, XBrushes.Black, new XRect(indent, spacing * pagesize, page.Width, page.Height), XStringFormats.TopLeft);
                pagesize++;
            }

            foreach (var pka in PKA.Items)
            {
                gfx.DrawString("Unkown " + acidbase + " " + pkapkb + ": " + pka.ToString(), font, XBrushes.Black, new XRect(indent, spacing * pagesize, page.Width, page.Height), XStringFormats.TopLeft);
                pagesize++;
            }

            gfx.DrawString("Unkown " + acidbase + ": " + unkownacid.Text, font, XBrushes.Black, new XRect(indent, spacing * (pagesize + 1), page.Width, page.Height), XStringFormats.TopLeft);

            chart1.SaveImage(directory + "\\tempchart.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);

            XImage graph = XImage.FromFile(directory + "\\tempchart.png");

            var aspectratio = graph.PointWidth / page.Width;

            gfx.DrawImage(graph, 0, spacing * (pagesize + 5), graph.PointWidth / aspectratio, graph.PointHeight / aspectratio);

            gfx.DrawString("Volume (mL) vs. PH", GraphCaption, XBrushes.Black, new XRect(0, spacing * (pagesize + 4), page.Width, page.Height), XStringFormats.TopCenter);

            graph.Dispose();

            File.Delete(directory + "\\tempchart.png");

            PdfPage page2 = documentobject.AddPage();
            XGraphics gfx2 = XGraphics.FromPdfPage(page2);

            gfx2.DrawString("Volume(mL),PH,Y',Y''", fontcaption, XBrushes.Black, new XRect(indent, spacing, page.Width, page.Height), XStringFormats.TopLeft);

            var pagesize2 = 2;
            var pagenumber = 2;

            foreach (string data in titrationdatastorage.completedataset)
            {
                var maxpagesize = spacing * pagesize2;

                if (maxpagesize >= 800)
                {
                    var newpage = documentobject.AddPage();
                    gfx2 = XGraphics.FromPdfPage(newpage);
                    pagesize2 = 2;
                    pagenumber++;
                }

                gfx2.DrawString(data, font, XBrushes.Black, new XRect(indent, spacing * pagesize2, page.Width, page.Height), XStringFormats.TopLeft);
                pagesize2++;
            }

            documentobject.Save(filepath);

            Process.Start(filepath);

        }

        private void Export(object sender, EventArgs e)
        {
            SaveFileDialog exportdata = new SaveFileDialog();

            exportdata.Filter = "Text File|*.txt|PDF files (*.pdf)|*.pdf|Save Graph (*.png)|*.png";
            exportdata.Title = "Export Titration Data";


            if (exportdata.ShowDialog() == DialogResult.OK)
            {
                var filename = exportdata.FileName;
                var fileextension = Path.GetExtension(filename);
                var fullfilepath = Path.GetFullPath(filename);
                var filepath = Path.GetDirectoryName(filename);


                exportdata.CheckFileExists = true;

                if (fileextension == ".txt")
                {
                    using (StreamWriter sw = new StreamWriter(exportdata.FileName))
                    {
                        Textexport(sw);
                    }
                }
                else if (fileextension == ".pdf")
                {
                    PdfDocument titrationdatasheet = new PdfDocument();
                    PDFexporter(titrationdatasheet, fullfilepath, filepath);
                }
                else if (fileextension == ".png")
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
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void knownconcentrationcheck(object sender, EventArgs e)
        {
            mass.Text = "";
            Volumetit.Text = "";
            TitConc.Text = "";

            if (Concknown.Checked == true)
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
                Hplus.Text = "OH-";
                PkaLabel.Text = "pKb";
                acidbase = "Base";
                pkapkb = "pKb";
                unkownacidlabel.Text = "Unkown Base";
                titrationdatastorage.isbase = true;
            }
            else
            {
                Hplus.Text = "H+";
                PkaLabel.Text = "pKa";
                acidbase = "Acid";
                pkapkb = "pKa";
                unkownacidlabel.Text = "Unkown Acid";
                titrationdatastorage.isbase = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings settingsform = new Settings(this);
            settingsform.hplustrans += new EventHandler(Proton_DataAvailable);
            settingsform.Show();
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
                System.Diagnostics.Process.Start(Application.StartupPath + "\\OpenTitration V1 User Manual.pdf");
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
        }

        private void Formula_TextChanged(object sender, EventArgs e)
        {
            Molarmass.Text = "";
        }

        private void Simulation(object sender, EventArgs e)
        {
            SimulatedSeries.Checked = true;
            SimulatedSeries.Enabled = true;
            SimulatedSeries.ForeColor = Color.Black;

            // Variables for titrant and analyte being base or acid
            bool a_acidic = !titrationdatastorage.isbase;
            bool t_acidic = titrationdatastorage.isbase;

            //string a_pK = "5.2,8.9";
            //collected pKa variables for unkown. Only will work if analysis of regular titration data has been completed.
            string a_pK = titrationdatastorage.pkavalues;

            //will have to be taken from internal dictionary
            string t_pK = "-1";

            bool a_strong = false; //how would you like to determine whether the analyte is strong or not? Right now there is no option for it.
            bool t_strong = titrationdatastorage.StrongAcidorBase;

            //The data needed will only be loaded once the titration data of the origonal sample
            //Has been successfully analyzed.

            double a_vol = titrationdatastorage.a_vol_Global;
            double a_conc = titrationdatastorage.a_conc_Global;
            double t_conc = titrationdatastorage.t_conc_Global;

            //Here is the volume that the simulated data should be generated to. From 0 to the max
            //Of the origonal titration data.

            double simulationvolume = titrationdatastorage.maxvolume;

            //Here is a setting that allows you to set what data points are calculated for the simulator
            //Are you okay with adding this, or is this too much work?

            double resolution = titrationdatastorage.resolution;


            ProcessStartInfo start = new ProcessStartInfo();


            // Create Process Info
            // TODO The filename needs to be the directory of python.exe
            // Can be found in python_env\Scripts\python.exe
            // Needs the full directory, not just the filename

            String pythonfilepath = Application.StartupPath + @"\python_env\Scripts\python.exe";

            // Because this is going into an install filepath with the stand alone installer
            // Every file needs to be in the release directory
            // I will have to figure out how to transfer many files at once though

            start.FileName = titrationdatastorage.pythonpath;


            // 2) Provide script and arguments
            // TODO var script should be the directory for script.py
            // Needs the full directory, not just the filename
            var script = Application.StartupPath + @"script.py";
            start.Arguments = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", script, a_acidic, t_acidic, a_pK, t_pK, a_strong, t_strong, a_vol, a_conc, t_conc);

            // 3) Process configuration
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;

            // 4) Execute process and get output
            using (Process process = Process.Start(start))
            {
                // Get the data from the printed output of the script.py
                var results = process.StandardOutput.ReadToEnd();

                // Split the printed statements by the newline separating them. Also remove all square brackets and spaces
                string[] split_results = results.Split(new[] { '\n' }, StringSplitOptions.None);
                var data_list = new List<string> { };
                foreach (string item in split_results)
                {
                    data_list.Add(item.Trim(new Char[] { ']', '[', ' ', '\r' }).Trim());
                }

                // Remove the third item in the list, which is just an null value
                data_list.RemoveAt(2);

                // Turn the block strings into lists of strings
                string[] simPhStr = data_list[0].Split(new[] { ',' }, StringSplitOptions.None);
                string[] simVolStr = data_list[1].Split(new[] { ',' }, StringSplitOptions.None);

                var simPhLs = new List<double> { };
                var simVolLs = new List<double> { };

                // Convert the substrings in each list to doubles
                foreach (string item in simPhStr)
                {
                    simPhLs.Add(double.Parse(item.Trim()));
                }

                foreach (string item in simVolStr)
                {
                    simVolLs.Add(double.Parse(item.Trim()));
                }
                MessageBox.Show(simVolLs[0].ToString());
                // simVolLs and simPhLs are the Volumes an pH values for the simulated titration
                // They are trimmed to be representative of the whole titration, not the range the user set.
            }
        }
    }
}
