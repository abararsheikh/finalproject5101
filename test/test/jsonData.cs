/**
* Author: Yi Zhao
*
*/
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
    /// <summary>
    /// Contains methods needed to get data in Json format
    /// </summary>
    public class jsonData
    {
        /// <summary> Stores table name </summary>
        private string _tableName;

        /// <summary>
        /// Connection string that is used to connect to hospital database.
        /// </summary>
        private string _cs = ConfigurationManager.ConnectionStrings["cs_HospitalDB"].ConnectionString;

        /// <summary>
        /// SQL command, table name will be added to be end later.
        /// </summary>
        private string _query = "select * from";

        /// <summary>
        /// TableName constructor, can only set _tableName.
        /// </summary>
        public string TableName
        {
            set { _tableName = value; }
        }

        /// <summary>
        /// Appends table name to the end of Sql command, and 
        /// only take either "doctors" or "patients" as table name
        /// </summary>
        /// <exception> Thrown when table name does not match </exception>
        public void setQueryString()
        {
            if (_tableName == "doctors")
            {
                _query += " tblDoctors;";
            }
            else if (_tableName == "patients")
            {
                _query += " tblPatients;";
            }
            else
            {
                throw new Exception("invalid table name");
            }
        }

        /// <summary>
        /// Connects to database, and executes sql command.
        /// Then it loads data in SqlDataReader to a new DataTable, and
        /// uses Json.net to convert data to Json format so that data can be used 
        /// in front-end.
        /// </summary>
        /// <returns>String of query result in Json format</returns>
        public string getJsonData()
        {
            using (SqlConnection con = new SqlConnection(_cs))
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
}