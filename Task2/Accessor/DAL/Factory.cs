using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoriesDAL
{
    public abstract class Factory<T>
    {

        public enum Accessors
        {
            xml,
            memory,
            ado_net,
            myorm
        }

        public abstract IAccessor<T> GetAccess();
    }
}
