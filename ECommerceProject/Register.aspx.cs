using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ECommerceProject
{
    public partial class Register : System.Web.UI.Page
    {
        Auth obj = new Auth();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = obj.registerAcoount(TextBox1.Text, TextBox2.Text, TextBox6.Text, Convert.ToInt32(TextBox5.Text), TextBox4.Text, TextBox3.Text);

            if (i != 0)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Label8.Visible = true;
                Label8.Text = "Registration failed due to some error.";
            }
        }
    }
}