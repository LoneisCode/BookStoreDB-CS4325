using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using static BooksGalore.CommonQuerys;

namespace BooksGalore
{
    public partial class SiteMaster : MasterPage
    {
        public string ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                signoutBtn.Visible = true;
                editProfile.Visible = true;
            }
            else
            {
                signoutBtn.Visible = false;
                editProfile.Visible = false;
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

        protected void editProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCustomer.aspx");
        }
    }
}