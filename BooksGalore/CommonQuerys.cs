using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace BooksGalore
{
    public static class CommonQuerys
    {
        public static bool UserAlreadlyExist(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT * FROM Customer WHERE Username = '" + username + "'",
                    Connection = conn
                };
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                //if username has been used for registration 
                if (sdr.HasRows)
                {
                    conn.Close();
                    return true;
                }
                else

                {
                    conn.Close();
                    return false;
                }

            }
        }

        public static string GetUserID(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                SqlCommand searchUser = new SqlCommand
                {
                    CommandText = "SELECT CustomerID FROM Customer WHERE UserName ='" + username + "'",
                    Connection = conn
                };

                conn.Open();

                SqlDataReader sdr = searchUser.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        
                        return sdr["CustomerID"].ToString();
                        
                    }
                    else
                    {
                        conn.Close();
                        throw new Exception("no read from data");
                    }
                }
                else
                {
                    conn.Close();
                    throw new Exception("no read from data");
                }
                
            }
        }

        public static string SQLPlaceOrder(Order order) 
        {
            string customerID = order.GetOwnerId();
            double val = order.GetValueOrder();
            string date = order.GetDate();

            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                SqlCommand placeO = new SqlCommand
                {
                    CommandText = $"INSERT INTO [Order](OrderDate, OrderValue, CustomerID) Values('{date}',{val},{customerID});" +
                    $" SELECT SCOPE_IDENTITY();",
                    Connection = conn
                };
                conn.Open();

                

                return placeO.ExecuteScalar().ToString();

            }

        }
        public static void SQLPlaceOrderItem(OrderItem oItem)
        {
            double val = oItem.GetPrice();
            string isbn = oItem.GetIsbn();
            string oID = oItem.GetOrderNum();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["BooksGaloreConnStr"].ConnectionString;
                SqlCommand placeO = new SqlCommand
                {
                    CommandText = $"INSERT INTO OrderItem(ItemPrice, OrderID, ISBN) Values({val}, {oID}, {isbn});" +
                    $" SELECT SCOPE_IDENTITY()",
                    Connection = conn
                };
                conn.Open();
                placeO.ExecuteNonQuery();
                conn.Close();
            }
        }

    }

}