using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Connect2Leads
{
    public partial class Connect2Lead : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.IsNewSession)
            {
                //remove authentication cookie
                FormsAuthentication.SignOut();
                Response.Redirect("~/Account/Login.aspx");


            }
        }
    }
}