using Dapper;
using MySqlConnector;

class ReservationDB
{
    private MySqlConnection _sqlconnection;
    public ReservationDB()
    {
        Connect();
    }

    public void Connect()
    {
        _sqlconnection = new MySqlConnection("Server = localhost;Database = test_operan;Uid=root");
    }
}