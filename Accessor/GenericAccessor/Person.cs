using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    [Serializable]
    [TableName("table_person","field_id")]
    public class Person
    {
        [FieldName("field_name",typeof(string))]
        public string Name { get; set; }

        [FieldName("field_age",typeof(int))]
        public int Age { get; set; }

        [FieldName("field_id",typeof(int))]
        public int ID { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            ID = GetHashCode();
        }

        public Person(string name, int age, int id)
        {
            Name = name;
            Age = age;
            ID = id;
        }

        public Person() { }
    }
}
