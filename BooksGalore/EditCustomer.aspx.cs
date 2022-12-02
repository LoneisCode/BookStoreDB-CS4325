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
        protected void Page_Load(object sender, EventArgs e)
        {
            int localId = AdminPortal.ID;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;

            SqlCommand searchUser = new SqlCommand
            {
                CommandText = $"SELECT UserName From Customer WHERE CustomerID = {localId}",
                Connection = conn
            };

            conn.Open();

            SqlDataReader sdr = searchUser.ExecuteReader();
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
                CommandText = $"UPDATE Customer SET username = {txtUName.Text}, FName = {txtFName.Text}, LName = {txtLName.Text} WHERE CustomerID = {AdminPortal.ID};",
                Connection = conn
            };
            Response.Redirect("AdminPortal.aspx");
        }
    }
}