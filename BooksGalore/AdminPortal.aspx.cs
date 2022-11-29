using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using static BooksGalore.CommonQuerys;

namespace BooksGalore
{
    public partial class AdminPortal : System.Web.UI.Page
    {
        public static String AdminTableStr;
        public static String IDName;
        public static int ID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["username"] != null)
                {
                    gvAdminInfo.Visible = false;
                    AdminTableStr = "";
                    IDName = "";
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

            }
        }

        void CustomerBind()
        {
            AdminTableStr = "Customer";
            IDName = "CustomerID";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;

            // 2. Create a SqlCommand object
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Customer";
            cmd.Connection = conn;

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            conn.Open();

            sda.Fill(dt);

            gvAdminInfo.DataSource = dt;
            gvAdminInfo.DataBind();
            conn.Close();
            gvAdminInfo.Visible = true;
        }

        void OrderBind()
        {
            AdminTableStr = "Order";
            IDName = "OrderID";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;

            // 2. Create a SqlCommand object
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Order";
            cmd.Connection = conn;

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            conn.Open();

            sda.Fill(dt);

            gvAdminInfo.DataSource = dt;
            gvAdminInfo.DataBind();
            conn.Close();

            gvAdminInfo.Visible = true;
        }

        void BookBind()
        {
            AdminTableStr = "Books";
            IDName = "ISBN";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;

            // 2. Create a SqlCommand object
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Books";
            cmd.Connection = conn;

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            conn.Open();

            sda.Fill(dt);

            gvAdminInfo.DataSource = dt;
            gvAdminInfo.DataBind();
            conn.Close();

            gvAdminInfo.Visible = true;
        }

        void SupplierBind()
        {
            IDName = "SID";
            AdminTableStr = "Supplier";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;

            // 2. Create a SqlCommand object
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Supplier";
            cmd.Connection = conn;

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            conn.Open();

            sda.Fill(dt);

            gvAdminInfo.DataSource = dt;
            gvAdminInfo.DataBind();
            conn.Close();

            gvAdminInfo.Visible = true;
        }

        void AuthorBind()
        {
            IDName = "AuthorID";
            AdminTableStr = "Author";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;

            // 2. Create a SqlCommand object
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Author";
            cmd.Connection = conn;

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            conn.Open();

            sda.Fill(dt);

            gvAdminInfo.DataSource = dt;
            gvAdminInfo.DataBind();
            conn.Close();

            gvAdminInfo.Visible = true;
        }

        protected void btnCustomerList_Click(object sender, EventArgs e)
        {
            CustomerBind();
        }

        protected void btnOrderList_Click(object sender, EventArgs e)
        {
            OrderBind();
        }

        protected void btnBookList_Click(object sender, EventArgs e)
        {
            BookBind();
        }

        protected void btnSupplierList_Click(object sender, EventArgs e)
        {
            SupplierBind();
        }

        protected void btnAuthorList_Click(object sender, EventArgs e)
        {
            AuthorBind();
        }

        protected void gvAdminInfo_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            //edit adn delete button functionality
            if (e.CommandName == "EditRow") // the Edit button was clicked
            {
                ID = int.Parse(e.CommandArgument.ToString());

                if (AdminTableStr == "Customers")
                    Response.Redirect("EditCustomer.aspx");
                else if (AdminTableStr == "Orders")
                    Response.Redirect("AdminPortal.aspx");
                else if (AdminTableStr == "Books")
                    Response.Redirect("EditBook.aspx");
                else if (AdminTableStr == "Suppliers")
                    Response.Redirect("AdminPortal.aspx");
                else
                    Response.Redirect("EditAuthor.aspx");

            }
            else if (e.CommandName == "DeleteRow") // the Delete button was clicked
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                    ID = int.Parse(e.CommandArgument.ToString());
                    // 2. Create a SqlCommand object
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = $"DELETE FROM {AdminTableStr} WHERE {IDName} = " + ID;
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    if (AdminTableStr == "Customer")
                        CustomerBind();
                    else if (AdminTableStr == "Order")
                        OrderBind();
                    else if (AdminTableStr == "Books")
                        BookBind();
                    else if (AdminTableStr == "Supplier")
                        SupplierBind();
                    else
                        AuthorBind();
                }

            }
        }

        protected void gvAdminInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            //edit and delete button
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button editButton = e.Row.FindControl("btnEdit") as Button;
                Button deleteButton = e.Row.FindControl("btnDelete") as Button;

                editButton.CommandArgument = e.Row.Cells[2].Text;
                deleteButton.CommandArgument = e.Row.Cells[2].Text;

            }
        }
    }
}