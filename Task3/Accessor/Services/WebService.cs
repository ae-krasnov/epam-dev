using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FactoriesDAL;

namespace Services
{
    public class WebService<T>:IServices<T>
    {
        private IAccessor<T> _a;

        public WebService(IAccessor<T> a) 
        {
            _a = a;
        }

        public void Delete(int id)
        {
            _a.RemoveByID(id);
        }

        public T Find(int id)
        {
            T obj = _a.GetByID(id);
            return obj;
        }

        public T[] GetAll()
        {
            return _a.GetAll();
        }
    }
}
