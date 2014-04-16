using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using core;

namespace ConsoleClient
{
    class Program
    {
        enum EntityType
        {
            person,
            point
        }
        static void Main(string[] args)
        {
            EntityType type = (EntityType)Enum.Parse(typeof(EntityType), ConfigurationManager.AppSettings["EntityType"].ToString());
            switch (type)
            {
                case EntityType.person:
                    ConsoleClient<Person> personClient = new ConsoleClient<Person>(new PersonAccessorFactory().getAccess());
                    personClient.Start();
                    break;
                case EntityType.point:
                    ConsoleClient<Point> pointClient = new ConsoleClient<Point>(new PointAccessorFactory().getAccess());
                    pointClient.Start();
                    break;
            }
        }
    }
}
