using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace _3DCAM.MurataKun
{
    class OpenFileMT
    {
        #region 変数定義
        /// <summary>
        /// ファイルの種類を列挙
        /// </summary>
        private enum FileType { ASCII,BYNARY,NONE};
        /// <summary>
        /// ファイルの拡張子を列挙
        /// </summary>
        private enum ExtensionType { CSV,TXT,NONE};
        /// <summary>
        /// ファイルタイプ
        /// </summary>
        private readonly FileType fType = FileType.NONE;
        /// <summary>
        /// 拡張子
        /// </summary>
        private readonly ExtensionType eType = ExtensionType.NONE;
        /// <summary>
        /// ファイルパス
        /// </summary>
        private readonly string filePath;
        /// <summary>
        ///ファイルチェッカー
        /// </summary>
        private bool processError = false;
        #endregion

        public OpenFileMT()
        {
            //ファイルパスを取得
            GetFilePath("", "Select Data", ref filePath);

            //ファイルを選択していなけらばここで処理を終了
            if (filePath.Contains("empty")) return;

            //ファイルがバイナリかどうか
            if (IsBinaryFile(filePath)) fType = FileType.BYNARY;

            //ファイルがテキストタイプかどうか
            else if (IsTextFile(filePath)) fType = FileType.ASCII;

            //ファイルがcsvかどうか
            if (filePath.Contains("csv")) eType = ExtensionType.CSV;

            //ファイルがtxtかどうか
            else if (filePath.Contains("txt")) eType = ExtensionType.TXT;

            //今回設定したファイル以外を選択した場合
            if (eType == ExtensionType.NONE || fType == FileType.NONE) MessageBox.Show("設定ファイル以外を選択しています");
        }
        public List<float[]> Execute()
        {
            //規定ファイル以外を選択したらここで処理を終了
            if (eType == ExtensionType.NONE || fType == FileType.NONE) return new List<float[]>();

            //数値データ
            List<float[]> numericalFileData = new List<float[]>();

            //ファイルタイプと拡張子によって処理を変更
            if (eType == ExtensionType.CSV)
            {
                if (fType == FileType.ASCII)
                {
                    //データを読み込む
                    List<string> fileData = InputDataReadLine();

                    //数値データに変換
                    numericalFileData = ConverDataFromString(fileData);
                }
                else if (fType == FileType.BYNARY)
                {

                }
            }
            else if (eType == ExtensionType.TXT)
            {
                if (fType == FileType.ASCII)
                {

                }
                else if (fType == FileType.BYNARY)
                {

                }
            }

            if(processError)
            {
                MessageBox.Show("問題が発生しました");
            }

            return numericalFileData;
        }
        /// <summary>
        /// ファイルパスを選択
        /// </summary>
        /// <param name="path"></param>
        /// <param name="title"></param>
        /// <param name="filePath"></param>
        private void GetFilePath(string path, string title, ref string filePath)
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
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] byteData = new byte[1];
            while (file.Read(byteData, 0, byteData.Length) > 0)
            {
                if (byteData[0] == 0)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// CSVファイルを読み取り
        /// </summary>
        /// <returns></returns>
        private List<string> InputDataReadLine()
        {
            //ファイルデータ
            List<string> fileData = new List<string>();

            try
            {
                using(var sr=new StreamReader(filePath))
                {
                    while(!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        fileData.Add(line);
                    }
                }
            }
            catch
            {
                MessageBox.Show("読み込めないデータが存在しました");

                processError = true;
            }

            return fileData;
        }
        /// <summary>
        /// 文字データを数値データに変換
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        private List<float[]> ConverDataFromString(List<string>fileData)
        {
            //データが取得できていなければ返す
            if (fileData.Count == 0)
            {
                processError = true;

                return null;
            }

            List<float[]> numericalData = new List<float[]>();

            //データ点数
            int dataCount = fileData.Count;

            //分割する文字
            char[] delimiter = { ',' };

            for (int i = 0; i < dataCount; i++)
            {
                //データを分割する
                string[] srData = fileData[i].Split(delimiter);

                //数値化後のデータ
                float[] nrData = new float[srData.Length];

                //データが変更できたかどうか
                bool[] isConvertData = new bool[srData.Length];

                for (int j = 0; j < srData.Length; j++)
                {
                    isConvertData[j] = float.TryParse(srData[j], out nrData[j]);
                }

                //全てのデータが数値変換できているなら加える
                if (Enumerable.Range(0, srData.Length).All(j => isConvertData[j])) numericalData.Add(nrData);
            }

            if (numericalData.Count == 0) processError = true;

            return numericalData;
        }
    }
}
