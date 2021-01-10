using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DCAM
{
    class GetSyntheticWave
    {
        /// <summary>
        /// csvかつテキスト形式ファイルのみを読み込み
        /// </summary>
        /// <param name="pathName"></param>
        public GetSyntheticWave(string pathName)
        {
            //拡張子チェック
            string fileName = Path.GetExtension(pathName);

            //何も読み込んでいない
            fileType = FileType.NONE;

            //csvファイルの場合
            if (fileName.Contains("csv"))
            {
                //CSVファイルかチェック
                Debug.Assert(fileName.Contains("csv"));

                //バイナリファイルかチェック
                Debug.Assert(IsBinaryFile(pathName) == false);

                //テキストファイルかチェック
                Debug.Assert(IsTextFile(pathName));

                //ファイルタイプを格納
                fileType = FileType.CSV;
            }
            else if (fileName.Contains("nsmp"))
            {
                //バイナリファイルかチェック
                Debug.Assert(IsBinaryFile(pathName));

                //テキストファイルかチェック
                Debug.Assert(IsTextFile(pathName) == false);

                //ファイルタイプを格納
                fileType = FileType.NSMP;
            }

            //パスを読み込む
            path = pathName;
        }
        /// <summary>
        /// ファイルの種類
        /// </summary>
        private enum FileType { CSV, NSMP, NONE };
        /// <summary>
        ///ファイルチェッカー
        /// </summary>
        private bool processError;
        /// <summary>
        /// ファイルパス名
        /// </summary>
        private string path;
        /// <summary>
        /// 今回のファイルタイプ
        /// </summary>
        private FileType fileType;


        /// <summary>
        /// ファイルの値を取得
        /// </summary>
        /// <param name="samplingFrequency"></param>
        /// <returns></returns>
        public Tuple<float[], float[]> GetFileWave(ref float samplingFrequency)
        {
            //生の文字データ
            List<string> rawValue = new List<string>();

            //生データを獲得
            new OpenFile().InputSolidData(ref rawValue, path);

            Tuple<float[], float[]> fileWave = new Tuple<float[], float[]>(new float[0], new float[0]);

            //csvファイルのとき
            if (fileType == FileType.CSV)
            {
                //波のデータを獲得
                fileWave = GetWavesFromCSV(rawValue, ref samplingFrequency);
            }

            else if (fileType == FileType.NSMP)
            {
                fileWave = ReadBinaryFile(path, ref samplingFrequency);
            }
            return fileWave;
        }
        /// <summary>
        /// 生データを変換
        /// </summary>
        /// <param name="rawValue"></param>
        /// <param name="samplingFrequency"></param>
        /// <returns></returns>
        private Tuple<float[], float[]> GetWavesFromCSV(List<string> rawValue, ref float samplingFrequency)
        {
            //振動の値を格納するリスト
            List<float> amplitude = new List<float>();
            //サンプリング時間
            List<float> samplingTime = new List<float>();

            for (int i = 0; i < rawValue.Count; i++)
            {
                //生データを分割
                string[] tmp = rawValue[i].Split(',');

                //数値変換後の値
                float[] amp = new float[tmp.Length];

                //分割データの数値化を判断
                bool[] convert = new bool[tmp.Length];

                //変換
                for (int j = 0; j < tmp.Length; j++) convert[j] = float.TryParse(tmp[j], out amp[j]);

                //全てにおいてtrueならば値を加算
                if (Enumerable.Range(0, tmp.Length).All(j => convert[j]))
                {
                    //サンプリング時間を格納
                    samplingTime.Add(amp[0]);
                    //振幅を格納
                    amplitude.Add(amp[1]);
                }
            }
            //サンプリング周期を取得
            if (samplingTime.Count > 0) samplingFrequency = (float)Math.Round(1 / (samplingTime[1] - samplingTime[0]));

            return new Tuple<float[], float[]>(samplingTime.ToArray(), amplitude.ToArray());
        }

        private Tuple<float[], float[]> ReadBinaryFile(string filePath, ref float samplingFrequency)
        {
            List<float> waves = new List<float>();
            List<float> time = new List<float>();
            
            //ファイルを読み込む
            byte[] fileBytes = File.ReadAllBytes(filePath);

            //データの長さを取得
            var dataLength = BitConverter.ToInt32(fileBytes, 136);

            //データの総容量を取得
            var dataAmount = BitConverter.ToInt64(fileBytes, 140);

            int count = 0;

            //データを最後まで取得
            for (int i = 156; i < dataAmount; i += 4)
            {
                //波を取得
                float data = BitConverter.ToInt32(fileBytes, i) * 0.02f;
                if (data == 0) continue;
                waves.Add(data);

                //サンプリング時間を取得
                time.Add(count * 0.00002f);

                //waves.Add((float)BitConverter.ToInt32(fileBytes, i) * 0.02f);

                count++;
            }

            if (time.Count > 0) samplingFrequency = 1 / (time[1] - time[0]);

            #region 非同期でバイナリ読み込み
            //Task.Run(async () =>
            //{
            //    byte[] result;

            //    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            //    {
            //        result = new byte[fs.Length];

            //        await fs.ReadAsync(result, 0, (int)fs.Length);

            //        //for (int i = 156; i < 1500000; i += 4)
            //        //{
            //        //    time.Add((i - 156) * 0.0002f);
            //        //    byte[] tt = new byte[] { result[i], result[i + 1], result[i + 2], result[i + 3] };
            //        //    waves.Add((float)BitConverter.ToSingle(result, i));
            //        //}
            //    }
            //});
            #endregion

            return new Tuple<float[], float[]>(time.ToArray(), waves.ToArray());
        }


        /// <summary>
        /// ファイルはバイナリファイルであるかどうか
        /// </summary>
        /// <param name="filePath">パス</param>
        /// <returns>バイナリファイルの場合trueを返す</returns>
        private bool IsBinaryFile(string filePath)
        {
            FileStream fs = File.OpenRead(filePath);
            int len = (int)fs.Length;
            int count = 0;
            byte[] content = new byte[len];
            int size = fs.Read(content, 0, len);

            for (int i = 0; i < size; i++)
            {
                if (content[i] == 0) { count++; if (count == 4) return true; }
                else { count = 0; }
            }
            return false;
        }
        /// <summary>
        /// ファイルはテキストファイルであるかどうか
        /// </summary>
        /// http://www.xuehi.com/
        /// <param name="filePath">パス</param>
        /// <returns>テキストファイルの場合Trueを返す</returns>
        private bool IsTextFile(string filePath)
        {
            FileStream file = new System.IO.FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] byteData = new byte[1];
            while (file.Read(byteData, 0, byteData.Length) > 0)
            {
                if (byteData[0] == 0)
                    return false;
            }
            return true;
        }
    }
}
