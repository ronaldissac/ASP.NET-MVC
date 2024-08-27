using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Security.Cryptography;

namespace CustomerPortal.Models
{
    public class Customer
    {
        private readonly static string server = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }
        public int ID { get; set; }
        public string CustomerId { get; set; }
        public string CustomerPassword { get; set; }

      public List<Customer> NewCustomer()
      {

          return new List<Customer>();
      }
        public bool Validation()
        {
            try
            {
                bool IsValid = false;
                using (SqlConnection connection = new SqlConnection(server))
                {
                    SqlCommand command = new SqlCommand("ValidateCustomer", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@customerid", CustomerId);
                    command.Parameters.AddWithValue("@customerpass", CustomerPassword); 
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsValid = (bool)reader["IsValid"];
                            CustomerName = reader["CustomerName"].ToString();
                            ID =Convert.ToInt32(reader["HidID"]);
                        }
                    }
                    connection.Close();
                    return IsValid;
                }
            } 
            catch (Exception)
            {
                
                return false;
            }
       }

        public string CustomerRegister()
        {
            string query = "select CustomerId from Customer";
            try
            {
                using (SqlConnection connection = new SqlConnection(server))
                {
                    SqlCommand cmd = new SqlCommand(query,connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (CustomerId == (reader["CustomerId"].ToString()))
                        {
                            string Alert = "Customer Id is already taken Try different Id";
                            return Alert;
                        }
                    }
                    connection.Close();
                    string InsertQuery = @"INSERT INTO [dbo].[Customer]([CustomerName],[CustomerEmail],[CustomerPhone],[customerId],[CustomerPassword])VALUES(@CustomerName,@CustomerEmail,@CustomerPhone,@CustomerId,@CustomerPassword)";
                    cmd.CommandText = InsertQuery;
                    SqlCommand sqlCommand = new SqlCommand(InsertQuery,connection);
                    cmd.Parameters.AddWithValue("@CustomerName",CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerEmail",CustomerEmail);
                    cmd.Parameters.AddWithValue("@CustomerPhone",CustomerPhone);
                    cmd.Parameters.AddWithValue("@customerId",CustomerId);
                    cmd.Parameters.AddWithValue("@CustomerPassword",CustomerPassword);
                    connection.Open();
                    int x=cmd.ExecuteNonQuery();
                    connection.Close();
                    if (x == 1) return "success";
                    else return "Failed";
                }
            }
            catch(Exception ex) 
            {
                return "System Error: "+ ex.Message;
            }
        }
    }
}