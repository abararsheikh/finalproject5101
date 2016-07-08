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
        // we create a variable to store info that shows Application where to find the connection string in Web.config file
        string cs = ConfigurationManager.ConnectionStrings["cs_HospitalDb"].ConnectionString;

        // creating variable to manage checking of existance of patient
        bool check = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        // following code will be executed when the button with id btnAssign will be clicked
        protected void btnAssign_Click(object sender, EventArgs e)
        {
            // getting info from user and outting it to the varibles, so we can work with this info
            string ohip = txtPatOHIP.Text.Trim(); // patient OHIP nimber
            string docname = txtDocName.Text.Trim(); // name of the doctor
            string docSurname = txtDocSurname.Text.Trim(); // surname of the doctor


            // checking if patient with such an OHIP number exists in our DB using predefined below function created by Helen Boitsova
            if (IsParientExists(ohip)) 
               
            {   
                // telling user that he got the right OHIP number
                lblMessage.Text = "This patient exists.";
                lblMessage.ForeColor = Color.Green;
                
                // getting dcotor_id using predefined below function created by Helen Boitsova
                int doctorNum = GetDoctorId(docname, docSurname);
               
                // continuing to check. Now we are checking if the doctor exists in our DB using doctor_id gonnen above and predefined below function created by Helen Boitsova
                if (IsDoctorExists(doctorNum))
                {  
                    // telling user that he got the right info about doctor
                    lblMessage2.Text = "This doctor exists.";
                    lblMessage2.ForeColor = Color.Green;
                    
                    // if all checking is complete assigning patient to the doctor using predefined below function created by Helen Boitsova and CHECKED data
                    if (Assign(ohip, doctorNum))
                    { 
                        //inform user that everything id OK and he made changes to the DB
                        lblAssign.Text = "Doctor has been assigned to patient! Thank you for your transaction. HAVE A NICE DAY!";
                        lblAssign.ForeColor = Color.Green;
                    }
                    else
                    { 
                        // if smth happened and SQL query was not executed, or returned that no rows was affected, then user will see this message
                        lblAssign.Text = "Unfortunately your transaction could not be approved. Contact your programmer for help. ";
                        lblAssign.ForeColor = Color.Red;
                    }

                }
                else
                {    
                    // if user entered not right info about the doctor, then user will see this message
                    lblMessage2.Text = "Please make sure you added all info about doctor correctly";
                    lblMessage2.ForeColor = Color.Red;
                }



            }
            else
            {   
                // if user entered wrong OHIP number, then user will see this message
                lblMessage.Text = "Please make sure you added OHIP number correctly";
                lblMessage.ForeColor = Color.Red;
            }

        }


        // this button is udes to check the existance of the patient in the DB using predefined below function created by Helen Boitsova
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string ohip = txtOhip.Text.Trim();
            
            if (IsParientExists(ohip))
            {
                lblCheck.Text = "This patient exists.";
                lblCheck.ForeColor = Color.Green;
                
                // this is usage of the variable to commit the checking of the existance
                check = true;
                
                // we store this checking variable into the Session variable to not lose it's state when clicking the next button used for discharge
                Session["check"] = true;
            }
            else
            {   
                // if user not exists, we show this message to the user and make cheking variable - false, and store it is Session variable
                lblCheck.Text = "Please make sure you added OHIP number correctly";
                lblCheck.ForeColor = Color.Red;
                check = false;
                Session["check"] = false;
            }


        }
        // this bunnon is used for discharging patient from the hospital
        protected void btnDischarge_Click(object sender, EventArgs e)
        {      
            // we check the checking variable. If patient exists therefore variable is true we continue. If not - we don't do anything
            if ((bool)Session["check"] == true)
            {    
                // getting info from user and outting it to the varibles, so we can work with this info
                string date = txtDate.Text.Trim();
                string ohip = txtOhip.Text.Trim();
                
                // we store an SQL query into variable, to use it easily. Note the usage of SQL Parameters to avoid SQL Injection
                string query = "Update tblPatients set date_out = @Date   where OHIP = @Ohip;";
                
                // creating an object of class ConnectionString to connect DB and Application
                // word using helps us to close connection automatically when the code is executed or when we got any problems with the DB.
                using (SqlConnection conn = new SqlConnection(cs))
                {   // creating an object of class SqlCommand to have an opportunity to execute stored query in variable query using a connection between DB and Application
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // defining SQL Parameters, and assigning info gotten from the user to those Parameters
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Ohip", ohip);

                    // opening a connection to make changes to the DB
                    conn.Open();

                    //executing the query and storing info gotten from it into variable
                    int rowsUpdated = cmd.ExecuteNonQuery();

                    // checking if any row was updated
                    if (rowsUpdated == 1)
                    {
                        // if yes, User will see the following message
                        lblDisharge.Text = "Patient has been discharged from hospital successfully. Thank you for your transaction. HAVE A NICE DAY!";
                        lblDisharge.ForeColor = Color.Green;
                    }
                    else
                    {   // if NO, User will see the following message
                        lblDisharge.Text = "Unfortunately your transaction could not be approved. Contact your programmer for help.";
                        lblDisharge.ForeColor = Color.Red;
                    }

                }
            }
        }



        
        // funtion for cheking the patient existance
        private bool IsParientExists(string ohip)
        {
            // working with DB has the same steps, so there is no need to explain them all
            string selectQuery = "Select count(OHIP) from tblPatients Where OHIP = @PatNum;";
            int patientSum = 0;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@PatNum", ohip);
                conn.Open();
                // we use method ExecuteScalar when we are working with Select statement
                patientSum = (int)cmd.ExecuteScalar();
            }
            // if patient exists function will return true
            if (patientSum == 1) { return true; }
            // if NOT - false
            else { return false; }
        }


        // funtion for cheking the doctor existance
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

        // but to use the ABOVE function we need doctor_id from the DB, but user is ready to provide us only Doctor Name and Doctor Surname, so next will be function to get the doctor_id when you have only Name and Surname
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


        // function with query that assignes patient to the doctor
        private bool Assign(string ohip, int docnum)
        {
            string selectQuery = "Update tblPatients SET doctor_id = @DocId where OHIP = @PatNumber";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@PatNumber", ohip);
                cmd.Parameters.AddWithValue("@DocId", docnum);

                conn.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();

                if (rowsUpdated == 1) { return true; }
                else { return false; }
            }
        }


        // function to use calendar and get info from it to the specified textbox
        protected void DischargeCalendar_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = DischargeCalendar.SelectedDate.ToString();
        }
    }
}