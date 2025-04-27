using Simple_Inventory.Interfaces;

namespace SimpleInventory;

class Inventory
{
    private IDataBase dataBase;

    public Inventory(IDataBase dataBase)
    {
        dataBase = dataBase;
    }

    public bool AddProduct(Product product)
    {
        if (dataBase.CheckIfExist(product.ID)) return false;
        return dataBase.AddProduct(product);
    }

    public Product? SearchProduct(int id)
    {
        return dataBase.Search(id);
    }

    public bool EditProduct(Product modifiedProduct)
    {

        return dataBase.UpdateProduct(modifiedProduct);

    }

    public bool DeleteProduct(int id)
    {
        return dataBase.Delete(id);
    }

    public List<Product> GetAllProducts()
    {
        return dataBase.GetAllProducts();
    }
}


