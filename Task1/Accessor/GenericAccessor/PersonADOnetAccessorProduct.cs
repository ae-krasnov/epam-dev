using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Configuration;
using System.IO;

namespace core
{
    class PersonADOnetAccessorProduct:IAccessorProduct<Person>
    {
        private class ADOnetAccessor:IAccessor<Person>
        {
            SqlCeConnectionStringBuilder cnStr=new SqlCeConnectionStringBuilder();

            public Person[] GetAll()
            {
                string sqlQuery = "SELECT * FROM table_person";

                Person[] pAr = DoSqlQuery(sqlQuery).ToArray();
                
                return pAr;
            }

            public Person GetByID(int id)
            {
                string sqlQuery = "SELECT * FROM table_person WHERE field_id="+id;

                HashSet<Person> res = DoSqlQuery(sqlQuery);

                if (res.Count!=0)
                {
                    return res.First();
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                string sqlQuery = "DELETE FROM table_person WHERE field_id="+id;

                using (SqlCeConnection cn=new SqlCeConnection(cnStr.ConnectionString))
                {
                    cn.Open();

                    using (SqlCeCommand cmd=new SqlCeCommand(sqlQuery,cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            HashSet<Person> DoSqlQuery(string sqlQuery)
            {
                HashSet<Person> res = new HashSet<Person>();

                using (SqlCeConnection cn = new SqlCeConnection(cnStr.ConnectionString))
                {
                    cn.Open();

                    SqlCeCommand cmd = new SqlCeCommand(sqlQuery, cn);

                    using (SqlCeDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            string name = myReader["field_name"].ToString();
                            int age = (int)myReader["field_age"];
                            int id = (int)myReader["field_id"];

                            res.Add(new Person(name, age, id));
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

        public IAccessor<Person> GetAccessor()
        {
            return new ADOnetAccessor();
        }
    }
}
