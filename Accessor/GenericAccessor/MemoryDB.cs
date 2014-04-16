using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    class MemoryDB
    {
        public static HashSet<Person> _dbPerson = new HashSet<Person>()
        {
            {new Person("Smith",23)},
            {new Person("Petrov",25)}
        };

        public static HashSet<Point> _dbPoint = new HashSet<Point>() 
        {
            {new Point(10,5)},
            {new Point(14,-1)}
        };
    }
}
