using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using System.Reflection;
using Microsoft.Practices.Unity;

using DataAccess;
using Services;
using Entities;

namespace ConsoleClient
{
    class Program
    {
        static object CommonService;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            IUnityContainer container = new UnityContainer();
            container.RegisterType(typeof(IServices<>), typeof(Service<>));

            Console.WriteLine("Выберите сущность:\n1)авторы (по-умолчанию)\n2)книги");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    AdjustAuthorDal(container);
                    CommonService = container.Resolve<IServices<Author>>();
                    break;
                case "2":
                    AdjustBookDal(container);
                    CommonService = container.Resolve<IServices<Book>>();
                    break;
                default:
                    Console.WriteLine("Неверное значение, была выбрана сущность по-умолчанию");
                    AdjustAuthorDal(container);
                    CommonService = container.Resolve<IServices<Author>>();
                    break;
            }

            string menu = @"Введите 'q' для выхода или выберите операцию
1)Информация обо всех объектах; 
2)Найти по id; 
3)Удалить по id";

            bool stop = false;
            while (!stop)
            {
                Console.WriteLine(menu);
                switch (Console.ReadLine().Trim().ToLower())
                {
                    case "1":
                        if (CommonService is IServices<Author>)
                        {
                            IServices<Author> AuthorService = (IServices<Author>)CommonService;
                            var authors=AuthorService.GetAll();
                            PrintInfo(authors);
                        }
                        else
                        {
                            IServices<Book> BookService = (IServices<Book>)CommonService;
                            var books = BookService.GetAll();
                            PrintInfo(books);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите id:");
                        int FindId = -1;
                        try
                        {
                            FindId = Int32.Parse(Console.ReadLine().Trim());
                            if (FindId<0)
                            {
                                Console.WriteLine("Значени должно быть не отрицательное число");
                                FindId = -1;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Значени должно быть не отрицательное число");
                            FindId = -1;
                        }
                        if(FindId!=-1)
                        {
                            if (CommonService is IServices<Author>)
                            {
                                IServices<Author> AuthorService = (IServices<Author>)CommonService;
                                var author = AuthorService.Find(FindId);
                                PrintInfo(author);
                            }
                            else
                            {
                                IServices<Book> BookService = (IServices<Book>)CommonService;
                                var book = BookService.Find(FindId);
                                PrintInfo(book);
                            }
                        }
                        break;
                    case "3":
                         Console.WriteLine("Введите id:");
                        int RemoveId = -1;
                        try
                        {
                            RemoveId = Int32.Parse(Console.ReadLine().Trim());
                            if (RemoveId<0)
                            {
                                Console.WriteLine("Значени должно быть не отрицательное число");
                                RemoveId = -1;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Значени должно быть не отрицательное число");
                            RemoveId = -1;
                        }
                        if(RemoveId!=-1)
                        {
                            if (CommonService is IServices<Author>)
                            {
                                IServices<Author> AuthorService = (IServices<Author>)CommonService;
                                AuthorService.Delete(RemoveId);
                            }
                            else
                            {
                                IServices<Book> BookService = (IServices<Book>)CommonService;
                                BookService.Delete(RemoveId);
                            }
                        }
                        break;
                    case "q":
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Неверное значение");
                        break;
                }
            }
        }
        static void AdjustAuthorDal(IUnityContainer container) 
        {
            Console.WriteLine("Выберите DAL для автора:\n1)File\n2)Memory\n3)Ado.Net\n4)MyORM (по-умолчанию)");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    container.RegisterType(typeof(IAccessor<>),typeof(AuthorFileAccessor));
                    break;
                case "2":
                    container.RegisterType(typeof(IAccessor<>), typeof(AuthorMemoryAccess));
                    break;
                case "3":
                    container.RegisterType(typeof(IAccessor<>), typeof(AuthorAdoNetAccessor));
                    break;
                case "4":
                    container.RegisterType(typeof(IAccessor<>), typeof(MyORM<Author>));
                    break;
                default:
                    Console.WriteLine("Неверное значение, выбран DAL по-умолчанию");
                    container.RegisterType(typeof(IAccessor<>), typeof(MyORM<Author>));
                    break;
            }
        }
        static void AdjustBookDal(IUnityContainer container) 
        {
            Console.WriteLine("Выберите DAL для книги:\n1)File\n2)Memory\n3)Ado.Net\n4)MyORM (по-умолчанию)");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    container.RegisterType(typeof(IAccessor<>), typeof(BookFileAccessor));
                    break;
                case "2":
                    container.RegisterType(typeof(IAccessor<>), typeof(BookMemoryAccessor));
                    break;
                case "3":
                    container.RegisterType(typeof(IAccessor<>), typeof(BookAdoNetAccessor));
                    break;
                case "4":
                    container.RegisterType(typeof(IAccessor<>), typeof(MyORM<Book>));
                    break;
                default:
                    Console.WriteLine("Неверное значение, выбран DAL по-умолчанию");
                    container.RegisterType(typeof(IAccessor<>), typeof(MyORM<Book>));
                    break;
            }
        }
        static void PrintInfo(object[] entity) 
        {
            foreach (var item in entity)
            {
                if (item != null)
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
        static void PrintInfo(object entity)
        {
                 if (entity != null)
                {
                    Type type = entity.GetType();
                    PropertyInfo[] propertyArray = type.GetProperties();

                    foreach (PropertyInfo p in propertyArray)
                    {
                        Console.WriteLine("{0}: {1}", p.Name, p.GetValue(entity));
                    }
                    Console.WriteLine("");
                }
        }
    }
}
