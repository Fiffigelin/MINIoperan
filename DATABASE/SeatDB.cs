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

    public List<Seat> BookedSeats()
    {
        return _sqlconnection.Query<Seat>($@"SELECT * FROM seats WHERE seats.id IN 
        (SELECT reservations.shows_id FROM reservations WHERE reservations.shows_dates_id = '17')
        UNION
        SELECT * FROM seats WHERE seats.id NOT IN (SELECT seats_to_reservations.seats_id FROM seats_to_reservations)
        ORDER BY id ASC;").ToList();
    }
}