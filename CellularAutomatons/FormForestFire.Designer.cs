

namespace CellularAutomatons
{
    partial class FormForestFire
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
            this.pictureBoxFF = new System.Windows.Forms.PictureBox();
            this.buttonRunFF = new System.Windows.Forms.Button();
            this.numericUpDowSizeFF = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGrowth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSpontaneous = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownIgnition = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonGenerateFF = new System.Windows.Forms.Button();
            this.checkBoxRandomFF = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowSizeFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrowth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpontaneous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIgnition)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFF
            // 
            this.pictureBoxFF.Location = new System.Drawing.Point(159, 2);
            this.pictureBoxFF.Name = "pictureBoxFF";
            this.pictureBoxFF.Size = new System.Drawing.Size(500, 500);
            this.pictureBoxFF.TabIndex = 0;
            this.pictureBoxFF.TabStop = false;
            // 
            // buttonRunFF
            // 
            this.buttonRunFF.Location = new System.Drawing.Point(12, 468);
            this.buttonRunFF.Name = "buttonRunFF";
            this.buttonRunFF.Size = new System.Drawing.Size(121, 23);
            this.buttonRunFF.TabIndex = 1;
            this.buttonRunFF.Text = "Run";
            this.buttonRunFF.UseVisualStyleBackColor = true;
            this.buttonRunFF.Click += new System.EventHandler(this.buttonRunFF_Click);
            // 
            // numericUpDowSizeFF
            // 
            this.numericUpDowSizeFF.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDowSizeFF.Location = new System.Drawing.Point(13, 386);
            this.numericUpDowSizeFF.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDowSizeFF.Name = "numericUpDowSizeFF";
            this.numericUpDowSizeFF.Size = new System.Drawing.Size(120, 23);
            this.numericUpDowSizeFF.TabIndex = 2;
            this.numericUpDowSizeFF.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericUpDownGrowth
            // 
            this.numericUpDownGrowth.Location = new System.Drawing.Point(13, 221);
            this.numericUpDownGrowth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownGrowth.Name = "numericUpDownGrowth";
            this.numericUpDownGrowth.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownGrowth.TabIndex = 3;
            this.numericUpDownGrowth.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpDownSpontaneous
            // 
            this.numericUpDownSpontaneous.Location = new System.Drawing.Point(13, 177);
            this.numericUpDownSpontaneous.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.numericUpDownSpontaneous.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSpontaneous.Name = "numericUpDownSpontaneous";
            this.numericUpDownSpontaneous.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownSpontaneous.TabIndex = 4;
            this.numericUpDownSpontaneous.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownIgnition
            // 
            this.numericUpDownIgnition.Location = new System.Drawing.Point(12, 114);
            this.numericUpDownIgnition.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownIgnition.Name = "numericUpDownIgnition";
            this.numericUpDownIgnition.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownIgnition.TabIndex = 5;
            this.numericUpDownIgnition.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ignition probability (x/100)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Spontaneous Ignition";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Growth (x/10000)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "(x/5000000)";
            // 
            // buttonGenerateFF
            // 
            this.buttonGenerateFF.Location = new System.Drawing.Point(13, 415);
            this.buttonGenerateFF.Name = "buttonGenerateFF";
            this.buttonGenerateFF.Size = new System.Drawing.Size(120, 28);
            this.buttonGenerateFF.TabIndex = 11;
            this.buttonGenerateFF.Text = "Generate new";
            this.buttonGenerateFF.UseVisualStyleBackColor = true;
            this.buttonGenerateFF.Click += new System.EventHandler(this.buttonGenerateFF_Click);
            // 
            // checkBoxRandomFF
            // 
            this.checkBoxRandomFF.AutoSize = true;
            this.checkBoxRandomFF.Location = new System.Drawing.Point(13, 262);
            this.checkBoxRandomFF.Name = "checkBoxRandomFF";
            this.checkBoxRandomFF.Size = new System.Drawing.Size(71, 19);
            this.checkBoxRandomFF.TabIndex = 12;
            this.checkBoxRandomFF.Text = "Random";
            this.checkBoxRandomFF.UseVisualStyleBackColor = true;
            // 
            // FormForestFire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 503);
            this.Controls.Add(this.checkBoxRandomFF);
            this.Controls.Add(this.buttonGenerateFF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownIgnition);
            this.Controls.Add(this.numericUpDownSpontaneous);
            this.Controls.Add(this.numericUpDownGrowth);
            this.Controls.Add(this.numericUpDowSizeFF);
            this.Controls.Add(this.buttonRunFF);
            this.Controls.Add(this.pictureBoxFF);
            this.Name = "FormForestFire";
            this.Text = "Forest Fire";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowSizeFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrowth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpontaneous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIgnition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFF;
        private System.Windows.Forms.Button buttonRunFF;
        private System.Windows.Forms.NumericUpDown numericUpDowSizeFF;
        private System.Windows.Forms.NumericUpDown numericUpDownGrowth;
        private System.Windows.Forms.NumericUpDown numericUpDownSpontaneous;
        private System.Windows.Forms.NumericUpDown numericUpDownIgnition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonGenerateFF;
        private System.Windows.Forms.CheckBox checkBoxRandomFF;
    }
}