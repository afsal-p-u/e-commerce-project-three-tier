using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace ECommerceProject
{
    public partial class ProductsAdminPage : System.Web.UI.Page
    {
        AdminProductsPageBLL obj = new AdminProductsPageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FnDataBind();
            }
        }

        public void FnDataBind()
        {
            DataSet ds = obj.getAllProducts();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
            Label1.Text = row.Cells[5].Text;
            Label2.Text = row.Cells[6].Text;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = e.RowIndex;
            int getId = Convert.ToInt32(GridView1.DataKeys[id].Value);

            int i = obj.deleteProduct(getId);
            FnDataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FnDataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FnDataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = e.RowIndex;
            int getId = Convert.ToInt32(GridView1.DataKeys[id].Value);
            TextBox txtName = (TextBox)GridView1.Rows[id].Cells[6].Controls[0];
            Label1.Text = txtName.Text;
            int i = obj.updateProduct(getId, txtName.Text);
            GridView1.EditIndex = -1;
            FnDataBind();
        }
    }
}