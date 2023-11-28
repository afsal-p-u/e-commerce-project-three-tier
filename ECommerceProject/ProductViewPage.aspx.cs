using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Data.SqlClient;

namespace ECommerceProject
{
    public partial class ProductViewPage : System.Web.UI.Page
    {
        ProductViewPageBLL obj = new ProductViewPageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
                
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                SqlDataReader dr = obj.getSingleProduct(id);

                while (dr.Read())
                {
                    Label1.Text = dr["name"].ToString();
                    Label2.Text = dr["description"].ToString();
                    Label3.Text = dr["price"].ToString();
                    Label4.Text = dr["status"].ToString();
                }
            }
        }
    }
}