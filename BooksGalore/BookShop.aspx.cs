using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksGalore
{
    public partial class BookShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["username"] != null)
                {

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

            }
        }
    }
}