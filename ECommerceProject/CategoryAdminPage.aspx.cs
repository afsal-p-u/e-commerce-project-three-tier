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
                FnDataBind();
            }
        }

        public void FnDataBind()
        {
            DataSet ds = obj.FnGetAllCategories();
            if (ds.Tables[0] != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = e.RowIndex;
            int getId = Convert.ToInt32(GridView1.DataKeys[id].Value);
            obj.FnDeleteCategory(getId);
            FnDataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FnDataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = e.RowIndex;
            int getId = Convert.ToInt32(GridView1.DataKeys[id].Value);

            TextBox txtName = (TextBox)GridView1.Rows[id].Cells[4].Controls[0];
            Label1.Text = txtName.Text;
            obj.FnUpdateCategory(getId, txtName.Text);
            GridView1.EditIndex = -1;
            FnDataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FnDataBind();
        }
    }
}