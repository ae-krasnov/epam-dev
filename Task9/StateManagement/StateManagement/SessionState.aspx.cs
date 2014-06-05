﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class SessionState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionLabel.Text = "Сессия началась в " + Session["StartTime"] + " ID: " + Session.SessionID;
        }
    }
}