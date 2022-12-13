using Dapper;
using MySqlConnector;

class ReservationDB
{
    MySqlConnection _sqlconnection;
    public ReservationDB()
    {
        _sqlconnection = new MySqlConnection("Server = localhost;Database = test_operan;Uid=root");
    }

    public Reservation InsertReservation(Reservation reservation)
    {
        string sql = ($@"INSERT INTO reservations (id, customer_id, shows_dates_id, shows_id, price) 
        VALUES ('NULL', '{reservation.CustomerId}', '{reservation.ShowDateId}', '{reservation.ShowId}', '{reservation.Price}');
        SELECT LAST_INSERT_ID();");

        reservation.Id = _sqlconnection.QuerySingle<int>(sql);
        return reservation;
    }
}