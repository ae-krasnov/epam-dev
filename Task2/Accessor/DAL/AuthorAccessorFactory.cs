using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Entities;

namespace FactoriesDAL
{
    public class AuthorAccessorFactory: Factory<Author>
    {

        public override IAccessor<Author> GetAccess()
        {
            AppSettingsReader ar = new AppSettingsReader();

            string a = (string)ar.GetValue("AccessorType", typeof(string));

            Accessors accessorType = (Accessors)Enum.Parse(typeof(Accessors), a);

            switch (accessorType)
            {
                case Accessors.memory:
                    return new AuthorMemoryAccessProduct().GetAccessor();
                case Accessors.xml:
                    return new AuthorFileAccessProduct().GetAccessor();
                case Accessors.ado_net:
                    return new AuthorADOnetAccessorProduct().GetAccessor();
                case Accessors.myorm:
                    return new MyORM<Author>();
                default:
                    return null;
            }
        }
    }
}
