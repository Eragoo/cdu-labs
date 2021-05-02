using System.Collections.Generic;
using System;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace lab3
{
    [Serializable]
    public class Magazine : IXmlSerializable
    {
        private Period period;
        private string name;
        private List<Article> articles = new List<Article>();

        public Magazine(string name, Period period, ICollection<Article> articles)
        {
            this.period = period;

            if(name.Trim().Length < 1)
            {
                throw new ArgumentException("Name must be not blank!");
            }

            this.name = name;

            if(articles.Count < 0)
            {
                throw new ArgumentException("Magazine cannot be empty!");
            }

            this.articles = new List<Article>(articles);
        }

        public Magazine() {}

        public void setPeriod(Period period)
        {
            this.period = period;
        }

        public void addArticle(Article article)
        {
            articles.Add(article);
        }

        public string getName()
        {
            return name;
        }

        public Period getPeriod()
        {
            return period;
        }

        public int getPageCount()
        {
            int pageCount = 0;
            foreach(Article a in articles)
            {
                pageCount += a.getPageCount();
            }

            return pageCount;
        }

        public override string ToString()
        {
            return name + " " + period;
        }

        public void setName(string name)
        {
            if(name.Trim().Length <= 0)
            {
                throw new ArgumentException("Name must be not blank!");
            }
            this.name = name;
        }

        public void setArticles(List<Article> articles)
        {
            if(articles == null || articles.Count <= 0)
            {
                throw new ArgumentException("Articles must be not null and not empty!");
            }
            this.articles = articles;
        }

        public List<Article> getArticles()
        {
            return articles;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            period = (Period)Enum.Parse(typeof(Period), reader["Period"]);
            name = reader["Name"];

            if (reader.ReadToDescendant("Article"))
            {
                while (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Article")
                {
                    Article evt = new Article();
                    evt.ReadXml(reader);
                    articles.Add(evt);
                }
            }
            reader.Read();    
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Period", period.ToString());
            writer.WriteAttributeString("Name", name);

            foreach(Article a in articles)
            {
                writer.WriteStartElement("Article");
                a.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
    }
}
