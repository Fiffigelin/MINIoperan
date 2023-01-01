using MySqlConnector;
class SQLConnection
{
    MySqlConnection _sqlconnection;
    public MySqlConnection ConnectDatabase()
    {
        _sqlconnection = new MySqlConnection("Server = localhost;Database = mini_operan;Uid=root");
        return _sqlconnection;
    }
}