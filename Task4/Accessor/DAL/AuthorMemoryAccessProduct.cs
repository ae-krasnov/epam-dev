using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;

namespace FactoriesDAL
{
    class AuthorMemoryAccessProduct: IAccessorProduct<Author>
    {
        private class MemoryAccess: IAccessor<Author>
        {

            public Author[] GetAll()
            {
                Author[] p = Entities.MemoryDB.Authors.ToArray();
                return p;
            }

            public Author GetByID(int id)
            {
                foreach (Author p in Entities.MemoryDB.Authors)
                {
                    if (p.ID == id)
                        return p;
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                foreach (Author p in Entities.MemoryDB.Authors)
                {
                    if (p.ID == id)
                    {
                        Entities.MemoryDB.Authors.Remove(p);
                        return;
                    }
                }
            }
        }

        public IAccessor<Author> GetAccessor()
        {
            return new MemoryAccess();
        }
    }
}
