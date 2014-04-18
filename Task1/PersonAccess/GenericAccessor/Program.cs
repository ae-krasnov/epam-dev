using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAccessor
{
    class Program
    {
        static void Main(string[] args)
        {
            IClient c=null;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Выберите сущьность:\n1)Person\n2)Point");

            if (Console.ReadLine() == "1")
                c = new Client<Person>(new PersonAccessorFactory().getAccess());
            else
                c = new Client<Point>(new PointAccessorFactory().getAccess());

            string menu = "Введите 'q' для выхода\n"
                           + "1)Информация обо всех объектах;\n"
                           + "2)Найти по id;\n"
                           + "3)Удалить по id";
            bool stop = false;

            while (!stop)
            {
                Console.WriteLine(menu);
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        c.printAll();
                        break;
                    case "2":
                        Console.WriteLine("Введите id:");
                        c.find(Int32.Parse(Console.ReadLine()));
                        break;
                    case "3":
                        Console.WriteLine("id для удаления");
                        c.delete(Int32.Parse(Console.ReadLine()));
                        break;
                    case "q":
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Не корректное значение");
                        break;
                }
            }
        }
    }
}
