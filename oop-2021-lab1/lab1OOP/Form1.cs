using System;
using System.Windows.Forms;

namespace lab1OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LockButton_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            maskedTextBox1.Hide();
        }

        private void UnlockButton_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Show();
            this.ActiveControl = maskedTextBox1;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Random _r = new Random();
            int r = _r.Next(1, 255);
            int g = _r.Next(1, 255);
            int b = _r.Next(1, 255);

            this.BackColor = System.Drawing.Color.FromArgb(r, g, b);

            maskedTextBox1.Hide();
            LockButton.Hide();
            UnlockButton.Hide();
        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Show();
            LockButton.Show();
            UnlockButton.Show();
        }
    }
}
