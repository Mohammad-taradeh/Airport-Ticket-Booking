using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Classes;


public class Ticket
{
    private static long _id = 0;
    public long Id { get; init; } = ++_id;
    public required Flight Flight { get; set; }
    public required Airport Departure { get; set; }
    public required Airport Destination { get; set; }
    public required DateTime Time { get; set; }
    public override string ToString()
    {
        return $"Ticket ID: {Id}\n" +
            $"Flight ID: {Flight?.Id}\n" +
            $"Departure airport: {Departure}" +
            $"Destination airport: {Destination}" +
            $"At: {Time}\n" +
            $"{Flight?.Class.Item1} Class";
    }

}
