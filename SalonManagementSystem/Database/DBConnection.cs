using MySql.Data.MySqlClient;

public class DBConnection
{
    public static MySqlConnection GetConnection()
    {
        string connStr = "server=localhost;user=root;password=Urwaabid935.;database=salon_db;";
        return new MySqlConnection(connStr);
    }
}