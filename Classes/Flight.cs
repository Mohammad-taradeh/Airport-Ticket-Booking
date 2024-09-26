using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Classes;
#nullable disable
public class Flight
{
    private static long _id = 0;
    public long Id { get; init; } = ++_id;
    public Airport From { get; set; }
    public Airport To { get; set; }
    public DateTime Time { get; set; }
    public FlightClass Class {  get; set; }


    public override string ToString()
    {
        return $"Flight ID: {Id}" +
            $"From: {From} \n" +
            $"To: {To}\n" +
            $"{Class.Type} class\n" +
            $"{Class.Seats} seats\n" +
            $"for {Class.Price}$\n";
    }
}
#nullable restore
