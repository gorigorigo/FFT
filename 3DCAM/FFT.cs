using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace _3DCAM
{
    class FFT
    {
        /// <summary>
        /// タイプを表記
        /// FFTの場合，-1
        /// IFFTの場合，1
        /// </summary>
        public enum Type { fft = -1, ifft = 1 };
        /// <summary>
        /// FFTのデータ点数
        /// </summary>
        private readonly int n_FFT;
        /// <summary>
        /// タイプ
        /// </summary>
        private readonly Type type;
        /// <summary>
        /// 回転因子
        /// </summary>
        private readonly float[][] wTable;
        /// <summary>
        /// ビット逆順用
        /// </summary>
        private readonly int[] bTable;
        /// <summary>
        /// 作業領域
        /// </summary>
        private static float[] reG;
        /// <summary>
        /// 作業領域
        /// </summary>
        private static float[] imG;
        /// <summary>
        /// 出力用
        /// </summary>
        private static float[] output;
        /// <summary>
        /// 窓関数の番号
        /// </summary>
        private static int windowNumber;

        public FFT(Tuple<float[], float[]> waves, int Window, Type tp = Type.fft)
        {
            //2の乗数かチェック
            bool checkWhetherMulutiplier = Checker(waves.Item1);

            //もし2の乗数じゃなければnullを返す
            //元データを壊さないように保管
            if (tp == Type.fft)
            {
                if (checkWhetherMulutiplier == false) reG = Interpolation(waves.Item1, 1);
                else { reG = new float[waves.Item1.Length]; Array.Copy(waves.Item1, reG, waves.Item1.Length); }
            }
            else if (tp == Type.ifft) { reG = waves.Item1; imG = waves.Item2; }
            type = tp;
            output = new float[reG.Length];
            windowNumber = Window;

            //回転因子を格納
            wTable = RotationFactor();
            //ビット逆順を格納
            bTable = GetBitReverse();
        }

        public Tuple<float[], float[]> Execute(int conduct)
        {
            //窓関数にかけるかどうか
            if (conduct == 1) reG = Windowing(reG, windowNumber);

            //虚数成分に複製
            if (type == Type.fft)
            {
                imG = new float[reG.Length];
                Array.Copy(reG, imG, reG.Length);
            }

            //虚数部データにビット逆順をかけて実数部データとして保存し、その虚数部データをクリア
            MergeReAndIm();

            //バタフライ演算
            ButterflyOperations();

            if (type == Type.ifft) for (int i = 0; i < reG.Length; i++) { reG[i] /= reG.Length; imG[i] /= reG.Length; }

            ////振幅を取得
            //output = GetAmplitude();

            //return output;
            return new Tuple<float[], float[]>(reG, imG);
        }

        /// <summary>
        ///2の乗数か確認
        /// </summary>
        /// <param name="waves"></param>
        /// <returns></returns>
        private bool Checker(float[] waves)
        {
            if (waves.Length < 2) return false;

            for (int i = 2; i < waves.Length; i <<= 1)
            {
                if (waves.Length % i != 0 || waves.Length <= 0) return false;
            }
            return true;
        }
        //回転因子を格納
        private float[][] RotationFactor()
        {
            float[][] rotationFactor = new float[2][] { new float[reG.Length], new float[reG.Length] };
            for (int i = 0; i < reG.Length; i++)
            {
                float arg = ((float)type) * 2.0f * (float)Math.PI / reG.Length * i;
                rotationFactor[0][i] = (float)Math.Cos(arg);
                rotationFactor[1][i] = (float)Math.Sin(arg);
            }
            return rotationFactor;
        }
        //ビット逆順を格納
        private int[] GetBitReverse()
        {
            int[] bitReverse = new int[reG.Length];
            int lC = reG.Length;
            for (int i = 0; i < lC; i++)
            {
                int order = i;
                int reverse = 0;
                for (int j = lC >> 1; j >= 1; j >>= 1)
                {
                    reverse += (order % 2) * j;
                    order >>= 1;
                }
                bitReverse[i] = reverse;
            }
            return bitReverse;
        }
        //虚数部データにビット逆順をかけて実数部データとして保存し、その虚数部データをクリア
        private void MergeReAndIm()
        {
            for (int i = 0; i < reG.Length; i++)
            {
                int index = bTable[i];
                reG[i] = imG[index];
                imG[index] = 0;
            }
        }
        //バタフライ演算
        private void ButterflyOperations()
        {
            int lC = reG.Length;
            for (int i = 1; i < lC; i <<= 1)
            {
                for (int j = 0; j < lC; j += i << 1)
                {
                    for (int k = 0; k < i; k++)
                    {
                        int a = j + k;
                        int b = a + i;
                        int w = lC / (2 * i) * k;

                        float ar = reG[a] + (reG[b] * wTable[0][w]) - (imG[b] * wTable[1][w]);
                        float ai = imG[a] + (reG[b] * wTable[1][w]) + (imG[b] * wTable[0][w]);
                        float br = reG[a] - (reG[b] * wTable[0][w]) + (imG[b] * wTable[1][w]);
                        float bi = imG[a] - (reG[b] * wTable[1][w]) - (imG[b] * wTable[0][w]);

                        reG[a] = ar;
                        imG[a] = ai;
                        reG[b] = br;
                        imG[b] = bi;
                    }
                }
            }
        }

        public float[] GetAmplitude(Tuple<float[], float[]> g)
        {
            float[] amplitude = new float[g.Item1.Length];
            for (int i = 0; i < reG.Length >> 1; i++)
            {
                //片側振幅なので2倍
                float re = g.Item1[i] * 2 / g.Item1.Length;
                float im = g.Item2[i] * 2 / g.Item1.Length;

                //スペクトルを取得
                amplitude[i] = (float)Math.Sqrt(Math.Pow(re, 2) + Math.Pow(im, 2));
            }
            return amplitude;
        }

        /// <summary>
        /// 窓関数
        /// </summary>
        /// <param name="wavesValue"></param>
        /// <param name="conductNumber"></param>
        /// <returns></returns>
        public float[] Windowing(float[] wavesValue, int conductNumber)
        {
            float[] winWave = (float[])wavesValue.Clone();

            float winValue = 0;
            int size = wavesValue.Length;

            for (int i = 0; i < size; i++)
            {
                //ハミング窓
                if (conductNumber == 0)
                {
                    winValue = (float)(0.54 - 0.46 * Math.Cos(2 * Math.PI * i / (size - 1)));
                }
                //ハニング窓
                else if (conductNumber == 1)
                {
                    winValue = (float)(0.5 - 0.5 * Math.Cos(2 * Math.PI * i / (size - 1)));
                }
                //ブッラクマン窓
                else if (conductNumber == 2)
                {
                    winValue = (float)(0.42 - 0.5 * Math.Cos(2 * Math.PI * i / (size - 1))
                                    + 0.08 * Math.Cos(4 * Math.PI * i / (size - 1)));
                }
                //レクタングル窓
                else if (conductNumber == 3)
                {
                    winValue = 1.0f;
                }
                else
                {
                    winValue = 1.0f;
                }
                winWave[i] *= winValue;
            }
            return winWave;
        }
        /// <summary>
        /// 点数補間
        /// </summary>
        /// <param name="mergeWave"></param>
        /// <param name="conduct"></param>
        /// <returns></returns>
        private float[] Interpolation(float[] mergeWave, int conduct)
        {
            int count = 2;
            while (count < mergeWave.Length) count <<= 1;

            float[] transformed = new float[count];
            Array.Copy(mergeWave, transformed, mergeWave.Length);

            //反転補間
            if (conduct == 1)
            {
                int index = 2;
                for (int i = mergeWave.Length; i < count; i++)
                {
                    transformed[i] = mergeWave[mergeWave.Length - index];
                    index++;
                }
            }
            return transformed;
        }
    }


    class IFFT
    {
        /// <summary>
        /// タイプを表記
        /// FFTの場合，-1
        /// IFFTの場合，1
        /// </summary>
        public enum Type { fft = -1, ifft = 1 };

        /// <summary>
        /// FFTのデータ点数
        /// </summary>
        private readonly int n_FFT;
        /// <summary>
        /// タイプ
        /// </summary>
        private readonly Type type;
        /// <summary>
        /// 回転因子
        /// </summary>
        private readonly Complex[] wTable;
        /// <summary>
        /// ビット逆順用
        /// </summary>
        private readonly int[] bTable;
        /// <summary>
        /// 作業領域
        /// </summary>
        private Complex[] g;
        /// <summary>
        /// 出力用
        /// </summary>
        private Complex[] output;

        public IFFT(int n, Type ty = Type.fft)
        {
            Debug.Assert(n >= 2);
            int pw = n;
            while ((pw & 0x1) == 0) pw >>= 1;
            Debug.Assert(pw == 0x1);


            n_FFT = n;
            type = ty;

            wTable = TwiddleFactor();
            bTable = BitReverse();

            g = new Complex[n_FFT];
            output = new Complex[n_FFT];
        }
        public Complex[] Execute(Complex[] xn)
        {
            Debug.Assert(xn.Length == n_FFT);

            Array.Copy(xn, g, n_FFT);
            int next = n_FFT;

            for (int stage = 1; stage < n_FFT; stage <<= 1)
            {
                int half = next / 2;
                for (int m = 0; m < n_FFT; m += next)
                {
                    int k = 0;
                    for (int n = m; n < m + half; n++)
                    {
                        Complex tmp = g[n];
                        g[n] = tmp + g[n + half];
                        g[n + half] = (tmp - g[n + half]) * wTable[k];
                        k = k + stage;
                    }
                }
                next = half;
            }

            if (type == Type.fft)
                for (int n = 0; n < n_FFT; n++) output[n] = g[bTable[n]];
            else
                for (int n = 0; n < n_FFT; n++) output[n] = g[bTable[n]] / n_FFT;

            return output;
        }

        private Complex[] TwiddleFactor()
        {
            Complex arg = ((float)type) * 2 * Math.PI * Complex.ImaginaryOne / n_FFT;
            Complex[] w = Enumerable.Range(0, n_FFT / 2).AsParallel().AsOrdered().Select(x => Complex.Exp(arg * x)).ToArray();
            return w;
        }
        private int[] BitReverse()
        {
            int offset = n_FFT >> 1;
            int[] br = new int[n_FFT];
            br[0] = 0;
            for (int n = 1; n < n_FFT; n <<= 1)
            {
                for (int k = 0; k < n; k++) br[k + n] = br[k] + offset;
                offset >>= 1;
            }
            return br;

        }
    }
}
