using System;
using System.Threading;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Figure f = new Circle(30, 40, 30, CreateGraphics());
                f.MoveRight(Size.Width);
            }).Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Figure f = new Rhomb(30, 150, 45, 40,CreateGraphics());
                f.MoveRight(Size.Width);
            }).Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Figure f = new Square(30, 210, 40, CreateGraphics());
                f.MoveRight(Size.Width);
                Console.WriteLine(Size.Width);
                Console.WriteLine();
            }).Start();
        }
    }
}
