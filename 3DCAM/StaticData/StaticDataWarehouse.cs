using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DCAM
{
    class StaticDataWarehouse
    {
        /// <summary>
        /// フィルタをかけたかどうかのフラグ
        /// </summary>
        public static bool didFilter = false;
        /// <summary>
        /// フィルタをかけたデータ
        /// </summary>
        public static float[] filteredData;
        /// <summary>
        /// フィルタをかけた複素数データ
        /// </summary>
        public static Tuple<float[], float[]> filteredComplexData;
    }
}
