using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DCAM
{
    class StaticDataSetting
    {
        /// <summary>
        /// 読み込んだファイルパス
        /// </summary>
        public static string filePath;

        /// <summary>
        /// 読み込んだ直後の生データ
        /// </summary>
        public static List<string> rawValue;

        /// <summary>
        /// サンプリング周波数
        /// </summary>
        public static float samplingFrequency;

        /// <summary>
        /// 直流バイアス
        /// </summary>
        public static float biasDC;

        /// <summary>
        /// サンプリング数
        /// </summary>
        public static int theNumberOfSampling;

        /// <summary>
        /// 合成する波の種類
        /// </summary>
        public static float kindOfWaves;

        /// <summary>
        /// 最大周波数
        /// </summary>
        public static float maxFreaquency;

        /// <summary>
        /// 分割数
        /// </summary>
        public static int divisionNumber;

        /// <summary>
        /// 全体の行数
        /// </summary>
        public static int totalNumber;

        /// <summary>
        /// 解析の最初の行数
        /// </summary>
        public static int startPosition;

        /// <summary>
        ///解析の終了行数
        /// </summary>
        public static int endPosition;
    }
}
