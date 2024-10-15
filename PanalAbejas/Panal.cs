using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanalAbejas
{

    internal class Panal
    {
        private float altura;
        private float ancho;

        private Hexagono objHexagono = new Hexagono();
        private float lado;
        private float x;
        private float y;
        
        private PointF[] puntos;

        public Panal()
        {
            lado = 0;
        }

        public void InitializeData(PictureBox picCanvas)
        {
            altura = 0;
            ancho = 0;
            lado = 0;
            x = 0;
            y = 0;
            puntos = null;
            picCanvas.Refresh();
        }

        public void ReadData(TextBox txtLado, PictureBox picCanvas)
        {
            lado = float.Parse(txtLado.Text);
            x = lado * (float)Math.Cos(Math.PI / 3);
            y = lado * (float)Math.Sin(Math.PI / 3);
            altura = picCanvas.Height;
            ancho = picCanvas.Width;
        }

        public void CalcularPuntos()
        {
            float hexagonosY = (int)(altura / (2 * y)) + 1;
            puntos = new PointF[(int)hexagonosY];
            puntos[0].X = 0;
            puntos[0].Y = y;
            for (int i = 1; i < hexagonosY; i++)
            {
                puntos[i].X = 0;
                puntos[i].Y = puntos[i - 1].Y + 2 * y;
            }
        }

        public void PlotShape(PictureBox picCanvas)
        {
            Graphics mGraph = picCanvas.CreateGraphics();
            Pen mPen = new Pen(Color.Yellow, 1);

            mGraph.FillRectangle(Brushes.Gray, 0, 0, ancho, altura);
            mGraph.DrawRectangle(new Pen(Color.Yellow, 5), 0, 0, ancho - 1, altura - 1);

            while (puntos[0].X <= ancho)
            {
                for (int i = 0; i < puntos.Length; i++)
                {
                    PointF finalHexagono = objHexagono.PlotShape(lado, picCanvas, puntos[i]);
                    puntos[i].X = finalHexagono.X + lado;
                    puntos[i].Y = finalHexagono.Y;
                    mGraph.DrawLine(mPen, finalHexagono, puntos[i]);
                }
            }
        }
    }
}
