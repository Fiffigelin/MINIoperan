internal class Program
{
    private static void Main(string[] args)
    {
        Customer person = new("Elin", "Nyman", "nyman@mail.com", "0702726612");
        Console.WriteLine(person.FirstName + person.Email);
        CustomerDB customerDB = new ();
        person.ID = customerDB.InsertNewCustomer(person);
        Console.WriteLine(person.ID);

    }
}