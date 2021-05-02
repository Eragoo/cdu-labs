using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace lab3
{
    public partial class MagazineEditForm : Form
    {

        private Magazine magazine;
        private List<Author> authors;
        private BindingList<Article> articles = new BindingList<Article>();

        public MagazineEditForm(Magazine magazine, List<Author> authors)
        {
            InitializeComponent();

            this.magazine = magazine;
            this.authors = authors;
            if(magazine.getArticles() != null)
            {
                articles = new BindingList<Article>(magazine.getArticles());
            }

            comboBox1.DataSource = Enum.GetValues(typeof(Period));

            textBox1.Text = magazine.getName();
            comboBox1.SelectedItem = magazine.getPeriod();
            listBox1.DataSource = articles;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEditSelected.Enabled = true;
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                magazine.setPeriod((Period)comboBox1.SelectedItem);
                magazine.setName(textBox1.Text);

                magazine.setArticles(articles.ToList());

                this.DialogResult = DialogResult.OK;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("You must specify at least 1 article!");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void addArticle_Click(object sender, EventArgs e)
        {
            Article article = new Article();
            ArticleEditForm articleForm = new ArticleEditForm(article, authors);

            var res = articleForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                articles.Add(article);
            }
            else if (res != DialogResult.Abort)
            {
                MessageBox.Show("Nothing changed");
            }
        }

        private void buttonEditSelected_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index < 0 || index >= articles.Count)
            {
                MessageBox.Show("Choose 1 article!");
                return;
            }
            ArticleEditForm articleForm = new ArticleEditForm(articles[index], authors);

            var res = articleForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                Article article = new Article(articles[index]);
                //hack to make articles notify listBox about state change
                articles.Add(article);
                articles.RemoveAt(index);
            }
            else if (res != DialogResult.Abort)
            {
                MessageBox.Show("Nothing changed");
            }
        }
    }
}
