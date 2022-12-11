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

    public List<Seat> AvailableSeats(int dateId)
    {
        // Gets all seats that are available
        return _sqlconnection.Query<Seat>($@"SELECT seats.id 
        FROM seats
        WHERE seats.id NOT IN 
        (select seats_to_reservations.seats_id FROM seats_to_reservations WHERE seats_to_reservations.shows_dates_id = '{dateId}')").ToList();
    }
}


// SELECT seats.id FROM seats
// UNION
// SELECT seats_to_reservations.seats_id FROM seats_to_reservations WHERE seats_to_reservations.seats_id NOT IN (SELECT seats_to_reservations.seats_id WHERE seats_to_reservations.shows_dates_id = '17');