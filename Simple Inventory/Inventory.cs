
using Simple_Inventory.DataBaseConnection;
using Microsoft.Data.SqlClient;

namespace SimpleInventory
{
       class Inventory
       {
            private Dictionary<int, Product> products = new Dictionary<int, Product>();
            public IReadOnlyDictionary<int, Product> Products => products;

            public Inventory()
            {
                products = new Dictionary<int, Product>();
            }

            public bool AddProduct(Product product)
            {
                try
                {
                    using (var conn = new SqlConnection(MsSQLConnection.MsSqlConnectionString))
                    {
                        conn.Open();
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



            public Product? SearchProduct(int id)
                {
                    return products.GetValueOrDefault(id, null);
                }

            public bool EditProduct(Product modifiedProduct,int id)
            {
               Product product = SearchProduct(id);
                if (product != null)
                {
                    if (modifiedProduct.Name != null)
                    {
                        product.Name = modifiedProduct.Name;
                    }
                    if (modifiedProduct.Price != -1)
                    {
                        product.Price = modifiedProduct.Price;
                    }
                    if (modifiedProduct.Quantity != -1)
                    {
                        product.Quantity = modifiedProduct.Quantity;
                    }
                    return true;

                }
                return false;


            }

            public bool DeleteProduct (int id)
            {
                
                return products.Remove(id); ;
            }
        }

}
