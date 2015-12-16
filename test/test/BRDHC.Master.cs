using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class BRDHC : System.Web.UI.MasterPage
    {
        Auth u = new Auth();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (u.isLoggedIn)
            {
                lblWelcome.Text = "Hello, " + u.userName;
                btnLogOut.Visible = Visible;
            }
            else if(Request.QueryString["r"] != null)
            {
                lblRedirect.Text = "Please log in first";
            }
            
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            u.logOut();
        }
    }
}