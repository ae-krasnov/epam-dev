using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

namespace ConsoleClient
{
    class UnityIoC : IContainer
    {
        IUnityContainer _container;
        public UnityIoC()
        {
            _container = new UnityContainer();
        }

        public void RegisterType(Type FirstRegisterType, Type SecondRegisterType)
        {
            _container.RegisterType(FirstRegisterType, SecondRegisterType);
        }

        public object ResolveType(Type ResolveType)
        {
            return _container.Resolve(ResolveType);
        }
    }
}
