using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace lab3
{
    public partial class ArticleEditForm : Form
    {
        private Article article;
        private List<Author> authors;

        public ArticleEditForm(Article article, List<Author> authors)
        {
            InitializeComponent();
            this.article = article;
            this.authors = authors;
            
            name.Text = article.getName();
            royalti.Text = article.getRoyalti().ToString();
            pageCount.Text = article.getPageCount().ToString();

            authorComboBox.DataSource = this.authors;
        }

        private void buttonEditSelected_Click(object sender, EventArgs e)
        {
            article.setName(name.Text);
            article.setPageCount(Int32.Parse(pageCount.Text));
            article.setRoyalti(Int32.Parse(royalti.Text));

            var index = authorComboBox.SelectedIndex;
            article.setAuthor(authors[index]);

            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void royalti_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int i = Int32.Parse(royalti.Text);
            } catch(FormatException ex)
            {
                e.Cancel = true;
                MessageBox.Show("Not valid royalti format!");
            }
        }

        private void pageCount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
               int i = Int32.Parse(royalti.Text);
            }
            catch (FormatException ex)
            {
                e.Cancel = true;
                MessageBox.Show("Not valid page count format!");
            }
        }
    }
}
