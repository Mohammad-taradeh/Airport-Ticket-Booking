using AirportTicketBooking.EqualityComparer;
using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csv_service.Csv_Readers;

namespace AirportTicketBooking.Model.Repositories;
public class TicketRepository : IRepository<Ticket>
{
    private static List<Ticket> _tickets = ReadTicketsFromFile();
    private static TicketEqualityComparer TicketEqualityComparer = new TicketEqualityComparer();

    public static List<Ticket> ReadTicketsFromFile()
    {
        CsvTicketReader reader = new CsvTicketReader();
        return reader.Read();
    }
    public static void WriteTicketsToFile()
    {
        CsvTicketReader writer = new();
        writer.Write(_tickets);
    }
    public List<Ticket>? GetAllTickets (long userID)
    {
        if (_tickets == null)
            return null;

        return _tickets.Where(ticket => ticket.Passenger == userID).ToList();

    }

    public Ticket? Save(Ticket item)
    {
        bool isExist = _tickets.Contains(item, TicketEqualityComparer);
        if (isExist)
            return null;
        _tickets.Add(item);
        return item;
    }

    public Ticket? Delete(Ticket item)
    {
        if (_tickets == null) return null;
        bool exist = _tickets.Contains(item, TicketEqualityComparer);
        if (@exist)
            return null; ;
        bool removed = _tickets.Remove(item);
        if (removed)
            return item;
        else return null;
    }

    public Ticket? FindById(long id) => _tickets.SingleOrDefault(ticket => ticket.Id == id);
    public List<Ticket>? FindByUser(long userId) => _tickets.Where(ticket => ticket.Passenger == userId).ToList();
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

    public List<Ticket>? GetAll() => _tickets;
}
