public class Customer : Person
{
    public string Email {get; set;}
    public string Phonenumber {get; set;}

    public Customer (string firstName, string lastName, string mail, string phonenr) : base (firstName, lastName)
    {
        Email = mail;
        Phonenumber = phonenr;
    }
}