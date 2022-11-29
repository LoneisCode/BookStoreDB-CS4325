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
        public Cart(string ownerOfCart) {
            this.ownerOfCart = ownerOfCart;
        }
        public void AddItem(double priceOfItem)
        {
            cartValue += priceOfItem;
        }
        public double GetCartValue()
        {
            return cartValue;
        }
        public string GetOwnerOfCart()
        {
            return ownerOfCart;
        }
    }
}