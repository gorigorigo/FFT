using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;

using _3DCAM.Graphic.Graphic1;
using System.Diagnostics;

namespace _3DCAM
{
    public partial class Form1 : Form
    {
        private Graphic1 Graphic1;
        private Graphic1Operator form1obj_Graghic;
        private Random r1 = new Random();
        private static FilterControl FCObj;
        private static MrMurata MTObj;

        #region 変数定義
        /// <summary>
        /// グラフのヘッダを定義
        /// </summary>
        static string[] Header = new string[1] { "Weight" };

        /// <summary>
        /// 窓関数の番号
        /// </summary>
        private int windowNumber = 0;

        /// <summary>
        /// 窓関数をかけるかどうかの変数
        /// </summary>
        private static int windowConduct = 0;
        #endregion

        public Form1()
        {
            //状態を初期化
            InitializeComponent();

            //マウスで規格変更
            chart1.MouseWheel += new MouseEventHandler(this.chart1_MouseWheel);

            //起動したときに通過する関数
            StartUpProject();
        }

        public void StartUpProject()
        {
            //タイマーを使用可能に変更
            timer1.Enabled = true;

            //グラフィックのインスタンスを作成
            Graphic1 = new Graphic1(glControl1);

            //実際に操作するクラスのインスタンスを作成
            form1obj_Graghic = new Graphic1Operator(this);

            //フィルタ用のインスタンス作成
            FCObj = new FilterControl(this);

            //むら用のインスタンス作成
            MTObj = new MrMurata(this);
            MTObj.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //毎フレームごとに描画を更新
            glControl1.Refresh();
        }

        /// <summary>
        /// マウス操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Math.Round(chart1.ChartAreas["ChartArea1"].AxisY.Maximum * 0.8, 5);
            }
            if (e.Delta < 0)
            {
                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Math.Round(chart1.ChartAreas["ChartArea1"].AxisY.Maximum * 1.2, 5);
            }

            //double maximum_C2 = chart1.ChartAreas[0].AxisX.Maximum; //現在の最大値を取得
            //float viewRate = 0.8f;
            //if (e.Delta > 0)
            //{
            //    chart1.ChartAreas[0].AxisX.Interval = 100;
            //    chart1.ChartAreas[0].AxisX.ScaleView.Size = maximum_C2 * viewRate;
            //}
            //if (e.Delta < 0)
            //{
            //    viewRate = 1.2f;
            //    chart1.ChartAreas[0].AxisX.Interval = 100;
            //    chart1.ChartAreas[0].AxisX.ScaleView.Size = maximum_C2 * viewRate;
            //}


            //if (e.Delta > 0)
            //{
            //    chart1.ChartAreas["ChartArea1"].AxisX.Maximum = Math.Round(chart1.ChartAreas["ChartArea1"].AxisX.Maximum * 0.8, 5);
            //}
            //if (e.Delta < 0)
            //{
            //    chart1.ChartAreas["ChartArea1"].AxisX.Maximum = Math.Round(chart1.ChartAreas["ChartArea1"].AxisX.Maximum * 1.2, 5);
            //}

        }
        /// <summary>
        /// ファイルを開ける
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_FileOpen_Click(object sender, EventArgs e)
        {
            //ファイルパス取得
            new OpenFile().GetFilePath("", "Select Solid data", ref StaticDataSetting.filePath);

            if (StaticDataSetting.filePath.Contains("empty")) return;

            //データ取得
            StaticDataStateValue.synthticWave = new GetSyntheticWave(StaticDataSetting.filePath).GetFileWave(ref StaticDataSetting.samplingFrequency);
            //チャートを描画
            DrawChart.DoDrawChart(chart1, Header, StaticDataStateValue.synthticWave.Item2, "Time Spectrum", new string[2] { "Time [s]", "Amplitude" }, new float[2] { StaticDataStateValue.synthticWave.Item1[0], 1 / StaticDataSetting.samplingFrequency });

            #region UI変更
            StaticDataSetting.totalNumber = StaticDataStateValue.synthticWave.Item2.Length;

            TotalNumber.Text = StaticDataSetting.totalNumber.ToString();
            StaticDataSetting.endPosition = int.Parse(TotalNumber.Text);
            EndPosition.Text = TotalNumber.Text;
            StaticDataWarehouse.didFilter = false;
            #endregion
        }
        /// <summary>
        /// 自作の波を作る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CreateWave_Click(object sender, EventArgs e)
        {
            StaticDataSetting.samplingFrequency = float.Parse(SamplingFrequency.Text);

            int loopCount = dataGridView_WaveFrewuency.RowCount - 1;

            float[] frequencyOfWaves = new float[loopCount];
            float[] amplitude = new float[loopCount];

            for (int i = 0; i < loopCount; i++)
            {
                float.TryParse(dataGridView_WaveFrewuency.Rows[i].Cells[1].Value.ToString(), out frequencyOfWaves[i]);
                float.TryParse(dataGridView_WaveFrewuency.Rows[i].Cells[0].Value.ToString(), out amplitude[i]);
            }

            StaticDataStateValue.synthticWave = new CreateOriginalWaves().CreateWaves(frequencyOfWaves, amplitude, StaticDataSetting.samplingFrequency, StaticDataSetting.biasDC, StaticDataSetting.theNumberOfSampling);
            //チャートを描画
            DrawChart.DoDrawChart(chart1, Header, StaticDataStateValue.synthticWave.Item2, "Time Spectrum", new string[2] { "Time [s]", "Amplitude" }, new float[2] { StaticDataStateValue.synthticWave.Item1[0], 1 / StaticDataSetting.samplingFrequency });

            #region UI変更
            StaticDataSetting.totalNumber = StaticDataStateValue.synthticWave.Item2.Length;
            TotalNumber.Text = StaticDataSetting.totalNumber.ToString();
            StaticDataSetting.endPosition = int.Parse(TheNumberOfSampling.Text);
            EndPosition.Text = TheNumberOfSampling.Text;
            StaticDataWarehouse.didFilter = false;
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DCBias_TextChanged(sender, e);

            float basis = 1000;
            float step = 500;

            int ini = 1;

            dataGridView_WaveFrewuency.ColumnCount = 3;

            dataGridView_WaveFrewuency.Columns[0].HeaderText = "振幅";
            dataGridView_WaveFrewuency.Columns[1].HeaderText = "周波数";
            dataGridView_WaveFrewuency.Columns[2].HeaderText = "割合";

            for (int i = 0; i < ini; i++)
            {
                dataGridView_WaveFrewuency.Rows.Add(1, basis + step * i, 100);
            }
        }

        private void button_DecideFrequency_Click(object sender, EventArgs e)
        {
            dataGridView_WaveFrewuency.Rows.Clear();

            float amplitude = 1;

            float step = StaticDataSetting.maxFreaquency / 100;

            for (int i = 0; i < StaticDataSetting.kindOfWaves; i++)
            {
                //振幅可変なら振幅をランダムで取得
                if (radioButton_AmpTrans.Checked) amplitude = r1.Next(1, 4);

                if (radioButton_RandomFrequency.Checked) dataGridView_WaveFrewuency.Rows.Add(amplitude, r1.Next(1, (int)StaticDataSetting.maxFreaquency), 100);
                else if (radioButton_StepFrequency.Checked) dataGridView_WaveFrewuency.Rows.Add(amplitude, step * i, 100);
            }
        }

        private void DCBias_TextChanged(object sender, EventArgs e)
        {
            try
            {
                StaticDataSetting.biasDC = float.Parse(DCBias.Text);
                StaticDataSetting.kindOfWaves = float.Parse(KindOfWaves.Text);
                StaticDataSetting.maxFreaquency = float.Parse(MaxFreaquency.Text);
                StaticDataSetting.samplingFrequency = float.Parse(SamplingFrequency.Text);
                StaticDataSetting.theNumberOfSampling = int.Parse(TheNumberOfSampling.Text);
                StaticDataSetting.divisionNumber = int.Parse(DivisionNumber.Text);
                StaticDataSetting.totalNumber = int.Parse(TheNumberOfSampling.Text);
                StaticDataSetting.startPosition = int.Parse(StartPosition.Text);
                StaticDataSetting.endPosition = int.Parse(EndPosition.Text);

                TotalNumber.Text = TheNumberOfSampling.Text;
                if(StaticDataSetting.totalNumber < StaticDataSetting.endPosition)
                {
                    StaticDataSetting.endPosition = int.Parse(TheNumberOfSampling.Text);
                    EndPosition.Text = TheNumberOfSampling.Text;
                }
            }
            catch { }
        }

        private void radioButton_AmpConst_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_FFT_Click(object sender, EventArgs e)
        {
            if (StaticDataStateValue.synthticWave == null) return;

            //全体解析で使用
            if (radioButtonAllAnalysis.Checked)
            {
                //インスタンスを作成
                FFT FFTExe = null;
                if (StaticDataWarehouse.didFilter == false)
                    FFTExe = new FFT(new Tuple<float[], float[]>(StaticDataStateValue.synthticWave.Item2, StaticDataStateValue.synthticWave.Item2), windowNumber, FFT.Type.fft);
                else if (StaticDataWarehouse.didFilter)
                    FFTExe = new FFT(new Tuple<float[], float[]>(StaticDataWarehouse.filteredData, StaticDataWarehouse.filteredData), windowNumber, FFT.Type.fft);

                Stopwatch st = new Stopwatch();
                st.Start();

                //FFT解析をして実部虚部を取り出す
                StaticDataStateValue.complexData = FFTExe.Execute(windowConduct);

                //振幅を取得
                StaticDataStateValue.spectol = FFTExe.GetAmplitude(StaticDataStateValue.complexData);

                st.Stop();
                //データ点数を取得
                StaticDataStateValue.actuallyNumber = StaticDataStateValue.spectol.Length;

                //横軸定義
                float x = StaticDataSetting.samplingFrequency / StaticDataStateValue.actuallyNumber;

                StaticDataStateValue.maxSpectrum = Draw3Dchart.maxSpectrum(new List<float[]>() { StaticDataStateValue.spectol });

                DrawChart.DoDrawChartFre(chart1, Header, StaticDataStateValue.spectol, "Frequency domain", new string[2] { "Frequency [Hz]", "Spectrum" }, new float[2] { 0, x });
            }

            else if (radioButton_ParcialAnalysis.Checked)
            {
                Stopwatch s1 = new Stopwatch();
                s1.Start();

                int loopCount = StaticDataSetting.totalNumber / StaticDataSetting.divisionNumber;
                if (checkBox_ChangeAnalysisRange.Checked) loopCount = (StaticDataSetting.endPosition - StaticDataSetting.startPosition) / StaticDataSetting.divisionNumber;

                StaticDataStateValue.parcialComplexData = new List<Tuple<float[], float[]>>();
                StaticDataStateValue.parcialSpectrum = new List<float[]>();

                for (int i = 0; i < loopCount; i++)
                {
                    float[] wave = new float[StaticDataSetting.divisionNumber];

                    for (int j = i * StaticDataSetting.divisionNumber; j < (i + 1) * StaticDataSetting.divisionNumber; j++)
                    {
                        if (StaticDataWarehouse.didFilter == false) wave[j - i * StaticDataSetting.divisionNumber] = StaticDataStateValue.synthticWave.Item2[j];
                        else if (StaticDataWarehouse.didFilter) wave[j - i * StaticDataSetting.divisionNumber] = StaticDataWarehouse.filteredData[j];
                    }

                    //インスタンスを作成
                    FFT FFTExe = new FFT(new Tuple<float[], float[]>(wave, wave), windowNumber, FFT.Type.fft);

                    //FFT解析をして実部虚部を取り出す
                    Tuple<float[], float[]> complexData = FFTExe.Execute(windowConduct);

                    //振幅を取得
                    float[] spectrum = FFTExe.GetAmplitude(complexData);

                    StaticDataStateValue.parcialComplexData.Add(complexData);
                    StaticDataStateValue.parcialSpectrum.Add(spectrum);
                }

                s1.Stop();

                //横軸定義
                float x = StaticDataSetting.samplingFrequency / StaticDataSetting.divisionNumber;

                StaticDataStateValue.maxSpectrum = Draw3Dchart.maxSpectrum(StaticDataStateValue.parcialSpectrum);

                //DrawChart.DoDraw3DColorMap(chart1, Header, StaticDataStateValue.parcialSpectrum, "3DColorMap", new string[2] { "Frequency [Hz]", "Time[s]" }, new float[2] { 0, x });

                DrawChart.DoDraw3DColorMapPoints(chart1, Header, StaticDataStateValue.parcialSpectrum, "3DColorMap", new string[2] { "Frequency [Hz]", "Time[s]" }, new float[2] { 0, x });
            }
        }

        private void button_IFFT_Click(object sender, EventArgs e)
        {
            if (StaticDataStateValue.spectol == null) return;

            //複素数の形に変換
            Complex[] complex = new Complex[StaticDataStateValue.complexData.Item1.Length];

            //複製
            for (int i = 0; i < complex.Length; i++) { complex[i] = new Complex(StaticDataStateValue.complexData.Item1[i], StaticDataStateValue.complexData.Item2[i]); }

            //IFFTを実行
            Complex[]  ifftComplex= new IFFT(StaticDataStateValue.spectol.Length, IFFT.Type.ifft).Execute(complex);

            //実部データに変換
            float[] real = new float[ifftComplex.Length]; for (int i = 0; i < ifftComplex.Length; i++) { real[i] = (float)ifftComplex[i].Real; }

            ////チャートを描画
            DrawChart.DoDrawChart(chart1, Header, real, "Frequency domain", new string[2] { "Frequency [Hz]", "Voltage" }, new float[2] { StaticDataStateValue.synthticWave.Item1[0], 1 / StaticDataSetting.samplingFrequency });
        }

        private void radioButton_NoWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_NoWindow.Checked == false) windowConduct = 1;
            else if (radioButton_NoWindow.Checked) windowConduct = 0;

            if (radioButton_HamingWindow.Checked) windowNumber = 0;
            else if (radioButton_HaningWindow.Checked) windowNumber = 1;
            else if (radioButton_BlackManWindow.Checked) windowNumber = 2;
            else if (radioButton_LectangleWindow.Checked) windowNumber = 3;
        }

        private void button_OutputFile_Click(object sender, EventArgs e)
        {
            string fileName = "FFT解析データ";

            new OutputFile().OutputComplexData(fileName, StaticDataStateValue.complexData, StaticDataStateValue.spectol);
        }

        private void radioButton_Japanese_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_English.Checked) EnglishLang();
            else if (radioButton_Japanese.Checked) JapaneseLang();
        }

        private void button_Filtering_Click(object sender, EventArgs e)
        {
            FCObj.Show();
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            chart1.ChartAreas[0].CursorX.Interval = 0.001;
            chart1.ChartAreas[0].CursorY.Interval = 0.001;
            try
            {
                double x = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                //double y = Math.Sin((double)x / 0.5 / 20);
                double y = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y) ;
                chart1.ChartAreas[0].CursorX.Position = x;
                chart1.ChartAreas[0].CursorY.Position = y;
                label_Coordinate.Text = "X:" + x.ToString("0.000") + " " + "Y:" + y.ToString("0.000");
            }
            catch
            {
                //pass
            }
        }

        private void DivisionNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                StaticDataSetting.divisionNumber = int.Parse(DivisionNumber.Text);
            }
            catch { }
        }
        private void JapaneseLang()
        {
            groupBox1.Text = "ソフト機能";
            groupBox2.Text ="合成波作成用";
            groupBox3.Text ="ノイズの種類";
            groupBox4.Text ="振幅";
            groupBox5.Text ="周期性";
            groupBox6.Text ="FFT解析種類";
            groupBox7.Text = "使用言語";
            groupBox8.Text ="窓関数";
            groupBox9.Text ="FFT解析設定";

            button_FileOpen.Text = "ファイルを開く";
            button_CreateWave.Text = "合成波\r\n作成";
            button_DecideFrequency.Text = "周波数\r\n決定";
            button_Filtering.Text = "フィルタ";
            button_OutputFile.Text = "ファイルを保存";
            button_Controler.Text = "コントローラ";

            radioButtonAllAnalysis.Text = "同時解析";
            radioButton_AmpConst.Text = "一定";
            radioButton_AmpTrans.Text = "可変";
            radioButton_BlackManWindow.Text = "ブラックマン窓";
            radioButton_English.Text = "英語";
            radioButton_FullIn.Text = "フルイン";
            radioButton_HamingWindow.Text = "ハミング窓";
            radioButton_HaningWindow.Text = "ハニング窓";
            radioButton_Japanese.Text = "日本語";
            radioButton_LectangleWindow.Text = "レクタングル窓";
            radioButton_NoWindow.Text = "なし";
            radioButton_Parcial.Text = "部分";
            radioButton_ParcialAnalysis.Text = "分割解析";
            radioButton_RandomFrequency.Text = "無作為";
            radioButton_StepFrequency.Text = "一定間隔";

            label1.Text = "サンプリング数";
            label2.Text = "サンプリング周波数";
            label3.Text = "直流バイアス";
            label4.Text = "波の種類";
            label5.Text = "波の最大周波数";
            label7.Text = "分割数";
            label8.Text = "全体行数";
            label9.Text = "開始行";
            label10.Text = "終了行";

            tabPage1.Text = "2次元";

            checkBox_ChangeAnalysisRange.Text = "解析区間の変更";

            dataGridView_WaveFrewuency.Columns[0].HeaderText = "振幅";
            dataGridView_WaveFrewuency.Columns[1].HeaderText = "周波数";
            dataGridView_WaveFrewuency.Columns[2].HeaderText = "割合";
        }
        private void EnglishLang()
        {
            groupBox1.Text = "Function of This Software";
            groupBox2.Text = "To Create Synthetic Wave";
            groupBox3.Text = "Types of Noise";
            groupBox4.Text = "Amplitude";
            groupBox5.Text = "Cycle";
            groupBox6.Text = "Analysis";
            groupBox7.Text = "Language";
            groupBox8.Text = "Window Function";
            groupBox9.Text = "Setting";

            button_FileOpen.Text = "OpenFile";
            button_CreateWave.Text = "Create\r\nWave";
            button_DecideFrequency.Text = "DetermineFrequency";
            button_Filtering.Text = "Filter";
            button_OutputFile.Text = "Output\r\nFile";
            button_Controler.Text = "Controler";

            radioButtonAllAnalysis.Text = "All";
            radioButton_AmpConst.Text = "Const";
            radioButton_AmpTrans.Text = "Variable";
            radioButton_BlackManWindow.Text = "Blackman";
            radioButton_English.Text = "English";
            radioButton_FullIn.Text = "FullIn";
            radioButton_HamingWindow.Text = "Haming";
            radioButton_HaningWindow.Text = "Haning";
            radioButton_Japanese.Text = "Japanese";
            radioButton_LectangleWindow.Text = "Rectangle";
            radioButton_NoWindow.Text = "Nothing";
            radioButton_Parcial.Text = "Portion";
            radioButton_ParcialAnalysis.Text = "Devide";
            radioButton_RandomFrequency.Text = "Random";
            radioButton_StepFrequency.Text = "Interval";

            label1.Text = "TheNumberOfSamp";
            label2.Text = "SampFrequency";
            label3.Text = "DCBias";
            label4.Text = "Types of Waves";
            label5.Text = "Max Frequency";
            label7.Text = "DevideNumber";
            label8.Text = "TotalRow";
            label9.Text = "StartPoint";
            label10.Text = "EndPoint";

            tabPage1.Text = "Two-Dimention";

            checkBox_ChangeAnalysisRange.Text = "ChangeAnalysisRange";

            dataGridView_WaveFrewuency.Columns[0].HeaderText = "Amplitude";
            dataGridView_WaveFrewuency.Columns[1].HeaderText = "Frequency";
            dataGridView_WaveFrewuency.Columns[2].HeaderText = "Ratio";
        }

        private void button_Controler_Click(object sender, EventArgs e)
        {
            Controler ct = new Controler();
            ct.Show();
        }

        private void StartPosition_TextChanged(object sender, EventArgs e)
        {
            //区間変更をしないなら返す
            if (checkBox_ChangeAnalysisRange.Checked == false) return;

            //データを読み込んでいない状態でも返す
            else if (StaticDataStateValue.synthticWave == null) return;

            //スタート位置を取得
            int start = int.Parse(StartPosition.Text);
            if (start < 0)
            {
                if (radioButton_Japanese.Checked) Console.WriteLine("開始行が取得できません");
                else if (radioButton_English.Checked) Console.WriteLine("unable to get value");
                StartPosition.Text = StaticDataSetting.startPosition.ToString();
            }
            else StaticDataSetting.startPosition = start;
            //終了位置を取得
            int end = int.Parse(EndPosition.Text);
            if (end > StaticDataSetting.totalNumber)
            {
                if (radioButton_Japanese.Checked) Console.WriteLine("終了行が取得できません");
                else if (radioButton_English.Checked) Console.WriteLine("unable to get value");
                EndPosition.Text = StaticDataSetting.endPosition.ToString();
            }
            else StaticDataSetting.endPosition = end;

            if (start > end)
            {
                if (radioButton_Japanese.Checked) Console.WriteLine("開始行が終了行より大きくなっています");
                else if (radioButton_English.Checked) Console.WriteLine("StartPoint is bigger than EndPoint");
                StartPosition.Text = StaticDataSetting.startPosition.ToString();
                EndPosition.Text = StaticDataSetting.endPosition.ToString();
                return;
            }
            //開始行と終了行を変更
            StaticDataWarehouse.filteredData = new ChangeAnalysisRange().DoChange(StaticDataStateValue.synthticWave.Item2, StaticDataSetting.startPosition, StaticDataSetting.endPosition);

            //チャートを描画
            DrawChart.DoDrawChart(chart1, Header, StaticDataWarehouse.filteredData, "Time Spectrum", new string[2] { "Time [s]", "Amplitude" }, new float[2] { StaticDataStateValue.synthticWave.Item1[start], 1 / StaticDataSetting.samplingFrequency });

            StaticDataWarehouse.didFilter = true;
        }
    }
}
