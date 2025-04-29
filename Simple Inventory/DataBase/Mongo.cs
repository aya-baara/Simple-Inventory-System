using MongoDB.Driver;
using Simple_Inventory.DataBaseConnection;
using Simple_Inventory.Interfaces;
using SimpleInventory;

namespace Simple_Inventory.DataBase;

public class MongoProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _productsCollection;

    public MongoProductRepository()
    {
        var client = new MongoClient(MongoDBConnection.ConnectionString);
        var database = client.GetDatabase(MongoDBConnection.DatabaseName);
        _productsCollection = database.GetCollection<Product>(MongoDBConnection.CollectionName);
    }

    public bool AddProduct(Product product)
    {
        try
        {
            _productsCollection.InsertOne(product);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool CheckIfExist(int id)
    {
        try
        {
            var filter = Builders<Product>.Filter.Eq(p => p.ID, id);
            return _productsCollection.Find(filter).Any();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var filter = Builders<Product>.Filter.Eq(p => p.ID, id);
            var result = _productsCollection.DeleteOne(filter);
            return result.DeletedCount == 1;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public Product? Search(int id)
    {
        try
        {
            var filter = Builders<Product>.Filter.Eq(p => p.ID, id);
            return _productsCollection.Find(filter).FirstOrDefault();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public bool UpdateProduct(Product modifiedProduct)
    {
        try
        {
            var filter = Builders<Product>.Filter.Eq(p => p.ID, modifiedProduct.ID);

            var update = BuildUpdateDefinition(modifiedProduct);

            if (update == null)
            {
                return false;
            }

            var result = _productsCollection.UpdateOne(filter, update);

            return result.ModifiedCount > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    private UpdateDefinition<Product>? BuildUpdateDefinition(Product product)
    {
        var updates = new List<UpdateDefinition<Product>>();

        if (!string.IsNullOrEmpty(product.Name))
        {
            updates.Add(Builders<Product>.Update.Set(p => p.Name, product.Name));
        }

        if (product.Price != -1)
        {
            updates.Add(Builders<Product>.Update.Set(p => p.Price, product.Price));
        }

        if (product.Quantity != -1)
        {
            updates.Add(Builders<Product>.Update.Set(p => p.Quantity, product.Quantity));
        }

        return updates.Count > 0 ? Builders<Product>.Update.Combine(updates) : null;
    }

    public List<Product> GetAllProducts()
    {
        try
        {
            return _productsCollection.Find(_ => true).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}