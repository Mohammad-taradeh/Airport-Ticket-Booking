using AirportTicketBooking.Model.Classes;
using System.Diagnostics.CodeAnalysis;

namespace AirportTicketBooking.EqualityComparer;

public class TicketEqualityComparer : EqualityComparer<Ticket>
{
    public override bool Equals(Ticket? x, Ticket? y)
    {
        if (x == null && y == null) return true;
        if(x == null || y == null) return false;
        if(x.Id == y.Id
            && x.Time == y.Time
            && x.Passenger == y.Passenger
            && x.Flight == y.Flight)
            return true;
        else return false;
    }

    public override int GetHashCode([DisallowNull] Ticket obj)
    {
        throw new NotImplementedException();
    }
}
