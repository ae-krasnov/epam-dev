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
    class AuthorFileAccessProduct: IAccessorProduct<Author>
    {
        private class FileAccessor:IAccessor<Author>
        {
            const string PATH_TO_FILE = @"res/AuthorCollection.xml";

            public Author[] GetAll()
            {
                HashSet<Author> l = LoadFromFile();
                Author[] perArr = l.ToArray();
                return perArr;
            }

            public Author GetByID(int id)
            {
                HashSet<Author> l = LoadFromFile();
                foreach (Author p in l)
                {
                    if (p.ID == id)
                        return p;
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                HashSet<Author> l = LoadFromFile();

                foreach (Author p in l)
                {
                    if (p.ID == id)
                    {
                        l.Remove(p);
                        SaveToFile(l);
                        return;
                    }
                }
            }

            void SaveToFile(HashSet<Author> p)
            {
                using (Stream fStream = new FileStream(PATH_TO_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer xmlFormater = new XmlSerializer(typeof(HashSet<Author>));
                    xmlFormater.Serialize(fStream, p);
                }
            }

            HashSet<Author> LoadFromFile()
            {
                if (!File.Exists(PATH_TO_FILE))
                    SaveToFile(Entities.MemoryDB.Authors);

                XDocument AuthorCollection = XDocument.Load(PATH_TO_FILE);

                //два linq запроса для получения имен и возраста
                var AuthorName = from p in AuthorCollection.Descendants("Author")
                                 select p.Element("Name").Value;

                var AuthorAge = from p in AuthorCollection.Descendants("Author")
                                select p.Element("Age").Value;

                var AuthorId = from p in AuthorCollection.Descendants("Author")
                               select p.Element("ID").Value;

                object[] names = AuthorName.ToArray();
                object[] ages = AuthorAge.ToArray();
                object[] id = AuthorId.ToArray();

                //создаем коллекцию из полученных значений
                HashSet<Author> res = new HashSet<Author>();
                for (int i = 0; i < names.Length; i++)
                {
                    res.Add(new Author(names[i].ToString(), Int32.Parse(ages[i].ToString()), Int32.Parse(id[i].ToString())));
                }

                return res;
            }
        }
        public IAccessor<Author> GetAccessor()
        {
            return new FileAccessor();
        }
    }
}
