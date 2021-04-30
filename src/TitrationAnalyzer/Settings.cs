using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Reflection;

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

            startcode();
            
        }

        public Settings(Form1 opentitration, int tabcontrol)
            : base()
        {

            titrationanal = opentitration;

            InitializeComponent();

            startcode();

            this.Simulator.SelectTab(tabcontrol);
         
        }

        Graphics g = null;
        private int linewidth, lineheight;

        private void startcode()
        {
            

            hplusstate.Text = Convert.ToString(Properties.Settings.Default.HPlus);

            //Simulator Settings

            resolution.Text = Convert.ToString(Form1.titrationdatastorage.resolution);

            CustompKa.Checked = Form1.titrationdatastorage.custompKaselect;
            TargetRangeType.Text = Form1.titrationdatastorage.rangetype;
            SolveMethod.Text = Form1.titrationdatastorage.solvemethod;
            pKa1.Text = Form1.titrationdatastorage.custompKa;
            Customdatcheck.Checked = Form1.titrationdatastorage.customsensitivityselect;
            Temperature.Text = Convert.ToString(Form1.titrationdatastorage.temperature);

            if (SolveMethod.Text == "Automatic")
            {
                TargetRangeType.Enabled = false;
                rangeone.Enabled = false;
                rangetwo.Enabled = false;
                rangeone.BackColor = Color.Beige;
                rangetwo.BackColor = Color.Beige;

                Customdatcheck.Checked = Form1.titrationdatastorage.customsensitivityselect;

                if (Customdatcheck.Checked == true)
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
            else if (SolveMethod.Text == "Manual Range")
            {
                TargetRangeType.Text = Form1.titrationdatastorage.rangetype;
                rangeone.Text = Convert.ToString(Form1.titrationdatastorage.rangeone);
                TargetRangeType.Enabled = true;
                if (hplusstate.Text == "2")
                {
                    rangetwo.Enabled = false;
                    rangetwo.BackColor = Color.Beige;
                    rangetwo.Text = "";
                }
                else if (hplusstate.Text == "3")
                {
                    rangetwo.Enabled = true;
                    rangetwo.Text = Convert.ToString(Form1.titrationdatastorage.rangetwo);
                    rangetwo.BackColor = Color.White;
                }

                rangeone.Enabled = true;
                rangeone.Text = Convert.ToString(Form1.titrationdatastorage.rangeone);
                rangeone.BackColor = Color.White;

            }

            if (Customdatcheck.Checked == false)
            {
                Sensitivitymanual.Enabled = false;

                Sensitivitymanual.BackColor = Color.Beige;

                if(Form1.titrationdatastorage.iterationsetting < 10)
                {
                    Sensitivty.Text = "2";
                }

                Sensitivty.Text = Convert.ToString(Form1.titrationdatastorage.iterationsetting);
            }
            else if (Customdatcheck.Checked == true)
            {
                Sensitivitymanual.Enabled = true;

                Sensitivitymanual.BackColor = Color.White;

                Sensitivitymanual.Text = Convert.ToString(Form1.titrationdatastorage.iterationsetting);

                Sensitivty.Enabled = false;
            }

            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);

            foreach (PropertyInfo c in propInfoList)
            {
                if (Convert.ToString(c) == "Transparent")
                {

                }
                else
                {
                    this.TitrationColor.Items.Add(c.Name);
                    this.FirstDerivativeColor.Items.Add(c.Name);
                    this.SecondDerivativeColor.Items.Add(c.Name);
                    this.SimulatedColor.Items.Add(c.Name);
                }

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
            lineheight = linedemonstrator.Height / 2;
            TitrationColor.Text = Form1.titrationdatastorage.titrationcolor;
            FirstDerivativeColor.Text = Form1.titrationdatastorage.firstderivativecolor;
            SecondDerivativeColor.Text = Form1.titrationdatastorage.secondderivativecolor;
            SimulatedColor.Text = Form1.titrationdatastorage.simulationcolor;
            SimulatedStyle.Text = Form1.titrationdatastorage.simulatedstyle;
            TitrationStyle.Text = Form1.titrationdatastorage.titrationstyle;
            OneDerivStyle.Text = Form1.titrationdatastorage.firstderivstyle;
            TwoDerivStyle.Text = Form1.titrationdatastorage.secondderivstyle;
        }

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

            resolution.Text = "0.1";

            CustompKa.Checked = false;
            Sensitivitymanual.Text = "";
            TargetRangeType.Text = "Volume";
            pKa1.Text = "";

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
            TitrationColor.Text = "Blue";
            FirstDerivativeColor.Text = "Orange";
            SecondDerivativeColor.Text = "Red";
            SimulatedColor.Text = "Fuchsia";
            TitrationStyle.Text = "Line";
            OneDerivStyle.Text = "Line";
            TwoDerivStyle.Text = "Line";
            SimulatedStyle.Text = "Line";
            Temperature.Text = "20";

        }

        private void Save_Settings(object sender, EventArgs e)
        {
            //Simulator Settings

            try
            {
                if (Convert.ToDouble(resolution.Text) < 0.02)
                {
                    resolution.Text = "0.02";
                    MessageBox.Show("The minimum value for resolution is 0.02.", "Error: Small resolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (Convert.ToDouble(resolution.Text) > 2)
                {
                    resolution.Text = "2";
                    MessageBox.Show("The maximum value for resolution is 2.", "Error: large resolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                resolution.Text = "0.01";
                MessageBox.Show("The resolution must be a value between 0.02 and 2", "Error: Improper Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (Convert.ToDouble(Temperature.Text) < 0)
                {
                    Temperature.Text = "0";
                    MessageBox.Show("The minimum value for temperature is 0C.", "Error: Low Temperature", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (Convert.ToDouble(Temperature.Text) > 300)
                {
                    Temperature.Text = "300";
                    MessageBox.Show("The maximum value for temperature is 300C.", "Error: High Temperature", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                Temperature.Text = "20";
                MessageBox.Show("The temperature must be a value between 0 and 300C", "Error: Improper Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Graph Settings

            if (Customdatcheck.Checked == true && Sensitivitymanual.Text == "")
            {
                MessageBox.Show("Sensitivity must have a value", "Error: Improper Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Sensitivitymanual.Text = "2";
            }
            else if(Customdatcheck.Checked == true && int.TryParse(Sensitivitymanual.Text, out int n) == false)
            {
                MessageBox.Show("Sensitivity must be an integer", "Error: Improper Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Sensitivitymanual.Text = "2";
            }
            else if(Customdatcheck.Checked == true && Convert.ToInt32(Sensitivitymanual.Text) < 1)
            {
                MessageBox.Show("Sensitivity must be greater or equal to one", "Error: Improper Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Sensitivitymanual.Text = "2";
            }

            Form1.titrationdatastorage.resolution = Convert.ToDouble(resolution.Text);
            Properties.Settings.Default.Resolution = Convert.ToDouble(resolution.Text);

            Form1.titrationdatastorage.temperature = Convert.ToDouble(Temperature.Text);
            Properties.Settings.Default.Temperature = Convert.ToDouble(Temperature.Text);

            Properties.Settings.Default.CustompKaselect = CustompKa.Checked;
            Form1.titrationdatastorage.custompKaselect = CustompKa.Checked;
            Form1.titrationdatastorage.custompKa = pKa1.Text;
            Properties.Settings.Default.CustompKa = pKa1.Text;

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
            Properties.Settings.Default.TitrationColor = TitrationColor.Text;
            Properties.Settings.Default.OneDerivColor = FirstDerivativeColor.Text;
            Properties.Settings.Default.TwoDerivColor = SecondDerivativeColor.Text;
            Properties.Settings.Default.SimulatorColor = SimulatedColor.Text;
            Properties.Settings.Default.TitrationStyle = TitrationStyle.Text;
            Properties.Settings.Default.OneDerivStyle = OneDerivStyle.Text;
            Properties.Settings.Default.TwoDerivStyle = TwoDerivStyle.Text;
            Properties.Settings.Default.SimulatedStyle = SimulatedStyle.Text;

            if (Customdatcheck.Checked == false)
            {
                Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivty.Text);
                Properties.Settings.Default.Iterationsetting = Convert.ToInt32(Sensitivty.Text);
            }
            else if (Customdatcheck.Checked == true)
            {
                Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivitymanual.Text);
                Properties.Settings.Default.Iterationsetting = Convert.ToInt32(Sensitivitymanual.Text);
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
                    Form1.titrationdatastorage.rangetwo = Convert.ToDouble(rangetwo.Text);
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
            Form1.titrationdatastorage.titrationcolor = TitrationColor.Text;
            Form1.titrationdatastorage.firstderivativecolor = FirstDerivativeColor.Text;
            Form1.titrationdatastorage.secondderivativecolor = SecondDerivativeColor.Text;
            Form1.titrationdatastorage.simulationcolor = SimulatedColor.Text;
            Form1.titrationdatastorage.titrationstyle = TitrationStyle.Text;
            Form1.titrationdatastorage.firstderivstyle = OneDerivStyle.Text;
            Form1.titrationdatastorage.secondderivstyle = TwoDerivStyle.Text;
            Form1.titrationdatastorage.simulatedstyle = SimulatedStyle.Text;

            //PDF settings
            Form1.titrationdatastorage.margins = Convert.ToInt32(margins.Text);
            Form1.titrationdatastorage.spacing = Convert.ToDouble(Spacingpdf.Text);
            Form1.titrationdatastorage.headersize = Convert.ToInt32(HeadingSize.Text);
            Form1.titrationdatastorage.headerfont = HeadingsText.Text;
            Form1.titrationdatastorage.resultsfont = ResultsText.Text;
            Form1.titrationdatastorage.resultssize = Convert.ToInt32(ResultsSize.Text);

            MessageBox.Show("Your settings have been succesfully saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                
                if(Sensitivty.Text == "")
                {
                    Sensitivty.Text = "2";
                }

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

            
            
        }

        private void TitrationColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5,
                                rect.Width - 10, rect.Height - 10);
            }
        }

        private void change_settings(object sender, EventArgs e)
        {
            //Simulator Settings

            try
            {
                if (Convert.ToDouble(resolution.Text) < 0.02)
                {
                    resolution.Text = "0.02";
                    MessageBox.Show("The minimum value for resolution is 0.02.", "Error: Small resolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (Convert.ToDouble(resolution.Text) > 2)
                {
                    resolution.Text = "2";
                    MessageBox.Show("The maximum value for resolution is 2.", "Error: large resolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                resolution.Text = "0.01";
                MessageBox.Show("The resolution must be a value between 0.02 and 2", "Error: Improper Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (Convert.ToDouble(Temperature.Text) < 0)
                {
                    Temperature.Text = "0";
                    MessageBox.Show("The minimum value for temperature is 0C.", "Error: Low Temperature", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (Convert.ToDouble(Temperature.Text) > 300)
                {
                    Temperature.Text = "300";
                    MessageBox.Show("The maximum value for temperature is 300C.", "Error: High Temperature", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                Temperature.Text = "20";
                MessageBox.Show("The temperature must be a value between 0 and 300C", "Error: Improper Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Form1.titrationdatastorage.resolution = Convert.ToDouble(resolution.Text);
            Form1.titrationdatastorage.temperature = Convert.ToDouble(Temperature.Text);
            Form1.titrationdatastorage.custompKaselect = CustompKa.Checked;
            Form1.titrationdatastorage.custompKa = pKa1.Text;

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
                    Form1.titrationdatastorage.rangetwo = Convert.ToDouble(rangetwo.Text);
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
            Form1.titrationdatastorage.titrationcolor = TitrationColor.Text;
            Form1.titrationdatastorage.firstderivativecolor = FirstDerivativeColor.Text;
            Form1.titrationdatastorage.secondderivativecolor = SecondDerivativeColor.Text;
            Form1.titrationdatastorage.simulationcolor = SimulatedColor.Text;
            Form1.titrationdatastorage.titrationstyle = TitrationStyle.Text;
            Form1.titrationdatastorage.firstderivstyle = OneDerivStyle.Text;
            Form1.titrationdatastorage.secondderivstyle = TwoDerivStyle.Text;
            Form1.titrationdatastorage.simulatedstyle = SimulatedStyle.Text;


            //Graph Settings

            if (Customdatcheck.Checked == true && Sensitivitymanual.Text == "")
            {
                MessageBox.Show("Sensitivity must have a value", "Error: Improper Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Sensitivitymanual.Text = "2";
            }
            else if (Customdatcheck.Checked == true && int.TryParse(Sensitivitymanual.Text, out int n) == false)
            {
                MessageBox.Show("Sensitivity must be an integer", "Error: Improper Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Sensitivitymanual.Text = "2";
            }
            else if (Customdatcheck.Checked == true && Convert.ToInt32(Sensitivitymanual.Text) < 1)
            {
                MessageBox.Show("Sensitivity must be greater or equal to one", "Error: Improper Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Sensitivitymanual.Text = "2";
            }

            if (Customdatcheck.Checked == false)
            {
                Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivty.Text);
            }
            else if (Customdatcheck.Checked == true)
            {
                    Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivitymanual.Text);
            }

            //PDF settings
            Form1.titrationdatastorage.margins = Convert.ToInt32(margins.Text);
            Form1.titrationdatastorage.spacing = Convert.ToDouble(Spacingpdf.Text);
            Form1.titrationdatastorage.headersize = Convert.ToInt32(HeadingSize.Text);
            Form1.titrationdatastorage.headerfont = HeadingsText.Text;
            Form1.titrationdatastorage.resultsfont = ResultsText.Text;
            Form1.titrationdatastorage.resultssize = Convert.ToInt32(ResultsSize.Text);

            titrationanal.change_graph_settings();

            MessageBox.Show("Your settings have been successfully applied!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
}
