using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Modules
{
    abstract public class GeometricFigure
    {
        protected int x1;
        protected int y1;
        protected int x2;
        protected int y2;

        public GeometricFigure(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        abstract public void DrawFigure();

    }
}
