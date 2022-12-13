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

    public Seat GetSeatById(int seatId)
    {
        return _sqlconnection.QuerySingle<Seat>($@"SELECT * FROM seats WHERE seats.id = '{seatId}';");
    }

    public void SeatToReservation(SeatRender seatRender)
    {
        string sql = ($@"INSERT INTO seats_to_reservations (seats_id, reservation_id, shows_dates_id) 
        VALUES ('{seatRender.SeatId}', '{seatRender.ReservationId}', '{seatRender.ShowDateId}');");

        _sqlconnection.Execute(sql);
    }
}