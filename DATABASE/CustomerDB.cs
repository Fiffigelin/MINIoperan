using Dapper;
using MySqlConnector;

class CustomerDB
{
    private MySqlConnection _sqlconnection;
    public CustomerDB()
    {
        Connect();
    }

    public void Connect()
    {
        _sqlconnection = new MySqlConnection("Server = localhost;Database = mini;Uid=root");
    }
}