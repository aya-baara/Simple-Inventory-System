using Microsoft.Data.SqlClient;
using Simple_Inventory.DataBaseConnection;
using Simple_Inventory.Interfaces;
using SimpleInventory;

namespace Simple_Inventory.DataBase;
public class MsSqlProductRepository : IProductRepository
{
    private SqlConnection GetOpenConnection()
    {
        var conn = new SqlConnection(MsSQLConnection.MsSqlConnectionString);
        conn.Open();
        return conn;
    }

    public bool AddProduct(Product product)
    {
        try
        {
            using (var conn = GetOpenConnection())
            {
                string sql = "INSERT INTO Products (Product_id,Name, Price, Quantity) VALUES (@Id,@Name, @Price, @Quantity)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", product.ID);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    public bool CheckIfExist(int id)
    {
        try
        {
            using (var conn =  GetOpenConnection())
            {
                string query = "SELECT COUNT(*) FROM Products WHERE Product_id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var result = cmd.ExecuteScalar();
                    return (int)result > 0;
                }
            }
        }
        catch
        {
            return false;
        }
    
    }

    public bool Delete(int id)
    {
        try
        {
            using (var conn = GetOpenConnection())
            {
                string sql = "Delete From Products Where Product_id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected ==1;
                }
            }
        }
        catch
        {
            return false;
        }
    }


    public Product? Search(int id)
    {
        try
        {
            using (var conn = GetOpenConnection())
            {
                string query = "SELECT Product_id, Name, Price, Quantity FROM Products WHERE Product_id = @Id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            return new Product
                            (
                                 reader.GetInt32(0),  //Id
                                 reader.GetString(1), // Name
                                 reader.GetInt32(2),  // Price
                                 reader.GetInt32(3)  // Quantity
                            );
                        }
                        else
                        {
                            return null; 
                        }
                    }
                }
            }
        }
        catch
        {
            return null; 
        }
    }


    public bool UpdateProduct(Product modifiedProduct)
    {
        try
        {
            using (var conn = GetOpenConnection())
            {
                List<string> fieldsToUpdate = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrEmpty(modifiedProduct.Name))
                {
                    fieldsToUpdate.Add("Name = @Name");
                    cmd.Parameters.AddWithValue("@Name", modifiedProduct.Name);
                }

                if (modifiedProduct.Price != -1)
                {
                    fieldsToUpdate.Add("Price = @Price");
                    cmd.Parameters.AddWithValue("@Price", modifiedProduct.Price);
                }

                if (modifiedProduct.Quantity != -1)
                {
                    fieldsToUpdate.Add("Quantity = @Quantity");
                    cmd.Parameters.AddWithValue("@Quantity", modifiedProduct.Quantity);
                }

                if (fieldsToUpdate.Count == 0)
                {
                    return false;
                }

                string sql = $"UPDATE Products SET {string.Join(", ", fieldsToUpdate)} WHERE Product_id = @Id";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Id", modifiedProduct.ID);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        catch
        {
            return false;
        }
    }

    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();

        try
        {
            using (var conn = GetOpenConnection())
            {
                string query = "SELECT Product_id, Name, Price, Quantity FROM Products";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product(
                                reader.GetInt32(0),  // Product_id
                                reader.GetString(1), // Name
                                reader.GetInt32(2),  // Price
                                reader.GetInt32(3)   // Quantity
                            );

                            products.Add(product);
                        }
                    }
                }
            }
        }
        catch
        {
            return null;
        }

        return products;
    }

}

