using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class View_State : System.Web.UI.Page
    {
        List<string> PageList;

        List<string> CreatePageList() 
        {
            List<string> _courseItem = new List<string>();
            _courseItem.Add("C#, .Net Framework");
            _courseItem.Add("Multithreading");
            _courseItem.Add("WinForms");
            return _courseItem;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["PageList"] == null)
            {
                PageList = CreatePageList();
                ViewState["PageList"] = PageList;
            }
            StateViewGrid.DataSource = (List<string>)ViewState["PageList"];
            StateViewGrid.DataBind();
        }
    }
}