using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAccessor
{
    class PointMemoryAccessProduct: IAccessorProduct<Point>
    {
        private class MemoryAccessor: IAccessor<Point>
        {

            public Point[] GetAll()
            {
                Point[] p = MemoryDB._dbPoint.ToArray();
                return p;
            }

            public Point GetByID(int id)
            {
                foreach (Point p in MemoryDB._dbPoint)
                {
                    if (p.ID == id)
                        return p;
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                foreach (Point p in MemoryDB._dbPoint)
                {
                    if (p.ID == id)
                    {
                        MemoryDB._dbPoint.Remove(p);
                        return;
                    }
                }
            }
        }

        public IAccessor<Point> GetAccessor()
        {
            return new MemoryAccessor();
        }
    }
}
