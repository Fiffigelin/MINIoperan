using Dapper;
using MySqlConnector;

class CustomerDB
{
    private MySqlConnection _sqlconnection;
    public CustomerDB()
    {
        Connect();
    }

    public void Connect()
    {
        _sqlconnection = new MySqlConnection("Server = localhost;Database = mini;Uid=root");
    }

    public int InsertNewCustomer(Customer customer)
    {
        string sql = $@"INSERT INTO customers (id, first_name, last_name, email, phonenumber) 
        VALUES (NULL, '{customer.FirstName}', '{customer.LastName}', '{customer.Email}', '{customer.Phonenumber}')";
        int id = _sqlconnection.QuerySingle<int>(sql);
        return id;
    }
}