using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DCAM
{
    class OutputFile
    {
        /// <summary>
        /// FFT後のデータを出力
        /// </summary>
        /// <param name="Filename"></param>
        /// <param name="complex"></param>
        /// <param name="supectrum"></param>
        public void OutputComplexData(string Filename, Tuple<float[],float[]> complex, float[] supectrum)
        {
            if (complex == null) return;

            // 実行ファイルのディレクトリを取得
            string CurrentPath = Directory.GetCurrentDirectory();

            //親ディレクトリを取得
            for (int i = 0; i < 3; i++)
            {
                CurrentPath = Path.GetDirectoryName(CurrentPath);
            }

            //パス
            string FilePath = CurrentPath + "\\Output\\" + Filename + ".csv";

            //もしファイルパスが存在しなければ作成
            if (Directory.Exists(CurrentPath + "\\Output\\") == false) Directory.CreateDirectory(CurrentPath + "\\Output\\");

            //CSVファイルに書き込むときに使うEncoding
            System.Text.Encoding enc =
                System.Text.Encoding.GetEncoding("Shift_JIS");

            //書き込むファイルを開く
            System.IO.StreamWriter sr =
                new System.IO.StreamWriter(FilePath, false, enc);

            StringBuilder outputData = new StringBuilder();

            outputData.Append("time" + "," + "signal" + "\r\n");

            for (int i = 0; i < complex.Item1.Length; i++)
            {
                outputData.Append(complex.Item1[i] + "," + supectrum[i] + "\r\n");

                if (i == complex.Item1.Length / 2) { sr.Write(outputData); outputData = new StringBuilder(); }
            }
            sr.Write(outputData);

            sr.Close();

            Process.Start(Path.GetDirectoryName(FilePath));
        }
    }
}
