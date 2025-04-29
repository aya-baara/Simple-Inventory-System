using Simple_Inventory.Interfaces;

namespace SimpleInventory;

class Inventory
{
    private IProductRepository DataBase;

    public Inventory(IProductRepository dataBase)
    {
        DataBase = dataBase;
    }

    public bool AddProduct(Product product)
    {
        return (DataBase.CheckIfExist(product.ID)) ? true : false;
    }

    public Product? SearchProduct(int id)
    {
        return DataBase.Search(id);
    }

    public bool EditProduct(Product modifiedProduct)
    {

        return DataBase.Update(modifiedProduct);

    }

    public bool DeleteProduct(int id)
    {
        return DataBase.Delete(id);
    }

    public List<Product> GetAllProducts()
    {
        return DataBase.GetAllProducts();
    }
}


