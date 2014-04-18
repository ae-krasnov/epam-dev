using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GenericAccessor
{
    class PersonAccessorFactory: Factory<Person>
    {

        public override IAccessor<Person> getAccess()
        {
            AppSettingsReader ar = new AppSettingsReader();

            string a = (string)ar.GetValue("AccessorType", typeof(string));

            Accessors accessorType = (Accessors)Enum.Parse(typeof(Accessors), a);

            switch (accessorType)
            {
                case Accessors.memory:
                    return new PersonMemoryAccessProduct().GetAccessor();
                case Accessors.xml:
                    return new PersonFileAccessProduct().GetAccessor();
                case Accessors.ado_net:
                    return new PersonADOnetAccessorProduct().GetAccessor();
                case Accessors.myorm:
                    return new MyORM<Person>();
                default:
                    return null;
            }
        }
    }
}
