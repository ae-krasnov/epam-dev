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
        private IAccessor<T> a;

        public WinService(IAccessor<T> accessor)
        {
            a = accessor;
        }

        public void delete(int id)
        {
            a.RemoveByID(id);
        }

        public T find(int id)
        {
            return a.GetByID(id);
        }

        public T[] getAll()
        {
            return a.GetAll();
        }
    }
}
