
namespace CellularAutomatons
{
    partial class FormGameOfLife
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
            this.pictureBoxGof = new System.Windows.Forms.PictureBox();
            this.ButtonGofRun = new System.Windows.Forms.Button();
            this.ButtonGofReset = new System.Windows.Forms.Button();
            this.numericUpDownGofSize = new System.Windows.Forms.NumericUpDown();
            this.labelGofSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGof)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGofSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGof
            // 
            this.pictureBoxGof.Location = new System.Drawing.Point(159, 2);
            this.pictureBoxGof.Name = "pictureBoxGof";
            this.pictureBoxGof.Size = new System.Drawing.Size(500, 500);
            this.pictureBoxGof.TabIndex = 0;
            this.pictureBoxGof.TabStop = false;
            // 
            // ButtonGofRun
            // 
            this.ButtonGofRun.Enabled = false;
            this.ButtonGofRun.Location = new System.Drawing.Point(13, 462);
            this.ButtonGofRun.Name = "ButtonGofRun";
            this.ButtonGofRun.Size = new System.Drawing.Size(128, 23);
            this.ButtonGofRun.TabIndex = 1;
            this.ButtonGofRun.Text = "Run";
            this.ButtonGofRun.UseVisualStyleBackColor = true;
            this.ButtonGofRun.Click += new System.EventHandler(this.ButtonGofRun_Click);
            // 
            // ButtonGofReset
            // 
            this.ButtonGofReset.Location = new System.Drawing.Point(12, 390);
            this.ButtonGofReset.Name = "ButtonGofReset";
            this.ButtonGofReset.Size = new System.Drawing.Size(128, 23);
            this.ButtonGofReset.TabIndex = 2;
            this.ButtonGofReset.Text = "Generate new";
            this.ButtonGofReset.UseVisualStyleBackColor = true;
            this.ButtonGofReset.Click += new System.EventHandler(this.ButtonGofReset_Click);
            // 
            // numericUpDownGofSize
            // 
            this.numericUpDownGofSize.Location = new System.Drawing.Point(13, 361);
            this.numericUpDownGofSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownGofSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownGofSize.Name = "numericUpDownGofSize";
            this.numericUpDownGofSize.Size = new System.Drawing.Size(128, 23);
            this.numericUpDownGofSize.TabIndex = 3;
            this.numericUpDownGofSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelGofSize
            // 
            this.labelGofSize.AutoSize = true;
            this.labelGofSize.Location = new System.Drawing.Point(13, 343);
            this.labelGofSize.Name = "labelGofSize";
            this.labelGofSize.Size = new System.Drawing.Size(30, 15);
            this.labelGofSize.TabIndex = 4;
            this.labelGofSize.Text = "Size:";
            // 
            // FormGameOfLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 503);
            this.Controls.Add(this.labelGofSize);
            this.Controls.Add(this.numericUpDownGofSize);
            this.Controls.Add(this.ButtonGofReset);
            this.Controls.Add(this.ButtonGofRun);
            this.Controls.Add(this.pictureBoxGof);
            this.Name = "FormGameOfLife";
            this.Text = "Game of life";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGof)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGofSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGof;
        private System.Windows.Forms.Button ButtonGofRun;
        private System.Windows.Forms.Button ButtonGofReset;
        private System.Windows.Forms.NumericUpDown numericUpDownGofSize;
        private System.Windows.Forms.Label labelGofSize;
    }
}