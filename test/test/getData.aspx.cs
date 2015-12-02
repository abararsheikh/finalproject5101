using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace test
{
    public partial class getData : System.Web.UI.Page
    {

        string cs = ConfigurationManager.ConnectionStrings["cs_HospitalDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string t = Request.QueryString["t"];
            string tableName;
            
            if (t == "doctors") {
                tableName = "tblDoctors";
            }
            else
            {
                tableName = "tblPatients";
            }

            string q = "select * from " + tableName + ";";
            using (SqlConnection con = new SqlConnection(cs))
            {            
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@table", tableName);
                con.Open();
 
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //source http://www.c-sharpcorner.com/Blogs/13292/serialize-and-deserialize-objects-to-json-using-C-Sharp.aspx
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    string jsonData = JsonConvert.SerializeObject(dt);
                    DataTable dtt = (DataTable)JsonConvert.DeserializeObject(jsonData, dt.GetType());
                    Response.Write(jsonData);
                }
            }

            
        }
    }
}