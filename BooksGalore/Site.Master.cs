using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksGalore
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                signoutBtn.Visible = true;
                orderBtn.Visible = true;
            }
            else
            {
                signoutBtn.Visible = false;
                orderBtn.Visible = false;
            }
        }

        protected void signout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void Order_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderPage.aspx");
        }
    }
}