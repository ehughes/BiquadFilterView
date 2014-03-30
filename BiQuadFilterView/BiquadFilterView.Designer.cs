namespace WindowsFormsApplication1
{
    partial class BiquadFilterView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BiquadFilterView));
            this.FilterTypeCB = new System.Windows.Forms.ComboBox();
            this.f0_NUD = new System.Windows.Forms.NumericUpDown();
            this.f0_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SampleRate_NUD = new System.Windows.Forms.NumericUpDown();
            this.Q_NUD = new System.Windows.Forms.NumericUpDown();
            this.dbGain_NUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FilterSpec_TB = new System.Windows.Forms.TextBox();
            this.FreqResponsePlot = new OxyPlot.WindowsForms.Plot();
            this.DisplayGuiarStringReferencesCheckBox = new System.Windows.Forms.CheckBox();
            this.DisplayPhaseCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.f0_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleRate_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Q_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGain_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // FilterTypeCB
            // 
            this.FilterTypeCB.FormattingEnabled = true;
            this.FilterTypeCB.Location = new System.Drawing.Point(19, 54);
            this.FilterTypeCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FilterTypeCB.Name = "FilterTypeCB";
            this.FilterTypeCB.Size = new System.Drawing.Size(377, 23);
            this.FilterTypeCB.TabIndex = 0;
            this.FilterTypeCB.SelectedIndexChanged += new System.EventHandler(this.FilterTypeCB_SelectedIndexChanged);
            // 
            // f0_NUD
            // 
            this.f0_NUD.Location = new System.Drawing.Point(19, 103);
            this.f0_NUD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.f0_NUD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.f0_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.f0_NUD.Name = "f0_NUD";
            this.f0_NUD.Size = new System.Drawing.Size(160, 21);
            this.f0_NUD.TabIndex = 1;
            this.f0_NUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.f0_NUD.ValueChanged += new System.EventHandler(this.f0_NUD_ValueChanged);
            // 
            // f0_Label
            // 
            this.f0_Label.AutoSize = true;
            this.f0_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f0_Label.Location = new System.Drawing.Point(19, 85);
            this.f0_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.f0_Label.Name = "f0_Label";
            this.f0_Label.Size = new System.Drawing.Size(19, 15);
            this.f0_Label.TabIndex = 2;
            this.f0_Label.Text = "f0";
            this.f0_Label.Click += new System.EventHandler(this.f0_Label_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sample Rate";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SampleRate_NUD
            // 
            this.SampleRate_NUD.Location = new System.Drawing.Point(233, 103);
            this.SampleRate_NUD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SampleRate_NUD.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.SampleRate_NUD.Name = "SampleRate_NUD";
            this.SampleRate_NUD.Size = new System.Drawing.Size(160, 21);
            this.SampleRate_NUD.TabIndex = 3;
            this.SampleRate_NUD.TabStop = false;
            this.SampleRate_NUD.Value = new decimal(new int[] {
            24000,
            0,
            0,
            0});
            this.SampleRate_NUD.ValueChanged += new System.EventHandler(this.SampleRate_NUD_ValueChanged);
            // 
            // Q_NUD
            // 
            this.Q_NUD.DecimalPlaces = 1;
            this.Q_NUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Q_NUD.Location = new System.Drawing.Point(19, 154);
            this.Q_NUD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Q_NUD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Q_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Q_NUD.Name = "Q_NUD";
            this.Q_NUD.Size = new System.Drawing.Size(160, 21);
            this.Q_NUD.TabIndex = 5;
            this.Q_NUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.Q_NUD.ValueChanged += new System.EventHandler(this.Q_NUD_ValueChanged);
            // 
            // dbGain_NUD
            // 
            this.dbGain_NUD.Location = new System.Drawing.Point(233, 154);
            this.dbGain_NUD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dbGain_NUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.dbGain_NUD.Name = "dbGain_NUD";
            this.dbGain_NUD.Size = new System.Drawing.Size(160, 21);
            this.dbGain_NUD.TabIndex = 6;
            this.dbGain_NUD.ValueChanged += new System.EventHandler(this.dbGain_NUD_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Q";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(230, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "dbGain";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FilterSpec_TB
            // 
            this.FilterSpec_TB.Location = new System.Drawing.Point(416, 12);
            this.FilterSpec_TB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FilterSpec_TB.Multiline = true;
            this.FilterSpec_TB.Name = "FilterSpec_TB";
            this.FilterSpec_TB.Size = new System.Drawing.Size(589, 163);
            this.FilterSpec_TB.TabIndex = 9;
            // 
            // FreqResponsePlot
            // 
            this.FreqResponsePlot.KeyboardPanHorizontalStep = 0.1D;
            this.FreqResponsePlot.KeyboardPanVerticalStep = 0.1D;
            this.FreqResponsePlot.Location = new System.Drawing.Point(7, 181);
            this.FreqResponsePlot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FreqResponsePlot.Name = "FreqResponsePlot";
            this.FreqResponsePlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.FreqResponsePlot.Size = new System.Drawing.Size(1240, 409);
            this.FreqResponsePlot.TabIndex = 10;
            this.FreqResponsePlot.Text = "plot1";
            this.FreqResponsePlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.FreqResponsePlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.FreqResponsePlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // DisplayGuiarStringReferencesCheckBox
            // 
            this.DisplayGuiarStringReferencesCheckBox.AutoSize = true;
            this.DisplayGuiarStringReferencesCheckBox.Checked = true;
            this.DisplayGuiarStringReferencesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisplayGuiarStringReferencesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayGuiarStringReferencesCheckBox.Location = new System.Drawing.Point(1012, 14);
            this.DisplayGuiarStringReferencesCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DisplayGuiarStringReferencesCheckBox.Name = "DisplayGuiarStringReferencesCheckBox";
            this.DisplayGuiarStringReferencesCheckBox.Size = new System.Drawing.Size(235, 19);
            this.DisplayGuiarStringReferencesCheckBox.TabIndex = 11;
            this.DisplayGuiarStringReferencesCheckBox.Text = "Display Guitar String References";
            this.DisplayGuiarStringReferencesCheckBox.UseVisualStyleBackColor = true;
            this.DisplayGuiarStringReferencesCheckBox.CheckedChanged += new System.EventHandler(this.DisplayGuiarStringReferencesCheckBox_CheckedChanged);
            // 
            // DisplayPhaseCheckBox
            // 
            this.DisplayPhaseCheckBox.AutoSize = true;
            this.DisplayPhaseCheckBox.Checked = true;
            this.DisplayPhaseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisplayPhaseCheckBox.Location = new System.Drawing.Point(1012, 39);
            this.DisplayPhaseCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DisplayPhaseCheckBox.Name = "DisplayPhaseCheckBox";
            this.DisplayPhaseCheckBox.Size = new System.Drawing.Size(117, 19);
            this.DisplayPhaseCheckBox.TabIndex = 12;
            this.DisplayPhaseCheckBox.Text = "Display Phase";
            this.DisplayPhaseCheckBox.UseVisualStyleBackColor = true;
            this.DisplayPhaseCheckBox.CheckedChanged += new System.EventHandler(this.DisplayPhaseCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "BiQuad Filter Type";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(18, 12);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(345, 15);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.musicdsp.org/files/Audio-EQ-Cookbook.txt";
            // 
            // BiquadFilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 599);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DisplayPhaseCheckBox);
            this.Controls.Add(this.DisplayGuiarStringReferencesCheckBox);
            this.Controls.Add(this.FreqResponsePlot);
            this.Controls.Add(this.FilterSpec_TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dbGain_NUD);
            this.Controls.Add(this.Q_NUD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SampleRate_NUD);
            this.Controls.Add(this.f0_Label);
            this.Controls.Add(this.f0_NUD);
            this.Controls.Add(this.FilterTypeCB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1285, 638);
            this.Name = "BiquadFilterView";
            this.Text = "BiquadFilterView - 1.00";
            this.Load += new System.EventHandler(this.BiquadFilterView_Load);
            this.Resize += new System.EventHandler(this.BiquadFilterView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.f0_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleRate_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Q_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGain_NUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FilterTypeCB;
        private System.Windows.Forms.NumericUpDown f0_NUD;
        private System.Windows.Forms.Label f0_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown SampleRate_NUD;
        private System.Windows.Forms.NumericUpDown Q_NUD;
        private System.Windows.Forms.NumericUpDown dbGain_NUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FilterSpec_TB;
        private OxyPlot.WindowsForms.Plot FreqResponsePlot;
        private System.Windows.Forms.CheckBox DisplayGuiarStringReferencesCheckBox;
        private System.Windows.Forms.CheckBox DisplayPhaseCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

