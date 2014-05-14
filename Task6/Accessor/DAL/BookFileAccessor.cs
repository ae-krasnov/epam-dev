using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;

using Entities;

namespace DataAccess
{
        public class BookFileAccessor:IAccessor<Book>
        {
            const string PATH_TO_FILE = "BookCollection.xml";

            public Book[] GetAll()
            {
                HashSet<Book> l = LoadFromFile();
                Book[] bookArr = l.ToArray();
                return bookArr;
            }

            public Book GetByID(int id)
            {
                HashSet<Book> l = LoadFromFile();
                foreach (Book p in l)
                {
                    if (p.IdBook == id)
                        return p;
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                HashSet<Book> l = LoadFromFile();

                foreach (Book p in l)
                {
                    if (p.IdBook == id)
                    {
                        l.Remove(p);
                        SaveToFile(l);
                        return;
                    }
                }
            }

            void SaveToFile(HashSet<Book> p) 
            {
                using (Stream fStream = new FileStream(PATH_TO_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer xmlFormater = new XmlSerializer(typeof(HashSet<Book>));
                    xmlFormater.Serialize(fStream, p);
                }
            }

            HashSet<Book> LoadFromFile()
            {
                if (!File.Exists(PATH_TO_FILE))
                    SaveToFile(Entities.MemoryDB.Books);

                XDocument BookCollection = XDocument.Load(PATH_TO_FILE);

                IEnumerable<XElement> bookId = (IEnumerable<XElement>)BookCollection.XPathSelectElements("/ArrayOfBook/Book/IdBook");
                IEnumerable<XElement> authorId = (IEnumerable<XElement>)BookCollection.XPathSelectElements("/ArrayOfBook/Book/Author_id");
                IEnumerable<XElement> name = (IEnumerable<XElement>)BookCollection.XPathSelectElements("/ArrayOfBook/Book/Name");
                
                XElement[] id =bookId.ToArray();
                XElement[] author = authorId.ToArray();
                XElement[] bookName = name.ToArray();
                
                HashSet<Book> res = new HashSet<Book>();
                for (int i = 0; i < id.Length; i++)
                {
                    res.Add(new Book(Int32.Parse(id[i].Value.ToString()), Int32.Parse(author[i].Value.ToString()), bookName[i].Value.ToString()));
                }

                return res;
            }
        }
}
