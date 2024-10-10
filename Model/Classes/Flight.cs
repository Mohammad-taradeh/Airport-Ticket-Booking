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
        return $"Flight ID: {Id}" +
        $"From: {DepartureAirport} Airport" +
        $"To: {DestinationAirport} Airport" +
        $"{Class} class" +
        $"{AvailableSeats} empty seats" +
       $"for {Price} USD";
    }
}
#nullable restore
