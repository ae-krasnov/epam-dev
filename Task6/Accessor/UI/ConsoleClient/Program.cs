using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using System.Reflection;
using Microsoft.Practices.Unity;

using Containers;
using DataAccess;
using Loggers;
using Services;
using Entities;

namespace ConsoleClient
{
    class Program
    {
        static object CommonService;
        static IContainer container;
        static ILogger log;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Выберите тип Logger\n1)NLog (по-умолчанию)\n2)Log4Net\n3)MyLogger");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    log = new AdapterNLog();
                    break;
                case "2":
                    log = new AdapterLog4Net(typeof(Program));
                    break;
                case "3":
                    log = new MyLogger();
                    break;
                default:
                    Console.WriteLine("Неверное значение, был выбран IoC по-умолчанию");
                    log = new AdapterNLog();
                    break;
            }

            Console.WriteLine("Выберите тип IoC\n1)Unity (по-умолчанию)\n2)Autofac\n3)MyContainer");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    container = new AdapterUnity();
                    log.WriteToLog("IoC-Unity");
                    break;
                case "2":
                    container = new AdapterAutofac();
                    log.WriteToLog("IoC-Autofac");
                    break;
                case "3":
                    container = new MyContainer();
                    log.WriteToLog("IoC-MyContainer");
                    break;
                default:
                    Console.WriteLine("Неверное значение, был выбран IoC по-умолчанию");
                    container = new AdapterUnity();
                    log.WriteToLog("IoC-Unity");
                    break;
            }
            

            Console.WriteLine("Выберите сущность:\n1)авторы (по-умолчанию)\n2)книги");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    container.RegisterType(typeof(IServices<Author>), typeof(Service<Author>));
                    AdjustAuthorDal(container);                    
                    CommonService = container.ResolveType(typeof(Service<Author>));
                    log.WriteToLog("entity-author");
                    break;
                case "2":
                    container.RegisterType(typeof(IServices<Book>), typeof(Service<Book>));
                    AdjustBookDal(container);
                    CommonService = container.ResolveType(typeof(Service<Book>));
                    log.WriteToLog("entity-book");
                    break;
                default:
                    Console.WriteLine("Неверное значение, была выбрана сущность по-умолчанию");
                    container.RegisterType(typeof(IServices<Author>), typeof(Service<Author>));
                    AdjustAuthorDal(container);
                    CommonService = container.ResolveType(typeof(Service<Author>));
                    log.WriteToLog("entity-author");
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
        static void AdjustAuthorDal(IContainer container) 
        {
            Console.WriteLine("Выберите DAL для автора:\n1)File\n2)Memory\n3)Ado.Net\n4)MyORM (по-умолчанию)");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    container.RegisterType(typeof(IAccessor<Author>),typeof(AuthorFileAccessor));
                    break;
                case "2":
                    container.RegisterType(typeof(IAccessor<Author>), typeof(AuthorMemoryAccess));
                    break;
                case "3":
                    container.RegisterType(typeof(IAccessor<Author>), typeof(AuthorAdoNetAccessor));
                    break;
                case "4":
                    container.RegisterType(typeof(IAccessor<Author>), typeof(MyORM<Author>));
                    break;
                default:
                    Console.WriteLine("Неверное значение, выбран DAL по-умолчанию");
                    container.RegisterType(typeof(IAccessor<Author>), typeof(MyORM<Author>));
                    break;
            }
        }
        static void AdjustBookDal(IContainer container) 
        {
            Console.WriteLine("Выберите DAL для книги:\n1)File\n2)Memory\n3)Ado.Net\n4)MyORM (по-умолчанию)");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    container.RegisterType(typeof(IAccessor<Book>), typeof(BookFileAccessor));
                    break;
                case "2":
                    container.RegisterType(typeof(IAccessor<Book>), typeof(BookMemoryAccessor));
                    break;
                case "3":
                    container.RegisterType(typeof(IAccessor<Book>), typeof(BookAdoNetAccessor));
                    break;
                case "4":
                    container.RegisterType(typeof(IAccessor<Book>), typeof(MyORM<Book>));
                    break;
                default:
                    Console.WriteLine("Неверное значение, выбран DAL по-умолчанию");
                    container.RegisterType(typeof(IAccessor<Book>), typeof(MyORM<Book>));
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
