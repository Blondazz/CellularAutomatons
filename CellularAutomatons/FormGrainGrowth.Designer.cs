namespace CellularAutomatons
{
    partial class FormGrainGrowth
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
            this.pictureBoxGg = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownGrains = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSizeGg = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerateGg = new System.Windows.Forms.Button();
            this.buttonRunGg = new System.Windows.Forms.Button();
            this.comboBoxGg = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelSave = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeGg)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGg
            // 
            this.pictureBoxGg.Location = new System.Drawing.Point(159, 2);
            this.pictureBoxGg.Name = "pictureBoxGg";
            this.pictureBoxGg.Size = new System.Drawing.Size(500, 500);
            this.pictureBoxGg.TabIndex = 1;
            this.pictureBoxGg.TabStop = false;
            this.pictureBoxGg.Click += new System.EventHandler(this.pictureBoxGg_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Grain amount:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // numericUpDownGrains
            // 
            this.numericUpDownGrains.Location = new System.Drawing.Point(12, 290);
            this.numericUpDownGrains.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownGrains.Name = "numericUpDownGrains";
            this.numericUpDownGrains.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownGrains.TabIndex = 11;
            this.numericUpDownGrains.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Size:";
            // 
            // numericUpDownSizeGg
            // 
            this.numericUpDownSizeGg.Location = new System.Drawing.Point(12, 343);
            this.numericUpDownSizeGg.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownSizeGg.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSizeGg.Name = "numericUpDownSizeGg";
            this.numericUpDownSizeGg.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownSizeGg.TabIndex = 9;
            this.numericUpDownSizeGg.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // buttonGenerateGg
            // 
            this.buttonGenerateGg.Location = new System.Drawing.Point(9, 386);
            this.buttonGenerateGg.Name = "buttonGenerateGg";
            this.buttonGenerateGg.Size = new System.Drawing.Size(120, 23);
            this.buttonGenerateGg.TabIndex = 14;
            this.buttonGenerateGg.Text = "Generate";
            this.buttonGenerateGg.UseVisualStyleBackColor = true;
            this.buttonGenerateGg.Click += new System.EventHandler(this.buttonGenerateGg_Click);
            // 
            // buttonRunGg
            // 
            this.buttonRunGg.Location = new System.Drawing.Point(8, 415);
            this.buttonRunGg.Name = "buttonRunGg";
            this.buttonRunGg.Size = new System.Drawing.Size(121, 23);
            this.buttonRunGg.TabIndex = 13;
            this.buttonRunGg.Text = "Run";
            this.buttonRunGg.UseVisualStyleBackColor = true;
            this.buttonRunGg.Click += new System.EventHandler(this.buttonRunGg_Click);
            // 
            // comboBoxGg
            // 
            this.comboBoxGg.FormattingEnabled = true;
            this.comboBoxGg.Items.AddRange(new object[] {
            "Absorbing",
            "Periodic"});
            this.comboBoxGg.Location = new System.Drawing.Point(12, 233);
            this.comboBoxGg.Name = "comboBoxGg";
            this.comboBoxGg.Size = new System.Drawing.Size(121, 23);
            this.comboBoxGg.TabIndex = 15;
            this.comboBoxGg.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Boundary Condition:";
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(9, 468);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Save to file";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelSave
            // 
            this.labelSave.AutoSize = true;
            this.labelSave.Location = new System.Drawing.Point(18, 448);
            this.labelSave.Name = "labelSave";
            this.labelSave.Size = new System.Drawing.Size(0, 15);
            this.labelSave.TabIndex = 18;
            // 
            // FormGrainGrowth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 503);
            this.Controls.Add(this.labelSave);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxGg);
            this.Controls.Add(this.buttonGenerateGg);
            this.Controls.Add(this.buttonRunGg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownGrains);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSizeGg);
            this.Controls.Add(this.pictureBoxGg);
            this.Name = "FormGrainGrowth";
            this.Text = "FormGrainGrowth";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeGg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownGrains;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeGg;
        private System.Windows.Forms.Button buttonGenerateGg;
        private System.Windows.Forms.Button buttonRunGg;
        private System.Windows.Forms.ComboBox comboBoxGg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelSave;
    }
}