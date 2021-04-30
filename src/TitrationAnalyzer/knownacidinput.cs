using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Titration_Analyzer
{
    
    public partial class knownacidadd : Form
    {
        public Form1 mainform;
        public knownacidadd(Form1 formpicked)
        {
            mainform = formpicked;
            InitializeComponent();

            if (Form1.titrationdatastorage.isbase)
            {
                label1.Text = "Base Name";
                this.Text = "Base Select";
            }
            else
            {
                label1.Text = "Acid Name";
                this.Text = "Acid Select";
            }
        }

        private bool checkdata(string datainput)
        {
            var datacheck = datainput.Split(',');
            foreach(string pKavalue in datacheck)
            {
                double value = 0;
                bool datapointcheck = Double.TryParse(pKavalue, out value);
                if(datapointcheck == false)
                {
                    goto exitcheck;
                }

                if(value > 20)
                {
                    goto exitcheck;
                }
            }

            return true;

        exitcheck:
            {
                return false;
            }
        }

        private void DataInput_Click(object sender, EventArgs e)
        {
            if(acidname.Text == "")
            {
                MessageBox.Show("A name is required to input a custom acid", "Error: Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkdata(pKavalues.Text) == false) 
                {
                    MessageBox.Show("Please input your value in the correct format", "Error: Improper Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Form1.titrationdatastorage.customanalyteacid = acidname.Text;
                    Form1.titrationdatastorage.customanalyteacidpKa = pKavalues.Text;
                    mainform.customacidadd();
                    Close();
                }

            }
            

        }
    }
}
