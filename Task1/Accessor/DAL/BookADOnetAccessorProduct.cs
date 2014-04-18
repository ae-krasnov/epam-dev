using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using Entities;

namespace FactoriesDAL
{
    class BookADOnetAccessorProduct: IAccessorProduct<Book>
    {
        private class ADOnetAccessor:IAccessor<Book>
        {
            SqlConnectionStringBuilder cnStr = new SqlConnectionStringBuilder();

            public Book[] GetAll()
            {
                string sqlQuery = "SELECT * FROM book_table";

                Book[] pAr = DoSqlQuery(sqlQuery).ToArray();

                return pAr;
            }

            public Book GetByID(int id)
            {
                string sqlQuery = "SELECT * FROM table_Book WHERE bookId_field=" + id;

                HashSet<Book> res = DoSqlQuery(sqlQuery);

                if (res.Count != 0)
                {
                    return res.First();
                }
                return null;
            }

            public void RemoveByID(int id)
            {
                string sqlQuery = "DELETE FROM table_Book WHERE bookId_field=" + id;

                using (SqlConnection cn = new SqlConnection(cnStr.ConnectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            HashSet<Book> DoSqlQuery(string sqlQuery)
            {
                HashSet<Book> res = new HashSet<Book>();

                using (SqlConnection cn = new SqlConnection(cnStr.ConnectionString))
                {
                    cn.Open();

                    SqlCommand cmnd = new SqlCommand(sqlQuery, cn);

                    using (SqlDataReader myReader = cmnd.ExecuteReader())
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

            public ADOnetAccessor()
            {
                cnStr.ConnectionString = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            }
        }
       
        public IAccessor<Book> GetAccessor()
        {
            return new ADOnetAccessor();
        }
    }
}
