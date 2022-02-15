
namespace CellularAutomatons
{
    partial class Form1D
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1D = new System.Windows.Forms.PictureBox();
            this.Button1DRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1DRule = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1DRule)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1D
            // 
            this.pictureBox1D.Location = new System.Drawing.Point(158, 1);
            this.pictureBox1D.Name = "pictureBox1D";
            this.pictureBox1D.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1D.TabIndex = 0;
            this.pictureBox1D.TabStop = false;
            // 
            // Button1DRun
            // 
            this.Button1DRun.Location = new System.Drawing.Point(12, 458);
            this.Button1DRun.Name = "Button1DRun";
            this.Button1DRun.Size = new System.Drawing.Size(121, 23);
            this.Button1DRun.TabIndex = 1;
            this.Button1DRun.Text = "Run";
            this.Button1DRun.UseVisualStyleBackColor = true;
            this.Button1DRun.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rule:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // numericUpDown1DRule
            // 
            this.numericUpDown1DRule.Location = new System.Drawing.Point(12, 412);
            this.numericUpDown1DRule.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1DRule.Name = "numericUpDown1DRule";
            this.numericUpDown1DRule.Size = new System.Drawing.Size(121, 23);
            this.numericUpDown1DRule.TabIndex = 3;
            // 
            // Form1D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 503);
            this.Controls.Add(this.numericUpDown1DRule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button1DRun);
            this.Controls.Add(this.pictureBox1D);
            this.Name = "Form1D";
            this.Text = "1D Automaton";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1DRule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1D;
        private System.Windows.Forms.Button Button1DRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1DRule;
    }
}

