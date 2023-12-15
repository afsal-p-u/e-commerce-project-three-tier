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
    public partial class UserPage : System.Web.UI.Page
    {
        UserPageBLL obj = new UserPageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = obj.getItems();

                if (ds.Tables[0] != null)
                {
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                } else
                {
                    Label1.Text = "No categories available";
                }
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int itemIndex = e.Item.ItemIndex;
            Label lbl = DataList1.Items[itemIndex].FindControl("label3") as Label;
            Response.Redirect("ProductsPage.aspx?id=" + lbl.Text + "");
        }
    }
}