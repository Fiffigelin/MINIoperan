using MySqlConnector;
using Dapper;
class SeatDB
{
    MySqlConnection _sqlconnection;
    public SeatDB()
    {
        _sqlconnection = new MySqlConnection("Server = localhost;Database = test_operan;Uid=root");
    }

    public List<Seat> GetAllSeats()
    {
        return _sqlconnection.Query<Seat>($@"SELECT* FROM seats WHERE seats.section = 'Parkett';").ToList();
    }
}