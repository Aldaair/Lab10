using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;
using System.Collections;
using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace Data
{
    public class ProductDataAccess
    {
        private string connectionString = "Server=LAB1504-02\\SQLEXPRESS;Database=lab10;Integrated Security=True;";
        public List<Product> ListProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("ListProducts", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["product_id"]),
                                Name = reader["name"].ToString(),
                                Price = Convert.ToDecimal(reader["price"]),
                                Stock = Convert.ToInt32(reader["stock"]),
                                Active = Convert.ToBoolean(reader["active"])
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
        public List<Product> GetProducts()
        {
            ProductDataAccess productDataAccess = new ProductDataAccess();
            return productDataAccess.ListProducts();
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("AddProduct", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Stock", product.Stock);
                    cmd.Parameters.AddWithValue("@Active", product.Active);

                    // Ejecutar el comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("DeleteProduct", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetro
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    // Ejecutar el comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public Product GetProductById(int productId)
        {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("GetProductById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["product_id"]),
                                Name = reader["name"].ToString(),
                                Price = Convert.ToDecimal(reader["price"]),
                                Stock = Convert.ToInt32(reader["stock"]),
                                Active = Convert.ToBoolean(reader["active"])
                            };
                        }
                    }
                }
            }

            return product;
        }

    }
}
