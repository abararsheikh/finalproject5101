/**
* Author: Yi Zhao
*
* Description: This is an empty page only responses to certain query strings.
* Purpose: Returns data that will be used in search page.
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
    public partial class getData : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            jsonData json = new jsonData();
            json.TableName = Request.QueryString["t"];
           
            try
            {
                json.setQueryString();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

            Response.Write(json.getJsonData());
        }
    }
}