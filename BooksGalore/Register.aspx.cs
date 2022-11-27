using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static BooksGalore.CommonQuerys;
namespace BooksGalore
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Reg_Click(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void ValidateForm()
        {
            if (Page.IsValid)
            {
                string username = uName.Text.Trim();
                string password = passwd.Text.Trim();
                string confirmPass = passwdConfirm.Text.Trim();

                if(confirmPass == password)
                {
                    if (!UserAlreadlyExist(username))
                    {
                        //Old way of ddoing things but I came to far.
                        string hashPasswd = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                        RegisterUser(username, hashPasswd, fName.Text.Trim(), lName.Text.Trim());
                    }
                    else
                    {
                        wentWrong.Visible = true;
                        wentWrong.Text = "Registration failed...";
                    }
                }
                else
                {
                    wentWrong.Visible = true;
                    wentWrong.Text = "Passwords must match...";
                }

   
            }
        }

        private void RegisterContactInfo(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                string userId ="" ;
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                SqlCommand searchUser = new SqlCommand
                {
                    CommandText = "SELECT CustomerID FROM Customer WHERE UserName ='" + username + "'" ,
                    Connection = conn
                };

                conn.Open();

                SqlDataReader sdr = searchUser.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        userId = sdr["CustomerID"].ToString();
                    }
                }
                conn.Close();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO CContactDetails(Email, Address, Phone, CustomerID) Values('" + emailBx.Text.Trim() + "', '" + addyBx.Text.Trim() + "', '" + phoneNum.Text.Trim() +
                    "', '" + userId + "')",
                    Connection = conn
                };
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void RegisterUser(string username, string password, string fname, string lname)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO Customer(FName, LName, UserName, Password) VALUES('" + fname + "', '" + lname + "', '" + username + "', '" + password + "')",
                    Connection = conn
                };
                conn.Open();
                if(cmd.ExecuteNonQuery() == 1)
                {
                    RegisterContactInfo(username);
                    Response.Redirect("Login.aspx");
                }

                conn.Close();
            }
        }

    }
}