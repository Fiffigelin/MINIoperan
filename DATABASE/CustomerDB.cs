using Dapper;
using MySqlConnector;

class CustomerDB
{
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
}