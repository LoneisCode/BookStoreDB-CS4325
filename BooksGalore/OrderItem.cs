using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksGalore
{
    public class OrderItem
    {
        private double price;
        private int inOrderNum;
        private string isbn;
        private string title;
        public OrderItem(string title, double price, string isbn) { 
            this.price = price;
            this.isbn = isbn;
            this.title = title;
        }

        public void SetOrderNum(int orderNum)
        {
            this.inOrderNum = orderNum;
        }

        public double GetPrice()
        {
            return price;
        }
        public string GetIsbn()
        {
            return isbn;
        }
        public string GetTitle() { 
            return title;
        }
    }
}