using System.Drawing;

namespace lab4
{
    class Square : Figure
    {
        private Graphics formGraphics;
        private int sideLength;

        public Square(int x, int y, int sideLength, Graphics g) : base(x, y)
        {
            this.sideLength = sideLength;
            formGraphics = g;
        }

        ~Square()
        {
            formGraphics.Dispose();
        }

        public override void Draw(Pen pen)
        {
            formGraphics.DrawRectangle(pen, x + (sideLength/2), y-(sideLength/2), sideLength, sideLength);
        }
    }
}
