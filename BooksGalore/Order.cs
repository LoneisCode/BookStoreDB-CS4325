using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static BooksGalore.CommonQuerys;
namespace BooksGalore
{
    public class Order
    {
        private string ownerID;
        private List<OrderItem> orderItems;
        public Order(string username) { 
            ownerID= GetUserID(username);
        }
        public void AddOrderItem(OrderItem item)
        {
            orderItems.Add(item);
        }
        public void PutInRecords()
        {

        }
        public void DeleteInRecords()
        {

        }
        public List<OrderItem> GetOrderItems() { 
            return orderItems;
        }
    }
}