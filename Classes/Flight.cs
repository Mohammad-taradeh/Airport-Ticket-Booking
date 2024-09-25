namespace AirportTicketBooking.Classes;
#nullable disable
public class Flight
{
    private static int _id = 0;
    public int Id { get; init; } = ++_id;
    public Airport From { get; init; }
    public Airport To { get; init; }
    public int EconomyClass { get; init; }
    public int BusinessClass { get; init; }
    public int FirstClass { get; init; }
}
#nullable restore
