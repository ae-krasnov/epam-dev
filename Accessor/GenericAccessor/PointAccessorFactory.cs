using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace core
{
    public class PointAccessorFactory : Factory<Point>
    {
        
        public override IAccessor<Point> getAccess()
        {
            AppSettingsReader ar = new AppSettingsReader();

            string a = (string)ar.GetValue("AccessorType", typeof(string));

            Accessors accessorType = (Accessors)Enum.Parse(typeof(Accessors), a);

            switch (accessorType)
            {
                case Accessors.memory:
                    return new PointMemoryAccessProduct().GetAccessor();
                case Accessors.xml:
                    return new PointFileAccessProduct().GetAccessor();
                case Accessors.ado_net:
                    return new PointADOnetAccessorProduct().GetAccessor();
                case Accessors.myorm:
                    return new MyORM<Point>();
                default:
                    return null;
            }
        }
    }
}
