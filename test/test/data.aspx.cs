using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class data : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["cs_HospitalDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.ContentType = "application/json";

            string q = "select * from tblDoctors";
            string output;


            using (SqlConnection con = new SqlConnection(cs))
            {
                /*
                SqlCommand cmd = new SqlCommand(q, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Response.Write(reader[0].ToString());
                }
                */
                SqlCommand cmd = new SqlCommand(q, con);
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDa.Fill(dt);
                    string test = JsonConvert.SerializeObject(dt); // Serialization
                                                                   //JsonConvert.DeserializeObject(test);
                    DataTable dtt = (DataTable)JsonConvert.DeserializeObject(test, dt.GetType());
                    output = test;
                }

            }
            Response.Write(output);
        }
    }
}