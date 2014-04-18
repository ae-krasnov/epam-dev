using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    [TableName("book_table","bookId_field")]
    public class Book
    {
        [FieldName("bookId_field",typeof(int))]
        public int IdBook { get; set; }
        [FieldName("author_id_field",typeof(int))]
        public int Author_id { get; set; }
        [FieldName("name_field",typeof(string))]
        public string Name { get; set; }

        public Book(int id, int authorId, string name) 
        {
            IdBook = id;
            Author_id = authorId;
            Name = name;
        }
        public Book() { }
    }
}
