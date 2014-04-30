using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using Microsoft.Practices.Unity;
using System.Reflection;

using DataAccess;
using Services;
using Entities;

namespace WinFormClient
{
    public partial class MainForm : Form
    {
        bool FindIdFieldHasError=true;
        bool RemoveIdFieldHasError = true;
        object CommonService;
        IUnityContainer Container=new UnityContainer();

        public MainForm()
        {
            InitializeComponent();
            Container.RegisterType(typeof(IServices<>), typeof(Service<>));
            radioAuthor.CheckedChanged += radioButtons_CheckedChanged;
            radioBook.CheckedChanged += radioButtons_CheckedChanged;
            radioADONet.CheckedChanged += radioButtons_CheckedChanged;
            radioFile.CheckedChanged += radioButtons_CheckedChanged;
            radioMemory.CheckedChanged += radioButtons_CheckedChanged;
            radioMyORM.CheckedChanged += radioButtons_CheckedChanged;
            radioAuthor.Checked = true;
            textFindId.Validated += (sender, e) => 
            {
                if (textFindId.Text.Length > 0)
                {
                    try
                    {
                        Int32.Parse(textFindId.Text.Trim());
                        errorId.SetError(this.textFindId, String.Empty);
                        FindIdFieldHasError = false;
                    }
                    catch (FormatException)
                    {
                        errorId.SetError(this.textFindId, "должны быть только числа");
                        FindIdFieldHasError = true;
                    }
                }
            };
            textFindId.TextChanged += (sender, e) => 
            {
                errorId.Clear();
            };
            textRemoveId.Validated += (sender, e) =>
            {
                if (textRemoveId.Text.Length > 0)
                {
                    try
                    {
                        Int32.Parse(textRemoveId.Text.Trim());
                        errorId.SetError(this.textRemoveId, String.Empty);
                        RemoveIdFieldHasError = false;
                    }
                    catch (FormatException)
                    {
                        errorId.SetError(this.textRemoveId, "должны быть только числа");
                        RemoveIdFieldHasError = true;
                    }
                }
            };
            textRemoveId.TextChanged += (sender, e) =>
            {
                errorId.Clear();
            };
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (!FindIdFieldHasError)
            {
                object obj;
                if (CommonService is IServices<Author>)
                {
                    var authorService = (IServices<Author>)CommonService;
                    obj = authorService.Find(Int32.Parse(textFindId.Text.Trim()));
                }
                else
                {
                    var bookService = (IServices<Book>)CommonService;
                    obj = bookService.Find(Int32.Parse(textFindId.Text.Trim()));
                }
                if (obj != null)
                {
                    PropertyInfo[] propAr = obj.GetType().GetProperties();
                    StringBuilder propInfo = new StringBuilder();

                    foreach (PropertyInfo pr in propAr)
                    {
                        propInfo.AppendFormat("{0}: {1}\n", pr.Name, pr.GetValue(obj));
                    }
                    MessageBox.Show(propInfo.ToString());
                }
                else
                    MessageBox.Show("не найдено");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!RemoveIdFieldHasError)
            {
                if (CommonService is IServices<Author>)
                {
                    var authorServices = (IServices<Author>)CommonService;
                    authorServices.Delete(Int32.Parse(textRemoveId.Text));
                    entityGridView.DataSource = authorServices.GetAll();
                }
                else
                {
                    var bookServices = (IServices<Book>)CommonService;
                    bookServices.Delete(Int32.Parse(textRemoveId.Text));
                    entityGridView.DataSource = bookServices.GetAll();
                }
            }
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAuthor.Checked)
            {
                registerAuthorDAL();
                CommonService = Container.Resolve<IServices<Author>>();
                var authorService = (IServices<Author>)CommonService;
                entityGridView.DataSource = authorService.GetAll();
            }
            else
            {
                registerBookDAL();
                CommonService = Container.Resolve<IServices<Book>>();
                var bookService = (IServices<Book>)CommonService;
                entityGridView.DataSource = bookService.GetAll();
            }
        }

        private void registerAuthorDAL() 
        {
            if (radioMyORM.Checked)
            {
                Container.RegisterType(typeof(IAccessor<>), typeof(MyORM<Author>));
            }
            else if (radioFile.Checked)
            {
                Container.RegisterType(typeof(IAccessor<>),typeof(AuthorFileAccessor));
            }
            else if (radioMemory.Checked)
            {
                Container.RegisterType(typeof(IAccessor<>), typeof(AuthorMemoryAccess));
            }
            else if (radioADONet.Checked)
            {
                Container.RegisterType(typeof(IAccessor<>), typeof(AuthorAdoNetAccessor));
            }
        }
        private void registerBookDAL() 
        {
            if (radioMyORM.Checked)
            {
                Container.RegisterType(typeof(IAccessor<>), typeof(MyORM<Book>));
            }
            else if (radioFile.Checked)
            {
                Container.RegisterType(typeof(IAccessor<>), typeof(BookFileAccessor));
            }
            else if (radioMemory.Checked)
            {
                Container.RegisterType(typeof(IAccessor<>), typeof(BookMemoryAccessor));
            }
            else if (radioADONet.Checked)
            {
                Container.RegisterType(typeof(IAccessor<>), typeof(BookAdoNetAccessor));
            }
        }
    }
}
