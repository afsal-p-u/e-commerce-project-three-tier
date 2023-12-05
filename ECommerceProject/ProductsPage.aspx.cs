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
	public partial class ProductsPage : System.Web.UI.Page
	{
		ProductsPageBLL obj = new ProductsPageBLL();

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                DataSet ds = obj.getCategoryProducts(id);

                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int itemIndex = e.Item.ItemIndex;
            Label lbl = DataList1.Items[itemIndex].FindControl("label5") as Label;
            Response.Redirect("ProductViewPage.aspx?id=" + lbl.Text + "");
        }
    }
}