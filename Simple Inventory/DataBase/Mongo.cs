using MongoDB.Driver;
using Simple_Inventory.DataBaseConnection;
using Simple_Inventory.Interfaces;
using SimpleInventory;

namespace Simple_Inventory.DataBase;

class MongoDb : IDataBase
{
    private readonly IMongoCollection<Product> _productsCollection;

    public MongoDb()
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
        catch
        {
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
        catch
        {
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
        catch
        {
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
        catch
        {
            return null;
        }
    }

    public bool UpdateProduct(Product modifiedProduct)
    {
        try
        {
            var filter = Builders<Product>.Filter.Eq(p => p.ID, modifiedProduct.ID);

            var updates = new List<UpdateDefinition<Product>>();

            if (!string.IsNullOrEmpty(modifiedProduct.Name))
            {
                updates.Add(Builders<Product>.Update.Set(p => p.Name, modifiedProduct.Name));
            }

            if (modifiedProduct.Price != -1)
            {
                updates.Add(Builders<Product>.Update.Set(p => p.Price, modifiedProduct.Price));
            }

            if (modifiedProduct.Quantity != -1)
            {
                updates.Add(Builders<Product>.Update.Set(p => p.Quantity, modifiedProduct.Quantity));
            }

            if (updates.Count == 0)
            {
                return false; 
            }

            var update = Builders<Product>.Update.Combine(updates);

            var result = _productsCollection.UpdateOne(filter, update);

            return result.ModifiedCount > 0;
        }
        catch
        {
            return false;
        }
    }


    public List<Product> GetAllProducts()
    {
        try
        {
            return _productsCollection.Find(_ => true).ToList();
        }
        catch
        {
            return null;
        }
    }
}