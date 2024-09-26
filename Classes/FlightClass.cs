using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Classes;

public class FlightClass
{
    public FlightClassType Type { get; set; }
    public int Seats { get; set; }
    public double Price { get; set; }
}
