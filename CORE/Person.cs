public abstract class Person
{
    public int ID {get; set;}
    public string FirstName {get; set;}
    public string LastName{get; set;}

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public Person (int id, string firstName, string lastName)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
    }
}