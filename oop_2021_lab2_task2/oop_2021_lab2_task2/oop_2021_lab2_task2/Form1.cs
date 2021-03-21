using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_2021_lab2_task2
{
    public partial class Form1 : Form
    {

        public delegate void MagicAction(object sender, EventArgs e);

        public MagicAction magicAction = (sender, e)=> Console.WriteLine();

        public Form1()
        {
            InitializeComponent();
        }

        private void InvisibleModeButton_Click(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity.Equals(1) ? 0.75 : 1;
        }

        private void ChangeColorButton_Click(object sender, EventArgs e)
        {
            Random _r = new Random();
            int r = _r.Next(1, 255);
            int g = _r.Next(1, 255);
            int b = _r.Next(1, 255);
            this.BackColor = Color.FromArgb(r, g, b);
        }

        private void GreetingButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello!");
        }

        private void MagicButton_Click(object sender, EventArgs e)
        {
            magicAction(sender, e);
        }

        private void InvisibleModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                magicAction += InvisibleModeButton_Click;
            }
            else
            {
                magicAction -= InvisibleModeButton_Click;
            }
        }

        private void CahangeColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                magicAction += ChangeColorButton_Click;
            }
            else
            {
                magicAction -= ChangeColorButton_Click;
            }
        }

        private void GreetingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                magicAction += GreetingButton_Click;
            }
            else
            {
                magicAction -= GreetingButton_Click;
            }
        }
    }
}
