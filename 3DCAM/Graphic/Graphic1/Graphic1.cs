using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using _3DCAM.StaticData;
using _3DCAM.Graphic.Graphic1;

namespace _3DCAM
{
    public partial class Graphic1 : UserControl
    {

        #region カメラフィールド

        bool isCameraRotating;      //カメラが回転状態かどうか
        bool isCameraTrans;
        Vector2 current, previous;  //現在の点、前の点
        Vector2 current1, previous1;
        Matrix4 rotate;             //回転行列
        float zoom;                 //拡大度
        float wheelPrevious;        //マウスホイールの前の状態

        #endregion

        #region 光源フィールド
        Vector4 lightPosition0;      //平行光源の方向
        Vector4 lightPosition1;
        Color4 lightAmbient;        //光源の環境光成分
        Color4 lightDiffuse;        //光源の拡散光成分
        Color4 lightSpecular;       //光源の鏡面光成分

        //float lightConstantAttenuation;   //光源の一定減衰率
        //float lightLinerAttenuation;      //光源の線形減衰率
        //float lightQuadraticAttenuation;  //光源の二次減衰率

        Color4 materialAmbient;     //材質の環境光成分
        Color4 materialDiffuse;	    //材質の拡散光成分
        Color4 materialSpecular;    //材質の鏡面光成分
        float materialShininess;    //材質の鏡面光の鋭さ
        #endregion
        


        public Graphic1(GLControl glControl)
        {
            this.glControl = glControl;

            glControl.Load += new EventHandler(OnLoad);
            glControl.Paint += new PaintEventHandler(Onpaint);
            glControl.Resize += new EventHandler(OnResize);


            lightPosition0 = new Vector4(-800, 0f, 800.0f, 0.0f);
            lightPosition1 = new Vector4(800.0f, 800.0f, -1500.0f, 0.0f);
            lightAmbient = new Color4(0.5f, 0.5f, 0.5f, 1.0f);
            lightDiffuse = new Color4(0.7f, 0.7f, 0.7f, 1.0f);
            lightSpecular = new Color4(1.0f, 1.0f, 1.0f, 1.0f);

            materialAmbient = new Color4(0.24725f, 0.24725f, 0.24725f, 1.0f);
            materialDiffuse = new Color4(0.75164f, 0.75164f, 0.75164f, 1.0f);
            materialSpecular = new Color4(0.628281f, 0.628281f, 0.628281f, 1.0f);
            materialShininess = 50.4f;

            //lightConstantAttenuation = 0.01f;
            //lightLinerAttenuation = 0.01f;
            //lightQuadraticAttenuation = 0.01f;


            #region カメラの初期設定

            isCameraRotating = false;
            current = Vector2.Zero;
            //current = Vector2.UnitX;
            previous = Vector2.Zero;
            //previous = Vector2.UnitY;
            rotate = Matrix4.Identity;
            //rotate = Matrix4.CreateRotationX((float)-Math.PI / 2) /** Matrix4.CreateRotationZ((float)Math.PI / 72)*/ *
            //         Matrix4.CreateRotationY((float)Math.PI / 4) * Matrix4.CreateTranslation(new Vector3(0.0f, -40.0f, 0.0f));
            zoom = 1.0f;
            wheelPrevious = 0.0f;

            #endregion

            #region マウスイベント

            //マウスボタンが押されると発生するイベント
            glControl.MouseDown += (sender, e) =>
            {
                //左ボタンが押された場合
                if (e.Button == MouseButtons.Left)
                {
                    isCameraRotating = true;
                    current = new Vector2(e.X, e.Y);
                }
                //右ボタンが押された場合
                if (e.Button == MouseButtons.Right)
                {
                    isCameraTrans = true;
                    current1 = new Vector2(e.X, e.Y);
                }
            };

            //マウスボタンが離されると発生するイベント
            glControl.MouseUp += (sender, e) =>
            {
                //左ボタンが押された場合
                if (e.Button == MouseButtons.Left)
                {
                    isCameraRotating = false;
                    previous = Vector2.Zero;
                }
                //右ボタンが押された場合
                if (e.Button == MouseButtons.Right)
                {
                    isCameraTrans = false;
                    previous1 = Vector2.Zero;
                }
            };

            //マウスが動くと発生するイベント
            glControl.MouseMove += (sender, e) =>
            {
                ////カメラが回転状態の場合
                if (isCameraRotating)
                {
                    previous = current;
                    current = new Vector2(e.X, e.Y);
                    Vector2 delta = current - previous;
                    delta /= (float)Math.Sqrt(this.Width * this.Width + this.Height * this.Height);
                    float length = (float)(delta.Length * 0.2);     //初期値では回転しすぎのため，0.2倍に変更
                    //float length = delta.Length;
                    if (length > 0.0)
                    {
                        float rad = length * MathHelper.Pi;
                        float theta = (float)Math.Sin(rad) / length;
                        Quaternion after = new Quaternion(delta.Y * theta, delta.X * theta, 0.0f, (float)Math.Cos(rad));
                        rotate = rotate * Matrix4.CreateFromQuaternion(after);
                    }
                }

                if (isCameraTrans)
                {
                    previous1 = current1;
                    current1 = new Vector2(e.X, e.Y);
                    Vector2 delta = current1 - previous1;
                    delta /= 0.1f * (float)Math.Sqrt(this.Width * this.Width + this.Height * this.Height);
                    Vector3 after = new Vector3(delta.X, -delta.Y, 0.0f);
                    rotate = rotate * Matrix4.CreateTranslation(after);
                }
            };

            //マウスホイールが回転すると発生するイベント
            glControl.MouseWheel += (sender, e) =>
            {
                //float delta = (float)this.Mouse.Wheel - (float)wheelPrevious;

                zoom *= (float)Math.Pow(1.2, e.Delta / 120);

                //拡大、縮小の制限
                if (zoom > 10000f)
                    zoom = 10000f;
                if (zoom < 0.000001f)
                    zoom = 0.000001f;
                wheelPrevious = e.Delta;
            };

            #endregion

            #region キーイベント
            glControl.KeyDown += (sender, e) =>
            {
                Keys Key = e.KeyCode;

                switch (Key)
                {
                    case Keys.F1:
                        rotate = Matrix4.Identity; //xy平面
                        break;
                    case Keys.F2:
                        rotate = Matrix4.CreateRotationX((float)Math.PI / 2) * Matrix4.CreateRotationZ((float)Math.PI / 2); //xz平面
                        break;
                    case Keys.F3:
                        rotate = Matrix4.CreateRotationY((float)-Math.PI / 2) * Matrix4.CreateRotationZ((float)-Math.PI / 2); //yz平面
                        break;
                    case Keys.F4:
                        rotate = Matrix4.CreateRotationZ((float)-Math.PI * 3 / 4) * Matrix4.CreateRotationX((float)-Math.PI / 3); //俯瞰
                        break;
                    case Keys.F5:
                        rotate = Matrix4.CreateRotationZ((float)Math.PI / 3) * Matrix4.CreateRotationX((float)-Math.PI / 3); //俯瞰
                        break;
                }
            };
            #endregion

        }


        //windowの起動時に実行される
        protected void OnLoad(object sender, EventArgs e)
        {
            //背景をクリア
            GL.ClearColor(Color4.White);
            GL.Enable(EnableCap.DepthTest);

            #region　グラフィックの初期設定
            //点と線の太さを設定
            GL.LineWidth(0.01f);
            GL.PointSize(5f);

            //裏面削除、反時計回りが表でカリング
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.FrontFace(FrontFaceDirection.Ccw);

            //ライティングON Light0を有効化
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.Light1);

            //法線の正規化
            GL.Enable(EnableCap.Normalize);

            //色を材質に変換
            GL.Enable(EnableCap.ColorMaterial);
            GL.ColorMaterial(MaterialFace.Front, ColorMaterialParameter.Diffuse);

            //各Arrayを有効化
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            #endregion

            //#region シミュレータの初期設定
            ////デフォルト工具経路取得
            //ToolPath.SetToolPath();
            ////デフォルト工具初期位置を設定
            //ToolPosition.SetInitialToolPosition(false);
            //#endregion

        }


        //画面描画で実行される。
        protected void Onpaint(object sender, PaintEventArgs e)
        {
            //複数画面を描画する際の処理
            glControl.MakeCurrent();

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.PointSize(1.0f * zoom);
            Matrix4 modelView = Matrix4.LookAt(Vector3.UnitZ * 10 / zoom, Vector3.Zero, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelView);
            GL.MultMatrix(ref rotate);

            #region ライトの指定
            GL.Light(LightName.Light0, LightParameter.Position, lightPosition0);
            GL.Light(LightName.Light0, LightParameter.Ambient, lightAmbient);
            GL.Light(LightName.Light0, LightParameter.Diffuse, lightDiffuse);
            GL.Light(LightName.Light0, LightParameter.Specular, lightSpecular);

            GL.Light(LightName.Light1, LightParameter.Position, lightPosition1);
            GL.Light(LightName.Light1, LightParameter.Ambient, lightAmbient);
            GL.Light(LightName.Light1, LightParameter.Diffuse, lightDiffuse);
            GL.Light(LightName.Light1, LightParameter.Specular, lightSpecular);
            #endregion

            GL.Material(MaterialFace.Front, MaterialParameter.Ambient, materialAmbient);
            GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, materialDiffuse);
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, materialSpecular);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, materialShininess);
            GL.Material(MaterialFace.Front, MaterialParameter.Emission, Color4.Black);

            //遠近法なし
            //Matrix4 projection = Matrix4.CreateOrthographic(Width / zoom * 0.1f, Height / zoom * 0.1f, -3000.0f, 5000.0f);
            Matrix4 projection = Matrix4.CreateOrthographic(Width / zoom, Height / zoom, StaticDataDraw.ZNear, StaticDataDraw.ZFar);


            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);


            #region 描画処理
            //シミュレーション実行時の処理
            //RunSimulation.Process(glControl, cuttingForceChart, nccChart);

            //光源の位置の描画
            //DrawStage.LightPosition(lightPosition0);
            //DrawStage.LightPosition(lightPosition1);
            //Drawstage.LightPosition(lightPosition2);
            //Drawstage.LightPosition(lightPosition3);


            //Task.Run(() =>
            //{
            //    GraphicConduct.Graphic4sim();

            //});
            //加工シミュレーションを行うときの処理
            
            Graphic1Operator.MainGraphicFunction();

            glControl.SwapBuffers();

            #endregion
        }

        //ウィンドウのサイズが変更された場合に実行される。
        protected void OnResize(object sender, EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, glControl.Width, glControl.Height);
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 projection = Matrix4.CreateOrthographic(Width, Height, 1.0f, 50.0f);
            GL.LoadMatrix(ref projection);
        }

        private OpenTK.GLControl glControl;
    }
}
