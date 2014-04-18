using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Reflection;

using FactoriesDAL;
using Entities;
using Services;
using System.Text;

namespace WebFormClient
{
    public partial class Default : System.Web.UI.Page
    {
        WebService<Author> AuthorClient;
        WebService<Book> BookClient;

        EntityType CurrentEntity;
        enum EntityType
        {
            Author,
            Book
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentEntity = (EntityType)Enum.Parse(typeof(EntityType), ConfigurationManager.AppSettings["EntityType"]);
            switch (CurrentEntity)
            {
                case EntityType.Author:
                    AuthorClient = new WebService<Author>(new AuthorAccessorFactory().GetAccess());
                    entityGrid.DataSource = AuthorClient.GetAll();
                    entityGrid.DataBind();
                    break;
                case EntityType.Book:
                    BookClient = new WebService<Book>(new BookAccessorFactory().GetAccess());
                    entityGrid.DataSource = BookClient.GetAll();
                    entityGrid.DataBind();
                    break;
            }
        }

        protected void FindByIdButton_Click(object sender, EventArgs e)
        {
            string foundId = Request.Form["FindByIdTextBox"];
            if (foundId.Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(foundId,@"^\d+$"))
                    Response.Write("Должно быть положительное число");
                else
                {
                    object obj = null;
                    switch (CurrentEntity)
                    {
                        case EntityType.Author:
                            obj = AuthorClient.Find(Int32.Parse(foundId.Trim()));
                            break;
                        case EntityType.Book:
                            obj = BookClient.Find(Int32.Parse(foundId.Trim()));
                            break;
                    }
                    if (obj != null)
                    {
                        PropertyInfo[] propAr = obj.GetType().GetProperties();
                        StringBuilder propInfo = new StringBuilder();

                        foreach (PropertyInfo pr in propAr)
                        {
                            propInfo.AppendFormat("{0}: {1}\n", pr.Name, pr.GetValue(obj));
                        }
                        FoundByIdLabel.Text = propInfo.ToString();
                    }
                    else
                        FoundByIdLabel.Text = "не найдено";
                }
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void DeleteByIdButton_Click(object sender, EventArgs e)
        {
            string delId = Request.Form["DelByIdTexBox"];
            if (delId.Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(delId, @"^\d+$"))
                    Response.Write("Должно быть положительное число");
                else
                {
                    switch (CurrentEntity)
                    {
                        case EntityType.Author:
                            AuthorClient.Delete(Int32.Parse(delId.Trim()));
                            entityGrid.DataSource = AuthorClient.GetAll();
                            entityGrid.DataBind();
                            break;
                        case EntityType.Book:
                            BookClient.Delete(Int32.Parse(delId.Trim()));
                            entityGrid.DataSource = BookClient.GetAll();
                            entityGrid.DataBind();
                            break;
                    }
                }
            }
        }
    }
}