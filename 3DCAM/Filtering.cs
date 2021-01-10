using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3DCAM
{
    class Filtering
    {
        /// <summary>
        /// フィルタを計算
        /// </summary>
        /// <param name="data"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public float[] DoFilter(float[] data, float[] a, float[] b)
        {
            float in2 = 0, in1 = 0, out1 = 0, out2 = 0;

            float[] output = new float[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                output[i] = b[0] / a[0] * data[i] + b[1] / a[0] * in1 + b[2] / a[0] * in2 - a[1] / a[0] * out1 - a[2] / a[0] * out2;

                in2 = in1;//２つ前の入力信号を更新
                in1 = data[i];//１つ前の入力信号を更新

                out2 = out1;//２つ前の出力信号を更新
                out1 = output[i];//１つ前の出力信号を更新
            }
            return output;
        }
    }
    struct Filter
    {
        public Filter(float Q, float BW, float SamFre, float PerFre, float Gain)
        {
            q = Q;
            bw = BW;
            samplingFrequency = SamFre;
            permissibleFrequency = PerFre;
            gain = Gain;
        }

        /// <summary>
        /// Q値
        /// </summary>
        float q;
        /// <summary>
        /// 帯域幅
        /// </summary>
        float bw;
        /// <summary>
        /// サンプリング周波数
        /// </summary>
        float samplingFrequency;
        /// <summary>
        /// カットオフ周波数
        /// </summary>
        float permissibleFrequency;
        /// <summary>
        /// 増幅率
        /// </summary>
        float gain;


        /// <summary>
        /// ローパスフィルタ
        /// </summary>
        /// <returns></returns>
        public Tuple<float[], float[]> LPF()
        {
            float[] a = new float[3];
            float[] b = new float[3];

            float omega = 2.0f * (float)Math.PI * permissibleFrequency / samplingFrequency;
            float alpha = (float)Math.Sin(omega) / (2.0f * q);


            a[0] = 1.0f + alpha;
            a[1] = -2.0f * (float)Math.Cos(omega);
            a[2] = 1.0f - alpha;
            b[0] = (1.0f - (float)Math.Cos(omega)) / 2.0f;
            b[1] = 1.0f - (float)Math.Cos(omega);
            b[2] = (1.0f - (float)Math.Cos(omega)) / 2.0f;

            return new Tuple<float[], float[]>(a, b);
        }
        /// <summary>
        /// ハイパスフィルタ
        /// </summary>
        /// <returns></returns>
        public Tuple<float[], float[]> HPF()
        {
            float[] a = new float[3];
            float[] b = new float[3];

            float omega = 2.0f * (float)Math.PI * permissibleFrequency / samplingFrequency;
            float alpha = (float)Math.Sin(omega) / (2.0f * q);


            a[0] = 1.0f + alpha;
            a[1] = -2.0f * (float)Math.Cos(omega);
            a[2] = 1.0f - alpha;
            b[0] = (1.0f + (float)Math.Cos(omega)) / 2.0f;
            b[1] = -(1.0f + (float)Math.Cos(omega));
            b[2] = (1.0f + (float)Math.Cos(omega)) / 2.0f;

            return new Tuple<float[], float[]>(a, b);
        }
        /// <summary>
        /// ハンドパスフィルタ
        /// </summary>
        /// <returns></returns>
        public Tuple<float[], float[]> HDPF()
        {
            float[] a = new float[3];
            float[] b = new float[3];

            float omega = 2.0f * (float)Math.PI * permissibleFrequency / samplingFrequency;
            float alpha = (float)Math.Sin(omega) * (float)Math.Sinh(Math.Log(2.0f) / 2.0f * bw * omega / Math.Sin(omega));


            a[0] = 1.0f + alpha;
            a[1] = -2.0f * (float)Math.Cos(omega);
            a[2] = 1.0f - alpha;
            b[0] = alpha;
            b[1] = 0.0f;
            b[2] = -alpha;

            return new Tuple<float[], float[]>(a, b);
        }
        /// <summary>
        /// ノッチフィルタ
        /// </summary>
        /// <returns></returns>
        public Tuple<float[], float[]> NTF()
        {
            float[] a = new float[3];
            float[] b = new float[3];

            float omega = 2.0f * (float)Math.PI * permissibleFrequency / samplingFrequency;
            float alpha = (float)Math.Sin(omega) * (float)Math.Sinh(Math.Log(2.0f) / 2.0f * bw * omega / Math.Sin(omega));


            a[0] = 1.0f + alpha;
            a[1] = -2.0f * (float)Math.Cos(omega);
            a[2] = 1.0f - alpha;
            b[0] = 1.0f;
            b[1] = -2.0f * (float)Math.Cos(omega);
            b[2] = 1.0f;

            return new Tuple<float[], float[]>(a, b);
        }
        /// <summary>
        /// ローシェルフフィルタ
        /// </summary>
        /// <returns></returns>
        public Tuple<float[], float[]> LSHF()
        {
            float[] a = new float[3];
            float[] b = new float[3];

            float omega = 2.0f * (float)Math.PI * permissibleFrequency / samplingFrequency;
            float alpha = (float)Math.Sin(omega) / (2.0f * q);
            float A = (float)Math.Pow(10.0f, (gain / 40.0f));
            float beta = (float)Math.Sqrt(A) / q;

            a[0] = (A + 1.0f) + (A - 1.0f) * (float)Math.Cos(omega) + beta * (float)Math.Sin(omega);
            a[1] = -2.0f * ((A - 1.0f) + (A + 1.0f) * (float)Math.Cos(omega));
            a[2] = (A + 1.0f) + (A - 1.0f) * (float)Math.Cos(omega) - beta * (float)Math.Sin(omega);
            b[0] = A * ((A + 1.0f) - (A - 1.0f) * (float)Math.Cos(omega) + beta * (float)Math.Sin(omega));
            b[1] = 2.0f * A * ((A - 1.0f) - (A + 1.0f) * (float)Math.Cos(omega));
            b[2] = A * ((A + 1.0f) - (A - 1.0f) * (float)Math.Cos(omega) - beta * (float)Math.Sin(omega));

            return new Tuple<float[], float[]>(a, b);
        }
        /// <summary>
        /// ハイシェルフフィルタ
        /// </summary>
        /// <returns></returns>
        public Tuple<float[], float[]> HSHF()
        {
            float[] a = new float[3];
            float[] b = new float[3];

            float omega = 2.0f * (float)Math.PI * permissibleFrequency / samplingFrequency;
            float alpha = (float)Math.Sin(omega) / (2.0f * q);
            float A = (float)Math.Pow(10.0f, (gain / 40.0f));
            float beta = (float)Math.Sqrt(A) / q;

            a[0] = (A + 1.0f) - (A - 1.0f) * (float)Math.Cos(omega) + beta * (float)Math.Sin(omega);
            a[1] = 2.0f * ((A - 1.0f) - (A + 1.0f) * (float)Math.Cos(omega));
            a[2] = (A + 1.0f) - (A - 1.0f) * (float)Math.Cos(omega) - beta * (float)Math.Sin(omega);
            b[0] = A * ((A + 1.0f) + (A - 1.0f) * (float)Math.Cos(omega) + beta * (float)Math.Sin(omega));
            b[1] = -2.0f * A * ((A - 1.0f) + (A + 1.0f) * (float)Math.Cos(omega));
            b[2] = A * ((A + 1.0f) + (A - 1.0f) * (float)Math.Cos(omega) - beta * (float)Math.Sin(omega));

            return new Tuple<float[], float[]>(a, b);
        }
        /// <summary>
        /// ピーキングフィルタ
        /// </summary>
        /// <returns></returns>
        public Tuple<float[], float[]> PKF()
        {
            float[] a = new float[3];
            float[] b = new float[3];

            float omega = 2.0f * (float)Math.PI * permissibleFrequency / samplingFrequency;
            float alpha = (float)Math.Sin(omega) * (float)Math.Sinh(Math.Log(2.0f) / 2.0f * bw * omega / Math.Sin(omega));
            float A = (float)Math.Pow(10.0f, (gain / 40.0f));

            a[0] = 1.0f + alpha / A;
            a[1] = -2.0f * (float)Math.Cos(omega);
            a[2] = 1.0f - alpha / A;
            b[0] = 1.0f + alpha * A;
            b[1] = -2.0f * (float)Math.Cos(omega);
            b[2] = 1.0f - alpha * A;

            return new Tuple<float[], float[]>(a, b);
        }
        /// <summary>
        /// ピーキングフィルタ
        /// </summary>
        /// <returns></returns>
        public Tuple<float[], float[]> APF()
        {
            float[] a = new float[3];
            float[] b = new float[3];

            float omega = 2.0f * (float)Math.PI * permissibleFrequency / samplingFrequency;
            float alpha = (float)Math.Sin(omega) / (2.0f * q);

            a[0] = 1.0f + alpha;
            a[1] = -2.0f * (float)Math.Cos(omega);
            a[2] = 1.0f - alpha;
            b[0] = 1.0f - alpha;
            b[1] = -2.0f * (float)Math.Cos(omega);
            b[2] = 1.0f + alpha;

            return new Tuple<float[], float[]>(a, b);
        }

    }
}
