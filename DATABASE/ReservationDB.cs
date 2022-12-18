using Dapper;
using MySqlConnector;

class ReservationDB
{
    MySqlConnection _sqlconnection;
    public ReservationDB()
    {
        SQLConnection connection = new();
        _sqlconnection = connection.ConnectDatabase();
    }

    public Reservation InsertReservation(Reservation reservation)
    {
        string sql = ($@"INSERT INTO reservations (id, customer_id, shows_dates_id, shows_id, price) 
        VALUES ('NULL', '{reservation.CustomerId}', '{reservation.ShowDateId}', '{reservation.ShowId}', '{reservation.Price}');
        SELECT LAST_INSERT_ID();");

        reservation.Id = _sqlconnection.QuerySingle<int>(sql);
        return reservation;
    }

    public Reservation SelectSingleReservation(int id)
    {
        string sql = ($@"SELECT * FROM reservations WHERE reservations.id = '{id}';");


        Reservation reservation = new();
        _sqlconnection.Open();
        MySqlCommand cmd = new MySqlCommand(sql, _sqlconnection);
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                reservation.Id = Convert.ToInt32(reader["id"].ToString());
                reservation.CustomerId = Convert.ToInt32(reader["customer_id"].ToString());
                reservation.ShowDateId = Convert.ToInt32(reader["shows_dates_id"].ToString());
                reservation.ShowId = Convert.ToInt32(reader["shows_id"].ToString());
                reservation.Price = Convert.ToInt32(reader["price"].ToString());

            }
            _sqlconnection.Close();
            return reservation;
        }
    }

    public (List<Seat>, ShowToDates) SelectReceiptInfo(Reservation r)
    {
        List<Seat> seats = _sqlconnection.Query<Seat>($@"SELECT * FROM seats WHERE seats.id IN (SELECT seats_to_reservations.seats_id FROM seats_to_reservations WHERE seats_to_reservations.reservation_id = '{r.Id}');").ToList();

        var sql = ($@"SELECT shows.id, shows.title, shows.type, 
        show_dates.dateid, show_dates.date, show_dates.time
        FROM shows
        INNER JOIN show_dates ON shows.id = show_dates.shows_id
        INNER JOIN reservations ON show_dates.dateid = reservations.shows_dates_id
        WHERE reservations.id = '{r.Id}';");

        ShowToDates showDates = new();
        _sqlconnection.Open();
        MySqlCommand cmd = new MySqlCommand(sql, _sqlconnection);
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"].ToString());
                string title = reader["title"].ToString()!;
                string type = reader["type"].ToString()!;
                int dateId = Convert.ToInt32(reader["dateid"].ToString());
                string date = reader["date"].ToString()!;
                string time = reader["time"].ToString()!;

                showDates.ShowId = id;
                showDates.DateTimeId = dateId;
                showDates.Title = title;
                showDates.Type = type;
                showDates.DateTime(date, time);

            }
            _sqlconnection.Close();
            return (seats, showDates);

        }
    }
}