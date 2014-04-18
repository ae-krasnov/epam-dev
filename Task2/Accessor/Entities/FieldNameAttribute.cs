using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [AttributeUsage(AttributeTargets.Property, Inherited=false)]
    public class FieldNameAttribute: Attribute
    {
        public string fieldName { get; set; }

        public Type fieldType { get; set; }

        public FieldNameAttribute(string fieldName, Type fieldType)
        {
            this.fieldName = fieldName;
            this.fieldType = fieldType;
        }
    }
}
