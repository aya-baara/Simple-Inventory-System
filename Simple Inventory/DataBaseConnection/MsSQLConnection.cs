using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Simple_Inventory.DataBaseConnection;

class MsSQLConnection
{
    public static string MsSqlConnectionString { get; private set; }

    public static void LoadConnection()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("ConnectionName.json", optional: false, reloadOnChange: true)
            .Build();

        MsSqlConnectionString = configuration["SQL:MsSqlConnectionString"];
    }


}

