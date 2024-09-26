using AirportTicketBooking.Utils;
using System.Text;

namespace AirportTicketBooking.Model.Classes;
#nullable disable
public class Flight
{
    private static long _id = 0;
    public long Id { get; init; } = ++_id;
    public Airport DepartureAirport { get; set; }
    public Airport DestinationAirport { get; set; }
    public Countries DepartureCountry { get; set; }
    public Countries DestinationCountry { get; set; }
    public DateTime Time { get; set; }
    public FlightClass Class {  get; set; }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Flight ID: {Id}");
        sb.AppendLine($"From: {DepartureAirport} Airport");
        sb.AppendLine($"To: {DestinationAirport} Airport");
        sb.AppendLine($"{Class.Type} class");
        sb.AppendLine($"{Class.Seats} empty seats");
        sb.AppendLine($"for {Class.Price} USD");
        return sb.ToString();
    }
}
#nullable restore
