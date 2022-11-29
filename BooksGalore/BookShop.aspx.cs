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
            string cmdStr = "SELECT Books.Title, Author.FName, Author.LName, Books.Price, Books.UserReviews, Books.PublicationDate, BookCategories.CategoryDescription, Books.ISBN FROM " +
                    "Books INNER JOIN BookCategories ON Books.CategoryCode = BookCategories.CategoryCode INNER JOIN Author ON Books.AuthorID = " +
                    "Author.AuthorID";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand(cmdStr,conn))
                {
                    conn.Open();
                    itemData.Load(cmd.ExecuteReader());
                };

            }
           return itemData;
        }

        protected void addCartBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Added"); 
        }
    }
}