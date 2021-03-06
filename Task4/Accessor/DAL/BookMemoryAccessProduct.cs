﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;

namespace FactoriesDAL
{
    class BookMemoryAccessProduct: IAccessorProduct<Book>
    {
        private class MemoryAccessor: IAccessor<Book>
        {

            public Book[] GetAll()
            {
                Book[] p = Entities.MemoryDB.Books.ToArray();
                return p;
            }

            public Book GetByID(int id)
            {
                foreach (Book p in Entities.MemoryDB.Books)
                {
                    if (p.IdBook == id)
                        return p;
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                foreach (Book p in Entities.MemoryDB.Books)
                {
                    if (p.IdBook == id)
                    {
                        Entities.MemoryDB.Books.Remove(p);
                        return;
                    }
                }
            }
        }

        public IAccessor<Book> GetAccessor()
        {
            return new MemoryAccessor();
        }
    }
}
