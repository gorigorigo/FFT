using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3DCAM.Draw;


namespace _3DCAM.Graphic.Graphic1
{
    class Graphic1Operator
    {
        public static Form1 Form1Obj;

        public Graphic1Operator(Form1 Form_obj)
        {
            Form1Obj = Form_obj;
        }

        public static void MainGraphicFunction()
        {
            //基本的に常に描画
            //BasicGraphic();

            DrawGraph();
        }

        private static void BasicGraphic()
        {
            //軸を描画
            DrawAxis.DrawXYZAxis();
        }

        private static void DrawGraph()
        {
            Draw3Dchart.DoDrawArea(StaticDataStateValue.parcialSpectrum, StaticDataStateValue.maxSpectrum);
        }
    }
}
