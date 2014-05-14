using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;

namespace Containers
{
    public class AdapterAutofac : IContainer
    {
        ContainerBuilder _builder;
        public AdapterAutofac()
        {
            _builder = new ContainerBuilder();
        }
        public void RegisterType(Type FirstRegisterType, Type SecondRegisterType)
        {

            //_builder.RegisterTypes(FirstRegisterType, SecondRegisterType);
            _builder.RegisterType(SecondRegisterType).As(FirstRegisterType);
        }

        public object ResolveType(Type ResolveType)
        {
            _builder.RegisterType(ResolveType);
            return _builder.Build().Resolve(ResolveType);
        }
    }
}
