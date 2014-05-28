using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Configuration;

using Entities;

namespace DataAccess
{
        public class BookAdoNetAccessor:IAccessor<Book>
        {
            SqlCeConnectionStringBuilder cnStr = new SqlCeConnectionStringBuilder();

            public virtual Book[] GetAll()
            {
                string sqlQuery = "SELECT * FROM book_table";

                Book[] pAr = DoSqlQuery(sqlQuery).ToArray();

                return pAr;
            }

            public Book GetByID(int id)
            {
                string sqlQuery = "SELECT * FROM book_table WHERE bookId_field=" + id;

                HashSet<Book> res = DoSqlQuery(sqlQuery);

                if (res.Count != 0)
                {
                    return res.First();
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                string sqlQuery = "DELETE FROM book_table WHERE bookId_field=" + id;

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

                    using (SqlCeCommand cmd = new SqlCeCommand(sqlQuery, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            HashSet<Book> DoSqlQuery(string sqlQuery)
            {
                HashSet<Book> res = new HashSet<Book>();

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

                    SqlCeCommand cmnd = new SqlCeCommand(sqlQuery, cn);

                    using (SqlCeDataReader myReader = cmnd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            int AuthorID = (int)myReader["author_id_field"];
                            string Name = (string)myReader["name_field"];
                            int BookID = (int)myReader["bookId_field"];

                            res.Add(new Book(BookID,AuthorID,Name));
                        }
                    }
                }

                return res;
            }

            public BookAdoNetAccessor()
            {
                cnStr.ConnectionString = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            }
        }
}
