using Dapper;
using MySqlConnector;

class CustomerDB
{
    public List<Customer> custList = new();
    MySqlConnection _sqlconnection;
    public CustomerDB()
    {
        _sqlconnection = new MySqlConnection("Server = localhost;Database = test_operan;Uid=root");
    }

    public int InsertNewCustomer(Customer customer)
    {
        string sql = $@"INSERT INTO customers (id, first_name, last_name, email, phonenumber) 
        VALUES (NULL, '{customer.FirstName}', '{customer.LastName}', '{customer.Email}', '{customer.Phonenumber}');
        SELECT LAST_INSERT_ID()";
        return _sqlconnection.QuerySingle<int>(sql);
    }

    public Customer GetCustomerByEmail(Customer customer)
    {
        string sql = $"SELECT * FROM customers WHERE customers.email = '{customer.Email}'";
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
            }
            _sqlconnection.Close();
            return customer;
        }
    }

    public Customer GetCustomerById(Reservation reservation)
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
}