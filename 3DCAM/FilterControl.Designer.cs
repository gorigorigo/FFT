namespace _3DCAM
{
    partial class FilterControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_HSHF = new System.Windows.Forms.RadioButton();
            this.radioButton_APF = new System.Windows.Forms.RadioButton();
            this.radioButton_PKF = new System.Windows.Forms.RadioButton();
            this.radioButton_LSHF = new System.Windows.Forms.RadioButton();
            this.radioButton_NTF = new System.Windows.Forms.RadioButton();
            this.radioButton_HDPF = new System.Windows.Forms.RadioButton();
            this.radioButton_HPF = new System.Windows.Forms.RadioButton();
            this.radioButton_LPF = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CutOffFrequency = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BW = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QValue = new System.Windows.Forms.ComboBox();
            this.radioButton_DoFreFilt = new System.Windows.Forms.RadioButton();
            this.radioButtonDoTimeFilt = new System.Windows.Forms.RadioButton();
            this.button_DoFiltering = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Gain = new System.Windows.Forms.ComboBox();
            this.button_Initialize = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_HSHF);
            this.groupBox1.Controls.Add(this.radioButton_APF);
            this.groupBox1.Controls.Add(this.radioButton_PKF);
            this.groupBox1.Controls.Add(this.radioButton_LSHF);
            this.groupBox1.Controls.Add(this.radioButton_NTF);
            this.groupBox1.Controls.Add(this.radioButton_HDPF);
            this.groupBox1.Controls.Add(this.radioButton_HPF);
            this.groupBox1.Controls.Add(this.radioButton_LPF);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(405, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "時間軸フィルタリング";
            // 
            // radioButton_HSHF
            // 
            this.radioButton_HSHF.AutoSize = true;
            this.radioButton_HSHF.Location = new System.Drawing.Point(242, 94);
            this.radioButton_HSHF.Name = "radioButton_HSHF";
            this.radioButton_HSHF.Size = new System.Drawing.Size(182, 29);
            this.radioButton_HSHF.TabIndex = 7;
            this.radioButton_HSHF.Text = "ハイシェルフィルタ";
            this.radioButton_HSHF.UseVisualStyleBackColor = true;
            // 
            // radioButton_APF
            // 
            this.radioButton_APF.AutoSize = true;
            this.radioButton_APF.Location = new System.Drawing.Point(242, 192);
            this.radioButton_APF.Name = "radioButton_APF";
            this.radioButton_APF.Size = new System.Drawing.Size(186, 29);
            this.radioButton_APF.TabIndex = 6;
            this.radioButton_APF.Text = "オールパスフィルタ";
            this.radioButton_APF.UseVisualStyleBackColor = true;
            // 
            // radioButton_PKF
            // 
            this.radioButton_PKF.AutoSize = true;
            this.radioButton_PKF.Location = new System.Drawing.Point(242, 144);
            this.radioButton_PKF.Name = "radioButton_PKF";
            this.radioButton_PKF.Size = new System.Drawing.Size(184, 29);
            this.radioButton_PKF.TabIndex = 5;
            this.radioButton_PKF.Text = "ピーキングフィルタ";
            this.radioButton_PKF.UseVisualStyleBackColor = true;
            // 
            // radioButton_LSHF
            // 
            this.radioButton_LSHF.AutoSize = true;
            this.radioButton_LSHF.Location = new System.Drawing.Point(242, 48);
            this.radioButton_LSHF.Name = "radioButton_LSHF";
            this.radioButton_LSHF.Size = new System.Drawing.Size(181, 29);
            this.radioButton_LSHF.TabIndex = 4;
            this.radioButton_LSHF.Text = "ローシェルフィルタ";
            this.radioButton_LSHF.UseVisualStyleBackColor = true;
            // 
            // radioButton_NTF
            // 
            this.radioButton_NTF.AutoSize = true;
            this.radioButton_NTF.Location = new System.Drawing.Point(19, 192);
            this.radioButton_NTF.Name = "radioButton_NTF";
            this.radioButton_NTF.Size = new System.Drawing.Size(146, 29);
            this.radioButton_NTF.TabIndex = 3;
            this.radioButton_NTF.Text = "ノッチフィルタ";
            this.radioButton_NTF.UseVisualStyleBackColor = true;
            // 
            // radioButton_HDPF
            // 
            this.radioButton_HDPF.AutoSize = true;
            this.radioButton_HDPF.Location = new System.Drawing.Point(19, 144);
            this.radioButton_HDPF.Name = "radioButton_HDPF";
            this.radioButton_HDPF.Size = new System.Drawing.Size(185, 29);
            this.radioButton_HDPF.TabIndex = 2;
            this.radioButton_HDPF.Text = "ハンドパスフィルタ";
            this.radioButton_HDPF.UseVisualStyleBackColor = true;
            // 
            // radioButton_HPF
            // 
            this.radioButton_HPF.AutoSize = true;
            this.radioButton_HPF.Location = new System.Drawing.Point(19, 94);
            this.radioButton_HPF.Name = "radioButton_HPF";
            this.radioButton_HPF.Size = new System.Drawing.Size(169, 29);
            this.radioButton_HPF.TabIndex = 1;
            this.radioButton_HPF.Text = "ハイパスフィルタ";
            this.radioButton_HPF.UseVisualStyleBackColor = true;
            // 
            // radioButton_LPF
            // 
            this.radioButton_LPF.AutoSize = true;
            this.radioButton_LPF.Checked = true;
            this.radioButton_LPF.Location = new System.Drawing.Point(19, 48);
            this.radioButton_LPF.Name = "radioButton_LPF";
            this.radioButton_LPF.Size = new System.Drawing.Size(168, 29);
            this.radioButton_LPF.TabIndex = 0;
            this.radioButton_LPF.TabStop = true;
            this.radioButton_LPF.Text = "ローパスフィルタ";
            this.radioButton_LPF.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(407, 282);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 140);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "周波数フィルタリング";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "カットオフ周波数";
            // 
            // CutOffFrequency
            // 
            this.CutOffFrequency.FormattingEnabled = true;
            this.CutOffFrequency.Items.AddRange(new object[] {
            "1000",
            "2000",
            "3000",
            "4000",
            "5000",
            "10000",
            "20000",
            "30000",
            "40000",
            "50000",
            "100000",
            "200000",
            "500000"});
            this.CutOffFrequency.Location = new System.Drawing.Point(227, 115);
            this.CutOffFrequency.Name = "CutOffFrequency";
            this.CutOffFrequency.Size = new System.Drawing.Size(121, 33);
            this.CutOffFrequency.TabIndex = 3;
            this.CutOffFrequency.Text = "1000";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.Gain);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.BW);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.QValue);
            this.groupBox3.Controls.Add(this.radioButton_DoFreFilt);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.radioButtonDoTimeFilt);
            this.groupBox3.Controls.Add(this.CutOffFrequency);
            this.groupBox3.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(23, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 302);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "フィルタリング条件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "帯域幅";
            // 
            // BW
            // 
            this.BW.FormattingEnabled = true;
            this.BW.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1.0",
            "1.1",
            "1.2",
            "1.3",
            "1.5",
            "2.0",
            "3.0",
            "5.0"});
            this.BW.Location = new System.Drawing.Point(227, 203);
            this.BW.Name = "BW";
            this.BW.Size = new System.Drawing.Size(121, 33);
            this.BW.TabIndex = 13;
            this.BW.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Q値";
            // 
            // QValue
            // 
            this.QValue.FormattingEnabled = true;
            this.QValue.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1.0",
            "1.1",
            "1.2",
            "1.3",
            "1.5",
            "2.0",
            "3.0",
            "5.0"});
            this.QValue.Location = new System.Drawing.Point(227, 159);
            this.QValue.Name = "QValue";
            this.QValue.Size = new System.Drawing.Size(121, 33);
            this.QValue.TabIndex = 11;
            this.QValue.Text = "1";
            // 
            // radioButton_DoFreFilt
            // 
            this.radioButton_DoFreFilt.AutoSize = true;
            this.radioButton_DoFreFilt.Location = new System.Drawing.Point(10, 68);
            this.radioButton_DoFreFilt.Name = "radioButton_DoFreFilt";
            this.radioButton_DoFreFilt.Size = new System.Drawing.Size(210, 29);
            this.radioButton_DoFreFilt.TabIndex = 9;
            this.radioButton_DoFreFilt.Text = "周波数フィルタリング";
            this.radioButton_DoFreFilt.UseVisualStyleBackColor = true;
            // 
            // radioButtonDoTimeFilt
            // 
            this.radioButtonDoTimeFilt.AutoSize = true;
            this.radioButtonDoTimeFilt.Checked = true;
            this.radioButtonDoTimeFilt.Location = new System.Drawing.Point(10, 33);
            this.radioButtonDoTimeFilt.Name = "radioButtonDoTimeFilt";
            this.radioButtonDoTimeFilt.Size = new System.Drawing.Size(210, 29);
            this.radioButtonDoTimeFilt.TabIndex = 8;
            this.radioButtonDoTimeFilt.TabStop = true;
            this.radioButtonDoTimeFilt.Text = "時間軸フィルタリング";
            this.radioButtonDoTimeFilt.UseVisualStyleBackColor = true;
            // 
            // button_DoFiltering
            // 
            this.button_DoFiltering.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DoFiltering.Location = new System.Drawing.Point(23, 22);
            this.button_DoFiltering.Name = "button_DoFiltering";
            this.button_DoFiltering.Size = new System.Drawing.Size(183, 83);
            this.button_DoFiltering.TabIndex = 3;
            this.button_DoFiltering.Text = "フィルタリング";
            this.button_DoFiltering.UseVisualStyleBackColor = true;
            this.button_DoFiltering.Click += new System.EventHandler(this.button_DoFiltering_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "増幅量";
            // 
            // Gain
            // 
            this.Gain.FormattingEnabled = true;
            this.Gain.Items.AddRange(new object[] {
            "-30",
            "-20",
            "-15",
            "-10",
            "-5",
            "0",
            "5",
            "10",
            "15",
            "20",
            "30"});
            this.Gain.Location = new System.Drawing.Point(227, 247);
            this.Gain.Name = "Gain";
            this.Gain.Size = new System.Drawing.Size(121, 33);
            this.Gain.TabIndex = 15;
            this.Gain.Text = "15";
            // 
            // button_Initialize
            // 
            this.button_Initialize.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Initialize.Location = new System.Drawing.Point(212, 22);
            this.button_Initialize.Name = "button_Initialize";
            this.button_Initialize.Size = new System.Drawing.Size(183, 83);
            this.button_Initialize.TabIndex = 4;
            this.button_Initialize.Text = "初期化";
            this.button_Initialize.UseVisualStyleBackColor = true;
            this.button_Initialize.Click += new System.EventHandler(this.button_Initialize_Click);
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(918, 430);
            this.Controls.Add(this.button_Initialize);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_DoFiltering);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "FilterControl";
            this.Text = "FilterControl";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_HSHF;
        private System.Windows.Forms.RadioButton radioButton_APF;
        private System.Windows.Forms.RadioButton radioButton_PKF;
        private System.Windows.Forms.RadioButton radioButton_LSHF;
        private System.Windows.Forms.RadioButton radioButton_NTF;
        private System.Windows.Forms.RadioButton radioButton_HDPF;
        private System.Windows.Forms.RadioButton radioButton_HPF;
        private System.Windows.Forms.RadioButton radioButton_LPF;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CutOffFrequency;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox BW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox QValue;
        private System.Windows.Forms.Button button_DoFiltering;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Gain;
        public System.Windows.Forms.RadioButton radioButton_DoFreFilt;
        public System.Windows.Forms.RadioButton radioButtonDoTimeFilt;
        private System.Windows.Forms.Button button_Initialize;
    }
}