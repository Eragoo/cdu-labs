using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class AuthorEditForm : Form
    {
        private Author author;
        public AuthorEditForm(Author author)
        {
            InitializeComponent();
            this.author = author;

            nameInput.Text = author.getName();
            surnameInput.Text = author.getSurname();
            dateTimePicker1.Value = author.getBirthDate();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void save_Click(object sender, EventArgs e)
        {
            author.setName(nameInput.Text);
            author.setSurname(surnameInput.Text);
            author.setBirthDate(dateTimePicker1.Value);

            this.DialogResult = DialogResult.OK;
        }

        private void nameInput_Validating(object sender, CancelEventArgs e)
        {
            Regex regexGroupFormat = new Regex(@"[a-zA-Z]");
            if (!regexGroupFormat.IsMatch(nameInput.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Not valid name format!");
            }
        }

        private void surnameInput_Validating(object sender, CancelEventArgs e)
        {
            Regex regexGroupFormat = new Regex(@"[a-zA-Z]");
            if (!regexGroupFormat.IsMatch(surnameInput.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Not valid surname format!");
            }
        }
    }
}
