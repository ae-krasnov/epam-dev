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
using System.Reflection;
using core;

namespace WinFormClient
{
    public partial class MainForm : Form
    {
        bool FindIdFieldHasError=true;
        bool RemoveIdFieldHasError = true;

        WinClient<Person> personClient;
        WinClient<core.Point> pointClient;

        EntityType CurrentEntity;
        enum EntityType
        {
            person,
            point
        }

        public MainForm()
        {
            InitializeComponent();

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

            CurrentEntity = (EntityType)Enum.Parse(typeof(EntityType), ConfigurationManager.AppSettings["EntityType"]);
            switch (CurrentEntity)
            {
                case EntityType.person:
                    personClient = new WinClient<Person>(new PersonAccessorFactory().getAccess());
                    entityGridView.DataSource = personClient.getAll();
                    break;
                case EntityType.point:
                    pointClient = new WinClient<core.Point>(new PointAccessorFactory().getAccess());
                    entityGridView.DataSource = pointClient.getAll();
                    break;
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (!FindIdFieldHasError)
            {
                object obj;
                if (CurrentEntity == EntityType.person)
                {
                    obj = personClient.find(Int32.Parse(textFindId.Text.Trim()));
                }
                else
                {
                    obj = pointClient.find(Int32.Parse(textFindId.Text.Trim()));
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
                if (CurrentEntity == EntityType.person)
                {
                    personClient.delete(Int32.Parse(textRemoveId.Text));
                    entityGridView.DataSource = personClient.getAll();
                }
                else
                {
                    pointClient.delete(Int32.Parse(textRemoveId.Text));
                    entityGridView.DataSource = pointClient.getAll();
                }
            }
        }
    }
}
