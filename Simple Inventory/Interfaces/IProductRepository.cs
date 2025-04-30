using SimpleInventory;

namespace Simple_Inventory.Interfaces;
public interface IProductRepository
{
    public abstract bool Add(Product product);

    public abstract bool Delete(int id);

    public abstract bool Update(Product product);

    public abstract Product? Search(int id);

    public abstract bool CheckIfExist(int id);

    public List<Product> GetAllProducts();

}
