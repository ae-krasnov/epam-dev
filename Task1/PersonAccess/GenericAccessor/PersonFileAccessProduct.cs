using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;

namespace GenericAccessor
{
    class PersonFileAccessProduct: IAccessorProduct<Person>
    {
        private class FileAccessor:IAccessor<Person>
        {
            const string PATH_TO_FILE = @"res/PersonCollection.xml";

            public Person[] GetAll()
            {
                HashSet<Person> l = LoadFromFile();
                Person[] perArr = l.ToArray();
                return perArr;
            }

            public Person GetByID(int id)
            {
                HashSet<Person> l = LoadFromFile();
                foreach (Person p in l)
                {
                    if (p.ID == id)
                        return p;
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                HashSet<Person> l = LoadFromFile();

                foreach (Person p in l)
                {
                    if (p.ID == id)
                    {
                        l.Remove(p);
                        SaveToFile(l);
                        return;
                    }
                }
            }

            void SaveToFile(HashSet<Person> p)
            {
                using (Stream fStream = new FileStream(PATH_TO_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer xmlFormater = new XmlSerializer(typeof(HashSet<Person>));
                    xmlFormater.Serialize(fStream, p);
                }
            }

            HashSet<Person> LoadFromFile()
            {
                if (!File.Exists(PATH_TO_FILE))
                    SaveToFile(MemoryDB._dbPerson);

                XDocument personCollection = XDocument.Load(PATH_TO_FILE);

                //два linq запроса для получения имен и возраста
                var personName = from p in personCollection.Descendants("Person")
                                 select p.Element("Name").Value;

                var personAge = from p in personCollection.Descendants("Person")
                                select p.Element("Age").Value;

                var personId = from p in personCollection.Descendants("Person")
                               select p.Element("ID").Value;

                object[] names = personName.ToArray();
                object[] ages = personAge.ToArray();
                object[] id = personId.ToArray();

                //создаем коллекцию из полученных значений
                HashSet<Person> res = new HashSet<Person>();
                for (int i = 0; i < names.Length; i++)
                {
                    res.Add(new Person(names[i].ToString(), Int32.Parse(ages[i].ToString()), Int32.Parse(id[i].ToString())));
                }

                return res;
            }
        }
        public IAccessor<Person> GetAccessor()
        {
            return new FileAccessor();
        }
    }
}
