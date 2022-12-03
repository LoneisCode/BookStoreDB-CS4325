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
    public partial class EditAuthor : System.Web.UI.Page
    {
        String gender;
        String FName;
        String LName;
        String DOB;

        protected void Page_Load(object sender, EventArgs e)
        {
            string localId = AdminPortal.ID;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;

            SqlCommand searchUser = new SqlCommand
            {
                CommandText = $"SELECT Gender From Author WHERE AuthorID = {localId}",
                Connection = conn
            };

            conn.Open();

            SqlDataReader sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtGender.Text = sdr["Gender"].ToString();
                    gender = txtGender.Text;
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
                CommandText = $"SELECT FName From Author WHERE AuthorID = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtFName.Text = sdr["FName"].ToString();
                    FName = txtFName.Text;
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
                CommandText = $"SELECT LName From Author WHERE AuthorID = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtLName.Text = sdr["LName"].ToString();
                    LName = txtLName.Text;
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
                CommandText = $"SELECT DOB From Author WHERE AuthorID = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtDOB.Text = sdr["DOB"].ToString();
                    DOB = txtDOB.Text;
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
                CommandText = $"UPDATE Author SET Gender = {gender}, FName = {FName}, LName = {LName}, DOB = {DOB} WHERE AuthorID = {AdminPortal.ID};",
                Connection = conn
            };
            int i = updateDb.ExecuteNonQuery();
            Response.Redirect("AdminPortal.aspx");
        }

        protected void txtGender_TextChanged(object sender, EventArgs e)
        {
            gender = txtGender.Text;
        }

        protected void txtFName_TextChanged(object sender, EventArgs e)
        {
            FName = txtFName.Text; 
        }

        protected void txtLName_TextChanged(object sender, EventArgs e)
        {
            LName = txtLName.Text;
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            DOB = txtDOB.Text; 
        }
    }
}