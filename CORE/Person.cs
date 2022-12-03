public abstract class Person
{
    public int ID {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}

    public Person (string name, string surname)
    {
        FirstName = name;
        LastName = surname;
    }
}