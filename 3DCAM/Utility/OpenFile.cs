using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace _3DCAM
{
    class OpenFile
    {
        public void GetFilePath(string path, string title, ref string filePath)
        {
            //実行ファイルのディレクトリを取得
            string CurrentPath = Directory.GetCurrentDirectory();

            //親ディレクトリを取得
            for (int i = 0; i < 3; i++)
            {
                CurrentPath = Path.GetDirectoryName(CurrentPath);
            }

            //オープンファイルダイアログを表示する
            OpenFileDialog op = new OpenFileDialog();
            op.Title = title;
            op.InitialDirectory = CurrentPath + "\\" + path;
            op.FilterIndex = 1;
            //オープンファイルダイアログを表示する
            DialogResult result = op.ShowDialog();

            filePath = "empty";

            if (result == DialogResult.OK)
            {
                //「開く」ボタンが選択された時の処理
                filePath = op.FileName;
            }
            else if (result == DialogResult.Cancel)
            {
                //「キャンセル」ボタンまたは「×」ボタンが選択された時の処理
            }
        }


        //形状データを読み込む
        public void InputSolidData(ref List<string> waveDataList, string filePath)
        {
            //ファイルの読み込み行数
            int countOfLine = 0;
            //ファイルのデータのリスト(コマ数を先に把握するため)
            List<string> lineList = new List<string>();
            //分割する文字
            string[] delimiter = { " " };

            //生ソリッドデータを初期化
            waveDataList = new List<string>();

            try
            {
                // csvファイルを開く
                using (var sr = new StreamReader(filePath))
                {
                    // ストリームの末尾まで繰り返す(ここの繰り返しがシーン数となる)
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        //リストに追加する．
                        lineList.Add(line);

                        countOfLine++;
                    }
                }

                //読み込んだファイルをデータに格納する．
                int numOfData = lineList.Count;

                for (int index = 0; index < numOfData; index++)
                {
                    //読み込んだ一行をsスペース毎に分けて配列に格納する
                    string[] values = lineList[index].Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                    //リストに追加
                    for (int i = 0; i < values.Length; i++)
                    {
                        //現在の列にあるデータをリストに格納
                        waveDataList.Add(values[i]);
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                Console.WriteLine(e.Message);
            }
        }
    }
}
