using MySqlConnector;
using Dapper;
class SeatDB
{
    MySqlConnection _sqlconnection;
    public SeatDB()
    {
        SQLConnection connection = new();
        _sqlconnection = connection.ConnectDatabase();
    }

    public List<Seat> SelectAllSeats()
    {
        return _sqlconnection.Query<Seat>($@"SELECT* FROM seats WHERE seats.section = 'Parkett';").ToList();
    }

    public List<Seat> SelectAvailableSeats(int dateId)
    {
        // Gets all seats that are available
        return _sqlconnection.Query<Seat>($@"SELECT seats.id 
        FROM seats
        WHERE seats.id NOT IN 
        (select seats_to_reservations.seats_id FROM seats_to_reservations WHERE seats_to_reservations.shows_dates_id = '{dateId}')").ToList();
    }

    public Seat SelectSeatById(int seatId)
    {
        return _sqlconnection.QuerySingle<Seat>($@"SELECT * FROM seats WHERE seats.id = '{seatId}';");
    }

    public void InsertSeatToReservation(SeatRender seatRender)
    {
        string sql = ($@"INSERT INTO seats_to_reservations (seats_id, reservation_id, shows_dates_id) 
        VALUES ('{seatRender.SeatId}', '{seatRender.ReservationId}', '{seatRender.ShowDateId}');");

        _sqlconnection.Execute(sql);
    }
}