using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Classes;

public class Airport
{
    public int Id { get; set; }
    public AirportNames Name { get; set; }
    public Countries Location { get; set; }
}
