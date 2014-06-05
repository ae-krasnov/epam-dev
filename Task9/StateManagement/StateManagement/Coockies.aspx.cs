using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class Coockies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["FirstVisitDate"] != null)
            {
                InfoFromCookiesLabel.Text = "Вы заходили сюда первый раз в " + Server.HtmlEncode(Request.Cookies["FirstVisitDate"].Value);
            }
            else
            {
                Response.Cookies["FirstVisitDate"].Value = DateTime.Now.ToString();
                Response.Cookies["FirstVisitDate"].Expires = DateTime.Now.AddDays(1);
                InfoFromCookiesLabel.Text = "Впервые здесь";
            }
            
        }
    }
}