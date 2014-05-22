using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [TableName("author_table", "id_field")]
    public class Author
    {
        [FieldName("Name",typeof(string))]
        public string Name { get; set; }
        [FieldName("age_field",typeof(int))]
        public int Age { get; set; }
        [FieldName("id_field",typeof(int))]
        public int ID { get; set; }

        public Author(string name, int age, int id)
        {
            Name = name;
            Age = age;
            ID = id;
        }
        public Author() { }
    }
}
