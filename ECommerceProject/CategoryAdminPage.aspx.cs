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
    public partial class CategoryAdminPage : System.Web.UI.Page
    {
        AdminCategoryPageBBL obj = new AdminCategoryPageBBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = obj.FnGetAllCategories();
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
}