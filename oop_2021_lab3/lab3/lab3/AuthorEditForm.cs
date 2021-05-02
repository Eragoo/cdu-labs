using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
