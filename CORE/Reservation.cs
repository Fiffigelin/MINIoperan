class Reservation
{
    public int Id {get; set;}
    public int CustomerId {get; set;}
    public int ShowDateId {get; set;}
    public int ShowId {get; set;}
    public int Price {get; set;}

    public Reservation (int id, int customerId, int showDateId, int showId)
    {
        Id = id;
        CustomerId = customerId;
        ShowDateId = showDateId;
        ShowId = showId;
    }
    public Reservation (){}
}