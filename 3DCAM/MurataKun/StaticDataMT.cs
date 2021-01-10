using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DCAM.MurataKun
{
    public static class StaticDataMT
    {
        /// <summary>
        /// ファイルデータ
        /// </summary>
        public static List<float[]> fileData { get; set; }

        /// <summary>
        /// 999以外のデータ
        /// </summary>
        public static Tuple<List<float[]>,List<float[]>> mesureData { get; set; }

        /// <summary>
        /// 中心データ
        /// </summary>
        public static Tuple<float[],float[]> centerData { get; set; }

        /// <summary>
        /// FFT後のデータ
        /// </summary>
        public static Tuple<float[], float[]> complexDataX { get; set; }

        /// <summary>
        /// FFT後のデータ
        /// </summary>
        public static Tuple<float[], float[]> complexDataY { get; set; }

        /// <summary>
        /// FFT解析後のスペクトル
        /// </summary>
        public static float[] spectrumX { get; set; }

        /// <summary>
        /// FFT解析後のスペクトル
        /// </summary>
        public static float[] spectrumY { get; set; }


        /// <summary>
        /// データ取得の分解能
        /// </summary>
        public static float resolution { get; set; }

        /// <summary>
        /// 工具径
        /// </summary>
        public static float toolRadius { get; set; }

        /// <summary>
        /// 学習率
        /// </summary>
        public static float scalingFactor { get; set; }

        /// <summary>
        /// 終了条件
        /// </summary>
        public static float endScale { get; set; }
    }
}
