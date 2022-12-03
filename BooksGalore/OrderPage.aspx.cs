using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace BooksGalore.Style
{
    public partial class OrderPage : System.Web.UI.Page
    {
        Cart currCart;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (!Page.IsPostBack)
                {
                    currCart = Session["UserCart"] as Cart;
                    List<OrderItem> items = currCart.GetOrderItems();
                    CartItemRow.DataSource = items ;
                    CartItemRow.DataBind();
                }
                currCart = Session["UserCart"] as Cart;
                
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void PlaceOrder(object sender, EventArgs e)
        {
            Order order = new Order(Session["username"].ToString());
            Cart curCart = Session["UserCart"] as Cart;
            List<OrderItem> items = curCart.GetOrderItems();
            foreach(OrderItem i in items)
            {
                order.AddOrderItem(i);
            }
            order.PutInRecords(order);
            Response.Redirect("BookShop.aspx");
        }

        protected void CartItemRow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dtlItem")
            {
                int idOfItem = int.Parse(e.CommandArgument.ToString());
                currCart.RemoveItem(idOfItem);
                CartItemRow.DataSource = currCart.GetOrderItems();
                CartItemRow.DataBind();
            }
        }

        protected void CartItemRow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button delBtn = e.Row.FindControl("dtlItem") as Button;
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookShop.aspx");
        }
    }
}