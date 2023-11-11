using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerDataAccess
    {
        private string connectionString = "Server=LAB1504-02\\SQLEXPRESS;Database=tecsup;Integrated Security=True;";
        public List<Customer> ListProducts()
        {
            List<Customer> products = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("ListCustomers", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                CustomerId = Convert.ToInt32(reader["customer_id"]),
                                Name = reader["name"].ToString(),
                                Address = reader["address"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Active = Convert.ToBoolean(reader["active"])
                            };

                            products.Add(customer);
                        }
                    }
                }
            }

            return products;
        }
        public List<Customer> GetCustomers()
        {
            CustomerDataAccess productDataAccess = new CustomerDataAccess();
            return productDataAccess.ListProducts();
        }
    }
}
