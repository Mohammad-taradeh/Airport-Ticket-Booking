using AirportTicketBooking.Classes;
using System.Diagnostics.CodeAnalysis;

namespace AirportTicketBooking.EqualityComparer;

internal class TicketEqualityComparer : EqualityComparer<Ticket>
{
    public override bool Equals(Ticket? x, Ticket? y)
    {
        if(x == null || y == null) return false;
        if(x.Id == y.Id
            && x.Time == y.Time
            && x.Class == y.Class) return true;
        return false;
    }

    public override int GetHashCode([DisallowNull] Ticket obj)
    {
        throw new NotImplementedException();
    }
}
