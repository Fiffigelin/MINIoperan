class Reservation
{
    public int Id {get; set;}
    public int CustomerId {get; set;}
    public int ShowDateId {get; set;}
    public int ShowId {get; set;}
    public int Price {get; set;}

    public Reservation (int customerId, int showDateId, int showId)
    {
        CustomerId = customerId;
        ShowDateId = showDateId;
        ShowId = showId;
    }
    public Reservation (){}
}