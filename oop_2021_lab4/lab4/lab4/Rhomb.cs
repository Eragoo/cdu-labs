using System;
using System.Drawing;

namespace lab4
{
    class Rhomb : Figure
    {
        private Graphics formGraphics;
        private int horDiagLen;
        private int verDiagLen;

        public Rhomb(int x, int y, int horDiagLen, int verDiagLen, Graphics g) : base(x, y)
        {
            this.horDiagLen = horDiagLen;
            this.verDiagLen = verDiagLen;
            formGraphics = g;
        }

        ~Rhomb()
        {
            formGraphics.Dispose();
        }

        public override void Draw(Pen pen)
        {
            Point[] polygon = new Point[]
             {
                new Point(x, y - (verDiagLen/2)),
                new Point(x + (horDiagLen / 2), y),
                new Point(x, y + (verDiagLen/2)),
                new Point(x - (horDiagLen / 2), y)
             };

            formGraphics.DrawPolygon(pen, polygon);
        }
    }
}
