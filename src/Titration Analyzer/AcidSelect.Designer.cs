namespace Titration_Analyzer
{
    partial class AcidSelect
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
            this.acidlist = new System.Windows.Forms.ComboBox();
            this.selectitem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // acidlist
            // 
            this.acidlist.FormattingEnabled = true;
            this.acidlist.Location = new System.Drawing.Point(54, 75);
            this.acidlist.Name = "acidlist";
            this.acidlist.Size = new System.Drawing.Size(220, 28);
            this.acidlist.TabIndex = 0;
            this.acidlist.SelectedValueChanged += new System.EventHandler(this.acidadd);
            // 
            // selectitem
            // 
            this.selectitem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectitem.Location = new System.Drawing.Point(105, 121);
            this.selectitem.Name = "selectitem";
            this.selectitem.Size = new System.Drawing.Size(114, 40);
            this.selectitem.TabIndex = 1;
            this.selectitem.Text = "Select";
            this.selectitem.UseVisualStyleBackColor = true;
            this.selectitem.Click += new System.EventHandler(this.acidselect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select your acid";
            // 
            // AcidSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 182);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectitem);
            this.Controls.Add(this.acidlist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AcidSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox acidlist;
        private System.Windows.Forms.Button selectitem;
        private System.Windows.Forms.Label label1;
    }
}