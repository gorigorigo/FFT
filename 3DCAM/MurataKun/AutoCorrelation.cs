using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;

using _3DCAM.Graphic.Graphic1;
using System.Diagnostics;

namespace _3DCAM.MurataKun
{
    class AutoCorrelation
    {
        public float[] IFFTAutoCorrelation(float[] spectrum)
        {
            //複素数の形に変換
            Complex[] complex = new Complex[spectrum.Length];

            //複製
            for (int i = 0; i < complex.Length >> 1; i++)
            {
                //complex[i * 2] = new Complex(StaticDataMT.complexDataX.Item1[i], spectrum[i]);
                //complex[i * 2 + 1] = new Complex(StaticDataMT.complexDataX.Item1[i + 1], 0);

                complex[i * 2] = new Complex(spectrum[i], spectrum[i]);
                complex[i * 2 + 1] = new Complex(spectrum[i + 1], 0);
            }
            //complex[1] = new Complex(StaticDataMT.complexDataX.Item2[spectrum.Length / 2], spectrum[spectrum.Length / 2]);
            complex[1] = new Complex(spectrum[spectrum.Length / 2], spectrum[spectrum.Length / 2]);

            //IFFTを実行
            Complex[] ifftComplex = new IFFT(spectrum.Length, IFFT.Type.ifft).Execute(complex);

            //実部データに変換
            float[] real = new float[ifftComplex.Length]; for (int i = 0; i < ifftComplex.Length; i++) { real[i] = (float)ifftComplex[i].Real; }

            return real;
        }


        public float[] NormalAutoCorrelation(float[] data)
        {
            float[] acf = new float[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length - i; j++)
                {
                    acf[i] += data[j] * data[i + j];
                }
                acf[i] /= (data.Length - i);
            }
            return acf;
        }


        public float[] AverageAutoCorrelation(float[] data)
        {
            //平均を引いたデータを格納用
            float[] tmpData = new float[data.Length];

            //自己相関係数
            float[] acf = new float[data.Length];

            //平均値
            float ave = 0;

            //平均を求める
            for (int i = 0; i < data.Length; i++)
            {
                ave += data[i];
            }
            ave /= data.Length;

            //平均を引く
            for (int i = 0; i < data.Length; i++)
            {
                tmpData[i] = data[i] - ave;
            }

            //分母を求める
            float denom = 0;
            for (int i = 0; i < data.Length; i++)
            {
                denom += (float)Math.Pow(tmpData[i], 2);
            }

            //分子及び自己相関係数の算出
            for (int i = 0; i < data.Length; i++)
            {
                float numer = 0;

                for (int j = 0; j < data.Length - i; j++)
                {
                    numer += tmpData[j] * tmpData[i + j];
                }
                acf[i] = numer / denom;
            }
            return acf;
        }

        public float[] CrossCorrelation(Tuple<float[],float[]>data)
        {
            float[] acf = new float[data.Item1.Length];

            float[] ave = new float[2];
            //平均値を算出
            for (int i = 0; i < data.Item1.Length; i++)
            {
                ave[0] += data.Item1[i] / data.Item1.Length;
                ave[1] += data.Item2[i] / data.Item1.Length;
            }

            for (int i = 0; i < data.Item2.Length; i++)
            {
                float denomX = 0;
                float denomY = 0;
                float numer = 0;
                for (int j = 0; j < data.Item1.Length - i; j++)
                {
                    denomX += (float)Math.Pow(data.Item1[j] - ave[0], 2);
                    denomY += (float)Math.Pow(data.Item2[i + j] - ave[1], 2);
                    numer += (data.Item1[j] - ave[0]) * (data.Item2[i + j] - ave[1]);
                }
                denomX = (float)Math.Sqrt(denomX);
                denomY = (float)Math.Sqrt(denomY);

                acf[i] = numer / (denomY * denomX);
            }
            return acf;
        }
    }
}
