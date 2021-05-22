using System.Drawing;

namespace lab4
{
    class Circle : Figure
    {
        private int r;
        private Graphics formGraphics;

        public Circle(int x, int y, int r, Graphics g) : base(x, y)
        {
            this.r = r;
            formGraphics = g;
        }

        ~Circle()
        {
            formGraphics.Dispose();
        }

        public override void Draw(Pen pen)
        {
            formGraphics.DrawEllipse(pen, new Rectangle(x-r, y-r, r*2, r*2));
        }
    }
}
