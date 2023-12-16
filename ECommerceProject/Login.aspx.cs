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
    public partial class Login : System.Web.UI.Page
    {
        Auth obj = new Auth();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = obj.FnLoginAccount(TextBox1.Text, TextBox2.Text);

            if (s != "0")
            {
                SqlDataReader dr = obj.FnUserType(TextBox1.Text, TextBox2.Text);

                if (dr.Read() == true)
                {
                    if (dr["type"].ToString() == "user")
                    {
                        Response.Redirect("UserPage.aspx");
                    } else
                    {
                        Response.Redirect("CategoryAdminPage.aspx");
                    }
                } else
                {
                    Label4.Visible = true;
                    Label4.Text = "Data not available";
                }
            } else
            {
                Label4.Visible = true;
                Label4.Text = "Invalid username or password";
            }
        }
    }
}