using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksGalore.Style
{
    public partial class OrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
            order.PutInRecords();
            Response.Redirect("BookShop.aspx");
        }
    }
}