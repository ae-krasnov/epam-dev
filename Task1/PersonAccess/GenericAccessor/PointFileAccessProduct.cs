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
    class PointFileAccessProduct: IAccessorProduct<Point>
    {

        private class FileAccessor:IAccessor<Point>
        {
            const string PATH_TO_FILE = @"res/PointCollection.xml";

            public Point[] GetAll()
            {
                HashSet<Point> l = LoadFromFile();
                Point[] perArr = l.ToArray();
                return perArr;
            }

            public Point GetByID(int id)
            {
                HashSet<Point> l = LoadFromFile();
                foreach (Point p in l)
                {
                    if (p.ID == id)
                        return p;
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                HashSet<Point> l = LoadFromFile();

                foreach (Point p in l)
                {
                    if (p.ID == id)
                    {
                        l.Remove(p);
                        SaveToFile(l);
                        return;
                    }
                }
            }

            void SaveToFile(HashSet<Point> p) 
            {
                using (Stream fStream = new FileStream(PATH_TO_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer xmlFormater = new XmlSerializer(typeof(HashSet<Point>));
                    xmlFormater.Serialize(fStream, p);
                }
            }

            HashSet<Point> LoadFromFile()
            {
                if (!File.Exists(PATH_TO_FILE))
                    SaveToFile(MemoryDB._dbPoint);

                XDocument personCollection = XDocument.Load(PATH_TO_FILE);

                var pointX = from p in personCollection.Descendants("Point")
                                 select p.Element("X").Value;

                var pointY = from p in personCollection.Descendants("Point")
                                select p.Element("Y").Value;

                var pointId = from p in personCollection.Descendants("Point")
                               select p.Element("ID").Value;

                object[] X = pointX.ToArray();
                object[] Y = pointY.ToArray();
                object[] id = pointId.ToArray();

                HashSet<Point> res = new HashSet<Point>();
                for (int i = 0; i < X.Length; i++)
                {
                    res.Add(new Point(Int32.Parse(X[i].ToString()), Int32.Parse(Y[i].ToString()), Int32.Parse(id[i].ToString())));
                }

                return res;
            }
        }

        public IAccessor<Point> GetAccessor()
        {
            return new FileAccessor();
        }
    }
}
