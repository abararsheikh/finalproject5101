using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace test
{
    public partial class Assign___Discharge__Helen : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["cs_HospitalDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(txtProdId.Text);

            string selectQuery = "Select ProductID, ProductName, UnitPrice, UnitsInStock from Products Where ProductID = @ProductId;";

            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
            da.SelectCommand.Parameters.AddWithValue("@ProductId", productId);

            DataSet ds = Cache["DataSet"] as DataSet;
            DataTable tblProducts = ds.Tables["Products"];

            if (tblProducts.Rows.Count == 1)
            {
                DataRow dr = tblProducts.Rows[0];
                dr["ProductName"] = txtProdName.Text;
                dr["UnitPrice"] = txtProdPrice.Text;
                dr["UnitsInStock"] = txtProdQuantity.Text;

                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                int rowsInserted = da.Update(ds, "Products");
                if (rowsInserted == 1)
                {
                    lblMessage.Text = "Product with ID = " + productId + "was updated in the DB";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Product with ID = " + productId + "was NOT updated in the DB";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
    }
}