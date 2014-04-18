using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using FactoriesDAL;
using Services;
using Entities;

namespace ConsoleClient
{
    class Program
    {
        enum EntityType
        {
            Author,
            Book
        }
        static void Main(string[] args)
        {
            EntityType type = (EntityType)Enum.Parse(typeof(EntityType), ConfigurationManager.AppSettings["EntityType"].ToString());
            switch (type)
            {
                case EntityType.Author:
                    ConsoleService<Author> personClient = new ConsoleService<Author>(new AuthorAccessorFactory().GetAccess());
                    personClient.Start();
                    break;
                case EntityType.Book:
                    ConsoleService<Book> pointClient = new ConsoleService<Book>(new BookAccessorFactory().GetAccess());
                    pointClient.Start();
                    break;
            }
        }
    }
}
