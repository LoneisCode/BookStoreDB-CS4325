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
    public partial class EditBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int localId = AdminPortal.ID;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;

            SqlCommand searchUser = new SqlCommand
            {
                CommandText = $"SELECT UserReviews From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            SqlDataReader sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    conn.Close();
                    txtUserReviews.Text = sdr["UserReviews"].ToString();
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
                CommandText = $"SELECT PublicationDate From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    conn.Close();
                    txtPublicationDate.Text = sdr["PublicationDate"].ToString();
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
                CommandText = $"SELECT Price From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    conn.Close();
                    txtPrice.Text = sdr["Price"].ToString();
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
                CommandText = $"SELECT Title From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    conn.Close();
                    txtTitle.Text = sdr["Title"].ToString();
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
                CommandText = $"SELECT AuthorID From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    conn.Close();
                    txtAuthorID.Text = sdr["AuthorID"].ToString();
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
                CommandText = $"SELECT SID From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    conn.Close();
                    txtSID.Text = sdr["SID"].ToString();
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
                CommandText = $"SELECT CategoryCode From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    conn.Close();
                    txtCategoryCode.Text = sdr["CategoryCode"].ToString();
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
                CommandText = $"UPDATE Books SET UserReviews = {txtUserReviews.Text}, PublicationDate = {txtPublicationDate.Text}, Price = {txtPrice.Text}, Title = {txtTitle.Text}, AuthorID = {txtAuthorID.Text}, SID = {txtSID.Text}, CategoryCode = {txtCategoryCode.Text} WHERE ISBN = {AdminPortal.ID}",
                Connection = conn
            };
        }
    }
}