using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class HiddenField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void SendToHideFieldButton_Click(object sender, EventArgs e)
        {
            HiddenField1.Value = HideFieldTextBox.Text;
            FromHideFieldLabel.Text = HiddenField1.Value;
        }
    }
}