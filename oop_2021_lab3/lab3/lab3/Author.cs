using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace lab3
{
    [Serializable]
    public class Author : IXmlSerializable
    {
        private string name;
        private string surname;
        private DateTime birthDate = DateTime.Now;

        public Author(string name, string surname, DateTime birthDate) 
        {
            setName(name);
            setSurname(surname);
            setBirthDate(birthDate);
        }

        public Author()
        {
        
        }

        public string getName()
        {
            return name;
        } 

        public string getSurname()
        {
            return surname;
        }

        public String getFullName()
        {
            return name + " " + surname;
        }

        public DateTime getBirthDate()
        {
            return birthDate;
        }

        public void setName(string name)
        {
            if (name.Trim().Length < 1 || !new System.Text.RegularExpressions.Regex(@"[a-zA-Z]").IsMatch(name.Trim()))
            {
                throw new ArgumentException("Not valid name provided");
            }

            this.name = name.Trim();
        }

        public void setSurname(string surname)
        {
            surname = surname.Trim();
            if (surname.Length < 1 || !new System.Text.RegularExpressions.Regex(@"[a-zA-Z]").IsMatch(surname))
            {
                throw new ArgumentException("Not valid surname provided");
            }

            this.surname = surname;
        }

        public void setBirthDate(DateTime dateTime)
        {
            if (DateTime.Compare(dateTime, DateTime.Now) >= 0) {
                throw new ArgumentException("Provided date npt valid!");
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Author);
        }

        public bool Equals(Author other)
        {
            return other != null &&
                   this.birthDate.Equals(other.birthDate) &&
                   this.name.Equals(other.name) &&
                   this.surname.Equals(other.surname);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^
                surname.GetHashCode() ^
                birthDate.GetHashCode();
        }

        public override string ToString()
        {
            return getFullName();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            name = reader["Name"];
            surname = reader["Surname"];
            birthDate = Convert.ToDateTime(reader["BirthDate"]);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", name);
            writer.WriteAttributeString("Surname", surname);
            writer.WriteAttributeString("BirthDate", birthDate.ToString());
        }
    }
}
