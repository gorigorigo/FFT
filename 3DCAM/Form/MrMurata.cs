using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using _3DCAM.MurataKun;

namespace _3DCAM
{
    public partial class MrMurata : Form
    {
        private static Form1 form1Obj;

        /// <summary>
        /// グラフのヘッダを定義
        /// </summary>
        static string[] Header = new string[1] { "Weight" };


        public MrMurata(Form1 Form1obj)
        {
            InitializeComponent();

            form1Obj = Form1obj;
        }

        private void button_FileOpen_Click(object sender, EventArgs e)
        {
            //ファイルを読み込んで数値データとして取得
            StaticDataMT.fileData = new OpenFileMT().Execute();

            //-999のデータを削除
            new ConvertDataMT(StaticDataMT.fileData).Execute();

            //MessageBox.Show("ファイルを読み込みました");
        }

        private void Resolution_TextChanged(object sender, EventArgs e)
        {
            StaticDataMT.resolution = float.Parse(Resolution.Text);
            StaticDataMT.toolRadius = float.Parse(ToolRadius.Text);
            StaticDataMT.endScale = float.Parse(EndScale.Text);
            StaticDataMT.scalingFactor = float.Parse(ScalingFactor.Text);
        }

        private void MrMurata_Load(object sender, EventArgs e)
        {
            Resolution_TextChanged(sender, e);
        }

        private void button_CalCenter_Click(object sender, EventArgs e)
        {
            new CalculateCircleCenter(StaticDataMT.scalingFactor, StaticDataMT.endScale, StaticDataMT.toolRadius).Execute();

            DrawChartMT.DoDrawCenter(form1Obj.chart1, Header, StaticDataMT.centerData, "CenterData", new string[2] { "x", "y" });
        }

        private void button_FFT_Click(object sender, EventArgs e)
        {
            //インスタンスを作成
            FFT FFTExe  = new FFT(new Tuple<float[], float[]>(StaticDataMT.centerData.Item1, StaticDataMT.centerData.Item1), 0, FFT.Type.fft);

            //FFT解析をして実部虚部を取り出す
            StaticDataMT.complexDataX = FFTExe.Execute(0);

            //振幅を取得
            StaticDataMT.spectrumX = FFTExe.GetAmplitude(StaticDataMT.complexDataX);

            //横軸定義
            float x = 1 / StaticDataMT.resolution;

            DrawChartMT.DoDrawChartFre(form1Obj.chart1, Header, StaticDataMT.spectrumX, "Frequency domain", new string[2] { "Frequency [Hz]", "Spectrum" }, new float[2] { 0, x });
        }

        private void button_AutoCorrelation_Click(object sender, EventArgs e)
        {
            //float[] real = new AutoCorrelation().IFFTAutoCorrelation(StaticDataMT.spectrumX);
            //float[] real = new AutoCorrelation().NormalAutoCorrelation(StaticDataMT.centerData.Item1);
            float[] real = new AutoCorrelation().AverageAutoCorrelation(StaticDataMT.centerData.Item1);

            //float[] real = StaticDataMT.centerData.Item1;

            //float[] real = new AutoCorrelation().CrossCorrelation(StaticDataMT.centerData);

            DrawChartMT.DoDrawChart(form1Obj.chart1, Header, real, "Frequency domain", new string[2] { "Frequency [Hz]", "Spectrum" }, new float[2] { 0, 0.1f });



            //FilterControl FC = new FilterControl();
            //FC.radioButton_HPF.Checked = true;
            //FC.CutOffFrequency.Text = "1";

            //Tuple<float[], float[]> filter = FC.GetFilterCoincident();

            //float[] filteredData = new Filtering().DoFilter(StaticDataMT.centerData.Item2, filter.Item1, filter.Item2);

            //float[] real = new AutoCorrelation().AverageAutoCorrelation(filteredData);

            //DrawChartMT.DoDrawChart(form1Obj.chart1, Header, real, "Frequency domain", new string[2] { "Frequency [Hz]", "Spectrum" }, new float[2] { 0, 0.1f });

        }

        private void button_IFFT_Click(object sender, EventArgs e)
        {
            //float[] real = new AutoCorrelation().AverageAutoCorrelation(StaticDataStateValue.synthticWave.Item2);
            float[] real = new AutoCorrelation().AverageAutoCorrelation(StaticDataWarehouse.filteredData);

            //float[] real = new AutoCorrelation().CrossCorrelation(StaticDataStateValue.synthticWave);

            //float x = StaticDataSetting.samplingFrequency / StaticDataSetting.theNumberOfSampling;
            float x = 1 / StaticDataSetting.samplingFrequency;

            DrawChartMT.DoDrawChart(form1Obj.chart1, Header, real, "Frequency domain", new string[2] { "Frequency [Hz]", "Spectrum" }, new float[2] { 0, x });
        }
    }
}
