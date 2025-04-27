using Microsoft.Data.SqlClient;
using Simple_Inventory.DataBaseConnection;
using Simple_Inventory.Interfaces;
using SimpleInventory;

namespace Simple_Inventory.DataBase;
class MsSql : IDataBase
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


    public bool updateProduct()
    {
        throw new NotImplementedException();
    }


}

