using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BooksGalore
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        public string UName;
        public string FName;
        public string LName;
        public string localId;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataReader sdr;
            SqlConnection conn;
            localId = "-1";

            if (Session["username"].ToString() == "admin")
                localId = AdminPortal.ID;
            else
            {
                using (conn = new SqlConnection())
                {
                    conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                    SqlCommand val = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = "SELECT CustomerID FROM Customer WHERE UserName ='" + Session["username"] + "';"
                    };
                    conn.Open();
                    sdr = val.ExecuteReader();
                    if (sdr.Read())
                        localId = sdr["CustomerID"].ToString();

                }
            } 
                
            
            conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;

            SqlCommand searchUser = new SqlCommand
            {
                CommandText = $"SELECT UserName From Customer WHERE CustomerID = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtUName.Text = sdr["UserName"].ToString();
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    throw new Exception("no read from data");
                }
            }
            else
            {
                conn.Close();
                throw new Exception("no read from data");
            }

            searchUser = new SqlCommand
            {
                CommandText = $"SELECT FName From Customer WHERE CustomerID = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtFName.Text = sdr["FName"].ToString();
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    throw new Exception("no read from data");
                }
            }
            else
            {
                conn.Close();
                throw new Exception("no read from data");
            }

            searchUser = new SqlCommand
            {
                CommandText = $"SELECT LName From Customer WHERE CustomerID = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtLName.Text = sdr["LName"].ToString();
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    throw new Exception("no read from data");
                }
            }
            else
            {
                conn.Close();
                throw new Exception("no read from data");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;

            SqlCommand updateDb = new SqlCommand
            {
                CommandText = "UPDATE Customer SET UserName = @UName, FName = @FName, LName = @LName WHERE CustomerID = @LocalId;",
                Connection = conn
            };
            updateDb.Parameters.AddWithValue("@UName", UName);
            updateDb.Parameters.AddWithValue("@FName", FName);
            updateDb.Parameters.AddWithValue("@LName", LName);
            updateDb.Parameters.AddWithValue("@LocalId", localId);
            conn.Open();
            updateDb.ExecuteNonQuery();
            Response.Redirect("AdminPortal.aspx");
        }

        protected void txtFName_TextChanged(object sender, EventArgs e)
        {
            UName = txtUName.Text;
        }

        protected void txtLName_TextChanged(object sender, EventArgs e)
        {
            FName = txtFName.Text;
        }

        protected void txtUName_TextChanged(object sender, EventArgs e)
        {
            LName = txtLName.Text;
        }
    }
}