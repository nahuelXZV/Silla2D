using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;

namespace Silla2D
{
    static class Program{
        static void Main(){
            GameWindow window = new GameWindow(750, 750, OpenTK.Graphics.GraphicsMode.Default, "Triangulo");
            Silla silla = new Silla(window);
            silla.Star();
        }
    }
}
