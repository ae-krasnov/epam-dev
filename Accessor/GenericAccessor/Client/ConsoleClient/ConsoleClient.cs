using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using core;

namespace ConsoleClient
{
    class ConsoleClient<T>
    {
        private IAccessor<T> a;

        public ConsoleClient(IAccessor<T> accessor)
        {
            a = accessor;
        }

        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string menu = @"Введите 'q' для выхода или выберите операцию
1)Информация обо всех объектах; 
2)Найти по id; 
3)Удалить по id";

            bool stop = false;

            while (!stop)
            {
                Console.WriteLine(menu);
                try
                {
                    switch (Console.ReadLine().ToLower().Trim())
                    {
                        case "1":
                            printAll();
                            break;
                        case "2":
                            Console.WriteLine("Введите id:");
                            find(Int32.Parse(Console.ReadLine()));
                            break;
                        case "3":
                            Console.WriteLine("id для удаления");
                            delete(Int32.Parse(Console.ReadLine()));
                            break;
                        case "q":
                            stop = true;
                            break;
                        default:
                            Console.WriteLine("Не корректное значение");
                            break;
                    }
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Значение должно быть цифрой ",e.Message);
                }
            }
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
