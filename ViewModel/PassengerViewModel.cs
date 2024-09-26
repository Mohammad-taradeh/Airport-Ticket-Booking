using AirportTicketBooking.Classes;
using AirportTicketBooking.EqualityComparer;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;

public class PassengerViewModel
{
    private User passenger;
    private List<Flight> _flights;
    private List<Ticket> _tickets;
    private TicketEqualityComparer _ticketEqualityComparer = new();
    
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
            if (passenger.RemoveTicket(oldTicket) is not null && passenger.BookTicket(newTicket))
                return "Ticket updated successfully";
            else return "Failed to update your ticket.";
        }
    }

    public List<Flight> FillterFlights(double price,
        String? departureCountrie,
        String? destinationCountrie,
        DateTime? date,
        Airport? departureAirport,
        Airport? destinationAirport,
        FlightClassType? Class)
    {
        var tempFlights = _flights;
        if (departureCountrie != null)
            tempFlights = tempFlights.Where(flight => flight.From == (Countries)Enum.Parse(typeof(Countries), departureCountrie)).ToList();
        if (destinationCountrie != null)
            tempFlights = tempFlights.Where(flight => flight.To == (Countries)Enum.Parse(typeof(Countries), destinationCountrie)).ToList();
        if (date != null)
            tempFlights = tempFlights.Where(flight => flight.Time >= date).ToList();
        //Equality Comparer
        if (departureAirport != null)
            tempFlights = tempFlights.Where(flight => flight.From == departureAirport).ToList();
        if (destinationAirport != null)
            tempFlights = tempFlights.Where(flight => flight.To == destinationAirport).ToList();
        if (Class != null)
            tempFlights = tempFlights.Where(flight => flight.Class.Type == Class).ToList();
        return tempFlights;

    }
}
