using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Classes;


public class Ticket
{
    private static int _id = 0;
    public int Id { get; set; } = ++_id;
    public required Flight? Flight { get; set; }
    public required Airport? Departure { get; set; }
    public required Airport? Destination { get; set; }
    public required FlightClass Class { get; set; }
    public required DateTime Time { get; set; }

}
