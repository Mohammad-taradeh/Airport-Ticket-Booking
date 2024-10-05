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
    public Country DepartureCountry { get; set; }
    public Country DestinationCountry { get; set; }
    public TimeSpan Time { get; set; }
    public FlightClassType Class {  get; set; }
    public int AvailableSeats { get; set; } = 10;
    public double Price { get; set; }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Flight ID: {Id}");
        sb.AppendLine($"From: {DepartureAirport} Airport");
        sb.AppendLine($"To: {DestinationAirport} Airport");
        sb.AppendLine($"{Class} class");
        sb.AppendLine($"{AvailableSeats} empty seats");
        sb.AppendLine($"for {Price} USD");
        return sb.ToString();
    }
}
#nullable restore
