using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace test
{
    public partial class Doctors_page_Bin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["cs_HospitalDb"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            int doctor_id = Convert.ToInt32(DoctorId.Text);

            string query = "Select doctor_id, first_name,last_name, speciality,phone,office,come_in_date,availability,come_out_date from tblDoctors Where doctor_id = @doctor_id;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@doctor_id", doctor_id);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DoctorId.Text = reader["doctor_id"].ToString();

                    FirstName.Text = reader["first_name"].ToString();
                    LastName.Text = reader["last_name"].ToString();
                    SpecialityId.Text = reader["speciality"].ToString();
                    PhoneNumber.Text = reader["phone"].ToString();
                    OfficeNumber.Text = reader["office"].ToString();
                    ComeInDate.Text = reader["come_in_date"].ToString();
                    AvaulabilityId.Text = reader["availability"].ToString();
                    ComeOutDate.Text = reader["come_out_date"].ToString();

                    lblMessage.Text = "DoctorId" + DoctorId.Text + " was found";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "DoctorId" + DoctorId.Text + " was not found. Please try again";
                    lblMessage.ForeColor = Color.Red;

                    FirstName.Text = "";
                    LastName.Text = "";
                    SpecialityId.Text = "";
                    PhoneNumber.Text = "";
                    OfficeNumber.Text = "";
                    ComeInDate.Text = "";
                    AvaulabilityId.Text = "";
                    ComeOutDate.Text = "";

                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int tblDoctors = Convert.ToInt32(DoctorId.Text);
            string first_name = FirstName.Text;
            string last_name = LastName.Text;
            string speciality = SpecialityId.Text;
            string phone = PhoneNumber.Text;
            int office = Convert.ToInt32(OfficeNumber.Text);
            string come_in_date = ComeInDate.Text;
            string availability = AvaulabilityId.Text;
            string come_out_date = ComeOutDate.Text;

            string query = "Update tblDoctors set first_name = @first_name, last_name = @last_name, speciality = @speciality,phone = @phone,office = @office,come_in_date = @come_in_date,availability = @availability, come_out_date = @come_out_date Where doctor_id = @tblDoctors;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tblDoctors", tblDoctors);
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@speciality", speciality);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@office", office);
                cmd.Parameters.AddWithValue("@come_in_date", come_in_date);
                cmd.Parameters.AddWithValue("@availability", availability);
                cmd.Parameters.AddWithValue("@come_out_date", come_out_date);

                conn.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();

                if (rowsUpdated == 1)
                {
                    lblMessage.Text = "DoctorId" + +tblDoctors + " was updated to the database";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "DoctorId" + +tblDoctors + " was not updated to the database";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int tblDoctors = Convert.ToInt32(DoctorId.Text);
            string first_name = FirstName.Text;
            string last_name = LastName.Text;
            string speciality = SpecialityId.Text;
            string phone = PhoneNumber.Text;
            int office = Convert.ToInt32(OfficeNumber.Text);
            string come_in_date = ComeInDate.Text;
            string availability = AvaulabilityId.Text;
            string come_out_date = ComeOutDate.Text;

            string query = "Insert into tblDoctors (doctor_id,first_name, last_name,speciality,phone,office,come_in_date,availability,come_out_date) values(@tblDoctors,@first_name, @last_name,@speciality,@phone,@office,@come_in_date,@availability,@come_out_date)";
            // string query = "Insert into tblDoctors first_name = @first_name, last_name = @last_name, speciality = @speciality,phone = @phone,office = @office,come_in_date = @come_in_date,availability = @availability, come_out_date = @come_out_date Where doctor_id = @tblDoctors;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tblDoctors", tblDoctors);

                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@speciality", speciality);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@office", office);
                cmd.Parameters.AddWithValue("@come_in_date", come_in_date);
                cmd.Parameters.AddWithValue("@availability", availability);
                cmd.Parameters.AddWithValue("@come_out_date", come_out_date);

                conn.Open();
                int rowsInsert = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (rowsInsert == 1)
                {
                    lblMessage.Text = "DoctorId" + tblDoctors + " was Inserted to the database";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "DoctorId" + tblDoctors + " was not Inserted to the database";
                    lblMessage.ForeColor = Color.Red;
                }
            }



            lblMessage.Text = "DoctorId" + tblDoctors + "Success" + "Inserted";
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int tblDoctors = Convert.ToInt32(DoctorId.Text);
            string first_name = FirstName.Text;
            string last_name = LastName.Text;
            string speciality = SpecialityId.Text;
            string phone = PhoneNumber.Text;
            int office = Convert.ToInt32(OfficeNumber.Text);
            string come_in_date = ComeInDate.Text;
            string availability = AvaulabilityId.Text;
            string come_out_date = ComeOutDate.Text;

            string query = "Delete from tblDoctors   Where doctor_id = @tblDoctors;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tblDoctors", tblDoctors);
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@speciality", speciality);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@office", office);
                cmd.Parameters.AddWithValue("@come_in_date", come_in_date);
                cmd.Parameters.AddWithValue("@availability", availability);
                cmd.Parameters.AddWithValue("@come_out_date", come_out_date);

                conn.Open();
                int rowsDelete = cmd.ExecuteNonQuery();

                if (rowsDelete == 1)
                {
                    lblMessage.Text = "DoctorId" + tblDoctors + " was updated to the database";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "DoctorId" + tblDoctors + " was not updated to the database";
                    lblMessage.ForeColor = Color.Red;
                }
            }



            lblMessage.Text = "DoctorId" + tblDoctors + "already Deleted";
        }
    }
}