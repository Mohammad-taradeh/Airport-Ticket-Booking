using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Model.Classes;


public class Ticket
{
    private static long _id = 0;
    public long Id { get; init; } = ++_id;
    public required Flight Flight { get; set; }
    public required Airport DepartureAirport { get; set; }
    public required Airport DestinationAirport { get; set; }
    public required DateTime Time { get; set; }
    public override string ToString()
    {
        return $"Ticket ID: {Id}\n" +
            $"Flight ID: {Flight?.Id}\n" +
            $"Departure airport: {DepartureAirport}" +
            $"Destination airport: {DestinationAirport}" +
            $"At: {Time}\n" +
            $"{Flight?.Class.Type} Class";
    }

}
