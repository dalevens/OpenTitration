using System;
using System.Windows.Forms;

namespace Titration_Analyzer
{
    public partial class AcidSelect : Form
    {
        public Form1 mainform;

        private int itemnumber;

        public AcidSelect(Form1 formpicked)
        {
            formpicked = mainform;

            InitializeComponent();

            selectitem.Enabled = false;

            foreach (string acid in Form1.titrationdatastorage.acidfind)
            {
                acidlist.Items.Add(acid);
            }

            acidlist.Text = Convert.ToString(Form1.titrationdatastorage.acidfind.Count) + " matches found";
        }

        private void acidadd(object sender, EventArgs e)
        {
            selectitem.Enabled = true;

            itemnumber = acidlist.SelectedIndex;

        }

        private void acidselect(object sender, EventArgs e)
        {
            Form1.titrationdatastorage.acidchosenname = acidlist.Text;

            Form1.titrationdatastorage.acidchosenpka = Form1.titrationdatastorage.acidpkavalues[itemnumber];

            this.Close();

        }
    }
}
