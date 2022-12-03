using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksGalore
{
    public class OrderItem
    {
        public double price { get;}
        public string inOrderNum { get; set; }
        public static int idCount;
        public string isbn { get;}
        public string title { get;}
        public int id { get; set; }
        public OrderItem(string title, double price, string isbn) { 
            this.price = price;
            this.isbn = isbn;
            this.title = title;
            idCount += 1;
            this.id = idCount;
        }

        public void SetOrderNum(string orderNum)
        {
            this.inOrderNum = orderNum;
        }
        public string GetOrderNum()
        {
            return this.inOrderNum;
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
        public int getId()
        {
            return id;
        }
    }
}