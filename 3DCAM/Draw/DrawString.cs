//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenTK.Graphics.OpenGL;
//using OpenTK.Graphics;
//using OpenTK.Platform.Windows;
//using System.Windows.Forms;
//using OpenTK;
//using System.Drawing;
//using System.Windows.Media.Media3D;

//namespace _3DCAM
//{
//    class DrawString
//    {
//        public void DrawStringTest(Camera Camera, OpenTK.GLControl glControl)
//        {
//            // ウィンドウの幅、高さの取得
//            int[] viewport = new int[4];
//            GL.GetInteger(GetPName.Viewport, viewport);
//            int winW = viewport[2];
//            int winH = viewport[3];
//            int fontSize = 18;
//            fontSize = (int)(fontSize * winW / (double)400);

//            GL.ClearColor(Color4.White);
//            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
//            GL.Enable(EnableCap.PolygonOffsetFill);
//            GL.PolygonOffset(1.1f, 4.0f);
//            GL.MatrixMode(MatrixMode.Modelview);
//            GL.LoadIdentity();
//            Camera.Fit(new BoundingBox3D(0, winW, 0, winH, 0, 0));
//            OpenGLUtils.SetModelViewTransform(Camera);

//            double asp = (winW + 1.0) / (winH + 1.0);
//            GL.MatrixMode(MatrixMode.Projection);
//            GL.PushMatrix();
//            GL.LoadIdentity();
//            GL.Ortho(-asp, asp, -1.0, 1.0, -1.0, 1.0);

//            GL.MatrixMode(MatrixMode.Modelview);
//            GL.PushMatrix();
//            GL.LoadIdentity();

//            string text = "DrawStringテスト";
//            int n = 20;
//            for (int i = 0; i < n; i++)
//            {
//                double xx = -asp + asp * 2.0 * i / (double)n;
//                double yy = 1.0 - 2.0 * (i + 1) / (double)n;
//                OpenTK.Vector2d drawpp = new OpenTK.Vector2d(xx, yy);
//                GL.Translate(drawpp.X, drawpp.Y, 1.0);
//                double ratio = 1.0 - i / (double)n;
//                GL.Color3(1.0 * ratio, 0.5 * ratio, 0.5 * ratio);
//                OpenGLUtils.DrawString(text, fontSize);
//                GL.Translate(-drawpp.X, -drawpp.Y, -1.0);
//            }

//            GL.MatrixMode(MatrixMode.Projection);
//            GL.PopMatrix();
//            GL.MatrixMode(MatrixMode.Modelview);
//            GL.PopMatrix();

//            glControl.SwapBuffers();
//        }
//    }
//}
