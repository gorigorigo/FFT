namespace _3DCAM
{
    partial class MrMurata
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
            this.button_FileOpen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ToolRadius = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Resolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EndScale = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ScalingFactor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_CalCenter = new System.Windows.Forms.Button();
            this.button_FFT = new System.Windows.Forms.Button();
            this.button_IFFT = new System.Windows.Forms.Button();
            this.button_AutoCorrelation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_FileOpen
            // 
            this.button_FileOpen.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_FileOpen.Location = new System.Drawing.Point(12, 12);
            this.button_FileOpen.Name = "button_FileOpen";
            this.button_FileOpen.Size = new System.Drawing.Size(131, 127);
            this.button_FileOpen.TabIndex = 0;
            this.button_FileOpen.Text = "File\r\nOpen";
            this.button_FileOpen.UseVisualStyleBackColor = true;
            this.button_FileOpen.Click += new System.EventHandler(this.button_FileOpen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ToolRadius);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Resolution);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 154);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ExperimentalConditions";
            // 
            // ToolRadius
            // 
            this.ToolRadius.FormattingEnabled = true;
            this.ToolRadius.Items.AddRange(new object[] {
            "0.5",
            "1.0",
            "1.5",
            "2.0",
            "2.5",
            "3.0",
            "3.5",
            "4.0"});
            this.ToolRadius.Location = new System.Drawing.Point(202, 94);
            this.ToolRadius.Name = "ToolRadius";
            this.ToolRadius.Size = new System.Drawing.Size(121, 33);
            this.ToolRadius.TabIndex = 3;
            this.ToolRadius.Text = "3";
            this.ToolRadius.TextChanged += new System.EventHandler(this.Resolution_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "ToolRadius";
            // 
            // Resolution
            // 
            this.Resolution.FormattingEnabled = true;
            this.Resolution.Items.AddRange(new object[] {
            "0.01",
            "0.02",
            "0.05",
            "0.1",
            "0.2",
            "0.5",
            "1.0"});
            this.Resolution.Location = new System.Drawing.Point(202, 48);
            this.Resolution.Name = "Resolution";
            this.Resolution.Size = new System.Drawing.Size(121, 33);
            this.Resolution.TabIndex = 1;
            this.Resolution.Text = "0.1";
            this.Resolution.TextChanged += new System.EventHandler(this.Resolution_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resolution";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EndScale);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ScalingFactor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 316);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 154);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CalCenterCondition";
            // 
            // EndScale
            // 
            this.EndScale.FormattingEnabled = true;
            this.EndScale.Items.AddRange(new object[] {
            "0.00001",
            "0.00002",
            "0.00005",
            "0.0001",
            "0.0002",
            "0.0005",
            "0.001",
            "0.002",
            "0.005",
            "0.01",
            "0.02",
            "0.05",
            "0.1",
            "0.2",
            "0.5"});
            this.EndScale.Location = new System.Drawing.Point(202, 94);
            this.EndScale.Name = "EndScale";
            this.EndScale.Size = new System.Drawing.Size(121, 33);
            this.EndScale.TabIndex = 3;
            this.EndScale.Text = "0.00005";
            this.EndScale.TextChanged += new System.EventHandler(this.Resolution_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "EndScale";
            // 
            // ScalingFactor
            // 
            this.ScalingFactor.FormattingEnabled = true;
            this.ScalingFactor.Items.AddRange(new object[] {
            "0.00001",
            "0.00002",
            "0.00005",
            "0.0001",
            "0.0002",
            "0.0005",
            "0.001",
            "0.002",
            "0.005",
            "0.01",
            "0.02",
            "0.05",
            "0.1",
            "0.2",
            "0.5"});
            this.ScalingFactor.Location = new System.Drawing.Point(202, 48);
            this.ScalingFactor.Name = "ScalingFactor";
            this.ScalingFactor.Size = new System.Drawing.Size(121, 33);
            this.ScalingFactor.TabIndex = 1;
            this.ScalingFactor.Text = "0.005";
            this.ScalingFactor.TextChanged += new System.EventHandler(this.Resolution_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "ScalingFactor";
            // 
            // button_CalCenter
            // 
            this.button_CalCenter.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CalCenter.Location = new System.Drawing.Point(149, 12);
            this.button_CalCenter.Name = "button_CalCenter";
            this.button_CalCenter.Size = new System.Drawing.Size(131, 127);
            this.button_CalCenter.TabIndex = 5;
            this.button_CalCenter.Text = "Calculate\r\nCenter";
            this.button_CalCenter.UseVisualStyleBackColor = true;
            this.button_CalCenter.Click += new System.EventHandler(this.button_CalCenter_Click);
            // 
            // button_FFT
            // 
            this.button_FFT.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_FFT.Location = new System.Drawing.Point(286, 12);
            this.button_FFT.Name = "button_FFT";
            this.button_FFT.Size = new System.Drawing.Size(131, 127);
            this.button_FFT.TabIndex = 6;
            this.button_FFT.Text = "FFT";
            this.button_FFT.UseVisualStyleBackColor = true;
            this.button_FFT.Click += new System.EventHandler(this.button_FFT_Click);
            // 
            // button_IFFT
            // 
            this.button_IFFT.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_IFFT.Location = new System.Drawing.Point(423, 12);
            this.button_IFFT.Name = "button_IFFT";
            this.button_IFFT.Size = new System.Drawing.Size(131, 127);
            this.button_IFFT.TabIndex = 7;
            this.button_IFFT.Text = "IFFT";
            this.button_IFFT.UseVisualStyleBackColor = true;
            this.button_IFFT.Click += new System.EventHandler(this.button_IFFT_Click);
            // 
            // button_AutoCorrelation
            // 
            this.button_AutoCorrelation.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AutoCorrelation.Location = new System.Drawing.Point(423, 145);
            this.button_AutoCorrelation.Name = "button_AutoCorrelation";
            this.button_AutoCorrelation.Size = new System.Drawing.Size(131, 127);
            this.button_AutoCorrelation.TabIndex = 8;
            this.button_AutoCorrelation.Text = "Auto\r\nCorrelation";
            this.button_AutoCorrelation.UseVisualStyleBackColor = true;
            this.button_AutoCorrelation.Click += new System.EventHandler(this.button_AutoCorrelation_Click);
            // 
            // MrMurata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 538);
            this.Controls.Add(this.button_AutoCorrelation);
            this.Controls.Add(this.button_IFFT);
            this.Controls.Add(this.button_FFT);
            this.Controls.Add(this.button_CalCenter);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_FileOpen);
            this.Name = "MrMurata";
            this.Text = "MrMurata";
            this.Load += new System.EventHandler(this.MrMurata_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_FileOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Resolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ToolRadius;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox EndScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ScalingFactor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_CalCenter;
        private System.Windows.Forms.Button button_FFT;
        private System.Windows.Forms.Button button_IFFT;
        private System.Windows.Forms.Button button_AutoCorrelation;
    }
}