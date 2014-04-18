using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAccessor
{
    public interface IAccessor<T>
    {
        T[] GetAll();
        T GetByID(int id);
        void RemoveByID(int id);
    }
}
