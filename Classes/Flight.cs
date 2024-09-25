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

    public override string ToString()
    {
        return $"Flight ID: {Id}" +
            $"From: {From} \n" +
            $"To: {To}\n" +
            $"With {EconomyClass} Economy class seats\n" +
            $"and {BusinessClass} Business class seats\n"+
            $"and {FirstClass} First class seats\n";
    }
}
#nullable restore
