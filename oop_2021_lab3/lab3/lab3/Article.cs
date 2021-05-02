using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace lab3
{
    [Serializable]
    public class Article : IXmlSerializable
    {
        private Author author;
        private string name;
        private int royalti;
        private int pageCount;

        public Article(Author author, string name, int royalti, int pageCount)
        {
            setAuthor(author);
            setPageCount(pageCount);
            setRoyalti(royalti);
            setName(name);
        }

        public Article(Article article)
        {
            setAuthor(article.author);
            setPageCount(article.pageCount);
            setRoyalti(article.royalti);
            setName(article.name);
        }

        public Article() {}

        public Author getAuthor()
        {
            return author;
        }

        public string getName()
        {
            return name;
        }

        public int getRoyalti()
        {
            return royalti;
        }

        public int getPageCount()
        {
            return pageCount;
        }

        public void setAuthor(Author author)
        {
            if(author == null)
            {
                throw new ArgumentNullException("Provided Author is null");
            }

            this.author = author;
        }

        public void setRoyalti(int royalti)
        {
            if(royalti < 0)
            {
                throw new ArgumentException("Royalti cannot be 0. We live in capitalist world, so all work must be paid!");
            }

            this.royalti = royalti;
        }

        public void setPageCount(int pages)
        {
            if(pages < 1)
            {
                throw new ArgumentException("This article too short!");
            }

            this.pageCount = pages;
        }

        public void setName(string name)
        {
            if(name.Trim().Length < 0)
            {
                throw new ArgumentException("Name must be not blank!");
            }
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Article);
        }

        public bool Equals(Article other)
        {
            return other != null &&
                   this.name == other.name && this.royalti == other.royalti && this.author == other.author;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^
                author.GetHashCode() ^
                royalti.GetHashCode() ^
                pageCount.GetHashCode();
        }

        public override string ToString()
        {
            return name + " Author: " + author.getFullName();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            name = reader["Name"];
            royalti = Int32.Parse(reader["Royalti"]);
            pageCount = Int32.Parse(reader["PageCount"]);

            if (reader.ReadToDescendant("Author") &&
                reader.MoveToContent() == XmlNodeType.Element &&
                reader.LocalName == "Author")
            {
                Author evt = new Author();
                evt.ReadXml(reader);
                this.author = evt; 
            }
            reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", name);
            writer.WriteAttributeString("Royalti", royalti.ToString());
            writer.WriteAttributeString("PageCount", pageCount.ToString());

            writer.WriteStartElement("Author");
            author.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}
