using DataGridView.DAL.Helpers;
using DataGridView.DAL.Interfaces;
using DataGridView.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.DAL.Repositories
{
    public class ProductRepository : IProduct
    {
        public void Create(Product product)
        {
            var connection = new DbConnectionHelper().Connection;
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "insert into Products values(@ProductName,@Price)";

            command.Parameters.AddWithValue("@ProductName", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
      


            connection.Open();
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }

        public void Delete(Product product)
        {
            var connection = new DbConnectionHelper().Connection;
            List<Product> products = new List<Product>();


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText=@"delete from Products where Id=@p1";
            command.Parameters.AddWithValue("@p1", product.Id);
            connection.Open();            
            var returnValue = command.ExecuteNonQuery();
           
            command.Parameters.Clear();
            connection.Close();

            
        }

        public List<Product> GetProduct()
        {

            var connection = new DbConnectionHelper().Connection;
            List<Product> products = new List<Product>();


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText = @"select * from Products";

            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var product = new Product();
                product.Id = reader.GetInt32(0);
                product.Name = reader.GetString(1); 
                product.Price = reader.GetInt32(2); 
               

                products.Add(product);
            }
            reader.Close();
            connection.Close();


            return products;
        }

        public void Update(Product product)
        {
            var connection = new DbConnectionHelper().Connection;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText = @"UPDATE Products SET ProductName=@ProductName, Price=@Price WHERE Id=@Id";
            command.Parameters.AddWithValue("@Id", product.Id);
            command.Parameters.AddWithValue("@ProductName", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
