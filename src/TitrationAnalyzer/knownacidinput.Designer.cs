namespace Titration_Analyzer
{
    partial class knownacidadd
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
            this.label1 = new System.Windows.Forms.Label();
            this.acidname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pKavalues = new System.Windows.Forms.TextBox();
            this.DataInput = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Acid Name";
            // 
            // acidname
            // 
            this.acidname.Location = new System.Drawing.Point(85, 38);
            this.acidname.Name = "acidname";
            this.acidname.Size = new System.Drawing.Size(212, 26);
            this.acidname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "pKa Values";
            // 
            // pKavalues
            // 
            this.pKavalues.Location = new System.Drawing.Point(85, 108);
            this.pKavalues.Name = "pKavalues";
            this.pKavalues.Size = new System.Drawing.Size(212, 26);
            this.pKavalues.TabIndex = 3;
            // 
            // DataInput
            // 
            this.DataInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataInput.Location = new System.Drawing.Point(128, 175);
            this.DataInput.Name = "DataInput";
            this.DataInput.Size = new System.Drawing.Size(127, 36);
            this.DataInput.TabIndex = 4;
            this.DataInput.Text = " Enter";
            this.DataInput.UseVisualStyleBackColor = true;
            this.DataInput.Click += new System.EventHandler(this.DataInput_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(114, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ex. pKa1,pKa2,pKa3";
            // 
            // knownacidadd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 224);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DataInput);
            this.Controls.Add(this.pKavalues);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.acidname);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "knownacidadd";
            this.Text = "Acid Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox acidname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pKavalues;
        private System.Windows.Forms.Button DataInput;
        private System.Windows.Forms.Label label3;
    }
}