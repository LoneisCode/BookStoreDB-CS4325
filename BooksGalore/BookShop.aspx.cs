using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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
                DataTable itemData;
                itemData = PopulateBooks();
                BookCard.DataSource = itemData;
                BookCard.DataBind();
            }
        }

        public DataTable PopulateBooks()
        {
            DataTable itemData = new DataTable();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT Title, Author, Price, UserReviews, PublicationDate, CategoryDescription, ISBN FROM " +
                    "Books, BookCategories WHERE Books.CategoryCode = BooksCategories.CategoryCode",
                    Connection = conn
                };
                conn.Open();
                itemData.Load(cmd.ExecuteReader());
                conn.Close();
                return itemData;
            }
        }
    }
}