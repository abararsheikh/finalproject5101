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
            
            Yi yi = new Yi();
            yi.TableName = Request.QueryString["t"];

            try
            {
                yi.setQueryString();
                Response.Write(yi.getJsonData());
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

            

            
        }
    }
}