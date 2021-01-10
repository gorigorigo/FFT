using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace _3DCAM.Draw
{
    class DrawAxis
    {
        public static void DrawXYZAxis()
        {
            GL.Begin(PrimitiveType.Lines);

            //x軸
            GL.Normal3(0, 0, 1);
            GL.Color4(Color4.Red);
            GL.Vertex3(0f, 0f, 0f);
            GL.Vertex3(2000.0f, 0f, 0f);

            //y軸
            GL.Color4(Color4.Blue);
            GL.Vertex3(0f, 0f, 0f);
            GL.Vertex3(0f, 2000.0f, 0f);

            //z軸
            GL.Color4(Color4.Green);
            GL.Vertex3(0f, 0f, 0f);
            GL.Vertex3(0f, 0f, 2000.0f);

            GL.End();
        }
    }
}
