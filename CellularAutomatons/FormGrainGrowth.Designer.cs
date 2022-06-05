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
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerateGg = new System.Windows.Forms.Button();
            this.buttonRunGg = new System.Windows.Forms.Button();
            this.comboBoxGg = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelSave = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxNeigh = new System.Windows.Forms.ComboBox();
            this.buttonPng = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxLocation = new System.Windows.Forms.ComboBox();
            this.labelTest = new System.Windows.Forms.Label();
            this.label789 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonRunMC = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownKt = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxN = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownSRXFrames = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownSRXAmount = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownBorderEnergy = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDownCenterEnergy = new System.Windows.Forms.NumericUpDown();
            this.buttonRunSRX = new System.Windows.Forms.Button();
            this.checkBoxEnergy = new System.Windows.Forms.CheckBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSRXFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSRXAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBorderEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterEnergy)).BeginInit();
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
            this.label3.Location = new System.Drawing.Point(11, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Grain amount:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // numericUpDownGrains
            // 
            this.numericUpDownGrains.Location = new System.Drawing.Point(11, 237);
            this.numericUpDownGrains.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownGrains.Name = "numericUpDownGrains";
            this.numericUpDownGrains.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownGrains.TabIndex = 11;
            this.numericUpDownGrains.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Width:";
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(11, 290);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownWidth.TabIndex = 9;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // buttonGenerateGg
            // 
            this.buttonGenerateGg.Location = new System.Drawing.Point(12, 387);
            this.buttonGenerateGg.Name = "buttonGenerateGg";
            this.buttonGenerateGg.Size = new System.Drawing.Size(120, 23);
            this.buttonGenerateGg.TabIndex = 14;
            this.buttonGenerateGg.Text = "Generate";
            this.buttonGenerateGg.UseVisualStyleBackColor = true;
            this.buttonGenerateGg.Click += new System.EventHandler(this.buttonGenerateGg_Click);
            // 
            // buttonRunGg
            // 
            this.buttonRunGg.Enabled = false;
            this.buttonRunGg.Location = new System.Drawing.Point(12, 416);
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
            this.comboBoxGg.Location = new System.Drawing.Point(10, 149);
            this.comboBoxGg.Name = "comboBoxGg";
            this.comboBoxGg.Size = new System.Drawing.Size(121, 23);
            this.comboBoxGg.TabIndex = 15;
            this.comboBoxGg.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Boundary Condition:";
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(12, 445);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Save to txt file";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelSave
            // 
            this.labelSave.AutoSize = true;
            this.labelSave.Location = new System.Drawing.Point(13, 368);
            this.labelSave.Name = "labelSave";
            this.labelSave.Size = new System.Drawing.Size(0, 15);
            this.labelSave.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Height:";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(11, 340);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownHeight.TabIndex = 19;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Neighbourhood:";
            // 
            // comboBoxNeigh
            // 
            this.comboBoxNeigh.FormattingEnabled = true;
            this.comboBoxNeigh.Items.AddRange(new object[] {
            "Von Neumann",
            "Moore",
            "Pentagonal",
            "Hexagonal"});
            this.comboBoxNeigh.Location = new System.Drawing.Point(10, 193);
            this.comboBoxNeigh.Name = "comboBoxNeigh";
            this.comboBoxNeigh.Size = new System.Drawing.Size(121, 23);
            this.comboBoxNeigh.TabIndex = 21;
            // 
            // buttonPng
            // 
            this.buttonPng.Enabled = false;
            this.buttonPng.Location = new System.Drawing.Point(12, 474);
            this.buttonPng.Name = "buttonPng";
            this.buttonPng.Size = new System.Drawing.Size(120, 23);
            this.buttonPng.TabIndex = 23;
            this.buttonPng.Text = "Save to png file";
            this.buttonPng.UseVisualStyleBackColor = true;
            this.buttonPng.Click += new System.EventHandler(this.buttonPng_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "Location:";
            // 
            // comboBoxLocation
            // 
            this.comboBoxLocation.FormattingEnabled = true;
            this.comboBoxLocation.Items.AddRange(new object[] {
            "Random",
            "Grid"});
            this.comboBoxLocation.Location = new System.Drawing.Point(10, 100);
            this.comboBoxLocation.Name = "comboBoxLocation";
            this.comboBoxLocation.Size = new System.Drawing.Size(121, 23);
            this.comboBoxLocation.TabIndex = 24;
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(696, 30);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(0, 15);
            this.labelTest.TabIndex = 26;
            // 
            // label789
            // 
            this.label789.AutoSize = true;
            this.label789.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label789.Location = new System.Drawing.Point(41, -2);
            this.label789.Name = "label789";
            this.label789.Size = new System.Drawing.Size(53, 37);
            this.label789.TabIndex = 27;
            this.label789.Text = "CA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(676, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 30);
            this.label7.TabIndex = 28;
            this.label7.Text = "Monte Carlo";
            // 
            // buttonRunMC
            // 
            this.buttonRunMC.Enabled = false;
            this.buttonRunMC.Location = new System.Drawing.Point(696, 94);
            this.buttonRunMC.Name = "buttonRunMC";
            this.buttonRunMC.Size = new System.Drawing.Size(121, 23);
            this.buttonRunMC.TabIndex = 29;
            this.buttonRunMC.Text = "Run";
            this.buttonRunMC.UseVisualStyleBackColor = true;
            this.buttonRunMC.Click += new System.EventHandler(this.buttonRunMC_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(691, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 15);
            this.label8.TabIndex = 31;
            this.label8.Text = "kt:";
            // 
            // numericUpDownKt
            // 
            this.numericUpDownKt.DecimalPlaces = 4;
            this.numericUpDownKt.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownKt.Location = new System.Drawing.Point(691, 65);
            this.numericUpDownKt.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownKt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownKt.Name = "numericUpDownKt";
            this.numericUpDownKt.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownKt.TabIndex = 30;
            this.numericUpDownKt.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(711, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 37);
            this.label9.TabIndex = 32;
            this.label9.Text = "SRX";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(689, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 15);
            this.label10.TabIndex = 34;
            this.label10.Text = "N";
            // 
            // comboBoxN
            // 
            this.comboBoxN.FormattingEnabled = true;
            this.comboBoxN.Items.AddRange(new object[] {
            "N once",
            "N every x frames"});
            this.comboBoxN.Location = new System.Drawing.Point(689, 218);
            this.comboBoxN.Name = "comboBoxN";
            this.comboBoxN.Size = new System.Drawing.Size(121, 23);
            this.comboBoxN.TabIndex = 33;
            this.comboBoxN.SelectedIndexChanged += new System.EventHandler(this.comboBoxN_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(689, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 15);
            this.label11.TabIndex = 36;
            this.label11.Text = "Every x frames";
            // 
            // numericUpDownSRXFrames
            // 
            this.numericUpDownSRXFrames.Location = new System.Drawing.Point(689, 303);
            this.numericUpDownSRXFrames.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownSRXFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSRXFrames.Name = "numericUpDownSRXFrames";
            this.numericUpDownSRXFrames.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownSRXFrames.TabIndex = 35;
            this.numericUpDownSRXFrames.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(689, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 15);
            this.label12.TabIndex = 38;
            this.label12.Text = "Grain amount:";
            // 
            // numericUpDownSRXAmount
            // 
            this.numericUpDownSRXAmount.Location = new System.Drawing.Point(689, 262);
            this.numericUpDownSRXAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSRXAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSRXAmount.Name = "numericUpDownSRXAmount";
            this.numericUpDownSRXAmount.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownSRXAmount.TabIndex = 37;
            this.numericUpDownSRXAmount.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(689, 340);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 15);
            this.label13.TabIndex = 40;
            this.label13.Text = "Border Energy:";
            // 
            // numericUpDownBorderEnergy
            // 
            this.numericUpDownBorderEnergy.Location = new System.Drawing.Point(689, 358);
            this.numericUpDownBorderEnergy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBorderEnergy.Name = "numericUpDownBorderEnergy";
            this.numericUpDownBorderEnergy.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownBorderEnergy.TabIndex = 39;
            this.numericUpDownBorderEnergy.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(689, 382);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 15);
            this.label14.TabIndex = 42;
            this.label14.Text = "Center Energy:";
            // 
            // numericUpDownCenterEnergy
            // 
            this.numericUpDownCenterEnergy.Location = new System.Drawing.Point(689, 400);
            this.numericUpDownCenterEnergy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCenterEnergy.Name = "numericUpDownCenterEnergy";
            this.numericUpDownCenterEnergy.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownCenterEnergy.TabIndex = 41;
            this.numericUpDownCenterEnergy.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // buttonRunSRX
            // 
            this.buttonRunSRX.Enabled = false;
            this.buttonRunSRX.Location = new System.Drawing.Point(689, 448);
            this.buttonRunSRX.Name = "buttonRunSRX";
            this.buttonRunSRX.Size = new System.Drawing.Size(121, 23);
            this.buttonRunSRX.TabIndex = 43;
            this.buttonRunSRX.Text = "Run";
            this.buttonRunSRX.UseVisualStyleBackColor = true;
            this.buttonRunSRX.Click += new System.EventHandler(this.buttonRunSRX_Click);
            // 
            // checkBoxEnergy
            // 
            this.checkBoxEnergy.AutoSize = true;
            this.checkBoxEnergy.Enabled = false;
            this.checkBoxEnergy.Location = new System.Drawing.Point(695, 131);
            this.checkBoxEnergy.Name = "checkBoxEnergy";
            this.checkBoxEnergy.Size = new System.Drawing.Size(94, 19);
            this.checkBoxEnergy.TabIndex = 44;
            this.checkBoxEnergy.Text = "Show energy";
            this.checkBoxEnergy.UseVisualStyleBackColor = true;
            this.checkBoxEnergy.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Normal",
            "Image"});
            this.comboBoxType.Location = new System.Drawing.Point(10, 56);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 23);
            this.comboBoxType.TabIndex = 45;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 15);
            this.label15.TabIndex = 46;
            this.label15.Text = "Simulation:";
            // 
            // FormGrainGrowth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 503);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.checkBoxEnergy);
            this.Controls.Add(this.buttonRunSRX);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numericUpDownCenterEnergy);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericUpDownBorderEnergy);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericUpDownSRXAmount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDownSRXFrames);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxN);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownKt);
            this.Controls.Add(this.buttonRunMC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label789);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxLocation);
            this.Controls.Add(this.buttonPng);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxNeigh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.labelSave);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxGg);
            this.Controls.Add(this.buttonGenerateGg);
            this.Controls.Add(this.buttonRunGg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownGrains);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.pictureBoxGg);
            this.Name = "FormGrainGrowth";
            this.Text = "FormGrainGrowth";
            this.Load += new System.EventHandler(this.FormGrainGrowth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSRXFrames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSRXAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBorderEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterEnergy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownGrains;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Button buttonGenerateGg;
        private System.Windows.Forms.Button buttonRunGg;
        private System.Windows.Forms.ComboBox comboBoxGg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownSRXFrames;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxNeigh;
        private System.Windows.Forms.Button buttonPng;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxLocation;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Label label789;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonRunMC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownKt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxN;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownSRXAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDownBorderEnergy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDownCenterEnergy;
        private System.Windows.Forms.Button buttonRunSRX;
        private System.Windows.Forms.CheckBox checkBoxEnergy;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label15;
    }
}