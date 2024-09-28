using AirportTicketBooking.EqualityComparer;
using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;

public class PassengerViewModel
{
    private required User passenger;
    private List<Flight> _flights = FlightRepository.GetAllFlights();
    private List<Ticket> _tickets = TicketRepository.GetAllTickets();
    private TicketEqualityComparer _ticketEqualityComparer = new();
    public PassengerViewModel(User passenger)
    {
        this.passenger = passenger;
    }
    public List<Ticket> ViewBookings()
    {
        return passenger.Tickets;
    }
    public Ticket? CancelTicket(Ticket? ticket, long? ticketId)
    {
        if (ticketId is null && ticket is not null)
        {
            var ticketExist = passenger.Tickets.Contains(ticket, _ticketEqualityComparer);
            if (!ticketExist)
                return null;
            return passenger.RemoveTicket(ticket);
        }
        if (ticketId is not null && ticket is null)
        {
            foreach (var tick in passenger.Tickets)
            {
                if (tick.Id == ticketId)
                {
                    return passenger.Tickets.Remove(tick) ? tick : null;
                }
            }
        }
        return null;
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
            tempFlights = tempFlights.Where(flight => flight.DepartureCountry == (Countries)Enum.Parse(typeof(Countries), departureCountrie)).ToList();
        if (destinationCountrie != null)
            tempFlights = tempFlights.Where(flight => flight.DestinationCountry == (Countries)Enum.Parse(typeof(Countries), destinationCountrie)).ToList();
        if (date != null)
            tempFlights = tempFlights.Where(flight => flight.Time >= date).ToList();
        //Equality Comparer
        if (departureAirport != null)
            tempFlights = tempFlights.Where(flight => flight.DepartureAirport == departureAirport).ToList();
        if (destinationAirport != null)
            tempFlights = tempFlights.Where(flight => flight.DestinationAirport == destinationAirport).ToList();
        if (Class != null)
            tempFlights = tempFlights.Where(flight => flight.Class.Type == Class).ToList();
        return tempFlights;

    }
}
