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
    public class Yi
    {
        private string _tableName;
        private string cs = ConfigurationManager.ConnectionStrings["cs_HospitalDB"].ConnectionString;
        private string _query = "select * from";

        public string TableName
        {
            set { _tableName = value; }
        }
        

        public void setQueryString()
        {
            if(_tableName == "doctors")
            {
                _query += " tblDoctors;";
            }
            else if(_tableName == "patients")
            {
                _query += " tblPatients;";
            }
            else
            {
                throw new Exception("invalid table name");
            }
        }
    
        public string getJsonData()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(_query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //source http://www.c-sharpcorner.com/Blogs/13292/serialize-and-deserialize-objects-to-json-using-C-Sharp.aspx
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    string jsonData = JsonConvert.SerializeObject(dt);
                    DataTable dtt = (DataTable)JsonConvert.DeserializeObject(jsonData, dt.GetType());
                    return jsonData;
                }
            }
        }
    }
}