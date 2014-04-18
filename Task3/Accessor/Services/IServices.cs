using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IServices<T>
    {
        void Delete(int id);
        T Find(int id);
        T[] GetAll();
    }
}
