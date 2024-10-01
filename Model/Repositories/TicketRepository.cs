using AirportTicketBooking.EqualityComparer;
using AirportTicketBooking.Model.Classes;

namespace AirportTicketBooking.Model.Repositories;

public class TicketRepository : IRepository<Ticket>
{
    private static List<Ticket> _tickets = new();
    private static TicketEqualityComparer TicketEqualityComparer = new TicketEqualityComparer();

    public void ReadTicketsFromFile()
    {
        _tickets = new List<Ticket>()
        {
            new Ticket(){ Flight = long.Parse("1"),
            Passenger = long.Parse("1"),
            Time = TimeSpan.FromMinutes(50),
            DepartureAirport = Utils.Airport.QueenAliaInternationalAirport,
            DestinationAirport = Utils.Airport.QueenAliaInternationalAirport
            }
        };
    }
    public List<Ticket>? GetAllTickets (long userID)
    {
        ReadTicketsFromFile();

        return _tickets.Where(ticket => ticket.Passenger == userID).ToList();

    }

    public Ticket? Save(Ticket item)
    {
        bool exist = _tickets.Contains(item, TicketEqualityComparer);
        if (exist)
            return null;
        _tickets.Add(item);
        return item;
    }

    public Ticket? Delete(Ticket item)
    {
        bool exist = _tickets.Contains(item, TicketEqualityComparer);
        if (@exist)
            return null; ;
        bool removed = _tickets.Remove(item);
        if (removed)
            return item;
        else return null;
    }

    public Ticket? FindById(long id)
    {
        return _tickets.SingleOrDefault(ticket => ticket.Id == id);
    }
    public List<Ticket> FindByUser(long userId)
    {
        return _tickets.Where(ticket => ticket.Passenger ==  userId).ToList();
    }
    public Ticket? Update(long ID, Ticket item)
    {
        Ticket? oldTicket = _tickets.SingleOrDefault(ticket => ticket.Id == ID);
        bool exist = _tickets.Contains(item, TicketEqualityComparer);
        if (oldTicket is null || !exist)
            return null;
        _tickets.Remove(oldTicket);
        _tickets.Add(item);
        return item;


    }

    public List<Ticket>? GetAll()
    {
        if(_tickets == null)
            return null;
        else return _tickets;
    }
}
