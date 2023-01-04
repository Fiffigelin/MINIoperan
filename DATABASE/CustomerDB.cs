using Dapper;
using MySqlConnector;

class CustomerDB
{
    public List<Customer> custList = new();
    MySqlConnection _sqlconnection;
    public CustomerDB()
    {
        SQLConnection connection = new();
        _sqlconnection = connection.ConnectDatabase();
    }

    public Customer SelectCustomerByEmail(Customer customer)
    {
        string sql = $"SELECT * FROM customers WHERE customers.email = '{customer.Email}'";
        _sqlconnection.Open();

        MySqlCommand cmd = new MySqlCommand(sql, _sqlconnection);
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                customer = new();
                customer.Id = Convert.ToInt32(reader["id"].ToString());
                customer.FirstName = reader["first_name"].ToString();
                customer.LastName = reader["last_name"].ToString();
                customer.Email = reader["email"].ToString();
                customer.Phonenumber = reader["phonenumber"].ToString();
                customer.Password = reader["password"].ToString();
            }
            _sqlconnection.Close();
            return customer;
        }
    }

    public Customer SelectCustomerById(Reservation reservation)
    {
        Customer customer = new();
        string sql = $"SELECT * FROM customers WHERE customers.id = '{reservation.CustomerId}'";
        _sqlconnection.Open();
        MySqlCommand cmd = new MySqlCommand(sql, _sqlconnection);
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                customer.Id = Convert.ToInt32(reader["id"].ToString());
                customer.FirstName = reader["first_name"].ToString();
                customer.LastName = reader["last_name"].ToString();
                customer.Email = reader["email"].ToString();
                customer.Phonenumber = reader["phonenumber"].ToString();
                customer.Password = reader["password"].ToString();
            }
            _sqlconnection.Close();
            return customer;
        }
    }

    public Customer InserCustomer(Customer customer)
    {
        string sql = ($@"
        INSERT INTO customers (id, first_name, last_name, email, phonenumber) 
        VALUES ('NULL', '{customer.FirstName}', '{customer.LastName}', '{customer.Email}', '{customer.Phonenumber}');
        SELECT LAST_INSERT_ID();");

        customer.Id = _sqlconnection.QuerySingle<int>(sql);
        return customer;
    }

    public void InsertPassword(Customer customer)
    {
        _sqlconnection.Execute($@"UPDATE customers SET password = '{customer.Password}' WHERE customers.id = '{customer.Id}';");
    }
}