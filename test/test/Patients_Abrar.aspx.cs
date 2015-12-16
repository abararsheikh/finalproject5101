using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;

namespace test
{
    public partial class Patients_page_Abrar : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["cs_HospitalDb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            // this code for to load the dropdown list from table and display

            //string query = "Select department from tblpatients ; ";

            //using (SqlConnection conn = new SqlConnection(cs))
            //{
            //    DataTable dtTable = new DataTable();
            //    SqlCommand cmd = new SqlCommand(query, conn);

            //    conn.Open();

            //    SqlDataReader reader = cmd.ExecuteReader();
            //    dtTable.Load(reader);
            //    reader.Close();
            //    ddlDepartment.DataSource = dtTable;
            //    ddlDepartment.DataValueField = "department";
            //    ddlDepartment.DataTextField = "department";

            //    ddlDepartment.DataBind();

            //}
        }



        protected void btnLoad_Click(object sender, EventArgs e)
        {
            string patientId = Convert.ToString(txtPatientId.Text);

            string query = "Select * from tblpatients Where OHIP = @PatientId  ; ";

            //string query = "Select OHIP,first_name,last_name,phone,date_in,department from tblpatients Where OHIP = @PatientId  ; ";
            //this query for databind

            using (SqlConnection conn = new SqlConnection(cs))  //create sql connection
            {
                SqlCommand cmd = new SqlCommand(query, conn);   //create sqlcommand
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                conn.Open();  // open connection

                SqlDataReader reader = cmd.ExecuteReader(); // SqlDataReader is return type of ExecuteReader
                //we need object of this class that can fetch the data from the database server.

                if (reader.Read())
                {
                    txtFirstName.Text = reader["first_name"].ToString();
                    txtLastName.Text = reader["last_name"].ToString();
                    txtPhone.Text = reader["phone"].ToString();
                    txtDateIn.Text = reader["date_in"].ToString();

                    //ddlDepartment.SelectedItem.Text = reader["department"].ToString();
                    txtDepartment.Text = reader["department"].ToString();
                    lblMessage.Text = "Patient with ID = " + patientId + " was found";
                    lblMessage.ForeColor = Color.Green;

                }
                else
                {
                    lblMessage.Text = "Patient with ID = " + patientId + " was not found. Please try again";
                    lblMessage.ForeColor = Color.Red;

                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtPhone.Text = "";
                    txtDateIn.Text = "";
                    txtDepartment.Text = "";
                    //ddlDepartment.SelectedIndex = -1;
                    lblMessage2.Text = "";
                }
            }
        }

        protected void txtInsert_Click(object sender, EventArgs e)
        {
            string patientId = Convert.ToString(txtPatientId.Text);
            string FirstName = txtFirstName.Text.Trim();
            string LastName = txtLastName.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            //DateTime Date_In = Convert.ToDateTime(txtDateIn.Text.Trim());

            string Department = txtDepartment.Text.Trim();

            string Date_In = Convert.ToString(txtDateIn.Text.Trim());

            //DateTime Date_Out = Convert.ToDateTime(txtDateOut.Text.Trim());
            //string Department = ddlDepartment.SelectedItem.Text;


            string query = "Insert Into tblPatients(OHIP,first_name,last_name,phone,date_in,department)values(@patientId,@FirstName,@LastName,@Phone,@Date_In,@Department);";
            //string query1 = "select department from tblPatients ;";

            using (SqlConnection conn = new SqlConnection(cs)) //create sql connection
            {
                SqlCommand cmd = new SqlCommand(query, conn);  //create sqlcommand

                cmd.Parameters.AddWithValue("@patientId", patientId);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Date_In", Date_In);
                //cmd.Parameters.AddWithValue("@Date_Out", Date_Out);
                cmd.Parameters.AddWithValue("@Department", Department);

                //SqlCommand cmd1 = new SqlCommand(query1, conn);
                //cmd1.Parameters.AddWithValue("@Department", Department);
                //DataTable dtTable = new DataTable();


                conn.Open();

                int rowsInserted = cmd.ExecuteNonQuery();

                if (rowsInserted == 1)
                {
                    lblMessage.Text = "Patient with ID = " + patientId + " was inserted to the database";
                    lblMessage.ForeColor = Color.Green;
                    txtPatientId.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtPhone.Text = "";
                    txtDateIn.Text = "";
                    lblMessage2.Text = "";
                    //ddlDepartment.SelectedItem.Text = "";
                    txtDepartment.Text = "";
                }
                else
                {
                    lblMessage.Text = "Patient with ID = " + patientId + " was not inserted to the database";
                    lblMessage.ForeColor = Color.Red;
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtPhone.Text = "";
                    txtDateIn.Text = "";
                    lblMessage2.Text = "";
                    txtDepartment.Text = "";
                    //ddlDepartment.SelectedIndex = -1;

                }
                //SqlDataReader reader1 = cmd1.ExecuteReader();
                //dtTable.Load(reader1);
                //reader1.Close();
                //ddlDepartment.DataSource = dtTable;
                //ddlDepartment.DataTextField = "department";
                //ddlDepartment.DataValueField = "department";
                //ddlDepartment.DataBind();
                //ddlDepartment.Items.Insert(0, new ListItem("--Select Department--"));
                //conn.Close();

            }

        }


        protected void txtUpdate_Click(object sender, EventArgs e)
        {
            if (txtPatientId.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtPhone.Text != "" && txtDateIn.Text != "" && txtDepartment.Text != "")
            {
                string patientId = Convert.ToString(txtPatientId.Text);
                string FirstName = txtFirstName.Text.Trim();
                string LastName = txtLastName.Text.Trim();
                string Phone = txtPhone.Text.Trim();
                string Date_In = Convert.ToString(txtDateIn.Text.Trim());

                string Department = txtDepartment.Text.Trim();
                //string Department = ddlDepartment.SelectedItem.Text;


                string query = "Update tblPatients set first_name = @FirstName,last_name = @LastName,phone = @Phone,date_in = @Date_In,department = @Department Where OHIP = @patientId ;";
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Date_In", Date_In);
                    //cmd.Parameters.AddWithValue("@Date_Out", Date_Out);
                    cmd.Parameters.AddWithValue("@Department", Department);

                    conn.Open();

                    int rowsUpdated = cmd.ExecuteNonQuery();

                    if (rowsUpdated == 1)
                    {
                        lblMessage.Text = "Patient with ID = " + patientId + " was updated to the database";
                        lblMessage.ForeColor = Color.Green;
                        txtPatientId.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtPhone.Text = "";
                        txtDateIn.Text = "";
                        txtDepartment.Text = "";
                        //ddlDepartment.SelectedItem.Text = "";

                    }
                    else
                    {
                        lblMessage.Text = "Patient with ID = " + patientId + " was not updated to the database";
                        lblMessage.ForeColor = Color.Red;
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtPhone.Text = "";
                        txtDateIn.Text = "";
                        txtDepartment.Text = "";
                        //ddlDepartment.SelectedIndex = -1;
                    }


                }
            }
            else
            {
                lblMessage.Text = "Please fill all required fields";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void txtDelete_Click(object sender, EventArgs e)
        {
            if (txtPatientId.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtPhone.Text != "" && txtDateIn.Text != "" && txtDepartment.Text != "")
            {
                string patientId = Convert.ToString(txtPatientId.Text);
                string FirstName = txtFirstName.Text.Trim();
                string LastName = txtLastName.Text.Trim();
                string Phone = txtPhone.Text.Trim();
                string Date_In = Convert.ToString(txtDateIn.Text.Trim());

                string Department = txtDepartment.Text.Trim();

                //string Department = ddlDepartment.SelectedItem.Text;

                string query = "Delete from tblPatients Where OHIP = @patientId and first_name = @FirstName and last_name = @LastName and phone = @Phone and date_in = @Date_In and department = @Department ;";
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Date_In", Date_In);
                    //cmd.Parameters.AddWithValue("@Date_Out", Date_Out);
                    cmd.Parameters.AddWithValue("@Department", Department);

                    conn.Open();

                    int rowsDeleted = cmd.ExecuteNonQuery();

                    if (rowsDeleted == 1)
                    {
                        lblMessage.Text = "Patient with ID = " + patientId + " was deleted from the database";
                        lblMessage.ForeColor = Color.Green;
                        txtPatientId.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtPhone.Text = "";
                        txtDateIn.Text = "";
                        txtDepartment.Text = "";
                        //ddlDepartment.SelectedItem.Text = "";
                        lblMessage2.Text = "";
                    }
                    else
                    {
                        lblMessage.Text = "Patient with ID = " + patientId + " was not deleted from the database";
                        lblMessage.ForeColor = Color.Red;
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtPhone.Text = "";
                        txtDateIn.Text = "";
                        lblMessage2.Text = "";
                        txtDepartment.Text = "";
                        //ddlDepartment.SelectedIndex = -1;
                    }


                }
            }
            else
            {
                lblMessage.Text = "Please Fill all required fill";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            string query = "Select * from tblPatients";



            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();  //open the connection 

            SqlDataReader reader = cmd.ExecuteReader(); // SqlDataReader is return type of ExecuteReader
                                                        //we need object of this class that can fetch the data from the database server.

            GridView1.DataSource = reader;
            GridView1.DataBind();

            conn.Close(); //close the connection 
            lblMessage.Text = "";

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtPatientId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtDateIn.Text = "";
            txtDepartment.Text = "";

            //ddlDepartment.SelectedIndex = -1;
            //ddlDepartment.SelectedIndex = ddlDepartment.Items.IndexOf(ddlDepartment.Items.FindByValue("Select"));
            //ddlDepartment.ClearSelection();
        }


    }

}