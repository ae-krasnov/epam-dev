using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;

using Entities;

namespace FactoriesDAL
{
    class BookFileAccessProduct: IAccessorProduct<Book>
    {

        private class FileAccessor:IAccessor<Book>
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

                XDocument personCollection = XDocument.Load(PATH_TO_FILE);

                var bookId = from p in personCollection.Descendants("Book")
                                 select p.Element("IdBook").Value;

                var authorId = from p in personCollection.Descendants("Book")
                               select p.Element("Author_id").Value;

                var name = from p in personCollection.Descendants("Book")
                           select p.Element("Name").Value;

                object[] id =bookId.ToArray();
                object[] author = authorId.ToArray();
                object[] bookName = name.ToArray();
                
                HashSet<Book> res = new HashSet<Book>();
                for (int i = 0; i < id.Length; i++)
                {
                    res.Add(new Book(Int32.Parse(id[i].ToString()), Int32.Parse(author[i].ToString()), bookName[i].ToString()));
                }

                return res;
            }
        }

        public IAccessor<Book> GetAccessor()
        {
            return new FileAccessor();
        }
    }
}
