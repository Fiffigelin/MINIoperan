using MySqlConnector;
class SQLConnection
{
    MySqlConnection _sqlconnection;
    public SQLConnection()
    {
        _sqlconnection = new MySqlConnection("Server = localhost;Database = test_operan;Uid=root");
    }
}