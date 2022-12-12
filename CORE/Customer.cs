public class Customer
{
    public int Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string Phonenumber {get; set;}

    public Customer (string firstName, string lastName, string mail, string phonenr)
    {
        FirstName = firstName;
        LastName = LastName;
        Email = mail;
        Phonenumber = phonenr;
    }

    public Customer(){}
}