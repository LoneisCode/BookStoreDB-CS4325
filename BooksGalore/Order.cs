using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static BooksGalore.CommonQuerys;
namespace BooksGalore
{
    public class Order
    {
        private string OwnerID { get; set; }
        private string Date { get; set; }
        private List<OrderItem> orderItems;
        private double ValueOrder { get; set; }
        public Order(string username) { 
            this.OwnerID= GetUserID(username);
            this.orderItems = new List<OrderItem>();
            this.Date= DateTime.Now.ToString();
        }
        public void AddOrderItem(OrderItem item)
        {
            orderItems.Add(item);
            ValueOrder += item.GetPrice();
        }
        public void PutInRecords(Order order)
        {
            string orderID = SQLPlaceOrder(order);
            foreach(OrderItem item in orderItems)
            {
                item.SetOrderNum(orderID);
                SQLPlaceOrderItem(item);
            }
        }
        public List<OrderItem> GetOrderItems() { 
            return orderItems;
        }
        public string GetDate()
        {
            return Date;
        }
        public string GetOwnerId() 
        { 
            return OwnerID; 
        }
        public double GetValueOrder() 
        { 
            return ValueOrder; 
        }
    }
}