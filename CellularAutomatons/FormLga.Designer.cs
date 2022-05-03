
namespace CellularAutomatons
{
    partial class FormLga
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
            this.pictureBoxLga = new System.Windows.Forms.PictureBox();
            this.buttonRunLga = new System.Windows.Forms.Button();
            this.numericUpDownSizeLga = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGenerateLga = new System.Windows.Forms.Button();
            this.numericUpDownBarrier = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownChance = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeLga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChance)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLga
            // 
            this.pictureBoxLga.Location = new System.Drawing.Point(159, 2);
            this.pictureBoxLga.Name = "pictureBoxLga";
            this.pictureBoxLga.Size = new System.Drawing.Size(500, 500);
            this.pictureBoxLga.TabIndex = 0;
            this.pictureBoxLga.TabStop = false;
            // 
            // buttonRunLga
            // 
            this.buttonRunLga.Enabled = false;
            this.buttonRunLga.Location = new System.Drawing.Point(12, 468);
            this.buttonRunLga.Name = "buttonRunLga";
            this.buttonRunLga.Size = new System.Drawing.Size(121, 23);
            this.buttonRunLga.TabIndex = 1;
            this.buttonRunLga.Text = "Run";
            this.buttonRunLga.UseVisualStyleBackColor = true;
            this.buttonRunLga.Click += new System.EventHandler(this.buttonRunLga_Click);
            // 
            // numericUpDownSizeLga
            // 
            this.numericUpDownSizeLga.Location = new System.Drawing.Point(13, 351);
            this.numericUpDownSizeLga.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownSizeLga.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownSizeLga.Name = "numericUpDownSizeLga";
            this.numericUpDownSizeLga.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownSizeLga.TabIndex = 2;
            this.numericUpDownSizeLga.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Size:";
            // 
            // buttonGenerateLga
            // 
            this.buttonGenerateLga.Location = new System.Drawing.Point(13, 393);
            this.buttonGenerateLga.Name = "buttonGenerateLga";
            this.buttonGenerateLga.Size = new System.Drawing.Size(120, 23);
            this.buttonGenerateLga.TabIndex = 4;
            this.buttonGenerateLga.Text = "Generate";
            this.buttonGenerateLga.UseVisualStyleBackColor = true;
            this.buttonGenerateLga.Click += new System.EventHandler(this.buttonGenerateLga_Click);
            // 
            // numericUpDownBarrier
            // 
            this.numericUpDownBarrier.Location = new System.Drawing.Point(13, 298);
            this.numericUpDownBarrier.Name = "numericUpDownBarrier";
            this.numericUpDownBarrier.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownBarrier.TabIndex = 5;
            this.numericUpDownBarrier.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numericUpDownChance
            // 
            this.numericUpDownChance.Location = new System.Drawing.Point(13, 251);
            this.numericUpDownChance.Name = "numericUpDownChance";
            this.numericUpDownChance.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownChance.TabIndex = 6;
            this.numericUpDownChance.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Particle chance(percent):";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Barrier position (percent):";
            // 
            // FormLga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 503);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownChance);
            this.Controls.Add(this.numericUpDownBarrier);
            this.Controls.Add(this.buttonGenerateLga);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSizeLga);
            this.Controls.Add(this.buttonRunLga);
            this.Controls.Add(this.pictureBoxLga);
            this.Name = "FormLga";
            this.Text = "FormLga";
            this.Load += new System.EventHandler(this.FormLga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeLga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLga;
        private System.Windows.Forms.Button buttonRunLga;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeLga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGenerateLga;
        private System.Windows.Forms.NumericUpDown numericUpDownBarrier;
        private System.Windows.Forms.NumericUpDown numericUpDownChance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}