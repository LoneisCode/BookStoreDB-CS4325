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
using static BooksGalore.CommonQuerys;

namespace BooksGalore
{
    public partial class BookShop : System.Web.UI.Page
    {
        DataTable itemData;
        double price;
        Cart cart;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
               
                if (!Page.IsPostBack)
                {
                    Session["UserCart"] = new Cart(Session["username"].ToString());
                    itemData = PopulateBooks();
                    BookRow.DataSource = itemData;
                    BookRow.DataBind();
                }
                BookRow.DataSource = itemData;
                cart = Session["UserCart"] as Cart;
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

        protected void BookRow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button addBtn = e.Row.FindControl("btnAdd") as Button;

            }
        }

        protected void BookRow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                string[] parms = e.CommandArgument.ToString().Split(new char[] { ',' });
                price = double.Parse(parms[1]);
                OrderItem item = new OrderItem(parms[0],price, parms[2]);
                cart.AddItem(item);
                cartValue.Text = cart.GetCartValue().ToString();
            }
        }

        protected void orderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderPage.aspx");
        }

        protected void searchBx_TextChanged(object sender, EventArgs e)
        {
            DataTable queryItems = GetSearchRequest(searchBx.Text.Trim());
            if(queryItems == null)
            {
                return;
            }
            else
            {
                itemData = queryItems;
            }
            
        }
    }
}