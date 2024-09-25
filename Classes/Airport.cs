using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Classes;

public class Airport
{
    private static long _id = 0;
    public long Id { get; init; } = ++_id;
    public AirportNames Name { get; set; }
    public Countries Location { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}\n" +
            $"Airport: {Name}\n" +
            $"In: {Location} \n";
    }
}
