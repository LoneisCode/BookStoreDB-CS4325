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

namespace BooksGalore.Style
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Log_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                LoginProcess();
            }
        }

        private void LoginProcess()
        {
            string username = uName.Text.Trim();
            string password = passwd.Text.Trim();
            if (UserAlreadlyExist(username))
            {
                if(Validate(username, password))
                {
                    Session["username"] = username;
                    if(username == "Admin")
                    {
                        Response.Redirect("AdminPortal.aspx");
                    }
                    else
                    {
                        Response.Redirect("BookShop.aspx");
                    }
                }
                else
                {
                    wentWrong.Visible = true;
                    wentWrong.Text = "Login failed try checking creds";
                }

            }
        }
        private bool Validate(string user,  string passwd)
        {
            string givenpasswd = FormsAuthentication.HashPasswordForStoringInConfigFile(passwd,"SHA1");
            using(SqlConnection conn= new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                SqlCommand val = new SqlCommand()
                {
                    Connection = conn,
                    CommandText = "SELECT Password FROM Customer WHERE UserName ='" + user + "'"
                };
                conn.Open();
                SqlDataReader sdr = val.ExecuteReader();
                if (sdr.Read())
                {
                    if (sdr["Password"].ToString()  == givenpasswd)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }
    }
}