using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;


//Miranda Gagnon worked on this page.


namespace test
{
    public partial class LogIn_page_Miranda : System.Web.UI.Page
    {
        //contected to database
        string cs = ConfigurationManager.ConnectionStrings["cs_HospitalDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //clear message label
            lblMessage.Text = "";
            //store user name as session variable tobe used on home page
            Session["user"] = txtName.Text;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //get values
            string userName = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();

            //write sql query 
            string query = "Select Username from tblUsers Where Username = @username and Password = @password;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                //command to add values and open connection
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();

                //execute command
                SqlDataReader reader = cmd.ExecuteReader();

                //check to see if user is in database
                if (reader.HasRows)
                {
                    Response.Redirect("HomePage-Miranda.aspx");
                    lblMessage.ForeColor = Color.Green;
                }
                //catch users who aren't in database
                else
                {
                    lblMessage.Text = "Login failed. Either your username or password didn't match.";
                    lblMessage.ForeColor = Color.Red;
                }
            }

        }
    }
}