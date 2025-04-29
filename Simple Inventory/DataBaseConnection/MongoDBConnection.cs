using Microsoft.Extensions.Configuration;

namespace Simple_Inventory.DataBaseConnection;
public static class MongoDBConnection
{
    public static string ConnectionString { get; private set; }
    public static string DatabaseName { get; private set; }
    public static string CollectionName { get; private set; }

    public static void LoadConnection()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("ConnectionName.json", optional: false, reloadOnChange: true)
            .Build();

        ConnectionString = configuration["Mongo:ConnectionString"];
        DatabaseName = configuration["Mongo:DatabaseName"];
        CollectionName = configuration["Mongo:CollectionName"];
    }
}

