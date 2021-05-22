
using System.Drawing;
using System.Windows.Forms;

namespace lab4
{
    abstract class Figure
    {
        protected int x;
        protected int y;

        public Figure(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract void Draw(Pen pen);

        public void MoveRight(int size)
        {
            while(x < size - 100)
            {
                Draw(Pens.Black);
                System.Threading.Thread.Sleep(10);
                HideDrawingBackGround();
                x++;
            }
        }

        public void HideDrawingBackGround()
        {
            Draw(Pens.WhiteSmoke);
        }
    }
}
