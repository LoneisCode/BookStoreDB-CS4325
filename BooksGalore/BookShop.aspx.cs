using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BooksGalore
{
    public partial class BookShop : System.Web.UI.Page
    {
        Cart cart;
        DataTable itemData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (!Page.IsPostBack)
                {
                    itemData = PopulateBooks();
                    BookCard.DataSource = itemData;
                    BookCard.DataBind();
                    cart = new Cart(Session["username"].ToString());
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
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
            foreach(RepeaterItem item in BookCard.Items) {
                var price = (Label)item.FindControl("Content");
                string valtext = price.Text;
                double itemValue = double.Parse(valtext);
                cart.AddItem(itemValue);
                cartValue.Text = (cart.GetCartValue()).ToString();
            }
        }

        //protected void Search_TextChanged(object sender, EventArgs e)
        //{
        //    DataTable itemData = new DataTable();
        //    string cmdStr = "SELECT Books.Title, Author.FName, Author.LName, Books.Price, Books.UserReviews, Books.PublicationDate, BookCategories.CategoryDescription, Books.ISBN FROM " +
        //            "Books INNER JOIN BookCategories ON Books.CategoryCode = BookCategories.CategoryCode INNER JOIN Author ON Books.AuthorID = " +
        //            "Author.AuthorID " +
        //            "WHERE Books.Title = '"+ SearchBx.Text.Trim() +"'";
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
        //        using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
        //        {
        //            conn.Open();
        //            itemData.Load(cmd.ExecuteReader());
        //        };

        //    }
        //    BookCard.DataSource = itemData;
        //    BookCard.DataBind();
        //}
    }
}