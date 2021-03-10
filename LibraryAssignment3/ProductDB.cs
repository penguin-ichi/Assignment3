using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAssignment3
{
    public class ProductDB
    {
        string ConnectionString = @"server=DESKTOP-DLMULPB;database=SaleDB;uid=sa;pwd=tam";

        public List<Product> GetProductList()
        {
            List<Product> listProduct = new List<Product>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQL = "select ProductID, ProductName, UnitPrice, Quantity from Products";
            SqlCommand cmd = new SqlCommand(SQL, connection);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductID = int.Parse(reader[0].ToString());
                    p.ProductName = reader[1].ToString();
                    p.UnitPrice = float.Parse(reader[2].ToString());
                    p.Quantity = int.Parse(reader[3].ToString());
                    listProduct.Add(p);
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                connection.Close();
            }
            return listProduct;
        }

        public bool AddNewProduct(Product p)
        {
            bool check;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQL = "insert Products values(@ID,@Name,@Price,@Quantity)";
            SqlCommand command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@ID", p.ProductID);
            command.Parameters.AddWithValue("@Name", p.ProductName);
            command.Parameters.AddWithValue("@Price", p.UnitPrice);
            command.Parameters.AddWithValue("@Quantity", p.Quantity);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                check = command.ExecuteNonQuery() > 0;
            }
            catch (SqlException se)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return check;
        }

        public bool RemoveProduct(Product p)
        {
            bool check;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQL = "delete from Products where ProductID=@ID";
            SqlCommand command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@ID", p.ProductID);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                check = command.ExecuteNonQuery() > 0;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return check;
        }

        public Product FindProduct(int ProductID)
        {
            Product product = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQL = "select ProductName, UnitPrice, Quantity " +
                "from Products where ProductID=@ID";
            SqlCommand command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@ID", ProductID);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    product = new Product();
                    product.ProductID = ProductID;
                    product.ProductName = reader[0].ToString();
                    product.UnitPrice = float.Parse(reader[1].ToString());
                    product.Quantity = int.Parse(reader[2].ToString());
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                connection.Close();
            }
            return product;
        }
        public bool UpdateProduct(Product p)
        {
            bool check;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQL = "update Products set ProductName=@Name,UnitPrice=@Price,Quantity=@Quantity" +
                " where ProductID=@ID";
            SqlCommand command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@ID", p.ProductID);
            command.Parameters.AddWithValue("@Name", p.ProductName);
            command.Parameters.AddWithValue("@Price", p.UnitPrice);
            command.Parameters.AddWithValue("@Quantity", p.Quantity);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                check = command.ExecuteNonQuery() > 0;
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                connection.Close();
            }
            return check;
        }
    }
}
