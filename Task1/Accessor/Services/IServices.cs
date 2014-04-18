using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IServices<T>
    {
        void delete(int id);
        T find(int id);
        T[] getAll();
    }
}
