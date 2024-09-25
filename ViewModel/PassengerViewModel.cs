using AirportTicketBooking.Classes;
using AirportTicketBooking.EqualityComparer;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;

public class PassengerViewModel
{
    private User passenger;
    private List<Flight> _flights;
    private List<Ticket> _tickets;
    private TicketEqualityComparer _ticketEqualityComparer = new TicketEqualityComparer();
    
    public List<Ticket> ViewBookings()
    {
        return passenger.Tickets;
    }
    public Ticket? CancelTicket(Ticket ticket)
    {
        var ticketExist = passenger.Tickets.Contains(ticket, _ticketEqualityComparer);
        if (!ticketExist)
            return null;
        return passenger.RemoveTicket(ticket);
    }
    public String UpdateBooking(long oldTicketId, Ticket newTicket)
    {
        Ticket? oldTicket = _tickets.Find(ticket => ticket.Id == oldTicketId);
        if (oldTicket is null)
            return "you don't have ticket with this id to update.";
        else
        {
            if (passenger.RemoveTicket(oldTicket) is not null && passenger.BookTicket(newTicket) is not null)
                return "Ticket updated successfully";
            else return "Failed to update your ticket.";
        }
    }

    public List<Flight> SearchAvailableFlights(double price,
        Countries departureCountrie,
        Countries destinationCountrie,
        DateTime date,
        Airport departureAirport,
        Airport destinationAirport,
        FlightClass Class)
    {
        var result = _flights.Where(flight => flight.Class.Item3 > price
        && flight.Time >= date
        && flight.Class.Item1 == Class);
        //TODO
        return new List<Flight>;
            
    }
}
