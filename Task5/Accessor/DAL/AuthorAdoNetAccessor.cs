using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Configuration;
using System.IO;

using Entities;

namespace DataAccess
{
        public class AuthorAdoNetAccessor:IAccessor<Author>
        {
            SqlCeConnectionStringBuilder cnStr=new SqlCeConnectionStringBuilder();

            public Author[] GetAll()
            {
                string sqlQuery = "SELECT * FROM author_table";

                Author[] pAr = DoSqlQuery(sqlQuery).ToArray();
                
                return pAr;
            }

            public Author GetByID(int id)
            {
                string sqlQuery = "SELECT * FROM author_table WHERE id_field=" + id;

                HashSet<Author> res = DoSqlQuery(sqlQuery);

                if (res.Count!=0)
                {
                    return res.First();
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                string sqlQuery = "DELETE FROM author_table WHERE id_field=" + id;

                using (SqlCeConnection cn=new SqlCeConnection(cnStr.ConnectionString))
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (SqlCeException ex)
                    {
                        NLogger.WriteErrorInLog(ex.Message);
                        throw ex;
                    }

                    using (SqlCeCommand cmd=new SqlCeCommand(sqlQuery,cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            HashSet<Author> DoSqlQuery(string sqlQuery)
            {
                HashSet<Author> res = new HashSet<Author>();

                using (SqlCeConnection cn = new SqlCeConnection(cnStr.ConnectionString))
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (SqlCeException ex)
                    {
                        NLogger.WriteErrorInLog(ex.Message);
                        throw ex;
                    }

                    SqlCeCommand cmd = new SqlCeCommand(sqlQuery, cn);

                    using (SqlCeDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            string name = myReader["Name"].ToString();
                            int age = (int)myReader["Age_field"];
                            int id = (int)myReader["Id_field"];

                            res.Add(new Author(name, age, id));
                        }
                    }
                }

                return res;
            }

            public AuthorAdoNetAccessor()
            {
                cnStr.ConnectionString = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            }
        }
}
