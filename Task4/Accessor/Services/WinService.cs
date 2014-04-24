using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FactoriesDAL;

namespace Services
{
    public class WinService<T>: IServices<T>
    {
        private IAccessor<T> _a;

        public WinService(IAccessor<T> accessor)
        {
            _a = accessor;
        }

        public void Delete(int id)
        {
            _a.RemoveByID(id);
        }

        public T Find(int id)
        {
            return _a.GetByID(id);
        }

        public T[] GetAll()
        {
            return _a.GetAll();
        }
    }
}
