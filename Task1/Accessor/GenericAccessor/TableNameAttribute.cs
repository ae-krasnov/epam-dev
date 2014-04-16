using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    [AttributeUsage(AttributeTargets.Class,Inherited=false)]
    public class TableNameAttribute: Attribute
    {
        public string name { get; set; }//название таблицы
        
        public string idFieldName { get; set; }//название поля с id, указанной таблицы

        public TableNameAttribute(string tName, string idField)
        {
            name = tName;
            idFieldName = idField;
        }
    }
}
