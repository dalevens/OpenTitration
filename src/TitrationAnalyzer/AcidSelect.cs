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

            if(Form1.titrationdatastorage.isbase == true)
            {
                label1.Text = "Select Your Acid";
            }
            else
            {
                label1.Text = "Select Your Base";
            }

            selectitem.Enabled = false;

            foreach (string acid in Form1.titrationdatastorage.acidfind)
            {
                acidlist.Items.Add(acid);
            }

            acidlist.Items.Add("No Match");

            acidlist.Text = Convert.ToString(Form1.titrationdatastorage.acidfind.Count) + " matches found";
        }

        private void acidadd(object sender, EventArgs e)
        {
            
            selectitem.Enabled = true;

            itemnumber = acidlist.SelectedIndex;

        }

        private void acidselect(object sender, EventArgs e)
        {
            if(itemnumber == Form1.titrationdatastorage.acidpkavalues.Count)
            {
                MessageBox.Show("As no match could be found, please manually input it in the 'Sim' section under settings", "Error: Failure to find titrant acid from formula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form1.titrationdatastorage.custompKaselect = true;
                Properties.Settings.Default.CustompKaselect = true;
                this.Close();
            }
            else
            {
                Form1.titrationdatastorage.acidchosenname = acidlist.Text;

                Form1.titrationdatastorage.acidchosenpka = Form1.titrationdatastorage.acidpkavalues[itemnumber];
                
                this.Close();
            }
            

           

        }
    }
}
