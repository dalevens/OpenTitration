namespace Titration_Analyzer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Analyzebutton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.formula = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Molarmass = new System.Windows.Forms.TextBox();
            this.Derivcheck = new System.Windows.Forms.CheckBox();
            this.Interceptpoints = new System.Windows.Forms.CheckBox();
            this.Titrationcheck = new System.Windows.Forms.CheckBox();
            this.TitConc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PkaLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.unkownacidlabel = new System.Windows.Forms.Label();
            this.Equivalence = new System.Windows.Forms.ComboBox();
            this.PKA = new System.Windows.Forms.ComboBox();
            this.Concentration = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MolarRatio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.titrationdatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.Base = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dilutionfactor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.volumeanal = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.mass = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Concknown = new System.Windows.Forms.CheckBox();
            this.Volumetit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.derivative2 = new System.Windows.Forms.CheckBox();
            this.NormY1 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.NormY2 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.OffsetY2 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.hplusnum = new System.Windows.Forms.ComboBox();
            this.Hplus = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.Simulate = new System.Windows.Forms.Button();
            this.SimulatedSeries = new System.Windows.Forms.CheckBox();
            this.unkownacid = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.knownanal = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titrationdatBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Analyzebutton
            // 
            this.Analyzebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Analyzebutton.Location = new System.Drawing.Point(992, 466);
            this.Analyzebutton.Name = "Analyzebutton";
            this.Analyzebutton.Size = new System.Drawing.Size(184, 33);
            this.Analyzebutton.TabIndex = 0;
            this.Analyzebutton.Text = "Analyze";
            this.Analyzebutton.UseVisualStyleBackColor = true;
            this.Analyzebutton.Click += new System.EventHandler(this.analyze_click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(992, 544);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Export);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Formula";
            // 
            // formula
            // 
            this.formula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formula.Location = new System.Drawing.Point(6, 48);
            this.formula.Name = "formula";
            this.formula.Size = new System.Drawing.Size(108, 35);
            this.formula.TabIndex = 4;
            this.formula.TextChanged += new System.EventHandler(this.Formula_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(143, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "(g/mol)";
            // 
            // Molarmass
            // 
            this.Molarmass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Molarmass.Location = new System.Drawing.Point(129, 48);
            this.Molarmass.Name = "Molarmass";
            this.Molarmass.Size = new System.Drawing.Size(87, 35);
            this.Molarmass.TabIndex = 6;
            // 
            // Derivcheck
            // 
            this.Derivcheck.AutoSize = true;
            this.Derivcheck.Checked = true;
            this.Derivcheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Derivcheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Derivcheck.Location = new System.Drawing.Point(478, 13);
            this.Derivcheck.Name = "Derivcheck";
            this.Derivcheck.Size = new System.Drawing.Size(169, 29);
            this.Derivcheck.TabIndex = 7;
            this.Derivcheck.Text = "1st Derivative";
            this.Derivcheck.UseVisualStyleBackColor = true;
            this.Derivcheck.CheckedChanged += new System.EventHandler(this.Derivcheck_CheckedChanged);
            // 
            // Interceptpoints
            // 
            this.Interceptpoints.AutoSize = true;
            this.Interceptpoints.Checked = true;
            this.Interceptpoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Interceptpoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Interceptpoints.Location = new System.Drawing.Point(686, 24);
            this.Interceptpoints.Name = "Interceptpoints";
            this.Interceptpoints.Size = new System.Drawing.Size(133, 29);
            this.Interceptpoints.TabIndex = 8;
            this.Interceptpoints.Text = "Intercepts";
            this.Interceptpoints.UseVisualStyleBackColor = true;
            this.Interceptpoints.CheckedChanged += new System.EventHandler(this.InterceptCheck);
            // 
            // Titrationcheck
            // 
            this.Titrationcheck.AutoSize = true;
            this.Titrationcheck.Checked = true;
            this.Titrationcheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Titrationcheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titrationcheck.Location = new System.Drawing.Point(269, 24);
            this.Titrationcheck.Name = "Titrationcheck";
            this.Titrationcheck.Size = new System.Drawing.Size(181, 29);
            this.Titrationcheck.TabIndex = 9;
            this.Titrationcheck.Text = "Titration Curve";
            this.Titrationcheck.UseVisualStyleBackColor = true;
            this.Titrationcheck.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // TitConc
            // 
            this.TitConc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitConc.Location = new System.Drawing.Point(73, 261);
            this.TitConc.Name = "TitConc";
            this.TitConc.Size = new System.Drawing.Size(99, 35);
            this.TitConc.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(180, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Concentration (M)";
            // 
            // PkaLabel
            // 
            this.PkaLabel.AutoSize = true;
            this.PkaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PkaLabel.Location = new System.Drawing.Point(403, 35);
            this.PkaLabel.Name = "PkaLabel";
            this.PkaLabel.Size = new System.Drawing.Size(51, 25);
            this.PkaLabel.TabIndex = 15;
            this.PkaLabel.Text = "pKa";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.unkownacid);
            this.groupBox1.Controls.Add(this.unkownacidlabel);
            this.groupBox1.Controls.Add(this.Equivalence);
            this.groupBox1.Controls.Add(this.PKA);
            this.groupBox1.Controls.Add(this.Concentration);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.PkaLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(269, 458);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 120);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // unkownacidlabel
            // 
            this.unkownacidlabel.AutoSize = true;
            this.unkownacidlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unkownacidlabel.Location = new System.Drawing.Point(528, 33);
            this.unkownacidlabel.Name = "unkownacidlabel";
            this.unkownacidlabel.Size = new System.Drawing.Size(138, 25);
            this.unkownacidlabel.TabIndex = 40;
            this.unkownacidlabel.Text = "Unkown Acid";
            // 
            // Equivalence
            // 
            this.Equivalence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Equivalence.FormattingEnabled = true;
            this.Equivalence.Location = new System.Drawing.Point(18, 71);
            this.Equivalence.Name = "Equivalence";
            this.Equivalence.Size = new System.Drawing.Size(145, 33);
            this.Equivalence.TabIndex = 39;
            // 
            // PKA
            // 
            this.PKA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PKA.FormattingEnabled = true;
            this.PKA.Location = new System.Drawing.Point(364, 71);
            this.PKA.Name = "PKA";
            this.PKA.Size = new System.Drawing.Size(121, 33);
            this.PKA.TabIndex = 38;
            // 
            // Concentration
            // 
            this.Concentration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Concentration.FormattingEnabled = true;
            this.Concentration.Location = new System.Drawing.Point(198, 71);
            this.Concentration.Name = "Concentration";
            this.Concentration.Size = new System.Drawing.Size(121, 33);
            this.Concentration.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Equivalence";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Concentration (mol/L)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Molar Ratio";
            // 
            // MolarRatio
            // 
            this.MolarRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MolarRatio.Location = new System.Drawing.Point(45, 339);
            this.MolarRatio.Name = "MolarRatio";
            this.MolarRatio.Size = new System.Drawing.Size(81, 35);
            this.MolarRatio.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1009, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 50);
            this.button1.TabIndex = 19;
            this.button1.Text = "Import Data Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Import);
            // 
            // chart1
            // 
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.Title = "Volume (mL)";
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.Title = "PH";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.titrationdatBindingSource;
            legend1.BackColor = System.Drawing.Color.Silver;
            legend1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            legend1.Name = "Titration";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(269, 77);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(907, 375);
            this.chart1.TabIndex = 20;
            this.chart1.Text = "chart1";
            // 
            // titrationdatBindingSource
            // 
            this.titrationdatBindingSource.DataMember = "Titrationdat";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.knownanal);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.Base);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dilutionfactor);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.volumeanal);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 383);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 195);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Analyte";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(2, 57);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 20);
            this.label19.TabIndex = 29;
            this.label19.Text = "Base";
            // 
            // Base
            // 
            this.Base.AutoSize = true;
            this.Base.Location = new System.Drawing.Point(16, 32);
            this.Base.Name = "Base";
            this.Base.Size = new System.Drawing.Size(22, 21);
            this.Base.TabIndex = 29;
            this.Base.UseVisualStyleBackColor = true;
            this.Base.Click += new System.EventHandler(this.baseselect);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(55, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 25);
            this.label9.TabIndex = 28;
            this.label9.Text = "Dilution Factor";
            // 
            // dilutionfactor
            // 
            this.dilutionfactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dilutionfactor.Location = new System.Drawing.Point(61, 151);
            this.dilutionfactor.Name = "dilutionfactor";
            this.dilutionfactor.Size = new System.Drawing.Size(100, 35);
            this.dilutionfactor.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(66, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 25);
            this.label8.TabIndex = 26;
            this.label8.Text = "Volume (mL)";
            // 
            // volumeanal
            // 
            this.volumeanal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeanal.Location = new System.Drawing.Point(61, 65);
            this.volumeanal.Name = "volumeanal";
            this.volumeanal.Size = new System.Drawing.Size(101, 35);
            this.volumeanal.TabIndex = 25;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.mass);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.Concknown);
            this.groupBox3.Controls.Add(this.Volumetit);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.formula);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.Molarmass);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(232, 292);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Titrant";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(169, 269);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 20);
            this.label14.TabIndex = 28;
            this.label14.Text = "Known";
            // 
            // mass
            // 
            this.mass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mass.Location = new System.Drawing.Point(61, 113);
            this.mass.Name = "mass";
            this.mass.Size = new System.Drawing.Size(101, 35);
            this.mass.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(70, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 25);
            this.label11.TabIndex = 26;
            this.label11.Text = "Mass (g)";
            // 
            // Concknown
            // 
            this.Concknown.AutoSize = true;
            this.Concknown.Location = new System.Drawing.Point(189, 249);
            this.Concknown.Name = "Concknown";
            this.Concknown.Size = new System.Drawing.Size(22, 21);
            this.Concknown.TabIndex = 25;
            this.Concknown.UseVisualStyleBackColor = true;
            this.Concknown.CheckedChanged += new System.EventHandler(this.knownconcentrationcheck);
            // 
            // Volumetit
            // 
            this.Volumetit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volumetit.Location = new System.Drawing.Point(61, 179);
            this.Volumetit.Name = "Volumetit";
            this.Volumetit.Size = new System.Drawing.Size(99, 35);
            this.Volumetit.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(65, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 25);
            this.label10.TabIndex = 25;
            this.label10.Text = "Volume (mL)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(147, 335);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "Acid:Base";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(159, 356);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "Ex. 1:1";
            // 
            // derivative2
            // 
            this.derivative2.AutoSize = true;
            this.derivative2.Checked = true;
            this.derivative2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.derivative2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.derivative2.Location = new System.Drawing.Point(478, 42);
            this.derivative2.Name = "derivative2";
            this.derivative2.Size = new System.Drawing.Size(176, 29);
            this.derivative2.TabIndex = 28;
            this.derivative2.Text = "2nd Derivative";
            this.derivative2.UseVisualStyleBackColor = true;
            this.derivative2.CheckedChanged += new System.EventHandler(this.secondselect);
            // 
            // NormY1
            // 
            this.NormY1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NormY1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.NormY1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NormY1.FormattingEnabled = true;
            this.NormY1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.NormY1.Location = new System.Drawing.Point(1061, 252);
            this.NormY1.Name = "NormY1";
            this.NormY1.Size = new System.Drawing.Size(58, 33);
            this.NormY1.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Window;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1024, 224);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 25);
            this.label15.TabIndex = 29;
            this.label15.Text = "Normalize Y\'";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Window;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1024, 295);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 25);
            this.label16.TabIndex = 30;
            this.label16.Text = "Normalize Y\'\'";
            // 
            // NormY2
            // 
            this.NormY2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NormY2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.NormY2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NormY2.FormattingEnabled = true;
            this.NormY2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.NormY2.Location = new System.Drawing.Point(1061, 323);
            this.NormY2.Name = "NormY2";
            this.NormY2.Size = new System.Drawing.Size(58, 33);
            this.NormY2.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.Window;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1041, 369);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 25);
            this.label17.TabIndex = 32;
            this.label17.Text = "Offset Y\'\'";
            // 
            // OffsetY2
            // 
            this.OffsetY2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OffsetY2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OffsetY2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffsetY2.FormattingEnabled = true;
            this.OffsetY2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.OffsetY2.Location = new System.Drawing.Point(1061, 398);
            this.OffsetY2.Name = "OffsetY2";
            this.OffsetY2.Size = new System.Drawing.Size(58, 33);
            this.OffsetY2.TabIndex = 33;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(1009, 195);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(161, 251);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Graph Tools";
            // 
            // hplusnum
            // 
            this.hplusnum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hplusnum.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hplusnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hplusnum.FormattingEnabled = true;
            this.hplusnum.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.hplusnum.Location = new System.Drawing.Point(278, 412);
            this.hplusnum.Name = "hplusnum";
            this.hplusnum.Size = new System.Drawing.Size(58, 33);
            this.hplusnum.TabIndex = 35;
            this.hplusnum.SelectedIndexChanged += new System.EventHandler(this.change_protination);
            // 
            // Hplus
            // 
            this.Hplus.AutoSize = true;
            this.Hplus.BackColor = System.Drawing.SystemColors.Window;
            this.Hplus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hplus.Location = new System.Drawing.Point(291, 386);
            this.Hplus.Name = "Hplus";
            this.Hplus.Size = new System.Drawing.Size(40, 25);
            this.Hplus.TabIndex = 36;
            this.Hplus.Text = "H+";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(268, 56);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(76, 20);
            this.linkLabel1.TabIndex = 37;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Settings";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel1.MouseLeave += new System.EventHandler(this.linkLabel1_MouseLeave);
            this.linkLabel1.MouseHover += new System.EventHandler(this.linkLabel1_MouseHover);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(330, 56);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(46, 20);
            this.linkLabel2.TabIndex = 38;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Help";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Initiallize_Help);
            this.linkLabel2.MouseLeave += new System.EventHandler(this.linkLabel2_MouseLeave);
            this.linkLabel2.MouseHover += new System.EventHandler(this.linkLabel2_MouseHover);
            // 
            // Simulate
            // 
            this.Simulate.Enabled = false;
            this.Simulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Simulate.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Simulate.Location = new System.Drawing.Point(992, 505);
            this.Simulate.Name = "Simulate";
            this.Simulate.Size = new System.Drawing.Size(184, 33);
            this.Simulate.TabIndex = 39;
            this.Simulate.Text = "Simulate";
            this.Simulate.UseVisualStyleBackColor = true;
            this.Simulate.Click += new System.EventHandler(this.Simulation);
            // 
            // SimulatedSeries
            // 
            this.SimulatedSeries.AutoSize = true;
            this.SimulatedSeries.Enabled = false;
            this.SimulatedSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SimulatedSeries.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SimulatedSeries.Location = new System.Drawing.Point(850, 24);
            this.SimulatedSeries.Name = "SimulatedSeries";
            this.SimulatedSeries.Size = new System.Drawing.Size(134, 29);
            this.SimulatedSeries.TabIndex = 40;
            this.SimulatedSeries.Text = "Simulated";
            this.SimulatedSeries.UseVisualStyleBackColor = true;
            // 
            // unkownacid
            // 
            this.unkownacid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unkownacid.FormattingEnabled = true;
            this.unkownacid.Location = new System.Drawing.Point(517, 71);
            this.unkownacid.Name = "unkownacid";
            this.unkownacid.Size = new System.Drawing.Size(145, 33);
            this.unkownacid.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-4, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Known";
            // 
            // knownanal
            // 
            this.knownanal.AutoSize = true;
            this.knownanal.Location = new System.Drawing.Point(16, 88);
            this.knownanal.Name = "knownanal";
            this.knownanal.Size = new System.Drawing.Size(22, 21);
            this.knownanal.TabIndex = 29;
            this.knownanal.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 590);
            this.Controls.Add(this.SimulatedSeries);
            this.Controls.Add(this.Simulate);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Hplus);
            this.Controls.Add(this.hplusnum);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.OffsetY2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.NormY2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.NormY1);
            this.Controls.Add(this.derivative2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MolarRatio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TitConc);
            this.Controls.Add(this.Titrationcheck);
            this.Controls.Add(this.Interceptpoints);
            this.Controls.Add(this.Derivcheck);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Analyzebutton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "OpenTitration - V 1.2.0 - Build : 2021/01/22";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titrationdatBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Analyzebutton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox formula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Molarmass;
        private System.Windows.Forms.CheckBox Derivcheck;
        private System.Windows.Forms.CheckBox Interceptpoints;
        private System.Windows.Forms.CheckBox Titrationcheck;
        private System.Windows.Forms.TextBox TitConc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PkaLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MolarRatio;
        private System.Windows.Forms.BindingSource titrationdatBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dilutionfactor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox volumeanal;
        private System.Windows.Forms.TextBox Volumetit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox Concknown;
        private System.Windows.Forms.TextBox mass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox derivative2;
        private System.Windows.Forms.ComboBox NormY1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox NormY2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox OffsetY2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label Hplus;
        private System.Windows.Forms.ComboBox Concentration;
        private System.Windows.Forms.ComboBox Equivalence;
        private System.Windows.Forms.ComboBox PKA;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox Base;
        private System.Windows.Forms.Label unkownacidlabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        public System.Windows.Forms.ComboBox hplusnum;
        private System.Windows.Forms.Button Simulate;
        private System.Windows.Forms.CheckBox SimulatedSeries;
        private System.Windows.Forms.ComboBox unkownacid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox knownanal;
    }
}

