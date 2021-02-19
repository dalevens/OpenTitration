using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.IO;

namespace Titration_Analyzer
{
    public partial class Settings : Form
    {
        public Form1 titrationanal;

        public event EventHandler hplustrans;

        protected virtual void Onhplustrans(EventArgs e)
        {
            EventHandler eh = hplustrans;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        public string hplusstatetransfer
        {
            get
            {
                return hplusstate.Text;
            }
            set
            {
                hplusstate.Text = value;
            }
        }

        public Settings(Form1 opentitration)
        {
            
            titrationanal = opentitration;

            InitializeComponent();
            
            hplusstate.Text = Convert.ToString(Properties.Settings.Default.HPlus);

            //Simulator Settings

            millneg1.Text = Convert.ToString(Math.Round(Form1.titrationdatastorage.resolution, 2));
            millneg2.Text = Convert.ToString(Form1.titrationdatastorage.resolution - Math.Round(Form1.titrationdatastorage.resolution, 2));
            DirectoryPython.Text = Properties.Settings.Default.PythonPath;
            Default.Checked = !Properties.Settings.Default.CustomPythonPath;
            StrongAcid.Checked = Form1.titrationdatastorage.StrongAcidorBase;
            CustompKa.Checked = Form1.titrationdatastorage.custompKaselect;
            TargetRangeType.Text = Form1.titrationdatastorage.rangetype;
            SolveMethod.Text = Form1.titrationdatastorage.solvemethod;
            CustompKa.Text = Form1.titrationdatastorage.custompKa;

            if (SolveMethod.Text == "Automatic" )
            {
                TargetRangeType.Enabled = false;
                rangeone.Enabled = false;
                rangetwo.Enabled = false;
                rangeone.BackColor = Color.Beige;
                rangetwo.BackColor = Color.Beige;

                Customdatcheck.Checked = Properties.Settings.Default.ManualSensitivity;
                
                if(Customdatcheck.Checked == true)
                {
                    Sensitivitymanual.Enabled = true;
                }
                else
                {
                    Sensitivitymanual.Enabled = false;
                }
               
                Customdatcheck.Enabled = true;
                Sensitivitymanual.Enabled = true;
                Sensitivitymanual.BackColor = Color.White;
            }
            else if(SolveMethod.Text == "Manual Range")
            {
                TargetRangeType.Text = Properties.Settings.Default.RangeType;
                rangeone.Text = Convert.ToString(Properties.Settings.Default.Range1);
                TargetRangeType.Enabled = true;
                if(hplusstate.Text == "2")
                {
                    rangetwo.Enabled = false;
                    rangetwo.BackColor = Color.Beige;
                    rangetwo.Text = "";
                }
                else if (hplusstate.Text == "3")
                {
                    rangetwo.Enabled = true;
                    rangetwo.Text = Convert.ToString(Properties.Settings.Default.Range2);
                    rangetwo.BackColor = Color.White;
                }
                
                rangeone.Enabled = true;
                rangeone.Text = Convert.ToString(Properties.Settings.Default.Range1);
                rangeone.BackColor = Color.White;
               

            
            }

            if(Customdatcheck.Checked == false)
            {
                Sensitivitymanual.Enabled = false;

                Sensitivitymanual.BackColor = Color.Beige;

                Sensitivty.Text = Convert.ToString(Form1.titrationdatastorage.iterationsetting);
            }
            else if(Customdatcheck.Checked == true)
            {
                Sensitivitymanual.Enabled = true;

                Sensitivitymanual.BackColor = Color.White;

                Sensitivitymanual.Text = Convert.ToString(Form1.titrationdatastorage.iterationsetting);

                Sensitivty.Enabled = false;
            }

            

            InterceptFont.Items.Add(Form1.titrationdatastorage.interceptlabelstext);
            
            xaxisfont.Items.Add(Form1.titrationdatastorage.xaxislabeltext);
           
            yaxisfont.Items.Add(Form1.titrationdatastorage.yaxislabeltext);
            
            HeadingsText.Items.Add(Form1.titrationdatastorage.headerfont);
           
            ResultsText.Items.Add(Form1.titrationdatastorage.resultsfont);

            SolveMethod.Text = Convert.ToString(Form1.titrationdatastorage.solvemethod);
            LineThickness.Text = Convert.ToString(Form1.titrationdatastorage.linethickness);
            interceptSize.Text = Convert.ToString(Form1.titrationdatastorage.interceptlabelssize);
            InterceptFont.Text = Form1.titrationdatastorage.interceptlabelstext;
            xaxisfont.Text = Form1.titrationdatastorage.xaxislabeltext;
            xaxisSize.Text = Convert.ToString(Form1.titrationdatastorage.xaxisgraphsize);
            yaxisfont.Text = Form1.titrationdatastorage.yaxislabeltext;
            yaxisSize.Text = Convert.ToString(Form1.titrationdatastorage.yaxisgraphsize);
            HeadingSize.Text = Convert.ToString(Form1.titrationdatastorage.headersize);
            HeadingsText.Text = Form1.titrationdatastorage.headerfont;
            ResultsSize.Text = Convert.ToString(Form1.titrationdatastorage.resultssize);
            ResultsText.Text = Form1.titrationdatastorage.resultsfont;
            margins.Text = Convert.ToString(Form1.titrationdatastorage.margins);
            Spacingpdf.Text = Convert.ToString(Form1.titrationdatastorage.spacing);
            linewidth = linedemonstrator.Width;
            lineheight = linedemonstrator.Height/2;
            
        }

        Graphics g = null;
        private int linewidth, lineheight;

        private void Demonstratelinesize()
        {
            Pen linepen = new Pen(Color.Red);
            linepen.Width = Int32.Parse(LineThickness.Text);
            g = linedemonstrator.CreateGraphics();
            g.DrawLine(linepen, 0, lineheight, linewidth, lineheight);
        }

        private void Populate_Size(object sender, EventArgs e)
        {
            FontFamily[] installedfonts;

            var selectedcombobox = ((ComboBox)sender);

            InstalledFontCollection installedfontcollection = new InstalledFontCollection();

            installedfonts = installedfontcollection.Families;

            foreach(var font in installedfonts)
            {
                selectedcombobox.Items.Add(font.Name);
            }

            //selectedcombobox.Items.Remove(0);

        }

        private void DrawDemonstrationLine(object sender, PaintEventArgs e)
        {
            Demonstratelinesize();
        }

        private void LineThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            linedemonstrator.Refresh();
        }

        private void reset_settings(object sender, EventArgs e)
        {
            InterceptFont.Items.Clear();
            yaxisfont.Items.Clear();
            xaxisfont.Items.Clear();
            HeadingsText.Items.Clear();
            ResultsText.Items.Clear();

            millneg1.Text = "0.1";
            millneg2.Text = "0";

            StrongAcid.Checked = true;
            DirectoryPython.Text = Form1.titrationdatastorage.defaultpythonpath;
            Default.Checked = true;
            CustompKa.Checked = false;
            Sensitivitymanual.Text = "";
            TargetRangeType.Text = "Volume";
            CustompKa.Text = "";

            if (Form1.titrationdatastorage.titrationstorage.Count == 0)
            {
                rangeone.Text = "0";
                rangetwo.Text = "0";
            }
            else
            {
                var rangefind = new Form1.adddata();
                var maxvolume = rangefind.getmaxvolume();
                if(hplusstate.Text == "1")
                {
                    rangeone.Text = "0";
                    rangetwo.Text = "0";
                }
                else if(hplusstate.Text == "2")
                {
                    rangeone.Text = Convert.ToString(Math.Round(maxvolume / 2, 2));
                    rangetwo.Text = "0";
                }
                else if(hplusstate.Text == "3")
                {
                    rangeone.Text = Convert.ToString(Math.Round(maxvolume / 3, 2));
                    rangetwo.Text = Convert.ToString(Math.Round((maxvolume / 3)*2, 2));
                }
            }


            Customdatcheck.Checked = false;

            SolveMethod.Text = "Automatic";

            automatic_select();
            
            InterceptFont.Items.Add("Microsoft Sans Serif");
            yaxisfont.Items.Add("Microsoft Sans Serif");
            xaxisfont.Items.Add("Microsoft Sans Serif");
            HeadingsText.Items.Add("Microsoft Sans Serif");
            ResultsText.Items.Add("Microsoft Sans Serif");

            Sensitivty.Text = "2";
            LineThickness.Text = "3";
            interceptSize.Text = "8";
            InterceptFont.Text = "Microsoft Sans Serif";
            xaxisfont.Text = "Microsoft Sans Serif";
            xaxisSize.Text = "14";
            yaxisfont.Text = "Microsoft Sans Serif";
            yaxisSize.Text = "14";
            HeadingSize.Text = "12";
            HeadingsText.Text = "Microsoft Sans Serif";
            ResultsSize.Text = "10";
            ResultsText.Text = "Microsoft Sans Serif";
            margins.Text = "28";
            Spacingpdf.Text = "1";
        }

        private void Save_Settings(object sender, EventArgs e)
        {
            //Simulator Settings
            
            Form1.titrationdatastorage.resolution = Convert.ToDouble(millneg1.Text) + Convert.ToDouble(millneg2.Text);
            Properties.Settings.Default.Resolution = Convert.ToDouble(millneg1.Text) + Convert.ToDouble(millneg2.Text);
            Form1.titrationdatastorage.StrongAcidorBase = StrongAcid.Checked;
            Form1.titrationdatastorage.pythonpath = DirectoryPython.Text;
            Properties.Settings.Default.CustomPythonPath = Default.Checked;
            Properties.Settings.Default.CustompKaselect = CustompKa.Checked;
            Form1.titrationdatastorage.custompKaselect = CustompKa.Checked;
            Form1.titrationdatastorage.custompKa = CustompKa.Text;
            Properties.Settings.Default.CustompKa = CustompKa.Text;

            //Saves the settings so that it can be saved to the system
            //Calc Settings

            Properties.Settings.Default.HPlus = Convert.ToInt32(hplusstate.Text);
            Properties.Settings.Default.SolveMethod = SolveMethod.Text;
            Properties.Settings.Default.RangeType = TargetRangeType.Text;
            
            //Graph Settings
            Properties.Settings.Default.linethickness = Convert.ToInt32(LineThickness.Text);
            Properties.Settings.Default.interceptlabelstext = InterceptFont.Text;
            Properties.Settings.Default.interceptlabelssiz = Convert.ToInt32(interceptSize.Text);
            Properties.Settings.Default.xaxisgraphsize = Convert.ToInt32(xaxisSize.Text);
            Properties.Settings.Default.yaxisgraphsize = Convert.ToInt32(yaxisSize.Text);
            Properties.Settings.Default.xaxislabeltext = xaxisfont.Text;
            Properties.Settings.Default.yaxislabeltext = yaxisfont.Text;
            Properties.Settings.Default.ManualSensitivity = Customdatcheck.Checked;

            if (Customdatcheck.Checked == false)
            {
                Properties.Settings.Default.Iterationsetting = Convert.ToInt32(Sensitivty.Text);
            }
            else if(Customdatcheck.Checked == true)
            {
                try
                {
                    Properties.Settings.Default.Iterationsetting = Convert.ToInt32(Sensitivitymanual.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("This field requires an integer", "Error: Not an Integer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Sensitivty.Text = "2";
                    Properties.Settings.Default.Iterationsetting = Convert.ToInt32(Sensitivty.Text);
      
                }
            }
            
            //PDF settings
            Properties.Settings.Default.margins = Convert.ToInt32(margins.Text);
            Properties.Settings.Default.spacing = Convert.ToDouble(Spacingpdf.Text);
            Properties.Settings.Default.headersize = Convert.ToInt32(HeadingSize.Text);
            Properties.Settings.Default.headerfont = HeadingsText.Text;
            Properties.Settings.Default.resultsfont = ResultsText.Text;
            Properties.Settings.Default.resultssize = Convert.ToInt32(ResultsSize.Text);

            //Changes the settings in the application
            //Calc Settings
            Form1.titrationdatastorage.hplus = Convert.ToInt32(hplusstate.Text);
            Form1.titrationdatastorage.solvemethod = SolveMethod.Text;
            Form1.titrationdatastorage.rangetype = TargetRangeType.Text;

            if (rangeone.Text == "")
            {

            }
            else
            {
                try
                {
                    Form1.titrationdatastorage.rangeone = Convert.ToDouble(rangeone.Text);
                    Properties.Settings.Default.Range1 = Convert.ToDouble(rangeone.Text);
                }
                catch (Exception)
                {
                    Properties.Settings.Default.Range1 = 0;
                    Form1.titrationdatastorage.rangeone = 0;
                    rangeone.Text = "0";
                }
            }
            if (rangetwo.Text == "")
            {

            }
            else
            {
                try
                {
                    Form1.titrationdatastorage.rangetwo = Convert.ToDouble(rangeone.Text);
                    Properties.Settings.Default.Range2 = Convert.ToDouble(rangetwo.Text);
                }
                catch (Exception)
                {
                    Form1.titrationdatastorage.rangetwo = 0;
                    Properties.Settings.Default.Range2 = 0;
                    rangetwo.Text = "0";
                }
            }

            Properties.Settings.Default.Save();

            //Chart settings
            Form1.titrationdatastorage.linethickness = Convert.ToInt32(LineThickness.Text);
            Form1.titrationdatastorage.interceptlabelstext = InterceptFont.Text;
            Form1.titrationdatastorage.interceptlabelssize = Convert.ToInt32(interceptSize.Text);
            Form1.titrationdatastorage.xaxisgraphsize = Convert.ToInt32(xaxisSize.Text);
            Form1.titrationdatastorage.yaxisgraphsize = Convert.ToInt32(yaxisSize.Text);
            Form1.titrationdatastorage.xaxislabeltext = xaxisfont.Text;
            Form1.titrationdatastorage.yaxislabeltext = yaxisfont.Text;
            
            if(Customdatcheck.Checked == false)
            {
                Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivty.Text);
            }
            else if(Customdatcheck.Checked == true)
            {
                try
                {
                    Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivitymanual.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("This field requires an integer", "Error: Not an Integer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivty.Text);
                    throw;
                }
            }
            

            //PDF settings
            Form1.titrationdatastorage.margins = Convert.ToInt32(margins.Text);
            Form1.titrationdatastorage.spacing = Convert.ToDouble(Spacingpdf.Text);
            Form1.titrationdatastorage.headersize = Convert.ToInt32(HeadingSize.Text);
            Form1.titrationdatastorage.headerfont = HeadingsText.Text;
            Form1.titrationdatastorage.resultsfont = ResultsText.Text;
            Form1.titrationdatastorage.resultssize = Convert.ToInt32(ResultsSize.Text);
        }

        private void Customdatcheck_CheckedChanged(object sender, EventArgs e)
        {
            if(Customdatcheck.Checked == true)
            {
                Sensitivty.Enabled = false;
                Sensitivitymanual.Enabled = true;
                Sensitivitymanual.BackColor = Color.White;
            }
            else if(Customdatcheck.Checked == false)
            {
                Sensitivty.Enabled = true;
                Sensitivitymanual.Enabled = false;
                Sensitivitymanual.BackColor = Color.Beige;
            }
        }

        private void automatic_select()
        {
            TargetRangeType.Enabled = false;
            rangeone.Enabled = false;
            rangetwo.Enabled = false;
            rangeone.BackColor = Color.Beige;
            rangetwo.BackColor = Color.Beige;

            Sensitivty.Enabled = true;
            Customdatcheck.Enabled = true;
            Sensitivitymanual.Enabled = false;
            Sensitivitymanual.BackColor = Color.White;
        }

        private void change_method(object sender, EventArgs e)
        {
            if (SolveMethod.Text == "Automatic")
            {
                automatic_select();
            }
            else if(SolveMethod.Text == "Manual Range" && hplusstate.Text == "1")
            {
                SolveMethod.Text = "Automatic";
                MessageBox.Show("Manual Range can only be used for polyprotic substances");
            }
            else
            {
                TargetRangeType.Text = Properties.Settings.Default.RangeType;

                TargetRangeType.Enabled = true;

                rangeone.Enabled = true;

                if (hplusstate.Text == "3")
                {
                    rangetwo.Enabled = true;
                    rangetwo.BackColor = Color.White;
                }
                
                rangeone.BackColor = Color.White;

                Sensitivitymanual.Enabled = false;
                Sensitivty.Enabled = false;
                Customdatcheck.Enabled = false;
                Sensitivitymanual.Enabled = false;
                Sensitivitymanual.BackColor = Color.Beige;
            }
        }

        private void Change_Protination(object sender, EventArgs e)
        {
            //Onhplustrans(null);

            if (hplusstate.Text == "1" && SolveMethod.Text == "Manual Range")
            {
                SolveMethod.Text = "Automatic";
                MessageBox.Show("Manual Range can only be used for polyprotic substances");
                automatic_select();
            }
            else if(hplusstate.Text == "2" && SolveMethod.Text == "Manual Range")
            {
                TargetRangeType.Enabled = true;
                rangeone.Enabled = true;
                rangeone.BackColor = Color.White;
                rangetwo.Enabled = false;
                rangetwo.BackColor = Color.Beige;

                Sensitivitymanual.Enabled = false;
                Sensitivty.Enabled = false;
                Customdatcheck.Enabled = false;
                Sensitivitymanual.Enabled = false;
                Sensitivitymanual.BackColor = Color.Beige;

            }
            else if(hplusstate.Text == "3" && SolveMethod.Text == "Manual Range")
            {
                TargetRangeType.Enabled = true;
                rangeone.Enabled = true;
                rangeone.BackColor = Color.White;
                rangetwo.Enabled = true;
                rangetwo.BackColor = Color.White;

                Sensitivitymanual.Enabled = false;
                Sensitivty.Enabled = false;
                Customdatcheck.Enabled = false;
                Sensitivitymanual.Enabled = false;
                Sensitivitymanual.BackColor = Color.Beige;
            }

        }

        private void Protination_changevalue(object sender, EventArgs e)
        {
            Onhplustrans(null);
        }

        private void SolveMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hplusstate.Text == "1")
            {
                Properties.Settings.Default.SolveMethod = "Automatic";
                Sensitivty.Text = Convert.ToString(Properties.Settings.Default.Iterationsetting);
                SolveMethod.Text = "Automatic";

                if (Properties.Settings.Default.ManualSensitivity == false)
                {
                    Customdatcheck.Checked = false;
                    Sensitivitymanual.Enabled = false;
                    Sensitivitymanual.BackColor = Color.Beige;
                }
                else
                {
                    Customdatcheck.Checked = true;
                    Sensitivitymanual.Enabled = true;
                    Sensitivitymanual.BackColor = Color.White;
                }

            }
            else if(Customdatcheck.Checked == false)
            {
                Sensitivitymanual.BackColor = Color.Beige;
            }
        }

        private void Sensitivty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SolveMethod.Text == "Manual Range")
            {
                Customdatcheck.Enabled = false;
                Sensitivty.Enabled = false;
            }
        }

        private void Change_Directory(object sender, MouseEventArgs e)
        {

            OpenFileDialog findpythonexe = new OpenFileDialog();

            using (findpythonexe)
            {
                findpythonexe.InitialDirectory = @"C:\";
                //findpythonexe.Filter = "PDF files (*.pdf)|*.pdf";
                findpythonexe.RestoreDirectory = true;


                if (findpythonexe.ShowDialog() == DialogResult.OK)
                {
                    var filename = findpythonexe.FileName;

                    if(filename != "python.exe")
                    {
                        MessageBox.Show("Python must be selected");
                    }
                    else
                    {
                        var fullfilepath = Path.GetFullPath(filename);
                        Default.Checked = false;
                        Default.Enabled = true;
                        DirectoryPython.Text = fullfilepath;
                    }
                   
                }
                else
                {

                }
            }
        }

        private void Select_Custom_pKa(object sender, EventArgs e)
        {
            if(CustompKa.Checked == true)
            {
                pKa1.Enabled = true;
                pKa1.BackColor = Color.White;
            }
            else
            {
                pKa1.Enabled = false;
                pKa1.BackColor = Color.Beige;
            }
        }

        private void Default_CheckStateChanged(object sender, EventArgs e)
        {
            DirectoryPython.Text = Form1.titrationdatastorage.defaultpythonpath;
            Default.Enabled = false;
        }

        private void change_settings(object sender, EventArgs e)
        {
            //Simulator Settings
            //Properties.Def
            Form1.titrationdatastorage.resolution = Convert.ToDouble(millneg1.Text) + Convert.ToDouble(millneg2.Text);
            Form1.titrationdatastorage.StrongAcidorBase = StrongAcid.Checked;
            Form1.titrationdatastorage.pythonpath = DirectoryPython.Text;
            Form1.titrationdatastorage.custompKaselect = CustompKa.Checked;
            Form1.titrationdatastorage.custompKa = CustompKa.Text;

            //Calc Settings
            Properties.Settings.Default.SolveMethod = SolveMethod.Text;
            Form1.titrationdatastorage.hplus = Convert.ToInt32(hplusstate.Text);
            Form1.titrationdatastorage.solvemethod = SolveMethod.Text;
            Form1.titrationdatastorage.rangetype = TargetRangeType.Text;
            

            if (rangeone.Text == "")
            {

            }
            else
            {
                try
                {
                    Form1.titrationdatastorage.rangeone = Convert.ToDouble(rangeone.Text);
                }
                catch (Exception)
                {
                    Form1.titrationdatastorage.rangeone = 0;
                    rangeone.Text = "0";
                }
            }
            if(rangetwo.Text == "")
            {

            }
            else
            {
                try
                {
                    Form1.titrationdatastorage.rangetwo = Convert.ToDouble(rangeone.Text);
                }
                catch (Exception)
                {
                    Form1.titrationdatastorage.rangetwo = 0;
                    rangetwo.Text = "0";
                }
            }
           

            //Chart settings
            Form1.titrationdatastorage.linethickness = Convert.ToInt32(LineThickness.Text);
            Form1.titrationdatastorage.interceptlabelstext = InterceptFont.Text;
            Form1.titrationdatastorage.interceptlabelssize = Convert.ToInt32(interceptSize.Text);
            Form1.titrationdatastorage.xaxisgraphsize = Convert.ToInt32(xaxisSize.Text);
            Form1.titrationdatastorage.yaxisgraphsize = Convert.ToInt32(yaxisSize.Text);
            Form1.titrationdatastorage.xaxislabeltext = xaxisfont.Text;
            Form1.titrationdatastorage.yaxislabeltext = yaxisfont.Text;

            if (Customdatcheck.Checked == false)
            {
                Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivty.Text);
            }
            else if (Customdatcheck.Checked == true)
            {
                try
                {
                    Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivitymanual.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("This field requires an integer", "Error: Not an Integer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivty.Text);
                    throw;
                }
            }

            //PDF settings
            Form1.titrationdatastorage.margins = Convert.ToInt32(margins.Text);
            Form1.titrationdatastorage.spacing = Convert.ToDouble(Spacingpdf.Text);
            Form1.titrationdatastorage.headersize = Convert.ToInt32(HeadingSize.Text);
            Form1.titrationdatastorage.headerfont = HeadingsText.Text;
            Form1.titrationdatastorage.resultsfont = ResultsText.Text;
            Form1.titrationdatastorage.resultssize = Convert.ToInt32(ResultsSize.Text);

            titrationanal.ChangeGraph();
            titrationanal.ChangeSeries();
        }
    }
}
