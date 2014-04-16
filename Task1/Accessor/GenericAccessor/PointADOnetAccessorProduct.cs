using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace core
{
    class PointADOnetAccessorProduct: IAccessorProduct<Point>
    {
        private class ADOnetAccessor:IAccessor<Point>
        {
            SqlConnectionStringBuilder cnStr = new SqlConnectionStringBuilder();

            public Point[] GetAll()
            {
                string sqlQuery = "SELECT * FROM table_point";

                Point[] pAr = DoSqlQuery(sqlQuery).ToArray();

                return pAr;
            }

            public Point GetByID(int id)
            {
                string sqlQuery = "SELECT * FROM table_point WHERE field_id=" + id;

                HashSet<Point> res = DoSqlQuery(sqlQuery);

                if (res.Count != 0)
                {
                    return res.First();
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                string sqlQuery = "DELETE FROM table_point WHERE field_id=" + id;

                using (SqlConnection cn = new SqlConnection(cnStr.ConnectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            HashSet<Point> DoSqlQuery(string sqlQuery)
            {
                HashSet<Point> res = new HashSet<Point>();

                using (SqlConnection cn = new SqlConnection(cnStr.ConnectionString))
                {
                    cn.Open();

                    SqlCommand cmnd = new SqlCommand(sqlQuery, cn);

                    using (SqlDataReader myReader = cmnd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            int X = (int)myReader["field_X"];
                            int Y = (int)myReader["field_Y"];
                            int id = (int)myReader["field_id"];

                            res.Add(new Point(X, Y, id));
                        }
                    }
                }

                return res;
            }

            public ADOnetAccessor()
            {
                cnStr.ConnectionString = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            }
        }
       
        public IAccessor<Point> GetAccessor()
        {
            return new ADOnetAccessor();
        }
    }
}
