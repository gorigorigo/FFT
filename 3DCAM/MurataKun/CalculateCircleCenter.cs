using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathFunction;

namespace _3DCAM.MurataKun
{
    class CalculateCircleCenter
    {
        Function MF = new Function();
        /// <summary>
        /// 工具径
        /// </summary>
        private float toolRadius;
        /// <summary>
        /// 終了条件
        /// </summary>
        private float endScale;
        /// <summary>
        /// 学習率
        /// </summary>
        private float scalingFactor;

        public CalculateCircleCenter(float ScalingFactor, float EndScale, float ToolRadius)
        {
            toolRadius = ToolRadius;
            scalingFactor = ScalingFactor;
            endScale = EndScale;
        }

        public void Execute()
        {
            StaticDataMT.centerData = CalCenter(StaticDataMT.mesureData);
        }

        private Tuple<float[],float[]> CalCenter(Tuple<List<float[]>, List<float[]>> mesureData)
        {
            //Xの中心を時系列で格納
            float[] centerX = new float[mesureData.Item1.Count];
            //Yの中心を時系列で格納
            float[] centerY = new float[mesureData.Item2.Count];

            int dataCount = mesureData.Item1.Count;

            int loopCount = 10000;

            Parallel.For(0, dataCount, i =>
            {
                //中心を計算
                float[] tmpCenter = GetFirstPoint(mesureData.Item1[i], mesureData.Item2[i]);

                //毎回学習率を更新
                float tmpScale = scalingFactor;
                float tmpEnd = endScale;

                //一個前の勾配
                float pastSlope = 0;

                //現在の勾配
                float currentSlope = 0;

                int count = 0;

                for (int j = 0; j < loopCount; j++)
                {
                    //傾きを取得
                    float[] slope = GetSlope(tmpCenter, mesureData.Item1[i], mesureData.Item2[i]);

                    //傾きの絶対値を取得
                    float slopeNorm = MF.Norm(slope, 2);

                    //一定以下の移動量なら終了
                    if (slopeNorm < endScale) break;

                    //学習率をかけた分を移動
                    tmpCenter[0] -= scalingFactor * slope[0];
                    tmpCenter[1] -= scalingFactor * slope[1];

                    //過去のデータと現在のデータを変換
                    pastSlope = currentSlope;
                    currentSlope = slopeNorm;

                    //発散の恐れまたは移動しなくなった場合
                    if ((pastSlope < currentSlope && pastSlope != 0) || Math.Abs(pastSlope - currentSlope) < tmpEnd / 10)
                    {
                        if (count > 10) break;

                        tmpScale /= 10;
                        tmpEnd /= 10;
                        count++;
                    }
                    else count = 0;
                }
                centerX[i] = tmpCenter[0];
                centerY[i] = tmpCenter[1];
            });

            return new Tuple<float[], float[]>(centerX, centerY);
        }
        private float[] GetFirstPoint(float[] x, float[] y)
        {
            float[] center = new float[2];
            for (int i = 0; i < x.Length; i++)
            {
                center[0] += x[i];
                center[1] += y[i];
            }
            center[0] = center[0] / x.Length;
            center[1] = center[1] / x.Length - toolRadius;
            return center;
        }


        private float[] GetSlope(float[] center, float[] x, float[] y)
        {
            float[] slope = new float[2];

            int dataCount = x.Length;

            for (int i = 0; i < dataCount; i++)
            {
                float errorX = center[0] - x[i];
                float errorY = center[1] - y[i];

                slope[0] += 4 * errorX * (float)(Math.Pow(errorX, 2) + Math.Pow(errorY, 2) - Math.Pow(toolRadius, 2));
                slope[1] += 4 * errorY * (float)(Math.Pow(errorX, 2) + Math.Pow(errorY, 2) - Math.Pow(toolRadius, 2));
            }
            slope[0] /= dataCount;
            slope[1] /= dataCount;

            return slope;
        }
    }
}
