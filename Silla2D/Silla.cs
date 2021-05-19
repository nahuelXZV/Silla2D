using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Silla2D{
    class Silla{
        GameWindow window;
        private float UPS = 1;
        private float FPS = 60;
        private int IBO;
        private int VAO;


        public Silla(GameWindow window){
            this.window = window;
        }

        public void Star(){
            window.Resize += Resize;
            window.RenderFrame += Renderf;

            float[] vertices = new float[] { 10, 10, 10, 20,  20, 10, 20, 20,  10, 20, 20, 20,  10, 20, 10, 35,
                                             10, 35, 17, 38,  17, 38, 17, 25,  10, 20, 17, 25,  17, 25, 25 ,25,
                                             20, 20, 25, 25,  25, 25, 25, 15,  17, 15, 17, 20 };

            int[] indices = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };

            VAO = GL.GenVertexArray();
            IBO = GL.GenBuffer();
            int vbo = GL.GenBuffer();

            //indices
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);

            // vertices
            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            window.Run(UPS, FPS);
        }

        public void Resize(object ob, EventArgs e){
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, 50.0, 0.0, 50.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }


        public void Renderf(object o, EventArgs e){
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IBO);
            GL.DrawElements(BeginMode.Lines, 22, DrawElementsType.UnsignedInt, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindVertexArray(0);

            window.SwapBuffers();
        }

    }
}
