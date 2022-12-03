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
        string UserReviews;
        string PublicationDate;
        string Price;
        string Title;
        string AuthorID;
        string SID;
        string CategoryCode;

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
                    
                    txtUserReviews.Text = sdr["UserReviews"].ToString();
                    UserReviews = txtUserReviews.Text;
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
                CommandText = $"SELECT PublicationDate From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtPublicationDate.Text = sdr["PublicationDate"].ToString();
                    PublicationDate = txtPublicationDate.Text; 
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
                CommandText = $"SELECT Price From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                   
                    txtPrice.Text = sdr["Price"].ToString();
                    Price = txtPrice.Text;
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
                CommandText = $"SELECT Title From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtTitle.Text = sdr["Title"].ToString();
                    Title = txtTitle.Text;
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
                CommandText = $"SELECT AuthorID From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtAuthorID.Text = sdr["AuthorID"].ToString();
                    AuthorID = txtAuthorID.Text;
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
                CommandText = $"SELECT SID From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtSID.Text = sdr["SID"].ToString();
                    SID = txtSID.Text;
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
                CommandText = $"SELECT CategoryCode From Books WHERE ISBN = {localId}",
                Connection = conn
            };

            conn.Open();

            sdr = searchUser.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    
                    txtCategoryCode.Text = sdr["CategoryCode"].ToString();
                    CategoryCode = txtCategoryCode.Text;
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
                CommandText = $"UPDATE Books SET UserReviews = {UserReviews}, PublicationDate = {PublicationDate}, Price = {Price}, Title = {Title}, AuthorID = {AuthorID}, SID = {SID}, CategoryCode = {CategoryCode} WHERE ISBN = {AdminPortal.ID};",
                Connection = conn
            };
            int i = updateDb.ExecuteNonQuery();
            Response.Redirect("AdminPortal.aspx");
        }

        protected void txtUserReviews_TextChanged(object sender, EventArgs e)
        {
            UserReviews = txtUserReviews.Text;
        }

        protected void txtPublicationDate_TextChanged(object sender, EventArgs e)
        {
            PublicationDate = txtPublicationDate.Text;
        }

        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {
            Price = txtPrice.Text;
        }

        protected void txtTitle_TextChanged(object sender, EventArgs e)
        {
            Title = txtTitle.Text;
        }

        protected void txtAuthorID_TextChanged(object sender, EventArgs e)
        {
            AuthorID = txtAuthorID.Text;
        }

        protected void txtSID_TextChanged(object sender, EventArgs e)
        {
            SID = txtSID.Text;
        }

        protected void txtCategoryCode_TextChanged(object sender, EventArgs e)
        {
            CategoryCode = txtCategoryCode.Text;
        }
    }
}