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
    public partial class Controler : Form
    {
        public Controler()
        {
            InitializeComponent();
        }

        private void button_DrawGnuplot_Click(object sender, EventArgs e)
        {
            //var gnuGraph = new DrawGnuplot();
            //var sampleDataInc = new GraphData(@"[datafilepath]",
            //    "NaCl Singlecrystal #1 increase", GraphData.Axis.inverse);
            //var sampleDataDec = new GraphData(@"[datafilepath",
            //    "NaCl Singlecrystal #1 decrease", GraphData.Axis.inverse);

            //gnuGraph.AddGraphData(sampleDataInc);
            //gnuGraph.AddGraphData(sampleDataDec);
            //gnuGraph.Draw();


            string dirName = "test";
            string subName = "test2";
            string date = DateTime.Now.ToString("yyyyMMdd");
            string createDirName = dirName + "\\" + date + "_" + subName;
            string fileName = createDirName + "\\fft.csv";

            //if (System.IO.Directory.Exists(createDirName))
            //{
            //    MessageBox.Show("ファイルが存在します");
            //}
            //else
            //{
            //    // フォルダ作成
            //    System.IO.Directory.CreateDirectory(@createDirName);

            //    // fftデータ保存
            //    System.IO.StreamWriter sw = new System.IO.StreamWriter(@fileName);
            //    string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            //    sw.WriteLine("#" + dateTime);
            //    sw.WriteLine("#Freq[Hz],DFT,Freq[Hz],FFT");
            //    for (int i = 0; i < size; i++)
            //    {
            //        sw.Write((double)i / (fs / 180) + "," + Math.Sqrt(re[i] * re[i] + im[i] * im[i]) + ","
            //                        + (double)i * (180.0 / size) + "," + Math.Sqrt(reFFT[i] * reFFT[i] + imFFT[i] * imFFT[i]) + "\n");
            //    }
            //    sw.Close();

            //    // 画像保存
            //    chart1.SaveImage(createDirName + "\\chart.jpg", ChartImageFormat.Jpeg);
            //}

            // gnuplotで表示＆設定保存
            try
            {
                System.Diagnostics.Process gnuplot = new System.Diagnostics.Process();

                gnuplot.StartInfo.FileName = @"C:\Program Files\gnuplot\bin\gnuplot.exe";
                gnuplot.StartInfo.UseShellExecute = false;
                gnuplot.StartInfo.RedirectStandardInput = true;
                gnuplot.StartInfo.RedirectStandardOutput = true;

                gnuplot.Start();
                gnuplot.StandardInput.WriteLine("set title 'FFT Graph'");
                gnuplot.StandardInput.WriteLine("set logscale x");
                gnuplot.StandardInput.WriteLine("set xl 'Freq[Hz]'");
                gnuplot.StandardInput.WriteLine("set logscale y");
                gnuplot.StandardInput.WriteLine("set yl 'PSD'");
                gnuplot.StandardInput.WriteLine("set grid xtics ytics mxtics mytics");
                gnuplot.StandardInput.WriteLine("cd '" + createDirName + "'");
                gnuplot.StandardInput.WriteLine("plot 'fft.csv' using '%lf,%lf' w l title 'FFT'");
                gnuplot.StandardInput.WriteLine("save 'fft.plt'");
                gnuplot.StandardInput.WriteLine("set terminal png");
                gnuplot.StandardInput.WriteLine("set out 'fft.png'");
                gnuplot.StandardInput.WriteLine("replot");
                //gnuplot.Close();
            }
            catch
            {
                MessageBox.Show("gnuplot開けません");
            }
        }
    }
}
