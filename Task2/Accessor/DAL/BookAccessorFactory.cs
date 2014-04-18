using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Entities;

namespace FactoriesDAL
{
    public class BookAccessorFactory : Factory<Book>
    {
        
        public override IAccessor<Book> GetAccess()
        {
            AppSettingsReader ar = new AppSettingsReader();

            string a = (string)ar.GetValue("AccessorType", typeof(string));

            Accessors accessorType = (Accessors)Enum.Parse(typeof(Accessors), a);

            switch (accessorType)
            {
                case Accessors.memory:
                    return new BookMemoryAccessProduct().GetAccessor();
                case Accessors.xml:
                    return new BookFileAccessProduct().GetAccessor();
                case Accessors.ado_net:
                    return new BookADOnetAccessorProduct().GetAccessor();
                case Accessors.myorm:
                    return new MyORM<Book>();
                default:
                    return null;
            }
        }
    }
}
