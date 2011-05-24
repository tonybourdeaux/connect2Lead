using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Connect2Leads.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            TextBox TextBox1 = (TextBox)LoginUser.FindControl("UserName");
            TextBox TextBox2 = (TextBox)LoginUser.FindControl("Password");
            //bool foundUser = false;

            string theResult = "";
            //if( Membership.Providers[theCallCenterConnectString].ValidateUser(TextBox1.Text, TextBox2.Text))
            //{ foundUser = true; }
            
            biz.virtualacd.www.SystemUserGatewayService theProxy=new biz.virtualacd.www.SystemUserGatewayService();

            try
            {
                theResult = theProxy.getSystemUserAccounts(TextBox1.Text, TextBox2.Text);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(theResult);
                Session["theAccounts"] = doc;
                e.Authenticated = true;
            }

            catch
            {
                e.Authenticated = false;
            }
            
            

            
        }
    }
}