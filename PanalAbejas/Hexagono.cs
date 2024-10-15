using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanalAbejas
{
    internal class Hexagono
    {
        private Graphics mGraph;
        private Pen mPen;
        private PointF[] puntos;

        public Hexagono()
        {
        }

        public PointF PlotShape(float lado ,PictureBox picCanvas, PointF inicio)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Yellow, 1);
            puntos = new PointF[6];

            float x = lado * (float)Math.Cos(Math.PI / 3);
            float y = lado * (float)Math.Sin(Math.PI / 3);

            puntos[0] = inicio;
            puntos[1] = new PointF(puntos[0].X + x, puntos[0].Y + y);
            puntos[2] = new PointF(puntos[1].X + lado, puntos[1].Y);
            puntos[3] = new PointF(puntos[2].X + x, puntos[2].Y  - y);
            puntos[4] = new PointF(puntos[3].X - x, puntos[3].Y - y);
            puntos[5] = new PointF(puntos[4].X - lado, puntos[4].Y);

            mGraph.DrawLine(mPen, puntos[0], puntos[1]);
            mGraph.DrawLine(mPen, puntos[1], puntos[2]);
            mGraph.DrawLine(mPen, puntos[2], puntos[3]);
            mGraph.DrawLine(mPen, puntos[3], puntos[4]);
            mGraph.DrawLine(mPen, puntos[4], puntos[5]);
            mGraph.DrawLine(mPen, puntos[5], puntos[0]);

            mPen.Dispose();
            mGraph.Dispose();

            return puntos[3];
        }
    }
}
