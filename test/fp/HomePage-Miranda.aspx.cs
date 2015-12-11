using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class HomePage_Miranda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = Session["user"].ToString();
        }

        protected void btnUserAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUsers-Miranda.aspx");
        }
    }
}