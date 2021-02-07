namespace Titration_Analyzer
{
    partial class Settings
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
            this.Apply = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Simulator = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.hplusstate = new System.Windows.Forms.ComboBox();
            this.protinationstate = new System.Windows.Forms.Label();
            this.Sensitivitymanual = new System.Windows.Forms.TextBox();
            this.rangetwo = new System.Windows.Forms.TextBox();
            this.rangeone = new System.Windows.Forms.TextBox();
            this.TargetRangeType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SolveMethod = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Customdatcheck = new System.Windows.Forms.CheckBox();
            this.Sensitivty = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linedemonstrator = new System.Windows.Forms.Panel();
            this.LineThickness = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.interceptSize = new System.Windows.Forms.ComboBox();
            this.InterceptFont = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.yaxisSize = new System.Windows.Forms.ComboBox();
            this.yaxisfont = new System.Windows.Forms.ComboBox();
            this.xaxisSize = new System.Windows.Forms.ComboBox();
            this.xaxisfont = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ResultsSize = new System.Windows.Forms.ComboBox();
            this.ResultsText = new System.Windows.Forms.ComboBox();
            this.HeadingSize = new System.Windows.Forms.ComboBox();
            this.HeadingsText = new System.Windows.Forms.ComboBox();
            this.margins = new System.Windows.Forms.ComboBox();
            this.Spacingpdf = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.results = new System.Windows.Forms.Label();
            this.Headings = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.CustompKa = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pKa3 = new System.Windows.Forms.TextBox();
            this.pKa2 = new System.Windows.Forms.TextBox();
            this.pKa1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.StrongAcid = new System.Windows.Forms.CheckBox();
            this.millneg2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.millneg1 = new System.Windows.Forms.ComboBox();
            this.Default = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DirectoryPython = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Simulator.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Apply
            // 
            this.Apply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Apply.Location = new System.Drawing.Point(26, 391);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(141, 47);
            this.Apply.TabIndex = 1;
            this.Apply.Text = "Apply";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.change_settings);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(198, 391);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(141, 47);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Settings);
            // 
            // Simulator
            // 
            this.Simulator.Controls.Add(this.tabPage1);
            this.Simulator.Controls.Add(this.tabPage3);
            this.Simulator.Controls.Add(this.tabPage2);
            this.Simulator.Controls.Add(this.tabPage4);
            this.Simulator.Location = new System.Drawing.Point(12, 12);
            this.Simulator.Name = "Simulator";
            this.Simulator.SelectedIndex = 0;
            this.Simulator.Size = new System.Drawing.Size(349, 359);
            this.Simulator.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.hplusstate);
            this.tabPage1.Controls.Add(this.protinationstate);
            this.tabPage1.Controls.Add(this.Sensitivitymanual);
            this.tabPage1.Controls.Add(this.rangetwo);
            this.tabPage1.Controls.Add(this.rangeone);
            this.tabPage1.Controls.Add(this.TargetRangeType);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.SolveMethod);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.Customdatcheck);
            this.tabPage1.Controls.Add(this.Sensitivty);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(341, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Solver";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // hplusstate
            // 
            this.hplusstate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hplusstate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hplusstate.FormattingEnabled = true;
            this.hplusstate.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.hplusstate.Location = new System.Drawing.Point(23, 34);
            this.hplusstate.Name = "hplusstate";
            this.hplusstate.Size = new System.Drawing.Size(66, 28);
            this.hplusstate.TabIndex = 28;
            this.hplusstate.SelectedIndexChanged += new System.EventHandler(this.Change_Protination);
            this.hplusstate.SelectedValueChanged += new System.EventHandler(this.Protination_changevalue);
            // 
            // protinationstate
            // 
            this.protinationstate.AutoSize = true;
            this.protinationstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.protinationstate.Location = new System.Drawing.Point(17, 3);
            this.protinationstate.Name = "protinationstate";
            this.protinationstate.Size = new System.Drawing.Size(172, 25);
            this.protinationstate.TabIndex = 27;
            this.protinationstate.Text = "Protination State";
            // 
            // Sensitivitymanual
            // 
            this.Sensitivitymanual.Location = new System.Drawing.Point(244, 169);
            this.Sensitivitymanual.Name = "Sensitivitymanual";
            this.Sensitivitymanual.Size = new System.Drawing.Size(76, 26);
            this.Sensitivitymanual.TabIndex = 26;
            // 
            // rangetwo
            // 
            this.rangetwo.Location = new System.Drawing.Point(244, 237);
            this.rangetwo.Name = "rangetwo";
            this.rangetwo.Size = new System.Drawing.Size(76, 26);
            this.rangetwo.TabIndex = 25;
            // 
            // rangeone
            // 
            this.rangeone.Location = new System.Drawing.Point(152, 237);
            this.rangeone.Name = "rangeone";
            this.rangeone.Size = new System.Drawing.Size(76, 26);
            this.rangeone.TabIndex = 24;
            // 
            // TargetRangeType
            // 
            this.TargetRangeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetRangeType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TargetRangeType.FormattingEnabled = true;
            this.TargetRangeType.Items.AddRange(new object[] {
            "pH",
            "Volume"});
            this.TargetRangeType.Location = new System.Drawing.Point(21, 237);
            this.TargetRangeType.Name = "TargetRangeType";
            this.TargetRangeType.Size = new System.Drawing.Size(115, 28);
            this.TargetRangeType.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(278, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Peak Determination Method";
            // 
            // SolveMethod
            // 
            this.SolveMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SolveMethod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SolveMethod.FormattingEnabled = true;
            this.SolveMethod.Items.AddRange(new object[] {
            "Automatic",
            "Manual Range"});
            this.SolveMethod.Location = new System.Drawing.Point(21, 101);
            this.SolveMethod.Name = "SolveMethod";
            this.SolveMethod.Size = new System.Drawing.Size(166, 28);
            this.SolveMethod.TabIndex = 21;
            this.SolveMethod.SelectedIndexChanged += new System.EventHandler(this.SolveMethod_SelectedIndexChanged);
            this.SolveMethod.SelectionChangeCommitted += new System.EventHandler(this.change_method);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Target Range";
            // 
            // Customdatcheck
            // 
            this.Customdatcheck.AutoSize = true;
            this.Customdatcheck.Location = new System.Drawing.Point(206, 171);
            this.Customdatcheck.Name = "Customdatcheck";
            this.Customdatcheck.Size = new System.Drawing.Size(22, 21);
            this.Customdatcheck.TabIndex = 18;
            this.Customdatcheck.UseVisualStyleBackColor = true;
            this.Customdatcheck.CheckedChanged += new System.EventHandler(this.Customdatcheck_CheckedChanged);
            // 
            // Sensitivty
            // 
            this.Sensitivty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sensitivty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Sensitivty.FormattingEnabled = true;
            this.Sensitivty.Items.AddRange(new object[] {
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
            this.Sensitivty.Location = new System.Drawing.Point(22, 168);
            this.Sensitivty.Name = "Sensitivty";
            this.Sensitivty.Size = new System.Drawing.Size(166, 28);
            this.Sensitivty.TabIndex = 17;
            this.Sensitivty.SelectedIndexChanged += new System.EventHandler(this.Sensitivty_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Peak Picking Sensitivity";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linedemonstrator);
            this.tabPage3.Controls.Add(this.LineThickness);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.interceptSize);
            this.tabPage3.Controls.Add(this.InterceptFont);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.yaxisSize);
            this.tabPage3.Controls.Add(this.yaxisfont);
            this.tabPage3.Controls.Add(this.xaxisSize);
            this.tabPage3.Controls.Add(this.xaxisfont);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(341, 326);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Graph";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // linedemonstrator
            // 
            this.linedemonstrator.Location = new System.Drawing.Point(244, 39);
            this.linedemonstrator.Name = "linedemonstrator";
            this.linedemonstrator.Size = new System.Drawing.Size(77, 28);
            this.linedemonstrator.TabIndex = 27;
            this.linedemonstrator.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawDemonstrationLine);
            // 
            // LineThickness
            // 
            this.LineThickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LineThickness.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LineThickness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineThickness.FormattingEnabled = true;
            this.LineThickness.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.LineThickness.Location = new System.Drawing.Point(20, 39);
            this.LineThickness.Name = "LineThickness";
            this.LineThickness.Size = new System.Drawing.Size(206, 28);
            this.LineThickness.TabIndex = 26;
            this.LineThickness.SelectedIndexChanged += new System.EventHandler(this.LineThickness_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "Line Thickness";
            // 
            // interceptSize
            // 
            this.interceptSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interceptSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.interceptSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interceptSize.FormattingEnabled = true;
            this.interceptSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18"});
            this.interceptSize.Location = new System.Drawing.Point(244, 112);
            this.interceptSize.Name = "interceptSize";
            this.interceptSize.Size = new System.Drawing.Size(77, 28);
            this.interceptSize.TabIndex = 24;
            // 
            // InterceptFont
            // 
            this.InterceptFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InterceptFont.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.InterceptFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterceptFont.FormattingEnabled = true;
            this.InterceptFont.Location = new System.Drawing.Point(20, 112);
            this.InterceptFont.Name = "InterceptFont";
            this.InterceptFont.Size = new System.Drawing.Size(206, 28);
            this.InterceptFont.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "Intercept Labels";
            // 
            // yaxisSize
            // 
            this.yaxisSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yaxisSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.yaxisSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yaxisSize.FormattingEnabled = true;
            this.yaxisSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18"});
            this.yaxisSize.Location = new System.Drawing.Point(244, 261);
            this.yaxisSize.Name = "yaxisSize";
            this.yaxisSize.Size = new System.Drawing.Size(77, 28);
            this.yaxisSize.TabIndex = 21;
            // 
            // yaxisfont
            // 
            this.yaxisfont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yaxisfont.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.yaxisfont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yaxisfont.FormattingEnabled = true;
            this.yaxisfont.Location = new System.Drawing.Point(20, 261);
            this.yaxisfont.Name = "yaxisfont";
            this.yaxisfont.Size = new System.Drawing.Size(206, 28);
            this.yaxisfont.TabIndex = 20;
            // 
            // xaxisSize
            // 
            this.xaxisSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xaxisSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.xaxisSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xaxisSize.FormattingEnabled = true;
            this.xaxisSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18"});
            this.xaxisSize.Location = new System.Drawing.Point(244, 187);
            this.xaxisSize.Name = "xaxisSize";
            this.xaxisSize.Size = new System.Drawing.Size(77, 28);
            this.xaxisSize.TabIndex = 19;
            // 
            // xaxisfont
            // 
            this.xaxisfont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xaxisfont.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.xaxisfont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xaxisfont.FormattingEnabled = true;
            this.xaxisfont.Location = new System.Drawing.Point(20, 187);
            this.xaxisfont.Name = "xaxisfont";
            this.xaxisfont.Size = new System.Drawing.Size(206, 28);
            this.xaxisfont.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Y-Axis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "X-Axis";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ResultsSize);
            this.tabPage2.Controls.Add(this.ResultsText);
            this.tabPage2.Controls.Add(this.HeadingSize);
            this.tabPage2.Controls.Add(this.HeadingsText);
            this.tabPage2.Controls.Add(this.margins);
            this.tabPage2.Controls.Add(this.Spacingpdf);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.results);
            this.tabPage2.Controls.Add(this.Headings);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(341, 326);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PDF";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ResultsSize
            // 
            this.ResultsSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ResultsSize.FormattingEnabled = true;
            this.ResultsSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18"});
            this.ResultsSize.Location = new System.Drawing.Point(244, 264);
            this.ResultsSize.Name = "ResultsSize";
            this.ResultsSize.Size = new System.Drawing.Size(77, 28);
            this.ResultsSize.TabIndex = 19;
            // 
            // ResultsText
            // 
            this.ResultsText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ResultsText.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ResultsText.FormattingEnabled = true;
            this.ResultsText.Location = new System.Drawing.Point(15, 264);
            this.ResultsText.Name = "ResultsText";
            this.ResultsText.Size = new System.Drawing.Size(206, 28);
            this.ResultsText.TabIndex = 18;
            this.ResultsText.DropDown += new System.EventHandler(this.Populate_Size);
            // 
            // HeadingSize
            // 
            this.HeadingSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HeadingSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.HeadingSize.FormattingEnabled = true;
            this.HeadingSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18"});
            this.HeadingSize.Location = new System.Drawing.Point(244, 186);
            this.HeadingSize.Name = "HeadingSize";
            this.HeadingSize.Size = new System.Drawing.Size(77, 28);
            this.HeadingSize.TabIndex = 17;
            // 
            // HeadingsText
            // 
            this.HeadingsText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HeadingsText.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.HeadingsText.FormattingEnabled = true;
            this.HeadingsText.Location = new System.Drawing.Point(15, 186);
            this.HeadingsText.Name = "HeadingsText";
            this.HeadingsText.Size = new System.Drawing.Size(206, 28);
            this.HeadingsText.TabIndex = 16;
            this.HeadingsText.DropDown += new System.EventHandler(this.Populate_Size);
            // 
            // margins
            // 
            this.margins.FormattingEnabled = true;
            this.margins.Items.AddRange(new object[] {
            "14",
            "28",
            "56"});
            this.margins.Location = new System.Drawing.Point(15, 110);
            this.margins.Name = "margins";
            this.margins.Size = new System.Drawing.Size(166, 28);
            this.margins.TabIndex = 15;
            this.margins.Text = "14";
            // 
            // Spacingpdf
            // 
            this.Spacingpdf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Spacingpdf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Spacingpdf.FormattingEnabled = true;
            this.Spacingpdf.Items.AddRange(new object[] {
            "1",
            "1.15",
            "1.5",
            "2",
            "2.5"});
            this.Spacingpdf.Location = new System.Drawing.Point(15, 39);
            this.Spacingpdf.Name = "Spacingpdf";
            this.Spacingpdf.Size = new System.Drawing.Size(166, 28);
            this.Spacingpdf.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Margins";
            // 
            // results
            // 
            this.results.AutoSize = true;
            this.results.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.results.Location = new System.Drawing.Point(15, 226);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(132, 25);
            this.results.TabIndex = 7;
            this.results.Text = "Results Text";
            // 
            // Headings
            // 
            this.Headings.AutoSize = true;
            this.Headings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Headings.Location = new System.Drawing.Point(15, 150);
            this.Headings.Name = "Headings";
            this.Headings.Size = new System.Drawing.Size(103, 25);
            this.Headings.TabIndex = 6;
            this.Headings.Text = "Headings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Spacing";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.CustompKa);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.pKa3);
            this.tabPage4.Controls.Add(this.pKa2);
            this.tabPage4.Controls.Add(this.pKa1);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.StrongAcid);
            this.tabPage4.Controls.Add(this.millneg2);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.millneg1);
            this.tabPage4.Controls.Add(this.Default);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.DirectoryPython);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(341, 326);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Sim";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // CustompKa
            // 
            this.CustompKa.AutoSize = true;
            this.CustompKa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustompKa.Location = new System.Drawing.Point(154, 206);
            this.CustompKa.Name = "CustompKa";
            this.CustompKa.Size = new System.Drawing.Size(112, 29);
            this.CustompKa.TabIndex = 41;
            this.CustompKa.Text = "Custom";
            this.CustompKa.UseVisualStyleBackColor = true;
            this.CustompKa.CheckedChanged += new System.EventHandler(this.Select_Custom_pKa);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(238, 246);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 25);
            this.label15.TabIndex = 40;
            this.label15.Text = "pK3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(137, 246);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 25);
            this.label14.TabIndex = 39;
            this.label14.Text = "pK2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(39, 246);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 25);
            this.label13.TabIndex = 38;
            this.label13.Text = "pK1";
            // 
            // pKa3
            // 
            this.pKa3.BackColor = System.Drawing.SystemColors.Info;
            this.pKa3.Enabled = false;
            this.pKa3.Location = new System.Drawing.Point(229, 280);
            this.pKa3.Name = "pKa3";
            this.pKa3.Size = new System.Drawing.Size(76, 26);
            this.pKa3.TabIndex = 37;
            // 
            // pKa2
            // 
            this.pKa2.BackColor = System.Drawing.SystemColors.Info;
            this.pKa2.Enabled = false;
            this.pKa2.Location = new System.Drawing.Point(125, 280);
            this.pKa2.Name = "pKa2";
            this.pKa2.Size = new System.Drawing.Size(76, 26);
            this.pKa2.TabIndex = 36;
            // 
            // pKa1
            // 
            this.pKa1.BackColor = System.Drawing.SystemColors.Info;
            this.pKa1.Enabled = false;
            this.pKa1.Location = new System.Drawing.Point(25, 280);
            this.pKa1.Name = "pKa1";
            this.pKa1.Size = new System.Drawing.Size(76, 26);
            this.pKa1.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 25);
            this.label12.TabIndex = 34;
            this.label12.Text = "PKa Values";
            // 
            // StrongAcid
            // 
            this.StrongAcid.AutoSize = true;
            this.StrongAcid.Checked = true;
            this.StrongAcid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StrongAcid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrongAcid.Location = new System.Drawing.Point(11, 168);
            this.StrongAcid.Name = "StrongAcid";
            this.StrongAcid.Size = new System.Drawing.Size(219, 29);
            this.StrongAcid.TabIndex = 33;
            this.StrongAcid.Text = "Strong Acid/Base?";
            this.StrongAcid.UseVisualStyleBackColor = true;
            // 
            // millneg2
            // 
            this.millneg2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.millneg2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.millneg2.FormattingEnabled = true;
            this.millneg2.Items.AddRange(new object[] {
            "0",
            "0.01",
            "0.02",
            "0.03",
            "0.04",
            "0.05",
            "0.06",
            "0.07",
            "0.08",
            "0.09"});
            this.millneg2.Location = new System.Drawing.Point(85, 123);
            this.millneg2.Name = "millneg2";
            this.millneg2.Size = new System.Drawing.Size(66, 28);
            this.millneg2.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(270, 25);
            this.label11.TabIndex = 31;
            this.label11.Text = "Data Point Resolution (mL)";
            // 
            // millneg1
            // 
            this.millneg1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.millneg1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.millneg1.FormattingEnabled = true;
            this.millneg1.Items.AddRange(new object[] {
            "0",
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1"});
            this.millneg1.Location = new System.Drawing.Point(11, 123);
            this.millneg1.Name = "millneg1";
            this.millneg1.Size = new System.Drawing.Size(66, 28);
            this.millneg1.TabIndex = 30;
            // 
            // Default
            // 
            this.Default.AutoSize = true;
            this.Default.Checked = true;
            this.Default.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Default.Enabled = false;
            this.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Default.Location = new System.Drawing.Point(229, 46);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(106, 29);
            this.Default.TabIndex = 29;
            this.Default.Text = "Default";
            this.Default.UseVisualStyleBackColor = true;
            this.Default.CheckStateChanged += new System.EventHandler(this.Default_CheckStateChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(212, 25);
            this.label10.TabIndex = 28;
            this.label10.Text = "Python.exe Directory";
            // 
            // DirectoryPython
            // 
            this.DirectoryPython.Location = new System.Drawing.Point(10, 49);
            this.DirectoryPython.Name = "DirectoryPython";
            this.DirectoryPython.Size = new System.Drawing.Size(210, 26);
            this.DirectoryPython.TabIndex = 27;
            this.DirectoryPython.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Change_Directory);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(272, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.reset_settings);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.Simulator);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Simulator.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TabControl Simulator;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox Sensitivty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label results;
        private System.Windows.Forms.Label Headings;
        private System.Windows.Forms.ComboBox ResultsSize;
        private System.Windows.Forms.ComboBox ResultsText;
        private System.Windows.Forms.ComboBox HeadingSize;
        private System.Windows.Forms.ComboBox HeadingsText;
        private System.Windows.Forms.ComboBox margins;
        private System.Windows.Forms.ComboBox Spacingpdf;
        private System.Windows.Forms.CheckBox Customdatcheck;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox interceptSize;
        private System.Windows.Forms.ComboBox InterceptFont;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox yaxisSize;
        private System.Windows.Forms.ComboBox yaxisfont;
        private System.Windows.Forms.ComboBox xaxisSize;
        private System.Windows.Forms.ComboBox xaxisfont;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TargetRangeType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox SolveMethod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Sensitivitymanual;
        private System.Windows.Forms.TextBox rangetwo;
        private System.Windows.Forms.TextBox rangeone;
        private System.Windows.Forms.Panel linedemonstrator;
        private System.Windows.Forms.ComboBox LineThickness;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox hplusstate;
        private System.Windows.Forms.Label protinationstate;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox DirectoryPython;
        private System.Windows.Forms.ComboBox millneg2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox millneg1;
        private System.Windows.Forms.CheckBox Default;
        private System.Windows.Forms.CheckBox CustompKa;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox pKa3;
        private System.Windows.Forms.TextBox pKa2;
        private System.Windows.Forms.TextBox pKa1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox StrongAcid;
    }
}