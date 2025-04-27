using Microsoft.Data.SqlClient;
using SimpleInventory;

namespace Simple_Inventory.Interfaces;
public interface IDataBase
{
    public abstract bool AddProduct(Product product);

    public abstract bool Delete(int id);

    public abstract bool UpdateProduct(Product product);

    public abstract Product? Search(int id);

    public abstract bool CheckIfExist(int id);

    public List<Product> GetAllProducts();

}
