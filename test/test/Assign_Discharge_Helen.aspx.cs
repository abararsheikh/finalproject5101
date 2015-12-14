using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace test
{
    public partial class Assign___Discharge__Helen : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["cs_HospitalDb"].ConnectionString;
        bool check = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            string ohip = txtPatOHIP.Text.Trim();
            string docname = txtDocName.Text.Trim();
            string docSurname = txtDocSurname.Text.Trim();

            if (IsParientExists(ohip))
            {
                lblMessage.Text = "This patient exists.";
                lblMessage.ForeColor = Color.Green;

                int doctorNum = GetDoctorId(docname, docSurname);

                if (IsDoctorExists(doctorNum))
                {
                    lblMessage2.Text = "This doctor exists.";
                    lblMessage2.ForeColor = Color.Green;

                    if (Assign(ohip, doctorNum))
                    {
                        lblMessage3.Text = "Doctor has been assigned to patient! Thank you for your transaction. HAVE A NICE DAY!";
                        lblMessage3.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblMessage3.Text = "Unfortunately your transaction could not be approved. Contact your programmer for help. ";
                        lblMessage3.ForeColor = Color.Red;
                    }

                }
                else
                {
                    lblMessage2.Text = "Please make sure you added all info about doctor correctly";
                    lblMessage2.ForeColor = Color.Red;
                }



            }
            else
            {
                lblMessage.Text = "Please make sure you added OHIP number correctly";
                lblMessage.ForeColor = Color.Red;
            }

        }



        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string ohip = txtOhip.Text.Trim();
            
            if (IsParientExists(ohip))
            {
                lblCheck.Text = "This patient exists.";
                lblCheck.ForeColor = Color.Green;
                check = true;
                Session["check"] = true;
            }
            else
            {
                lblCheck.Text = "Please make sure you added OHIP number correctly";
                lblCheck.ForeColor = Color.Red;
                check = false;
                Session["check"] = false;
            }


        }

        protected void btnDischarge_Click(object sender, EventArgs e)
        {
            if ((bool)Session["check"] == true)
            {
                string date = txtDate.Text.Trim();
                string ohip = txtOhip.Text.Trim();

                string query = "Update tblPatients set date_out = @Date   where OHIP = @Ohip;";

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Ohip", ohip);

                    conn.Open();

                    int rowsUpdated = cmd.ExecuteNonQuery();

                    if (rowsUpdated == 1)
                    {
                        lblMessage.Text = "Patient has been discharged from hospital successfully. Thank you for your transaction. HAVE A NICE DAY!";
                        lblMessage.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Unfortunately your transaction could not be approved. Contact your programmer for help.";
                        lblMessage.ForeColor = Color.Red;
                    }

                }
            }
        }



        // создание отдельной функции -проверки на существование пациента

        private bool IsParientExists(string ohip)
        {

            string selectQuery = "Select count(OHIP) from tblPatients Where OHIP = @PatNum;";
            int patientSum = 0;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@PatNum", ohip);
                conn.Open();

                patientSum = (int)cmd.ExecuteScalar();
            }

            if (patientSum == 1) { return true; }
            else { return false; }
        }


        // создание отдельной функции -проверки на существование doctor

        private bool IsDoctorExists(int doctorNum)
        {

            string selectQuery = "Select count(doctor_id) from tblDoctors Where doctor_id = @DocId;";
            int docSum = 0;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@DocId", doctorNum);
                conn.Open();

                docSum = (int)cmd.ExecuteScalar();
            }

            if (docSum == 1) { return true; }
            else { return false; }
        }

        // создание отдельной функции - получения id доктора
        int doc_id;
        private int GetDoctorId(string doctorname, string doctorSurname)
        {

            string selectQuery = "Select doctor_id from tblDoctors Where first_name = @FirstName and last_name = @LastName;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@FirstName", doctorname);
                cmd.Parameters.AddWithValue("@LastName", doctorSurname);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        doc_id = reader.GetInt32(0);
                    }
                }
                else
                {
                    doc_id = 0;
                }
                reader.Close();

            }
            return doc_id;
        }


        // создание отдельной функции - привязки доктора к пациенту
        private bool Assign(string ohip, int docnum)
        {
            string selectQuery = "Update tblPatients SET doctor_id = @DocId where OHIP = @PatNumber";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@PatNumber", ohip);
                cmd.Parameters.AddWithValue("@DocId", docnum);

                conn.Open();
                int rowsInserted = cmd.ExecuteNonQuery();

                if (rowsInserted == 1) { return true; }
                else { return false; }
            }
        }

        protected void DischargeCalendar_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = DischargeCalendar.SelectedDate.ToString();
        }
    }
}