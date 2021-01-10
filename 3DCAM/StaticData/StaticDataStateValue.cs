using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DCAM
{
    class StaticDataStateValue
    {
        /// <summary>
        /// 合成波
        /// </summary>
        public static Tuple<float[], float[]> synthticWave;

        /// <summary>
        /// FFT後のデータ
        /// </summary>
        public static Tuple<float[], float[]> complexData;

        /// <summary>
        /// 分割したFFT後のデータ
        /// </summary>
        public static List<Tuple<float[], float[]>> parcialComplexData;

        /// <summary>
        /// 分割したスペクトルリスト
        /// </summary>
        public static List<float[]> parcialSpectrum;

        /// <summary>
        /// FFT解析後のスペクトル
        /// </summary>
        public static float[] spectol;

        /// <summary>
        /// FFT解析後フィルター後のスペクトル
        /// </summary>
        public static float[] filteredSpectrum;

        /// <summary>
        /// 実際に計算に用いた点数
        /// </summary>
        public static int actuallyNumber;

        /// <summary>
        /// 最大のスペクトル
        /// </summary>
        public static float maxSpectrum;
    }
}
