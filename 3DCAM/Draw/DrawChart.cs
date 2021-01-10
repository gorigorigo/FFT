using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace _3DCAM
{
    class DrawChart
    {
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

            chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = true;
            //chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = 10;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.Gray;
            
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
                SelectedData[Item].IsVisibleInLegend = false;
                chart.Series.Add(SelectedData[Item]);

                //データ追加
                for (int i = 0; i < data.Length; i++)
                    SelectedData[Item].Points.AddXY(time[0] + time[1] * i, data[i]);
            }
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

            chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = true;
            //chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = 10;
            chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.Gray;

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
                for (int i = 0; i < data.Length / 2; i++)
                    SelectedData[Item].Points.AddXY(time[0] + time[1] * i, data[i]);
            }
        }

        /// <summary>
        /// データの描画
        /// </summary>
        /// <param name="chart"></param>グラフ
        /// <param name="seriesName"></param>シリーズ名
        /// <param name="data"></param>描画するデータ
        /// <param name="title"></param>グラフタイトル
        /// <param name="axesTitles"></param>X,Y軸のタイトル
        public static void DoDraw3DColorMap(Chart chart, string[] seriesName, List<float[]> data, string title, string[] axesTitles, float[] time)
        {
            #region 最初の設定
            ////初期化
            //chart.Series.Clear();
            //chart.ChartAreas.Clear();
            //chart.Titles.Clear();

            ////タイトル
            //Title title1 = new Title(title);

            ////チャートエリア
            //ChartArea area1 = new ChartArea();
            //area1.AxisX.Title = axesTitles[0];
            //area1.AxisY.Title = axesTitles[1];

            ////タイトル，エリアを加える
            //chart.Titles.Add(title1);
            //chart.ChartAreas.Add(area1);

            ////軸最小値、最大値、目盛間隔の設定
            //Series[] SelectedData = new Series[seriesName.Length];

            //chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            //chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = true;
            ////chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = 10;
            //chart.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.Gray;

            ////データ格納
            //for (int Item = 0; Item < seriesName.Length; Item++)
            //{
            //    //設定
            //    SelectedData[Item] = new Series();
            //    //SelectedData[Item].ChartType = SeriesChartType.Line;
            //    SelectedData[Item].IsVisibleInLegend = false;
            //    SelectedData[Item].BorderWidth = 3;
            //    SelectedData[Item].MarkerStyle = MarkerStyle.None;
            //    SelectedData[Item].LegendText = seriesName[Item];
            //    //SelectedData[Item].IsVisibleInLegend = true;
            //    chart.Series.Add(SelectedData[Item]);
            //    //SelectedData[Item].ChartType = SeriesChartType.Area;
            //    SelectedData[Item].ChartType = SeriesChartType.StackedArea;

            //    for (int j = 0; j < data.Count; j++)
            //    {
            //        //データ追加
            //        for (int i = 0; i < data[j].Length / 2; i++)
            //        {
            //            int former = (i - 1); if (i == 0) former = 0;
            //            int[] color = GetColor(StaticDataStateValue.maxSpectrum, data[j][former], data[j][i], data[j][i + 1]);

            //            //SelectedData[Item].Points.AddXY(time[0] + time[1] * i, data[j][i]);

            //            SelectedData[Item].Points.AddXY(time[0] + time[1] * i, j * 0.01);
            //            SelectedData[Item].Points[j * data[0].Length / 2 + i].Color = Color.FromArgb(255, color[0], color[1], color[2]);
            //        }
            //    }
            //}
            #endregion

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
            float yband = 0.01f;
            chart.ChartAreas["ChartArea1"].AxisY.Maximum = yband * (data.Count) + 0.0001f;

            for (int i = 0; i < data.Count; i++)
            {
                //設定
                SelectedData[i] = new Series();
                //SelectedData[Item].ChartType = SeriesChartType.Line;
                SelectedData[i].IsVisibleInLegend = false;
                SelectedData[i].BorderWidth = 3;
                SelectedData[i].MarkerStyle = MarkerStyle.None;
                SelectedData[i].LegendText = seriesName[0];
                //SelectedData[i].IsVisibleInLegend = true;
                chart.Series.Add(SelectedData[i]);
                SelectedData[i].ChartType = SeriesChartType.StackedColumn;
                for (int j = 0; j < data[i].Length / 2; j++)
                {
                    int former = (j - 1); if (j == 0) former = 0;
                    int[] color = GetColor(StaticDataStateValue.maxSpectrum, data[i][former], data[i][j], data[i][j + 1]);

                    SelectedData[i].Points.AddXY(time[0] + time[1] * j, yband);
                    SelectedData[i].Points[j].Color = Color.FromArgb(255, color[0], color[1], color[2]);
                }
            }
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
        public static void DoDraw3DColorMapPoints(Chart chart, string[] seriesName, List<float[]> data, string title, string[] axesTitles, float[] time)
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
            float yband = 0.01f;
            chart.ChartAreas["ChartArea1"].AxisY.Maximum = yband * (data.Count) + 0.0001f;

            //for (int i = 0; i < data.Count; i++)
            //{
            //    //設定
            //    SelectedData[i] = new Series();
            //    //SelectedData[Item].ChartType = SeriesChartType.Line;
            //    SelectedData[i].IsVisibleInLegend = false;
            //    SelectedData[i].BorderWidth = 3;
            //    SelectedData[i].MarkerStyle = MarkerStyle.None;
            //    SelectedData[i].LegendText = seriesName[0];
            //    //SelectedData[i].IsVisibleInLegend = true;
            //    chart.Series.Add(SelectedData[i]);
            //    //SelectedData[i].ChartType = SeriesChartType.StackedColumn;
            //    SelectedData[i].ChartType = SeriesChartType.Point;
            //    for (int j = 0; j < data[i].Length / 2; j++)
            //    {
            //        int former = (j - 1); if (j == 0) former = 0;
            //        int[] color = GetColor(StaticDataStateValue.maxSpectrum, data[i][former], data[i][j], data[i][j + 1]);

            //        SelectedData[i].Points.AddXY(time[0] + time[1] * j, yband * i);
            //        SelectedData[i].Points[j].Color = Color.FromArgb(255, color[0], color[1], color[2]);
            //    }
            //}

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
                SelectedData[Item].MarkerSize = 1000/data.Count;
                chart.Series.Add(SelectedData[Item]);

                //データ追加
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < data[i].Length / 2; j++)
                    {
                        int former = (j - 1); if (j == 0) former = 0;
                        int[] color = GetColor(StaticDataStateValue.maxSpectrum, data[i][former], data[i][j], data[i][j + 1]);

                        SelectedData[Item].Points.AddXY(time[0] + time[1] * j, yband * i);
                        
                        SelectedData[Item].Points[i * data[0].Length / 2 + j].Color = Color.FromArgb(255, color[0], color[1], color[2]);
                    }
                }
            }

            #endregion
        }

        private static int[] GetColor(float maxSpectrum, float data3, float data1, float data2)
        {
            if (StaticDataSetting.totalNumber > 500000)
                maxSpectrum /= 10;

            float[] color = new float[3];

            float data = (data1 * 3 + data2 + data3) / 5;

            float ratio = data / maxSpectrum;

            float max = maxSpectrum * 0.45f;
            float min = maxSpectrum * 0.005f;

            color[0] = 0.5f * (float)Math.Cos(Math.PI / (max - min) * (data - min) + Math.PI) + 0.5f;
            if (data < min) color[0] = 0;
            else if (data > max) color[0] = 1;
            color[1] = 0.5f * (float)Math.Cos(2 * Math.PI / (max - min) * (data - min) - Math.PI) + 0.5f;
            if (data < min || max < data) color[1] = 0;
            color[2] = 0.5f * (float)Math.Cos(Math.PI / (max - min) * (data - min)) + 0.5f;
            if (data < min) color[2] = 1;
            else if (data > max) color[2] = 0;

            return new int[3] { (int)Math.Round(color[0] * 255), (int)Math.Round(color[1] * 255), (int)Math.Round(color[2] * 255) };
        }
    }
}
