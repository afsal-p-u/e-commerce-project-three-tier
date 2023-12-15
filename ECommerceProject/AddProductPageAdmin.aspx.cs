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
    public partial class AddProductPageAdmin : System.Web.UI.Page
    {
        AdminCategoryPageBBL obj = new AdminCategoryPageBBL();
        AdminProductsPageBLL obj2 = new AdminProductsPageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = obj.FnGetCategories();
                DropDownList2.DataSource = ds;
                DropDownList2.DataTextField = "name";
                DropDownList2.DataValueField = "id";
                DropDownList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string image = "~/Images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(image));

            int i = obj2.FnAddProduct(Convert.ToInt32(DropDownList2.SelectedItem.Value), TextBox1.Text, TextBox2.Text, image, Convert.ToInt32(TextBox3.Text), DropDownList1.SelectedItem.Value);

            if (i != 0)
            {
                Label7.Visible = true;
                Label7.Text = "Success";
            }
        }
    }
}