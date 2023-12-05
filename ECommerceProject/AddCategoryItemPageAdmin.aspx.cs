using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ECommerceProject
{
    public partial class AddCategoryItemPageAdmin : System.Web.UI.Page
    {
        AdminCategoryPageBBL obj = new AdminCategoryPageBBL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string image = "~/Images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(image));

            int i = obj.FnAddCategory(TextBox1.Text, TextBox2.Text, image, DropDownList1.SelectedItem.Value);

            if (i != 0)
            {
                Label6.Visible = true;
                Label6.Text = "Inserted successfully";
            }
        }
    }
}