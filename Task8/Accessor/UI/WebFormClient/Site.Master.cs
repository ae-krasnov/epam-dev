using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormClient
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public long GenerateTime { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateTime = Default.GenerateTime;
        }
    }
}