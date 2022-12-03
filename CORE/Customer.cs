public class Customer : Person
{
    public string Email { get; set; }
    public string Phonenumber { get; set; }

    public Customer(string email, string phonenr) : base(firstName, lastName)
    {
        Email = email;
        Phonenumber = phonenr;
    }

    public Customer(int id, string firstName, string lastName, string email, string phonenr)
    {
        Email = email;
        Phonenumber = phonenr;
    }
}