using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;

namespace test
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        //contected to database
        string cs = ConfigurationManager.ConnectionStrings["cs_HospitalDb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear message label
            lblMessage.Text = "";

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //get values
            string userId = txtId.Text.Trim();
            string userName = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (IdExists(userId))
            {
                lblMessage.Text = "UserId already exists. Please choose a different value.";
                lblMessage.ForeColor = Color.Red;
            }
            else if (UserExists(userName))
            {
                lblMessage.Text = "Username already exists. Please choose a different name.";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                if (InsertUser(userId, userName, password))
                {
                    lblMessage.Text = "User successfully added to database.";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "User was not added to database. Please try again.";
                    lblMessage.ForeColor = Color.Red;
                }
            }

        }
        private bool UserExists(string userName)
        {
            string query = "Select username from tblUsers Where userName = @Username;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", userName);
                conn.Open();

                string user = (string)cmd.ExecuteScalar();

                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        private bool IdExists(string userId)
        {
            string query = "Select Id from tblUsers Where Id = @Id;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", userId);
                conn.Open();

                int Id = Convert.ToInt32(cmd.ExecuteScalar());

                if (Id != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool InsertUser(string userid, string userName, string password)
        {

            string query = "Insert Into tblUsers(Id, username, password) Values(@Id, @Username, @Password);";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                //command to add values and open connection
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", userid);
                cmd.Parameters.AddWithValue("@Username", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();

                int rowsInserted = cmd.ExecuteNonQuery();

                if (rowsInserted == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //get values
            string userid = txtId.Text.Trim();
            string userName = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (IdNoExists(userid))
            {
                lblMessage.Text = "UserId does not exist. Please choose a different value.";
                lblMessage.ForeColor = Color.Red;
            }
            else if (UserNoExists(userName))
            {
                lblMessage.Text = "Username does not exist. Please choose a different name.";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                if (UpdateUsers(userid, userName, password))
                {
                    lblMessage.Text = "User successfully updated.";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "User was not updated. Please try again.";
                    lblMessage.ForeColor = Color.Red;
                }
            }

        }
        private bool UserNoExists(string userName)
        {
            string query = "Select username from tblUsers Where userName = @Username;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", userName);
                conn.Open();

                string user = (string)cmd.ExecuteScalar();

                if (user != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
        private bool IdNoExists(string userId)
        {
            string query = "Select Id from tblUsers Where Id = @Id;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", userId);
                conn.Open();

                int Id = Convert.ToInt32(cmd.ExecuteScalar());

                if (Id != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private bool UpdateUsers(string userid, string userName, string password)
        {
            string query = "Update tblUsers set username = @Username, password = @Password Where Id = @Id;";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", userid);
                cmd.Parameters.AddWithValue("@Username", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();

                int rowsUpdated = cmd.ExecuteNonQuery();

                if (rowsUpdated == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //get values
            string userId = txtId.Text.Trim();
            string userName = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (IdNotExists(userId))
            {
                lblMessage.Text = "UserId does not exist. Please choose a different value.";
                lblMessage.ForeColor = Color.Red;
            }
            else if (UserNotExists(userName))
            {
                lblMessage.Text = "Username does not exist. Please choose a different name.";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                if (DeleteUser(userId, userName, password))
                {
                    lblMessage.Text = "User successfully deleted from database.";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "User was not deleted from database. Please try again.";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

         private bool UserNotExists(string userName)
        {
            string query = "Select username from tblUsers Where userName = @Username;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", userName);
                conn.Open();

                string user = (string)cmd.ExecuteScalar();

                if (user != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
        private bool IdNotExists(string userId)
        {
            string query = "Select Id from tblUsers Where Id = @Id;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", userId);
                conn.Open();

                int Id = Convert.ToInt32(cmd.ExecuteScalar());

                if (Id != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        private bool DeleteUser(string userid, string userName, string password)
        {
            //write query
            string query = "Delete From tblUsers Where Id = @Id;";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", userid);
                cmd.Parameters.AddWithValue("@Username", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();

                int rowsDeleted = cmd.ExecuteNonQuery();

                if (rowsDeleted == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            }
        }
    }