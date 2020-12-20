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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Sensitivty = new System.Windows.Forms.ComboBox();
            this.linedemonstrator = new System.Windows.Forms.Panel();
            this.interceptSize = new System.Windows.Forms.ComboBox();
            this.InterceptFont = new System.Windows.Forms.ComboBox();
            this.LineThickness = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.yaxisSize = new System.Windows.Forms.ComboBox();
            this.yaxisfont = new System.Windows.Forms.ComboBox();
            this.xaxisSize = new System.Windows.Forms.ComboBox();
            this.xaxisfont = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(349, 359);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Sensitivty);
            this.tabPage1.Controls.Add(this.linedemonstrator);
            this.tabPage1.Controls.Add(this.interceptSize);
            this.tabPage1.Controls.Add(this.InterceptFont);
            this.tabPage1.Controls.Add(this.LineThickness);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.yaxisSize);
            this.tabPage1.Controls.Add(this.yaxisfont);
            this.tabPage1.Controls.Add(this.xaxisSize);
            this.tabPage1.Controls.Add(this.xaxisfont);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(341, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graph";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            "5"});
            this.Sensitivty.Location = new System.Drawing.Point(18, 39);
            this.Sensitivty.Name = "Sensitivty";
            this.Sensitivty.Size = new System.Drawing.Size(166, 28);
            this.Sensitivty.TabIndex = 17;
            // 
            // linedemonstrator
            // 
            this.linedemonstrator.Location = new System.Drawing.Point(242, 98);
            this.linedemonstrator.Name = "linedemonstrator";
            this.linedemonstrator.Size = new System.Drawing.Size(77, 28);
            this.linedemonstrator.TabIndex = 16;
            this.linedemonstrator.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawDemonstrationLine);
            // 
            // interceptSize
            // 
            this.interceptSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interceptSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.interceptSize.FormattingEnabled = true;
            this.interceptSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18"});
            this.interceptSize.Location = new System.Drawing.Point(242, 158);
            this.interceptSize.Name = "interceptSize";
            this.interceptSize.Size = new System.Drawing.Size(77, 28);
            this.interceptSize.TabIndex = 15;
            // 
            // InterceptFont
            // 
            this.InterceptFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InterceptFont.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.InterceptFont.FormattingEnabled = true;
            this.InterceptFont.Location = new System.Drawing.Point(18, 158);
            this.InterceptFont.Name = "InterceptFont";
            this.InterceptFont.Size = new System.Drawing.Size(206, 28);
            this.InterceptFont.TabIndex = 14;
            this.InterceptFont.DropDown += new System.EventHandler(this.Populate_Size);
            // 
            // LineThickness
            // 
            this.LineThickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LineThickness.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LineThickness.FormattingEnabled = true;
            this.LineThickness.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.LineThickness.Location = new System.Drawing.Point(18, 98);
            this.LineThickness.Name = "LineThickness";
            this.LineThickness.Size = new System.Drawing.Size(166, 28);
            this.LineThickness.TabIndex = 13;
            this.LineThickness.SelectedIndexChanged += new System.EventHandler(this.LineThickness_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Intercept Labels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Line Thickness";
            // 
            // yaxisSize
            // 
            this.yaxisSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yaxisSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.yaxisSize.FormattingEnabled = true;
            this.yaxisSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18"});
            this.yaxisSize.Location = new System.Drawing.Point(242, 276);
            this.yaxisSize.Name = "yaxisSize";
            this.yaxisSize.Size = new System.Drawing.Size(77, 28);
            this.yaxisSize.TabIndex = 10;
            // 
            // yaxisfont
            // 
            this.yaxisfont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yaxisfont.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.yaxisfont.FormattingEnabled = true;
            this.yaxisfont.Location = new System.Drawing.Point(18, 276);
            this.yaxisfont.Name = "yaxisfont";
            this.yaxisfont.Size = new System.Drawing.Size(206, 28);
            this.yaxisfont.TabIndex = 9;
            this.yaxisfont.DropDown += new System.EventHandler(this.Populate_Size);
            // 
            // xaxisSize
            // 
            this.xaxisSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xaxisSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.xaxisSize.FormattingEnabled = true;
            this.xaxisSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18"});
            this.xaxisSize.Location = new System.Drawing.Point(242, 217);
            this.xaxisSize.Name = "xaxisSize";
            this.xaxisSize.Size = new System.Drawing.Size(77, 28);
            this.xaxisSize.TabIndex = 8;
            // 
            // xaxisfont
            // 
            this.xaxisfont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xaxisfont.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.xaxisfont.FormattingEnabled = true;
            this.xaxisfont.Location = new System.Drawing.Point(18, 217);
            this.xaxisfont.Name = "xaxisfont";
            this.xaxisfont.Size = new System.Drawing.Size(206, 28);
            this.xaxisfont.TabIndex = 7;
            this.xaxisfont.DropDown += new System.EventHandler(this.Populate_Size);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y-Axis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "X-Axis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Peak Picking Sensitivity";
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
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox interceptSize;
        private System.Windows.Forms.ComboBox InterceptFont;
        private System.Windows.Forms.ComboBox LineThickness;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox yaxisSize;
        private System.Windows.Forms.ComboBox yaxisfont;
        private System.Windows.Forms.ComboBox xaxisSize;
        private System.Windows.Forms.ComboBox xaxisfont;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel linedemonstrator;
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
    }
}