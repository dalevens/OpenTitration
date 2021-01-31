using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Titration_Analyzer
{
    public partial class Settings : Form
    {
        public Form1 titrationanal;

        public Settings(Form1 opentitration)
        {

            titrationanal = opentitration;

            InitializeComponent();

            InterceptFont.Items.Add(Form1.titrationdatastorage.interceptlabelstext);

            xaxisfont.Items.Add(Form1.titrationdatastorage.xaxislabeltext);

            yaxisfont.Items.Add(Form1.titrationdatastorage.yaxislabeltext);

            HeadingsText.Items.Add(Form1.titrationdatastorage.headerfont);

            ResultsText.Items.Add(Form1.titrationdatastorage.resultsfont);


            Sensitivty.Text = Convert.ToString(Form1.titrationdatastorage.iterationsetting);
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

            foreach (var font in installedfonts)
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
            //Saves the settings so that it can be saved to the system
            //Graph Settings
            Properties.Settings.Default.linethickness = Convert.ToInt32(LineThickness.Text);
            Properties.Settings.Default.interceptlabelstext = InterceptFont.Text;
            Properties.Settings.Default.interceptlabelssiz = Convert.ToInt32(interceptSize.Text);
            Properties.Settings.Default.xaxisgraphsize = Convert.ToInt32(xaxisSize.Text);
            Properties.Settings.Default.yaxisgraphsize = Convert.ToInt32(yaxisSize.Text);
            Properties.Settings.Default.xaxislabeltext = xaxisfont.Text;
            Properties.Settings.Default.yaxislabeltext = yaxisfont.Text;
            Properties.Settings.Default.Iterationsetting = Convert.ToInt32(Sensitivty.Text);

            //PDF settings
            Properties.Settings.Default.margins = Convert.ToInt32(margins.Text);
            Properties.Settings.Default.spacing = Convert.ToDouble(Spacingpdf.Text);
            Properties.Settings.Default.headersize = Convert.ToInt32(HeadingSize.Text);
            Properties.Settings.Default.headerfont = HeadingsText.Text;
            Properties.Settings.Default.resultsfont = ResultsText.Text;
            Properties.Settings.Default.resultssize = Convert.ToInt32(ResultsSize.Text);

            Properties.Settings.Default.Save();

            //Changes the settings in the application
            //Chart settings
            Form1.titrationdatastorage.linethickness = Convert.ToInt32(LineThickness.Text);
            Form1.titrationdatastorage.interceptlabelstext = InterceptFont.Text;
            Form1.titrationdatastorage.interceptlabelssize = Convert.ToInt32(interceptSize.Text);
            Form1.titrationdatastorage.xaxisgraphsize = Convert.ToInt32(xaxisSize.Text);
            Form1.titrationdatastorage.yaxisgraphsize = Convert.ToInt32(yaxisSize.Text);
            Form1.titrationdatastorage.xaxislabeltext = xaxisfont.Text;
            Form1.titrationdatastorage.yaxislabeltext = yaxisfont.Text;
            Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivty.Text);

            //PDF settings
            Form1.titrationdatastorage.margins = Convert.ToInt32(margins.Text);
            Form1.titrationdatastorage.spacing = Convert.ToDouble(Spacingpdf.Text);
            Form1.titrationdatastorage.headersize = Convert.ToInt32(HeadingSize.Text);
            Form1.titrationdatastorage.headerfont = HeadingsText.Text;
            Form1.titrationdatastorage.resultsfont = ResultsText.Text;
            Form1.titrationdatastorage.resultssize = Convert.ToInt32(ResultsSize.Text);
        }

        private void change_settings(object sender, EventArgs e)
        {

            //Chart settings
            Form1.titrationdatastorage.linethickness = Convert.ToInt32(LineThickness.Text);
            Form1.titrationdatastorage.interceptlabelstext = InterceptFont.Text;
            Form1.titrationdatastorage.interceptlabelssize = Convert.ToInt32(interceptSize.Text);
            Form1.titrationdatastorage.xaxisgraphsize = Convert.ToInt32(xaxisSize.Text);
            Form1.titrationdatastorage.yaxisgraphsize = Convert.ToInt32(yaxisSize.Text);
            Form1.titrationdatastorage.xaxislabeltext = xaxisfont.Text;
            Form1.titrationdatastorage.yaxislabeltext = yaxisfont.Text;
            Form1.titrationdatastorage.iterationsetting = Convert.ToInt32(Sensitivty.Text);

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
