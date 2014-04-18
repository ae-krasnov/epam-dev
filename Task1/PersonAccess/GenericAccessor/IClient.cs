using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAccessor
{
    interface IClient
    {
        void find(int id);
        void printAll();
        void delete(int id);
    }
}
