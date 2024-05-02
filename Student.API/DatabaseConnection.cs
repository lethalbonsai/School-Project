using MySql.Data.MySqlClient;

public class DatabaseConnection
{
    private string connectionString;

    public DatabaseConnection(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public MySqlConnection GetMySqlConnection()
    {
        return new MySqlConnection(connectionString);
    }
}