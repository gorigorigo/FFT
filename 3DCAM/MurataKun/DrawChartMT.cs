using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace _3DCAM.MurataKun
{
    class DrawChartMT
    {
        /// <summary>
        /// データの描画
        /// </summary>
        /// <param name="chart"></param>グラフ
        /// <param name="seriesName"></param>シリーズ名
        /// <param name="data"></param>描画するデータ
        /// <param name="title"></param>グラフタイトル
        /// <param name="axesTitles"></param>X,Y軸のタイトル
        public static void DoDrawMesureData(Chart chart, string[] seriesName, List<float[]> data, string title, string[] axesTitles, float[] time)
        {
            #region 実験
            //初期化
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            //タイトル
            Title title1 = new Title(title);

            //チャートエリア
            ChartArea area1 = new ChartArea();
            area1.AxisX.Title = axesTitles[0];
            area1.AxisY.Title = axesTitles[1];

            //タイトル，エリアを加える
            chart.Titles.Add(title1);
            chart.ChartAreas.Add(area1);

            //軸最小値、最大値、目盛間隔の設定
            Series[] SelectedData = new Series[data.Count];

            chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = true;
            //chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = 10;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.Gray;

            //Y軸の幅を定義
            float yband = 5;
            chart.ChartAreas["ChartArea1"].AxisY.Maximum = yband * (data.Count) + 0.0001f;


            //データ格納
            for (int Item = 0; Item < seriesName.Length; Item++)
            {
                //設定
                SelectedData[Item] = new Series();
                //SelectedData[Item].ChartType = SeriesChartType.Line;
                SelectedData[Item].ChartType = SeriesChartType.Point;
                SelectedData[Item].IsVisibleInLegend = false;
                SelectedData[Item].BorderWidth = 3;
                SelectedData[Item].MarkerStyle = MarkerStyle.None;
                SelectedData[Item].LegendText = seriesName[Item];
                SelectedData[Item].IsVisibleInLegend = false;
                SelectedData[Item].MarkerSize = 1;
                chart.Series.Add(SelectedData[Item]);

                //データ追加
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < data[i].Length / 2; j++)
                    {
                        int former = (j - 1); if (j == 0) former = 0;

                        SelectedData[Item].Points.AddXY(time[0] + time[1] * j, yband * i);
                    }
                }
            }

            #endregion
        }


        public static void DoDrawCenter(Chart chart, string[] seriesName, Tuple<float[],float[]> data, string title, string[] axesTitles)
        {
            #region 実験
            //初期化
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            //タイトル
            Title title1 = new Title(title);

            //チャートエリア
            ChartArea area1 = new ChartArea();
            area1.AxisX.Title = axesTitles[0];
            area1.AxisY.Title = axesTitles[1];

            //タイトル，エリアを加える
            chart.Titles.Add(title1);
            chart.ChartAreas.Add(area1);

            //軸最小値、最大値、目盛間隔の設定
            Series[] SelectedData = new Series[data.Item1.Length];

            //chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = true;
            chart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;

            //chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = 10;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.Gray;

            //Y軸の幅を定義
            float ymin = float.MaxValue;
            //chart.ChartAreas["ChartArea1"].AxisY.Maximum = yband * (data.Count) + 0.0001f;


            //データ格納
            for (int Item = 0; Item < seriesName.Length; Item++)
            {
                //設定
                SelectedData[Item] = new Series();
                //SelectedData[Item].ChartType = SeriesChartType.Line;
                SelectedData[Item].ChartType = SeriesChartType.Point;
                SelectedData[Item].IsVisibleInLegend = false;
                SelectedData[Item].BorderWidth = 3;
                SelectedData[Item].MarkerStyle = MarkerStyle.None;
                SelectedData[Item].LegendText = seriesName[Item];
                SelectedData[Item].IsVisibleInLegend = false;
                //SelectedData[Item].MarkerSize = 1;
                chart.Series.Add(SelectedData[Item]);

                //データ追加
                for (int i = 0; i < data.Item1.Length; i++)
                {
                    SelectedData[Item].Points.AddXY(data.Item1[i], data.Item2[i]);
                    if (data.Item2[i] < ymin) ymin = data.Item2[i];
                }
            }

            chart.ChartAreas["ChartArea1"].AxisY.Minimum = ymin - 0.01f;

            #endregion
        }

        /// <summary>
        /// データの描画
        /// </summary>
        /// <param name="chart"></param>グラフ
        /// <param name="seriesName"></param>シリーズ名
        /// <param name="data"></param>描画するデータ
        /// <param name="title"></param>グラフタイトル
        /// <param name="axesTitles"></param>X,Y軸のタイトル
        public static void DoDrawChartFre(Chart chart, string[] seriesName, float[] data, string title, string[] axesTitles, float[] time)
        {
            //初期化
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            //タイトル
            Title title1 = new Title(title);

            //チャートエリア
            ChartArea area1 = new ChartArea();
            area1.AxisX.Title = axesTitles[0];
            area1.AxisY.Title = axesTitles[1];

            //タイトル，エリアを加える
            chart.Titles.Add(title1);
            chart.ChartAreas.Add(area1);

            //軸最小値、最大値、目盛間隔の設定
            Series[] SelectedData = new Series[seriesName.Length];

            //chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = true;
            //chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = 10;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.Gray;

            float ymin = float.MaxValue;

            //データ格納
            for (int Item = 0; Item < seriesName.Length; Item++)
            {
                //設定
                SelectedData[Item] = new Series();
                //SelectedData[Item].ChartType = SeriesChartType.Line;
                SelectedData[Item].ChartType = SeriesChartType.FastLine;
                SelectedData[Item].IsVisibleInLegend = false;
                SelectedData[Item].BorderWidth = 3;
                SelectedData[Item].MarkerStyle = MarkerStyle.None;
                SelectedData[Item].LegendText = seriesName[Item];
                SelectedData[Item].IsVisibleInLegend = true;
                chart.Series.Add(SelectedData[Item]);


                //データ追加
                for (int i = 10; i < data.Length / 2; i++)
                {
                    SelectedData[Item].Points.AddXY(time[0] + time[1] * i, data[i]);
                    if (data[i] < ymin) ymin = data[i];
                }
            }

            //chart.ChartAreas["ChartArea1"].AxisY.Minimum = ymin - 0.00001f; ;
        }




        /// <summary>
        /// データの描画
        /// </summary>
        /// <param name="chart"></param>グラフ
        /// <param name="seriesName"></param>シリーズ名
        /// <param name="data"></param>描画するデータ
        /// <param name="title"></param>グラフタイトル
        /// <param name="axesTitles"></param>X,Y軸のタイトル
        public static void DoDrawChart(Chart chart, string[] seriesName, float[] data, string title, string[] axesTitles, float[] time)
        {
            //初期化
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            //タイトル
            Title title1 = new Title(title);

            //チャートエリア
            ChartArea area1 = new ChartArea();
            area1.AxisX.Title = axesTitles[0];
            area1.AxisY.Title = axesTitles[1];

            //タイトル，エリアを加える
            chart.Titles.Add(title1);
            chart.ChartAreas.Add(area1);

            //軸最小値、最大値、目盛間隔の設定
            Series[] SelectedData = new Series[seriesName.Length];

            //chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = true;
            //chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = 10;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.Gray;

            float ymin = float.MaxValue;

            //データ格納
            for (int Item = 0; Item < seriesName.Length; Item++)
            {
                //設定
                SelectedData[Item] = new Series();
                //SelectedData[Item].ChartType = SeriesChartType.Line;
                SelectedData[Item].ChartType = SeriesChartType.FastLine;
                //SelectedData[Item].ChartType = SeriesChartType.FastPoint;
                SelectedData[Item].IsVisibleInLegend = false;
                SelectedData[Item].BorderWidth = 1;
                SelectedData[Item].MarkerStyle = MarkerStyle.None;
                SelectedData[Item].LegendText = seriesName[Item];
                SelectedData[Item].IsVisibleInLegend = true;
                SelectedData[Item].MarkerSize = 1;
                chart.Series.Add(SelectedData[Item]);


                //データ追加
                for (int i = 10; i < data.Length; i++)
                {
                    SelectedData[Item].Points.AddXY(time[0] + time[1] * i, data[i]);
                    if (data[i] < ymin) ymin = data[i];
                }
            }

            chart.ChartAreas["ChartArea1"].AxisY.Minimum = ymin - 0.00001f; ;
        }

    }
}
