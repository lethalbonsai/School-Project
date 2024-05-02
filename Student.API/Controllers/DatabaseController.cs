using MySql.Data.MySqlClient;

public class DatabaseController
{
    private readonly DatabaseConnection databaseConnection;

    public DatabaseController()
    {
        string connectionString = "server=localhost; database=league_of_legends;uid=root;password=Midhi003*;";
        databaseConnection = new DatabaseConnection(connectionString);
    }

    public void GetDataFromMySQL()
    {
        MySqlConnection connection = databaseConnection.GetMySqlConnection();

        try
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM champions", connection);
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                long champid = reader.GetInt64(0);
                string FullName = reader.GetString(1);
                string Role = reader.GetString(2);
                float attackDamage = reader.GetFloat(3);
                float abilityPower = reader.GetFloat(4);
                float health = reader.GetFloat(5);
                float attackSpeed = reader.GetFloat(6);
                float mana = reader.GetFloat(7);
                float armor = reader.GetFloat(8);
                float magicResist = reader.GetFloat(9);
                float critDamage = reader.GetFloat(11);
                float movementSpeed = reader.GetFloat(12);
                float attackRange = reader.GetFloat(13);

                Console.WriteLine($"Champ ID: {champid},Name: {FullName}, Role: {Role}, AttackDamage: {attackDamage}, AbilityPower: {abilityPower}, Health: {health}, AttackSpeed: {attackSpeed}, Mana: {mana}, Armor: {armor}, MagicResist: {magicResist}, CritDamage: {critDamage}, MovementSpeed:  {movementSpeed}, AttackRange: {attackRange} ");
            }
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error " + e.Message);
        }
        finally
        {
            if(connection.State == System.Data.ConnectionState.Open)
            connection.Close();
        }
    }
}