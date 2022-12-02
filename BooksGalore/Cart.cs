using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksGalore
{
    public class Cart
    {
        private double cartValue = 0;
        private string ownerOfCart = "";
        public List<OrderItem> cartItems = new List<OrderItem>();
        public Cart(string ownerOfCart) {
            this.ownerOfCart = ownerOfCart;
            this.cartValue= 0;
        }
        public void AddItem(OrderItem item)
        {
            this.cartValue += item.GetPrice();
            this.cartItems.Add(item);
        }
        public double GetCartValue()
        {
            return this.cartValue ;
        }
        public string GetOwnerOfCart()
        {
            return this.ownerOfCart;
        }
        public void RemoveItem(OrderItem item)
        {
            this.cartItems.Remove(item);
        }
        public List<OrderItem> GetOrderItems()
        {
            return this.cartItems;
        }
    }
}