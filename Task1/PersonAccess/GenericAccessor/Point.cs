using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAccessor
{
    [Serializable]
    [TableName("table_point","field_id")]
    public class Point
    {
        [FieldName("field_X",typeof(int))]
        public int  X { get; set; }

        [FieldName("field_Y",typeof(int))]
        public int Y { get; set; }
             
        [FieldName("field_id",typeof(int))]
        public int ID { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            ID = GetHashCode();
        }

        public Point(int x, int y, int id)
        {
            X = x;
            Y = y;
            ID = id;
        }

        public Point() { }
    }
}
