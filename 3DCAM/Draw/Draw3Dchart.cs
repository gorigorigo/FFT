using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK.Platform.Windows;

namespace _3DCAM
{
    class Draw3Dchart
    {
        public static void DoDrawArea(List<float[]> spectrum, float maxSpectrum)
        {
            if (spectrum == null) return;

            GL.Color4(Color4.White);


            float scale = 100;
            float ratio = scale / maxSpectrum / 3;

            LineLoop(new float[3] { 0, 0, 0 }, new float[3] { scale, 0, 0 }, new float[3] { scale, scale, 0 }, new float[3] { 0, scale, 0 });
            LineLoop(new float[3] { 0, 0, scale }, new float[3] { scale, 0, scale }, new float[3] { scale, scale, scale }, new float[3] { 0, scale, scale });
            LineLoop(new float[3] { 0, 0, 0 }, new float[3] { 0, scale, 0 }, new float[3] { 0, scale, scale }, new float[3] { 0, 0, scale });
            LineLoop(new float[3] { scale, 0, 0 }, new float[3] { scale, scale, 0 }, new float[3] { scale, scale, scale }, new float[3] { scale, 0, scale });

            float x = scale / spectrum[0].Length * 2;
            float y = scale / (spectrum.Count - 1);

            //GL.Normal3(0, 0, 1);

            for (int i = 0; i < spectrum.Count - 1; i++)
            {
                for (int j = 5; j < spectrum[0].Length / 2 - 1; j++)
                {
                    //Area(new float[3] { x * j, y * i, scale / 10 + spectrum[i][j] * scale / 10 }, GetColor(maxSpectrum, spectrum[i][j], spectrum[i][j]),
                    //     new float[3] { x * (j + 1), y * i, scale / 10 + spectrum[i][j + 1] * scale / 10 }, GetColor(maxSpectrum, spectrum[i][j + 1], spectrum[i][j]),
                    //     new float[3] { x * j, y * (i + 1), scale / 10 + spectrum[i + 1][j] * scale / 10 }, GetColor(maxSpectrum, spectrum[i + 1][j], spectrum[i][j]),
                    //     new float[3] { x * (j + 1), y * (i + 1), scale / 10 + spectrum[i + 1][j + 1] * scale / 10 }, GetColor(maxSpectrum, spectrum[i + 1][j + 1], spectrum[i][j]));

                    //Area(new float[3] { x * j, y * i, scale / 10 + spectrum[i][j] * scale / 10 }, GetColor(maxSpectrum, spectrum[i][j], spectrum[i][j]),
                    //     new float[3] { x * j, y * (i + 1), scale / 10 + spectrum[i + 1][j] * scale / 10 }, GetColor(maxSpectrum, spectrum[i + 1][j], spectrum[i][j]),
                    //     new float[3] { x * (j + 1), y * i, scale / 10 + spectrum[i][j + 1] * scale / 10 }, GetColor(maxSpectrum, spectrum[i][j + 1], spectrum[i][j]),
                    //     new float[3] { x * (j + 1), y * (i + 1), scale / 10 + spectrum[i + 1][j + 1] * scale / 10 }, GetColor(maxSpectrum, spectrum[i + 1][j + 1], spectrum[i][j]));

                    Area(new float[3] { x * j, y * i, ratio + spectrum[i][j] * ratio }, GetColor(maxSpectrum, spectrum[i][j], spectrum[i][j]),
                         new float[3] { x * (j + 1), y * i, ratio + spectrum[i][j + 1] * ratio }, GetColor(maxSpectrum, spectrum[i][j + 1], spectrum[i][j]),
                         new float[3] { x * j, y * (i + 1), ratio + spectrum[i + 1][j] * ratio }, GetColor(maxSpectrum, spectrum[i + 1][j], spectrum[i][j]),
                         new float[3] { x * (j + 1), y * (i + 1), ratio + spectrum[i + 1][j + 1] * ratio }, GetColor(maxSpectrum, spectrum[i + 1][j + 1], spectrum[i][j]));

                    Area(new float[3] { x * j, y * i, ratio + spectrum[i][j] * ratio }, GetColor(maxSpectrum, spectrum[i][j], spectrum[i][j]),
                         new float[3] { x * j, y * (i + 1), ratio + spectrum[i + 1][j] * ratio }, GetColor(maxSpectrum, spectrum[i + 1][j], spectrum[i][j]),
                         new float[3] { x * (j + 1), y * i, ratio + spectrum[i][j + 1] * ratio }, GetColor(maxSpectrum, spectrum[i][j + 1], spectrum[i][j]),
                         new float[3] { x * (j + 1), y * (i + 1), ratio + spectrum[i + 1][j + 1] * ratio }, GetColor(maxSpectrum, spectrum[i + 1][j + 1], spectrum[i][j]));

                }
            }

            Area(new float[3] { 100, 0, 0 }, GetColor(100, 0, 10),
                 new float[3] { 200, 0, 0 }, GetColor(100, 10, 100),
                 new float[3] { 100, 100, 0 }, GetColor(100, 50, 10),
                 new float[3] { 200, 100, 0 }, GetColor(100, 100, 50));
        }
        private static void LineLoop(float[] data1, float[] data2, float[] data3, float[] data4)
        {
            GL.Begin(PrimitiveType.LineLoop);

            GL.Vertex3(data1[0], data1[1], data1[2]);
            GL.Vertex3(data2[0], data2[1], data2[2]);
            GL.Vertex3(data3[0], data3[1], data3[2]);
            GL.Vertex3(data4[0], data4[1], data4[2]);

            GL.End();
        }

        private static void Area(float[] data1, float[] color1, float[] data2, float[] color2, float[] data3, float[] color3, float[] data4, float[] color4)
        {
            GL.Begin(PrimitiveType.TriangleStrip);

            GL.Color4(color1[0], color1[1], color1[2], 1.0f);
            GL.Vertex3(data1[0], data1[1], data1[2]);
            GL.Color4(color2[0], color2[1], color2[2], 1.0f);
            GL.Vertex3(data2[0], data2[1], data2[2]);
            GL.Color4(color3[0], color3[1], color3[2], 1.0f);
            GL.Vertex3(data3[0], data3[1], data3[2]);
            GL.Color4(color4[0], color4[1], color4[2], 1.0f);
            GL.Vertex3(data4[0], data4[1], data4[2]);

            GL.End();

        }
        /// <summary>
        /// ベクトルの大きさを変更する
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="length"></param>
        /// <param name="loopCount"></param>
        /// <returns></returns>
        public static float[] ChangeVectorAbsolution(float[] vector, float length, int loopCount)
        {
            if (vector.Length < loopCount)
                return new float[0];

            if (loopCount == 0) loopCount = vector.Length;

            float absolution = 0;

            for (int i = 0; i < loopCount; i++)
            {
                absolution += (float)Math.Pow(vector[i], 2);
            }

            absolution = (float)Math.Sqrt(absolution);
            float[] absolutionVector = new float[vector.Length];

            for (int i = 0; i < loopCount; i++)
            {
                absolutionVector[i] = vector[i] / absolution * length;
            }

            return absolutionVector;
        }
        public static float maxSpectrum(List<float[]> spectrum)
        {
            float maxValue = float.MinValue;

            for (int i = 0; i < spectrum.Count; i++)
            {
                for (int j = spectrum[i].Length / 100; j < spectrum[i].Length; j++)
                {
                    if (maxValue < spectrum[i][j]) maxValue = spectrum[i][j];
                }
            }
            return maxValue;
        }

        private static float[] GetColor(float maxSpectrum, float data1, float data2)
        {
            if (StaticDataSetting.totalNumber > 500000)
                maxSpectrum /= 10;

            float[] color = new float[3];

            float data = (data1 * 3 + data2) / 4;

            float ratio = data / maxSpectrum;

            float max = maxSpectrum * 0.65f;
            float min = maxSpectrum * 0.005f;

            color[0] = 0.5f * (float)Math.Cos(Math.PI / (max - min) * (data - min) + Math.PI) + 0.5f;
            if (data < min) color[0] = 0;
            else if (data > max) color[0] = 1;
            color[1] = 0.5f * (float)Math.Cos(2 * Math.PI / (max - min) * (data - min) - Math.PI) + 0.5f;
            if (data < min || max < data) color[1] = 0;
            color[2] = 0.5f * (float)Math.Cos(Math.PI / (max - min) * (data - min)) + 0.5f;
            if (data < min) color[2] = 1;
            else if (data > max) color[2] = 0;

            return color;

        }
    }
}
