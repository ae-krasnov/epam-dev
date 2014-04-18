using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAccessor
{
    class PersonMemoryAccessProduct: IAccessorProduct<Person>
    {
        private class MemoryAccess: IAccessor<Person>
        {

            public Person[] GetAll()
            {
                Person[] p = MemoryDB._dbPerson.ToArray();
                return p;
            }

            public Person GetByID(int id)
            {
                foreach (Person p in MemoryDB._dbPerson)
                {
                    if (p.ID == id)
                        return p;
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                foreach (Person p in MemoryDB._dbPerson)
                {
                    if (p.ID == id)
                    {
                        MemoryDB._dbPerson.Remove(p);
                        return;
                    }
                }
            }
        }

        public IAccessor<Person> GetAccessor()
        {
            return new MemoryAccess();
        }
    }
}
