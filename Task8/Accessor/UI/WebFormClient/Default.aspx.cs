using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Reflection;

using DataAccess;
using Entities;
using Services;
using System.Text;

namespace WebFormClient
{
    public partial class Default : System.Web.UI.Page
    {
        Service<Author> authorService;
        Service<Book> bookService;

        bool IsUseCaptcha;

        public static long GenerateTime { get; set; }

        EntityType CurrentEntity;
        enum EntityType
        {
            author,
            book
        }

        protected Default()
        {
        }

        public Default(object commonServer) 
        {
            if (commonServer is Service<Author>)
            {
                authorService = (Service<Author>)commonServer;
                CurrentEntity = EntityType.author;
            }
            else
            {
                bookService = (Service<Book>)commonServer;
                CurrentEntity = EntityType.book;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IsUseCaptcha = Boolean.Parse(ConfigurationManager.AppSettings["IsUseCaptcha"]);

            switch (CurrentEntity)
            {
                case EntityType.author:
                    entityGrid.DataSource = authorService.GetAll();
                    entityGrid.DataBind();
                    break;
                case EntityType.book:
                    entityGrid.DataSource = bookService.GetAll();
                    entityGrid.DataBind();
                    break;
            }
        }

        protected void FindByIdButton_Click(object sender, EventArgs e)
        {
            string foundId = FindByIdTextBox.Text;
            if (foundId.Length > 0)
            {
                ErrorFindLabel.Text = "";
                if (!System.Text.RegularExpressions.Regex.IsMatch(foundId,@"^\d+$"))
                   ErrorFindLabel.Text="Должно быть положительное число";
                else
                {
                    object obj = null;
                    switch (CurrentEntity)
                    {
                        case EntityType.author:
                            obj = authorService.Find(Int32.Parse(foundId.Trim()));
                            break;
                        case EntityType.book:
                            obj = bookService.Find(Int32.Parse(foundId.Trim()));
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

        public void SetVerificationText()
        {
            Random ran = new Random();
            int no = ran.Next();
            Session["Captcha"] = no.ToString();
        }

        protected void CAPTCHAValidate(object source, ServerValidateEventArgs args)
        {
            if (Session["Captcha"] != null)
            {
                if (UserCaptchaInputTextBox.Text != Session["Captcha"].ToString())
                {
                    SetVerificationText();
                    args.IsValid = false;
                    return;

                }

            }
            else
            {
                SetVerificationText();
                args.IsValid = false;
                return;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void DeleteByIdButton_Click(object sender, EventArgs e)
        {
            ErrorRemoveLabel.Text = "";
            string delId = DelByIdTexBox.Text;
            if (delId.Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(delId, @"^\d+$"))
                    ErrorRemoveLabel.Text = "Должно быть положительное число";
                else
                {
                    if (!IsUseCaptcha)
                    {
                        RemoveRecord(delId);
                    }
                    else
                    {
                        SetVerificationText();
                        CaptchaPanel.Visible = true;
                    }
                }
            }
        }

        protected void ApplyCaptchaButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CaptchaPanel.Visible = false;
                UserCaptchaInputTextBox.Text = "";
                if (!System.Text.RegularExpressions.Regex.IsMatch(DelByIdTexBox.Text, @"^\d+$"))
                    ErrorRemoveLabel.Text = "Должно быть положительное число";
                else
                    RemoveRecord(DelByIdTexBox.Text);
            }
        }

        private void RemoveRecord(string delId)
        {
            switch (CurrentEntity)
            {
                case EntityType.author:
                    authorService.Delete(Int32.Parse(delId.Trim()));
                    entityGrid.DataSource = authorService.GetAll();
                    entityGrid.DataBind();
                    break;
                case EntityType.book:
                    bookService.Delete(Int32.Parse(delId.Trim()));
                    entityGrid.DataSource = bookService.GetAll();
                    entityGrid.DataBind();
                    break;
            }
        }
    }
}