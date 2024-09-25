using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Classes;

public class Airport
{
    public int Id { get; set; }
    public AirportNames Name { get; set; }
    public Countries Location { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}\n" +
            $"Airport: {Name}\n" +
            $"In: {Location} \n";
    }
}
