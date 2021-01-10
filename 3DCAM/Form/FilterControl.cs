using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DCAM
{
    public partial class FilterControl : Form
    {
        private static Form1 form1Obj;

        public FilterControl(Form1 Form1obj)
        {
            InitializeComponent();

            form1Obj = Form1obj;
        }
        public FilterControl()
        {
            InitializeComponent();
        }



        /// <summary>
        /// グラフのヘッダを定義
        /// </summary>
        static string[] Header = new string[1] { "Weight" };

        private void button_DoFiltering_Click(object sender, EventArgs e)
        {
            //横軸
            float[] x = new float[2] { StaticDataStateValue.synthticWave.Item1[0], 1 / StaticDataSetting.samplingFrequency };//時間フィルタリング
            if (radioButton_DoFreFilt.Checked) x = new float[2] { StaticDataStateValue.synthticWave.Item1[0], StaticDataSetting.samplingFrequency / StaticDataSetting.totalNumber };//周波数フィルタリング
            if (form1Obj.checkBox_ChangeAnalysisRange.Checked) x[0] = StaticDataStateValue.synthticWave.Item1[StaticDataSetting.startPosition];

            //フィルタの係数を取得
            Tuple<float[], float[]> filter = GetFilterCoincident();

            float[] filteredData = new float[0];

            if (radioButtonDoTimeFilt.Checked)
            {
                if (form1Obj.checkBox_ChangeAnalysisRange.Checked == false)
                    filteredData = new Filtering().DoFilter(StaticDataStateValue.synthticWave.Item2, filter.Item1, filter.Item2);
                else if (form1Obj.checkBox_ChangeAnalysisRange.Checked)
                    filteredData = new Filtering().DoFilter(StaticDataWarehouse.filteredData, filter.Item1, filter.Item2);

                DrawChart.DoDrawChart(form1Obj.chart1, Header, filteredData, "Frequency domain", new string[2] { "Frequency [Hz]", "Voltage" }, x);
            }
            else if (radioButton_DoFreFilt.Checked)
            {

            }

            StaticDataWarehouse.filteredData = filteredData;

            StaticDataWarehouse.didFilter = true;
        }
        public Tuple<float[], float[]> GetFilterCoincident()
        {
            float cutoff = float.Parse(CutOffFrequency.Text);
            float q = float.Parse(QValue.Text);
            float bw = float.Parse(BW.Text);
            float gain = float.Parse(Gain.Text);

            if (radioButton_LPF.Checked) return new Filter(q, bw, StaticDataSetting.samplingFrequency, cutoff, gain).LPF();
            if (radioButton_HPF.Checked) return new Filter(q, bw, StaticDataSetting.samplingFrequency, cutoff, gain).HPF();
            if (radioButton_HDPF.Checked) return new Filter(q, bw, StaticDataSetting.samplingFrequency, cutoff, gain).HDPF();
            if (radioButton_NTF.Checked) return new Filter(q, bw, StaticDataSetting.samplingFrequency, cutoff, gain).NTF();
            if (radioButton_LSHF.Checked) return new Filter(q, bw, StaticDataSetting.samplingFrequency, cutoff, gain).LSHF();
            if (radioButton_HSHF.Checked) return new Filter(q, bw, StaticDataSetting.samplingFrequency, cutoff, gain).HSHF();
            if (radioButton_PKF.Checked) return new Filter(q, bw, StaticDataSetting.samplingFrequency, cutoff, gain).PKF();
            return new Filter(q, bw, StaticDataSetting.samplingFrequency, cutoff, gain).APF();
        }

        private void button_Initialize_Click(object sender, EventArgs e)
        {
            //横軸
            float[] x = new float[2] { 0, 1 / StaticDataSetting.samplingFrequency };//時間フィルタリング
            if (radioButton_DoFreFilt.Checked) x = new float[2] { StaticDataStateValue.synthticWave.Item1[0], StaticDataSetting.samplingFrequency / StaticDataSetting.totalNumber };//周波数フィルタリング

            float[] filtered = new float[0];
            if (radioButtonDoTimeFilt.Checked)
            {
                StaticDataWarehouse.filteredData = StaticDataStateValue.synthticWave.Item2;
                filtered = StaticDataWarehouse.filteredData;

                DrawChart.DoDrawChart(form1Obj.chart1, Header, filtered, "Frequency domain", new string[2] { "Frequency [Hz]", "Voltage" }, x);
            }
            else if (radioButton_DoFreFilt.Checked)
            {
                if (form1Obj.radioButtonAllAnalysis.Checked)
                {
                    StaticDataWarehouse.filteredComplexData = StaticDataStateValue.complexData;
                    filtered = new FFT(StaticDataWarehouse.filteredComplexData, 0, FFT.Type.ifft).
                        GetAmplitude(StaticDataWarehouse.filteredComplexData);
                }
                else if (form1Obj.radioButton_ParcialAnalysis.Checked)
                {
                    StaticDataWarehouse.filteredComplexData = StaticDataStateValue.parcialComplexData[0];
                    filtered = new FFT(StaticDataWarehouse.filteredComplexData, 0, FFT.Type.ifft).
                        GetAmplitude(StaticDataWarehouse.filteredComplexData);

                }
                DrawChart.DoDrawChartFre(form1Obj.chart1, Header, filtered, "Frequency domain", new string[2] { "Frequency [Hz]", "Voltage" }, x);
            }
            StaticDataWarehouse.didFilter = false;
        }
    }
}
