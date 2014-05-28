using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containers
{
    public interface IContainer
    {
        void RegisterType(Type FirstRegisterType, Type SecondRegisterType);
        object ResolveType(Type ResolveType);
    }
}
