using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DCAM.MurataKun
{
    class ConvertDataMT
    {
        /// <summary>
        /// ファイルデータ
        /// </summary>
        private readonly List<float[]> fileData;
        /// <summary>
        /// データ変更種類を列挙
        /// </summary>
        private enum CovertType { REMOVE};
        /// <summary>
        /// 種類
        /// </summary>
        private CovertType CT;

        public ConvertDataMT(List<float[]> FileData)
        {
            fileData = FileData;

            CT = CovertType.REMOVE;
        }

        public void Execute()
        {
            if (CT == CovertType.REMOVE)
            {
                StaticDataMT.mesureData = RemoveWasteData(StaticDataMT.resolution);
            }
        }
        /// <summary>
        /// -999のデータを削除
        /// </summary>
        /// <returns></returns>
        private Tuple<List<float[]>,List<float[]>> RemoveWasteData(float resolution)
        {
            List<float[]> mesureData = new List<float[]>();
            List<float[]> timeData = new List<float[]>();

            for (int i = 0; i < fileData.Count; i++)
            {
                List<float> data = new List<float>();
                List<float> time = new List<float>();

                for (int j = 0; j < fileData[i].Length; j++)
                {
                    if (fileData[i][j] > -900)
                    {
                        time.Add((float)Math.Round(j * resolution * 1000) / 1000);
                        data.Add(fileData[i][j]);
                    }
                }
                timeData.Add(time.ToArray());
                mesureData.Add(data.ToArray());
            }

            return new Tuple<List<float[]>, List<float[]>>(timeData, mesureData);
        }
    }
}
