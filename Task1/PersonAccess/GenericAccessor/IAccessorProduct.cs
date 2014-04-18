using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAccessor
{
    interface IAccessorProduct<T>
    {
        IAccessor<T> GetAccessor();
    }
}
