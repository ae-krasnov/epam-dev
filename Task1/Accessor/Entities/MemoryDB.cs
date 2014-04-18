using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MemoryDB
    {
        public static HashSet<Author> Authors = new HashSet<Author>()
        {
            new Author("Andrew Troelsen", 33,1),
            new Author("Jeffrey Richter", 33,2)
        };

        public static HashSet<Book> Books = new HashSet<Book>() 
        {
            new Book(11,1,"Pro C# 5"),
            new Book(22,2,"Clr via C#")
        };
    }
}
