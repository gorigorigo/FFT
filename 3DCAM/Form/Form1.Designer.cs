namespace _3DCAM
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.glControl1 = new OpenTK.GLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label_Coordinate = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Controler = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.checkBox_ChangeAnalysisRange = new System.Windows.Forms.CheckBox();
            this.StartPosition = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.EndPosition = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TotalNumber = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DivisionNumber = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Filtering = new System.Windows.Forms.Button();
            this.button_OutputFile = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radioButton_HamingWindow = new System.Windows.Forms.RadioButton();
            this.radioButton_LectangleWindow = new System.Windows.Forms.RadioButton();
            this.radioButton_BlackManWindow = new System.Windows.Forms.RadioButton();
            this.radioButton_HaningWindow = new System.Windows.Forms.RadioButton();
            this.radioButton_NoWindow = new System.Windows.Forms.RadioButton();
            this.button_IFFT = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButton_ParcialAnalysis = new System.Windows.Forms.RadioButton();
            this.radioButtonAllAnalysis = new System.Windows.Forms.RadioButton();
            this.button_FFT = new System.Windows.Forms.Button();
            this.button_FileOpen = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton_StepFrequency = new System.Windows.Forms.RadioButton();
            this.radioButton_RandomFrequency = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton_AmpTrans = new System.Windows.Forms.RadioButton();
            this.radioButton_AmpConst = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.MaxFreaquency = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.KindOfWaves = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DCBias = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SamplingFrequency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TheNumberOfSampling = new System.Windows.Forms.ComboBox();
            this.button_DecideFrequency = new System.Windows.Forms.Button();
            this.dataGridView_WaveFrewuency = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton_Parcial = new System.Windows.Forms.RadioButton();
            this.radioButton_FullIn = new System.Windows.Forms.RadioButton();
            this.button_CreateWave = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioButton_English = new System.Windows.Forms.RadioButton();
            this.radioButton_Japanese = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WaveFrewuency)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.glControl1);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 1200);
            this.panel1.TabIndex = 0;
            // 
            // glControl1
            // 
            this.glControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(7, 6);
            this.glControl1.Margin = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1185, 1188);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1359, 1278);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label_Coordinate);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Size = new System.Drawing.Size(1343, 1231);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "2次元";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_Coordinate
            // 
            this.label_Coordinate.AutoSize = true;
            this.label_Coordinate.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Coordinate.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_Coordinate.Location = new System.Drawing.Point(869, 44);
            this.label_Coordinate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Coordinate.Name = "label_Coordinate";
            this.label_Coordinate.Size = new System.Drawing.Size(75, 34);
            this.label_Coordinate.TabIndex = 1;
            this.label_Coordinate.Text = "座標";
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(13, 12);
            this.chart1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1300, 1200);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage2.Size = new System.Drawing.Size(1343, 1231);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OpenGL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage3.Size = new System.Drawing.Size(1343, 1231);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Controler);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button_Filtering);
            this.groupBox1.Controls.Add(this.button_OutputFile);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.button_IFFT);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.button_FFT);
            this.groupBox1.Controls.Add(this.button_FileOpen);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1385, 130);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox1.Size = new System.Drawing.Size(1079, 544);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ソフト機能";
            // 
            // button_Controler
            // 
            this.button_Controler.Location = new System.Drawing.Point(775, 386);
            this.button_Controler.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_Controler.Name = "button_Controler";
            this.button_Controler.Size = new System.Drawing.Size(163, 150);
            this.button_Controler.TabIndex = 18;
            this.button_Controler.Text = "コントローラ";
            this.button_Controler.UseVisualStyleBackColor = true;
            this.button_Controler.Click += new System.EventHandler(this.button_Controler_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.checkBox_ChangeAnalysisRange);
            this.groupBox9.Controls.Add(this.StartPosition);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.EndPosition);
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(this.TotalNumber);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.DivisionNumber);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Location = new System.Drawing.Point(425, 62);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox9.Size = new System.Drawing.Size(336, 312);
            this.groupBox9.TabIndex = 17;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "FFT解析設定";
            // 
            // checkBox_ChangeAnalysisRange
            // 
            this.checkBox_ChangeAnalysisRange.AutoSize = true;
            this.checkBox_ChangeAnalysisRange.Location = new System.Drawing.Point(10, 254);
            this.checkBox_ChangeAnalysisRange.Name = "checkBox_ChangeAnalysisRange";
            this.checkBox_ChangeAnalysisRange.Size = new System.Drawing.Size(187, 29);
            this.checkBox_ChangeAnalysisRange.TabIndex = 23;
            this.checkBox_ChangeAnalysisRange.Text = "解析区間の変更";
            this.checkBox_ChangeAnalysisRange.UseVisualStyleBackColor = true;
            this.checkBox_ChangeAnalysisRange.CheckedChanged += new System.EventHandler(this.StartPosition_TextChanged);
            // 
            // StartPosition
            // 
            this.StartPosition.FormattingEnabled = true;
            this.StartPosition.Items.AddRange(new object[] {
            "1024",
            "2048",
            "4096",
            "8192",
            "16384",
            "32768",
            "65536",
            "131072",
            "262144",
            "524288",
            "1048576",
            "2097152",
            "4194304"});
            this.StartPosition.Location = new System.Drawing.Point(150, 136);
            this.StartPosition.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.StartPosition.Name = "StartPosition";
            this.StartPosition.Size = new System.Drawing.Size(171, 33);
            this.StartPosition.TabIndex = 21;
            this.StartPosition.Text = "2048";
            this.StartPosition.TextChanged += new System.EventHandler(this.StartPosition_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 140);
            this.label9.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "開始行";
            // 
            // EndPosition
            // 
            this.EndPosition.FormattingEnabled = true;
            this.EndPosition.Items.AddRange(new object[] {
            "1024",
            "2048",
            "4096",
            "8192",
            "16384",
            "32768",
            "65536",
            "131072",
            "262144",
            "524288",
            "1048576",
            "2097152",
            "4194304"});
            this.EndPosition.Location = new System.Drawing.Point(150, 184);
            this.EndPosition.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.EndPosition.Name = "EndPosition";
            this.EndPosition.Size = new System.Drawing.Size(171, 33);
            this.EndPosition.TabIndex = 19;
            this.EndPosition.Text = "1048576";
            this.EndPosition.TextChanged += new System.EventHandler(this.StartPosition_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 190);
            this.label10.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "終了行";
            // 
            // TotalNumber
            // 
            this.TotalNumber.FormattingEnabled = true;
            this.TotalNumber.Items.AddRange(new object[] {
            "1024",
            "2048",
            "4096",
            "8192",
            "16384",
            "32768",
            "65536"});
            this.TotalNumber.Location = new System.Drawing.Point(150, 40);
            this.TotalNumber.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TotalNumber.Name = "TotalNumber";
            this.TotalNumber.Size = new System.Drawing.Size(171, 33);
            this.TotalNumber.TabIndex = 17;
            this.TotalNumber.Text = "2048";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 25);
            this.label8.TabIndex = 18;
            this.label8.Text = "全体行数";
            // 
            // DivisionNumber
            // 
            this.DivisionNumber.FormattingEnabled = true;
            this.DivisionNumber.Items.AddRange(new object[] {
            "1024",
            "2048",
            "4096",
            "8192",
            "16384",
            "32768",
            "65536"});
            this.DivisionNumber.Location = new System.Drawing.Point(150, 88);
            this.DivisionNumber.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.DivisionNumber.Name = "DivisionNumber";
            this.DivisionNumber.Size = new System.Drawing.Size(171, 33);
            this.DivisionNumber.TabIndex = 15;
            this.DivisionNumber.Text = "2048";
            this.DivisionNumber.TextChanged += new System.EventHandler(this.DivisionNumber_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 94);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "分割数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(639, 104);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 16;
            // 
            // button_Filtering
            // 
            this.button_Filtering.Location = new System.Drawing.Point(598, 386);
            this.button_Filtering.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_Filtering.Name = "button_Filtering";
            this.button_Filtering.Size = new System.Drawing.Size(163, 150);
            this.button_Filtering.TabIndex = 6;
            this.button_Filtering.Text = "フィルタ";
            this.button_Filtering.UseVisualStyleBackColor = true;
            this.button_Filtering.Click += new System.EventHandler(this.button_Filtering_Click);
            // 
            // button_OutputFile
            // 
            this.button_OutputFile.Location = new System.Drawing.Point(423, 386);
            this.button_OutputFile.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_OutputFile.Name = "button_OutputFile";
            this.button_OutputFile.Size = new System.Drawing.Size(163, 150);
            this.button_OutputFile.TabIndex = 5;
            this.button_OutputFile.Text = "アウトプットファイル";
            this.button_OutputFile.UseVisualStyleBackColor = true;
            this.button_OutputFile.Click += new System.EventHandler(this.button_OutputFile_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.radioButton_HamingWindow);
            this.groupBox8.Controls.Add(this.radioButton_LectangleWindow);
            this.groupBox8.Controls.Add(this.radioButton_BlackManWindow);
            this.groupBox8.Controls.Add(this.radioButton_HaningWindow);
            this.groupBox8.Controls.Add(this.radioButton_NoWindow);
            this.groupBox8.Location = new System.Drawing.Point(189, 224);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox8.Size = new System.Drawing.Size(228, 312);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "窓関数";
            // 
            // radioButton_HamingWindow
            // 
            this.radioButton_HamingWindow.AutoSize = true;
            this.radioButton_HamingWindow.Location = new System.Drawing.Point(11, 92);
            this.radioButton_HamingWindow.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_HamingWindow.Name = "radioButton_HamingWindow";
            this.radioButton_HamingWindow.Size = new System.Drawing.Size(127, 29);
            this.radioButton_HamingWindow.TabIndex = 4;
            this.radioButton_HamingWindow.Text = "ハミング窓";
            this.radioButton_HamingWindow.UseVisualStyleBackColor = true;
            this.radioButton_HamingWindow.CheckedChanged += new System.EventHandler(this.radioButton_NoWindow_CheckedChanged);
            // 
            // radioButton_LectangleWindow
            // 
            this.radioButton_LectangleWindow.AutoSize = true;
            this.radioButton_LectangleWindow.Location = new System.Drawing.Point(11, 254);
            this.radioButton_LectangleWindow.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_LectangleWindow.Name = "radioButton_LectangleWindow";
            this.radioButton_LectangleWindow.Size = new System.Drawing.Size(159, 29);
            this.radioButton_LectangleWindow.TabIndex = 3;
            this.radioButton_LectangleWindow.Text = "レクタングル窓";
            this.radioButton_LectangleWindow.UseVisualStyleBackColor = true;
            this.radioButton_LectangleWindow.CheckedChanged += new System.EventHandler(this.radioButton_NoWindow_CheckedChanged);
            // 
            // radioButton_BlackManWindow
            // 
            this.radioButton_BlackManWindow.AutoSize = true;
            this.radioButton_BlackManWindow.Location = new System.Drawing.Point(11, 200);
            this.radioButton_BlackManWindow.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_BlackManWindow.Name = "radioButton_BlackManWindow";
            this.radioButton_BlackManWindow.Size = new System.Drawing.Size(155, 29);
            this.radioButton_BlackManWindow.TabIndex = 2;
            this.radioButton_BlackManWindow.Text = "ブラックマン窓";
            this.radioButton_BlackManWindow.UseVisualStyleBackColor = true;
            this.radioButton_BlackManWindow.CheckedChanged += new System.EventHandler(this.radioButton_NoWindow_CheckedChanged);
            // 
            // radioButton_HaningWindow
            // 
            this.radioButton_HaningWindow.AutoSize = true;
            this.radioButton_HaningWindow.Location = new System.Drawing.Point(11, 146);
            this.radioButton_HaningWindow.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_HaningWindow.Name = "radioButton_HaningWindow";
            this.radioButton_HaningWindow.Size = new System.Drawing.Size(130, 29);
            this.radioButton_HaningWindow.TabIndex = 1;
            this.radioButton_HaningWindow.Text = "ハニング窓";
            this.radioButton_HaningWindow.UseVisualStyleBackColor = true;
            this.radioButton_HaningWindow.CheckedChanged += new System.EventHandler(this.radioButton_NoWindow_CheckedChanged);
            // 
            // radioButton_NoWindow
            // 
            this.radioButton_NoWindow.AutoSize = true;
            this.radioButton_NoWindow.Checked = true;
            this.radioButton_NoWindow.Location = new System.Drawing.Point(11, 38);
            this.radioButton_NoWindow.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_NoWindow.Name = "radioButton_NoWindow";
            this.radioButton_NoWindow.Size = new System.Drawing.Size(76, 29);
            this.radioButton_NoWindow.TabIndex = 0;
            this.radioButton_NoWindow.TabStop = true;
            this.radioButton_NoWindow.Text = "なし";
            this.radioButton_NoWindow.UseVisualStyleBackColor = true;
            this.radioButton_NoWindow.CheckedChanged += new System.EventHandler(this.radioButton_NoWindow_CheckedChanged);
            // 
            // button_IFFT
            // 
            this.button_IFFT.Location = new System.Drawing.Point(13, 386);
            this.button_IFFT.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_IFFT.Name = "button_IFFT";
            this.button_IFFT.Size = new System.Drawing.Size(163, 150);
            this.button_IFFT.TabIndex = 4;
            this.button_IFFT.Text = "IFFT";
            this.button_IFFT.UseVisualStyleBackColor = true;
            this.button_IFFT.Click += new System.EventHandler(this.button_IFFT_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButton_ParcialAnalysis);
            this.groupBox6.Controls.Add(this.radioButtonAllAnalysis);
            this.groupBox6.Location = new System.Drawing.Point(189, 62);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox6.Size = new System.Drawing.Size(228, 150);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "FFT解析種類";
            // 
            // radioButton_ParcialAnalysis
            // 
            this.radioButton_ParcialAnalysis.AutoSize = true;
            this.radioButton_ParcialAnalysis.Location = new System.Drawing.Point(13, 88);
            this.radioButton_ParcialAnalysis.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_ParcialAnalysis.Name = "radioButton_ParcialAnalysis";
            this.radioButton_ParcialAnalysis.Size = new System.Drawing.Size(85, 29);
            this.radioButton_ParcialAnalysis.TabIndex = 1;
            this.radioButton_ParcialAnalysis.Text = "分割";
            this.radioButton_ParcialAnalysis.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllAnalysis
            // 
            this.radioButtonAllAnalysis.AutoSize = true;
            this.radioButtonAllAnalysis.Checked = true;
            this.radioButtonAllAnalysis.Location = new System.Drawing.Point(13, 38);
            this.radioButtonAllAnalysis.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButtonAllAnalysis.Name = "radioButtonAllAnalysis";
            this.radioButtonAllAnalysis.Size = new System.Drawing.Size(81, 29);
            this.radioButtonAllAnalysis.TabIndex = 0;
            this.radioButtonAllAnalysis.TabStop = true;
            this.radioButtonAllAnalysis.Text = "全て";
            this.radioButtonAllAnalysis.UseVisualStyleBackColor = true;
            // 
            // button_FFT
            // 
            this.button_FFT.Location = new System.Drawing.Point(13, 224);
            this.button_FFT.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_FFT.Name = "button_FFT";
            this.button_FFT.Size = new System.Drawing.Size(163, 150);
            this.button_FFT.TabIndex = 1;
            this.button_FFT.Text = "FFT";
            this.button_FFT.UseVisualStyleBackColor = true;
            this.button_FFT.Click += new System.EventHandler(this.button_FFT_Click);
            // 
            // button_FileOpen
            // 
            this.button_FileOpen.Location = new System.Drawing.Point(13, 62);
            this.button_FileOpen.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_FileOpen.Name = "button_FileOpen";
            this.button_FileOpen.Size = new System.Drawing.Size(163, 150);
            this.button_FileOpen.TabIndex = 0;
            this.button_FileOpen.Text = "ファイル\r\nオープン";
            this.button_FileOpen.UseVisualStyleBackColor = true;
            this.button_FileOpen.Click += new System.EventHandler(this.button_FileOpen_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.MaxFreaquency);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.KindOfWaves);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.DCBias);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.SamplingFrequency);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TheNumberOfSampling);
            this.groupBox2.Controls.Add(this.button_DecideFrequency);
            this.groupBox2.Controls.Add(this.dataGridView_WaveFrewuency);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.button_CreateWave);
            this.groupBox2.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1385, 686);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Size = new System.Drawing.Size(1079, 596);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "合成波作成用";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton_StepFrequency);
            this.groupBox5.Controls.Add(this.radioButton_RandomFrequency);
            this.groupBox5.Location = new System.Drawing.Point(360, 38);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox5.Size = new System.Drawing.Size(228, 150);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "周期性";
            // 
            // radioButton_StepFrequency
            // 
            this.radioButton_StepFrequency.AutoSize = true;
            this.radioButton_StepFrequency.Location = new System.Drawing.Point(13, 88);
            this.radioButton_StepFrequency.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_StepFrequency.Name = "radioButton_StepFrequency";
            this.radioButton_StepFrequency.Size = new System.Drawing.Size(127, 29);
            this.radioButton_StepFrequency.TabIndex = 1;
            this.radioButton_StepFrequency.Text = "一定間隔";
            this.radioButton_StepFrequency.UseVisualStyleBackColor = true;
            this.radioButton_StepFrequency.CheckedChanged += new System.EventHandler(this.radioButton_AmpConst_CheckedChanged);
            // 
            // radioButton_RandomFrequency
            // 
            this.radioButton_RandomFrequency.AutoSize = true;
            this.radioButton_RandomFrequency.Checked = true;
            this.radioButton_RandomFrequency.Location = new System.Drawing.Point(13, 38);
            this.radioButton_RandomFrequency.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_RandomFrequency.Name = "radioButton_RandomFrequency";
            this.radioButton_RandomFrequency.Size = new System.Drawing.Size(106, 29);
            this.radioButton_RandomFrequency.TabIndex = 0;
            this.radioButton_RandomFrequency.TabStop = true;
            this.radioButton_RandomFrequency.Text = "無作為";
            this.radioButton_RandomFrequency.UseVisualStyleBackColor = true;
            this.radioButton_RandomFrequency.CheckedChanged += new System.EventHandler(this.radioButton_AmpConst_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton_AmpTrans);
            this.groupBox4.Controls.Add(this.radioButton_AmpConst);
            this.groupBox4.Location = new System.Drawing.Point(598, 38);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox4.Size = new System.Drawing.Size(228, 150);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "振幅";
            // 
            // radioButton_AmpTrans
            // 
            this.radioButton_AmpTrans.AutoSize = true;
            this.radioButton_AmpTrans.Location = new System.Drawing.Point(13, 88);
            this.radioButton_AmpTrans.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_AmpTrans.Name = "radioButton_AmpTrans";
            this.radioButton_AmpTrans.Size = new System.Drawing.Size(85, 29);
            this.radioButton_AmpTrans.TabIndex = 1;
            this.radioButton_AmpTrans.Text = "可変";
            this.radioButton_AmpTrans.UseVisualStyleBackColor = true;
            this.radioButton_AmpTrans.CheckedChanged += new System.EventHandler(this.radioButton_AmpConst_CheckedChanged);
            // 
            // radioButton_AmpConst
            // 
            this.radioButton_AmpConst.AutoSize = true;
            this.radioButton_AmpConst.Checked = true;
            this.radioButton_AmpConst.Location = new System.Drawing.Point(13, 38);
            this.radioButton_AmpConst.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_AmpConst.Name = "radioButton_AmpConst";
            this.radioButton_AmpConst.Size = new System.Drawing.Size(85, 29);
            this.radioButton_AmpConst.TabIndex = 0;
            this.radioButton_AmpConst.TabStop = true;
            this.radioButton_AmpConst.Text = "一定";
            this.radioButton_AmpConst.UseVisualStyleBackColor = true;
            this.radioButton_AmpConst.CheckedChanged += new System.EventHandler(this.radioButton_AmpConst_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(635, 440);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "・波の最大周波数";
            // 
            // MaxFreaquency
            // 
            this.MaxFreaquency.FormattingEnabled = true;
            this.MaxFreaquency.Items.AddRange(new object[] {
            "1000",
            "5000",
            "10000",
            "20000",
            "50000",
            "100000"});
            this.MaxFreaquency.Location = new System.Drawing.Point(891, 434);
            this.MaxFreaquency.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaxFreaquency.Name = "MaxFreaquency";
            this.MaxFreaquency.Size = new System.Drawing.Size(171, 33);
            this.MaxFreaquency.TabIndex = 13;
            this.MaxFreaquency.Text = "10000";
            this.MaxFreaquency.TextChanged += new System.EventHandler(this.DCBias_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 382);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "・波の種類";
            // 
            // KindOfWaves
            // 
            this.KindOfWaves.FormattingEnabled = true;
            this.KindOfWaves.Items.AddRange(new object[] {
            "3",
            "10",
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000",
            "10000"});
            this.KindOfWaves.Location = new System.Drawing.Point(891, 376);
            this.KindOfWaves.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.KindOfWaves.Name = "KindOfWaves";
            this.KindOfWaves.Size = new System.Drawing.Size(171, 33);
            this.KindOfWaves.TabIndex = 11;
            this.KindOfWaves.Text = "100";
            this.KindOfWaves.TextChanged += new System.EventHandler(this.DCBias_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 208);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "・直流バイアス";
            // 
            // DCBias
            // 
            this.DCBias.FormattingEnabled = true;
            this.DCBias.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.DCBias.Location = new System.Drawing.Point(891, 202);
            this.DCBias.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.DCBias.Name = "DCBias";
            this.DCBias.Size = new System.Drawing.Size(171, 33);
            this.DCBias.TabIndex = 9;
            this.DCBias.Text = "0";
            this.DCBias.TextChanged += new System.EventHandler(this.DCBias_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(635, 324);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "・サンプリング周波数";
            // 
            // SamplingFrequency
            // 
            this.SamplingFrequency.FormattingEnabled = true;
            this.SamplingFrequency.Items.AddRange(new object[] {
            "5000",
            "10000",
            "20000",
            "50000",
            "100000",
            "200000",
            "500000",
            "1000000"});
            this.SamplingFrequency.Location = new System.Drawing.Point(891, 318);
            this.SamplingFrequency.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.SamplingFrequency.Name = "SamplingFrequency";
            this.SamplingFrequency.Size = new System.Drawing.Size(171, 33);
            this.SamplingFrequency.TabIndex = 7;
            this.SamplingFrequency.Text = "10000";
            this.SamplingFrequency.TextChanged += new System.EventHandler(this.DCBias_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 266);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "・サンプリング数";
            // 
            // TheNumberOfSampling
            // 
            this.TheNumberOfSampling.FormattingEnabled = true;
            this.TheNumberOfSampling.Items.AddRange(new object[] {
            "1024",
            "2048",
            "4096",
            "8192",
            "16384",
            "32768",
            "65536",
            "131072",
            "262144",
            "524288",
            "1048576"});
            this.TheNumberOfSampling.Location = new System.Drawing.Point(891, 260);
            this.TheNumberOfSampling.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TheNumberOfSampling.Name = "TheNumberOfSampling";
            this.TheNumberOfSampling.Size = new System.Drawing.Size(171, 33);
            this.TheNumberOfSampling.TabIndex = 5;
            this.TheNumberOfSampling.Text = "8192";
            this.TheNumberOfSampling.TextChanged += new System.EventHandler(this.DCBias_TextChanged);
            // 
            // button_DecideFrequency
            // 
            this.button_DecideFrequency.Location = new System.Drawing.Point(189, 38);
            this.button_DecideFrequency.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_DecideFrequency.Name = "button_DecideFrequency";
            this.button_DecideFrequency.Size = new System.Drawing.Size(163, 150);
            this.button_DecideFrequency.TabIndex = 4;
            this.button_DecideFrequency.Text = "周波数\r\n決定";
            this.button_DecideFrequency.UseVisualStyleBackColor = true;
            this.button_DecideFrequency.Click += new System.EventHandler(this.button_DecideFrequency_Click);
            // 
            // dataGridView_WaveFrewuency
            // 
            this.dataGridView_WaveFrewuency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_WaveFrewuency.Location = new System.Drawing.Point(13, 200);
            this.dataGridView_WaveFrewuency.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dataGridView_WaveFrewuency.Name = "dataGridView_WaveFrewuency";
            this.dataGridView_WaveFrewuency.RowHeadersWidth = 20;
            this.dataGridView_WaveFrewuency.RowTemplate.Height = 21;
            this.dataGridView_WaveFrewuency.Size = new System.Drawing.Size(609, 382);
            this.dataGridView_WaveFrewuency.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton_Parcial);
            this.groupBox3.Controls.Add(this.radioButton_FullIn);
            this.groupBox3.Location = new System.Drawing.Point(839, 38);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox3.Size = new System.Drawing.Size(228, 150);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ノイズの種類";
            // 
            // radioButton_Parcial
            // 
            this.radioButton_Parcial.AutoSize = true;
            this.radioButton_Parcial.Location = new System.Drawing.Point(13, 88);
            this.radioButton_Parcial.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_Parcial.Name = "radioButton_Parcial";
            this.radioButton_Parcial.Size = new System.Drawing.Size(85, 29);
            this.radioButton_Parcial.TabIndex = 1;
            this.radioButton_Parcial.Text = "部分";
            this.radioButton_Parcial.UseVisualStyleBackColor = true;
            this.radioButton_Parcial.CheckedChanged += new System.EventHandler(this.radioButton_AmpConst_CheckedChanged);
            // 
            // radioButton_FullIn
            // 
            this.radioButton_FullIn.AutoSize = true;
            this.radioButton_FullIn.Checked = true;
            this.radioButton_FullIn.Location = new System.Drawing.Point(13, 38);
            this.radioButton_FullIn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_FullIn.Name = "radioButton_FullIn";
            this.radioButton_FullIn.Size = new System.Drawing.Size(106, 29);
            this.radioButton_FullIn.TabIndex = 0;
            this.radioButton_FullIn.TabStop = true;
            this.radioButton_FullIn.Text = "フルイン";
            this.radioButton_FullIn.UseVisualStyleBackColor = true;
            this.radioButton_FullIn.CheckedChanged += new System.EventHandler(this.radioButton_AmpConst_CheckedChanged);
            // 
            // button_CreateWave
            // 
            this.button_CreateWave.Location = new System.Drawing.Point(13, 38);
            this.button_CreateWave.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_CreateWave.Name = "button_CreateWave";
            this.button_CreateWave.Size = new System.Drawing.Size(163, 150);
            this.button_CreateWave.TabIndex = 1;
            this.button_CreateWave.Text = "合成波\r\n作成\r\n";
            this.button_CreateWave.UseVisualStyleBackColor = true;
            this.button_CreateWave.Click += new System.EventHandler(this.button_CreateWave_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioButton_English);
            this.groupBox7.Controls.Add(this.radioButton_Japanese);
            this.groupBox7.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(1385, 12);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox7.Size = new System.Drawing.Size(1079, 106);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "使用言語";
            // 
            // radioButton_English
            // 
            this.radioButton_English.AutoSize = true;
            this.radioButton_English.Location = new System.Drawing.Point(202, 44);
            this.radioButton_English.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_English.Name = "radioButton_English";
            this.radioButton_English.Size = new System.Drawing.Size(85, 29);
            this.radioButton_English.TabIndex = 1;
            this.radioButton_English.Text = "英語";
            this.radioButton_English.UseVisualStyleBackColor = true;
            this.radioButton_English.CheckedChanged += new System.EventHandler(this.radioButton_Japanese_CheckedChanged);
            // 
            // radioButton_Japanese
            // 
            this.radioButton_Japanese.AutoSize = true;
            this.radioButton_Japanese.Checked = true;
            this.radioButton_Japanese.Location = new System.Drawing.Point(37, 44);
            this.radioButton_Japanese.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.radioButton_Japanese.Name = "radioButton_Japanese";
            this.radioButton_Japanese.Size = new System.Drawing.Size(106, 29);
            this.radioButton_Japanese.TabIndex = 0;
            this.radioButton_Japanese.TabStop = true;
            this.radioButton_Japanese.Text = "日本語";
            this.radioButton_Japanese.UseVisualStyleBackColor = true;
            this.radioButton_Japanese.CheckedChanged += new System.EventHandler(this.radioButton_Japanese_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2483, 1264);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "Form1";
            this.Text = "MainMonitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WaveFrewuency)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_FileOpen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_CreateWave;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.RadioButton radioButton_Parcial;
        public System.Windows.Forms.RadioButton radioButton_FullIn;
        private System.Windows.Forms.DataGridView dataGridView_WaveFrewuency;
        private System.Windows.Forms.Button button_DecideFrequency;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox SamplingFrequency;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox TheNumberOfSampling;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox MaxFreaquency;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox KindOfWaves;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox DCBias;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.RadioButton radioButton_AmpTrans;
        public System.Windows.Forms.RadioButton radioButton_AmpConst;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.RadioButton radioButton_StepFrequency;
        public System.Windows.Forms.RadioButton radioButton_RandomFrequency;
        private System.Windows.Forms.Button button_FFT;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.RadioButton radioButton_ParcialAnalysis;
        public System.Windows.Forms.RadioButton radioButtonAllAnalysis;
        private System.Windows.Forms.Button button_IFFT;
        private System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.RadioButton radioButton_English;
        public System.Windows.Forms.RadioButton radioButton_Japanese;
        private System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.RadioButton radioButton_HamingWindow;
        public System.Windows.Forms.RadioButton radioButton_LectangleWindow;
        public System.Windows.Forms.RadioButton radioButton_BlackManWindow;
        public System.Windows.Forms.RadioButton radioButton_HaningWindow;
        public System.Windows.Forms.RadioButton radioButton_NoWindow;
        private System.Windows.Forms.Button button_OutputFile;
        private System.Windows.Forms.Button button_Filtering;
        private System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.ComboBox TotalNumber;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox DivisionNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label_Coordinate;
        private System.Windows.Forms.Button button_Controler;
        public System.Windows.Forms.ComboBox StartPosition;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox EndPosition;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.CheckBox checkBox_ChangeAnalysisRange;
    }
}

