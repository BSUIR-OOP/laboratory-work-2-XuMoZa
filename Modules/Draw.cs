using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2.Modules
{
    public class Draw
    {
        Graphics graphic;
        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
        int[] coordinates = new int[4];

        public Draw(int x1, int y1, int x2, int y2, Graphics graphics)
        {
            graphic = graphics;

            this.coordinates[0] = x1;
            this.coordinates[1] = y1;
            this.coordinates[2] = x2;
            this.coordinates[3] = y2;
        }

        public void PrintFigure(IDisplay display)
        {
            display.Make(coordinates, pen, graphic);
        }
    }

    public interface IDisplay
    {
        void Make(int[] coordinates, Pen pen, Graphics graphics);
    }

    class DrawPentagon : IDisplay
    {
        public void Make(int[] coordinates, Pen pen, Graphics graphics)
        {
            Point a = new Point((coordinates[0]+coordinates[2])/2, coordinates[1]);
            Point b = new Point(coordinates[0], (coordinates[1] + coordinates[3])/2);
            Point c = new Point(coordinates[0]+((coordinates[2]-coordinates[0])/4),coordinates[3]);
            Point d = new Point(coordinates[2] - ((coordinates[2]-coordinates[0])/4), coordinates[3]);
            Point e = new Point(coordinates[2], (coordinates[1] + coordinates[3]) / 2);

            graphics.DrawLine(pen, a, b);
            graphics.DrawLine(pen, b, c);
            graphics.DrawLine(pen, c, d);
            graphics.DrawLine(pen, d, e);
            graphics.DrawLine(pen, e, a);
        }
    }

    class DrawCircle : IDisplay
    {
        public void Make(int[] coordinates, Pen pen, Graphics graphics)
        {
            if ((coordinates[0]!= coordinates[2]) && (coordinates[1]!= coordinates[3]))
            graphics.DrawArc(pen, coordinates[0], coordinates[1], (float)Math.Sqrt(Math.Pow(Math.Abs(coordinates[2] - coordinates[0]) , 2) + Math.Pow(Math.Abs(coordinates[3] - coordinates[1]), 2)) , (float)Math.Sqrt(Math.Pow(Math.Abs(coordinates[2] - coordinates[0]) , 2) + Math.Pow(Math.Abs(coordinates[3] - coordinates[1]), 2)) , 0, 360);
        }
    }

    class DrawRectangle : IDisplay
    {
        public void Make(int[] coordinates, Pen pen, Graphics graphics)
        {
            Point a = new Point(coordinates[0], coordinates[1]);
            Point b = new Point(coordinates[2], coordinates[1]);
            Point c = new Point(coordinates[2], coordinates[3]);
            Point d = new Point(coordinates[0], coordinates[3]);

            graphics.DrawLine(pen, a, b);
            graphics.DrawLine(pen, b, c);
            graphics.DrawLine(pen, c, d);
            graphics.DrawLine(pen, d, a);
        }
    }

    class DrawTriangle : IDisplay
    {
        public void Make(int[] coordinates, Pen pen, Graphics graphics)
        {
            Point a = new Point((coordinates[2] + coordinates[0]) / 2, coordinates[1]);
            Point b = new Point(coordinates[0], coordinates[3]);
            Point c = new Point(coordinates[2], coordinates[3]);

            graphics.DrawLine(pen, a, b);
            graphics.DrawLine(pen, b, c);
            graphics.DrawLine(pen, c, a);
        }
    }

    class DrawRhombus : IDisplay
    {
        public void Make(int[] coordinates, Pen pen, Graphics graphics)
        {
            Point a = new Point((coordinates[2] + coordinates[0]) / 2, coordinates[1]);
            Point b = new Point(coordinates[2], (coordinates[3] + coordinates[1]) / 2);
            Point c = new Point((coordinates[2] + coordinates[0]) / 2, coordinates[3]);
            Point d = new Point(coordinates[0], (coordinates[3] + coordinates[1]) / 2);

            graphics.DrawLine(pen, a, b);
            graphics.DrawLine(pen, b, c);
            graphics.DrawLine(pen, c, d);
            graphics.DrawLine(pen, d, a);
        }
    }

    class DrawHexagon : IDisplay
    {
        public void Make(int[] coordinates, Pen pen, Graphics graphics)
        {
            Point a = new Point((coordinates[2] + coordinates[0]) / 2, coordinates[1]);
            Point b = new Point(coordinates[2], coordinates[1] + (Math.Abs(coordinates[1] - coordinates[3]) / 3));
            Point c = new Point(coordinates[2], coordinates[3] - (Math.Abs(coordinates[1] - coordinates[3]) / 3));
            Point d = new Point((coordinates[2] + coordinates[0]) / 2, coordinates[3]);
            Point e = new Point(coordinates[0], coordinates[3] - (Math.Abs(coordinates[1] - coordinates[3]) / 3));
            Point f = new Point(coordinates[0], coordinates[1] + (Math.Abs(coordinates[1] - coordinates[3]) / 3));

            graphics.DrawLine(pen, a, b);
            graphics.DrawLine(pen, b, c);
            graphics.DrawLine(pen, c, d);
            graphics.DrawLine(pen, d, e);
            graphics.DrawLine(pen, e, f);
            graphics.DrawLine(pen, f, a);
        }
    }
}
