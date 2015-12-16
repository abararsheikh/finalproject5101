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
        // New Auth object, this will check login status, 
        // and may redirect user to login page based on the result.
        Auth u = new Auth();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Shows welcome message if user is logged in.
            if (u.isLoggedIn)
            {
                lblWelcome.Text = "Hello, " + u.userName;
                btnLogOut.Visible = Visible;
            }
            // Asks user to log in and display the message.
            else if(Request.QueryString["r"] != null)
            {
                lblRedirect.Text = "Please log in first";
            }
        }

        // Logs out user when log out button is clicked.
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            u.logOut();
        }
    }
}