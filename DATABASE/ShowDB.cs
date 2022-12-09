using Dapper;
using MySqlConnector;

class ShowDB
{
    MySqlConnection _sqlconnection;
    public ShowDB()
    {
        _sqlconnection = new MySqlConnection("Server = localhost;Database = test_operan;Uid=root");
    }

    public List<Show> SelectShowTitle()
    {
        var showsTitle =_sqlconnection.Query<Show>($@"SELECT shows.title FROM shows").ToList();
        return showsTitle;
    }

    public List<ShowToDates> SelectShowDate()
    {
        List<ShowToDates> listOfShows = new();
        var sql = ($@"SELECT shows.id, shows.title, shows.type, 
        show_dates.dateid, show_dates.date, show_dates.time
        FROM shows
        INNER JOIN show_dates ON shows.id = show_dates.shows_id;");

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

                ShowToDates showDates = new(id, dateId, title, type);
                showDates.DateTime(date, time);
                listOfShows.Add(showDates);
            }
            _sqlconnection.Close();
            return listOfShows;
        }
    }
}