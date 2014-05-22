using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Containers
{
    public class MyContainer : IContainer
    {
        private readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();


        public void RegisterType(Type FirstRegisterType, Type SecondRegisterType)
        {
            _dependencyMap.Add(FirstRegisterType, SecondRegisterType);
        }

        public object ResolveType(Type ResolveType)
        {
            if (!_dependencyMap.ContainsKey(ResolveType))
            {
                RegisterType(ResolveType, ResolveType);
            }
            Type resolvedType = LookUpDependency(ResolveType);
            ConstructorInfo constructor = resolvedType.GetConstructors().First();
            ParameterInfo[] parameters = constructor.GetParameters();

            if (!parameters.Any())
            {
                return Activator.CreateInstance(resolvedType);
            }
            else
            {
                return constructor.Invoke(ResolveParameters(parameters).ToArray());
            }
        }

        private Type LookUpDependency(Type type)
        {
            return _dependencyMap[type];
        }

        private IEnumerable<object> ResolveParameters(
            IEnumerable<ParameterInfo> parameters)
        {
            return parameters
                .Select(p => ResolveType(p.ParameterType))
                .ToList();
        }

        
    }
}
