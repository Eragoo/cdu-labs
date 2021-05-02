using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Magazine> magazines = new List<Magazine>();
        private List<Author> authors = new List<Author>();

        private const string cacheFileName = "magazines.xml";

        private void buttonEditSelected_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index < 0 || index >= magazines.Count)
            {
                MessageBox.Show("Choose 1 magazine!");
                return;
            }
            MagazineEditForm magazineForm = new MagazineEditForm(magazines[index], authors);

            var res = magazineForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                listBox1.Items[index] = magazines[index];
            }
            else if(res != DialogResult.Abort)
            {
                MessageBox.Show("Nothing changed");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Magazine magazine = new Magazine();
            MagazineEditForm magazineForm = new MagazineEditForm(magazine, authors);

            var res = magazineForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                listBox1.Items.Add(magazine);
                magazines.Add(magazine);
            }
            else if (res != DialogResult.Abort)
            {
                MessageBox.Show("Nothing changed");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Magazine>));
                using (TextReader reader = new StreamReader(cacheFileName))
                {
                    magazines = (List<Magazine>)deserializer.Deserialize(reader);
                }
                foreach (Magazine magazine in magazines)
                {
                    foreach (Article artilce in magazine.getArticles())
                    {
                        authors.Add(artilce.getAuthor());
                    }
                    listBox1.Items.Add(magazine);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Can't load users from cache. Details: " + e.ToString());
                magazines = new List<Magazine>();
            }
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEditSelected.Enabled = true;
        }

        private void addAuthorButton_Click(object sender, EventArgs e)
        {
            Author a = new Author();
            AuthorEditForm f = new AuthorEditForm(a);

            var res = f.ShowDialog();  
            if (res == DialogResult.OK)
            {
                authors.Add(a);
            }
            else if (res != DialogResult.Abort)
            {
                MessageBox.Show("Nothing changed");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(authors != null && authors.Count > 0 && magazines != null && magazines.Count > 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Magazine>));
                using (TextWriter writer = new StreamWriter(cacheFileName))
                {
                    serializer.Serialize(writer, magazines);
                }
            }
        }
    }
}
