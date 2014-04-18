using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GenericAccessor
{
    class Client<T>: IClient
    {
        private IAccessor<T> a;

        public Client(IAccessor<T> accessor)
        {
            a = accessor;
        }

        public void find(int id)
        {
            T t = a.GetByID(id);
            printInfo(t);
        }

        public void printAll()
        {
            T[] allObj = a.GetAll();
            foreach (T item in allObj)
            {
                printInfo(item);
            }
        }

        public void delete(int id)
        {
            a.RemoveByID(id);
        }

        private void printInfo(T item)
        {
            if(item!=null)
            {
                Type type = item.GetType();
                PropertyInfo[] propertyArray = type.GetProperties();

                foreach (PropertyInfo p in propertyArray)
                {
                    Console.WriteLine("{0}: {1}", p.Name, p.GetValue(item));
                }
                Console.WriteLine("");
            }
        }
    }
}
