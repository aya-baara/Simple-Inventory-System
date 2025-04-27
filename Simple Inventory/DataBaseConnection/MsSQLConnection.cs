using Microsoft.Data.SqlClient;

namespace Simple_Inventory.DataBaseConnection;

class MsSQLConnection
{
    public static string MsSqlConnectionString = "Server=DESKTOP-NKVRDQD;Database=SimpleInventory;Trusted_Connection=True;TrustServerCertificate=True;";

    public static SqlConnection GetOpenConnection()
    {
        var conn = new SqlConnection(MsSQLConnection.MsSqlConnectionString);
        conn.Open();
        return conn;
    }
}

