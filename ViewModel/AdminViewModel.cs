using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;

public class AdminViewModel
{
    private User _admin;
    private List<Ticket> _tickets = TicketRepository.GetAllTickets();
    public AdminViewModel(User admin)
    {
        this._admin = admin;
    }
    public List<Ticket> FillterFlights(
        double? price,
        String? departureCountrie,
        String? destinationCountrie,
        DateTime? date,
        Airport? departureAirport,
        Airport? destinationAirport,
        FlightClassType? Class)
    {
        var tempTickets = _tickets;
        if (departureCountrie != null)
            tempTickets = tempTickets.Where(ticket => ticket.Flight.DepartureCountry == (Country)Enum.Parse(typeof(Country), departureCountrie)).ToList();
        if (destinationCountrie != null)
            tempTickets = tempTickets.Where(ticket => ticket.Flight.DestinationCountry == (Country)Enum.Parse(typeof(Country), destinationCountrie)).ToList();
        if (date != null)
            tempTickets = tempTickets.Where(ticket => ticket.Time >= date).ToList();
        if (departureAirport != null)
            tempTickets = tempTickets.Where(ticket => ticket.DepartureAirport == departureAirport).ToList();
        if (destinationAirport != null)
            tempTickets = tempTickets.Where(ticket => ticket.DestinationAirport == destinationAirport).ToList();
        if (Class != null)
            tempTickets = tempTickets.Where(ticket => ticket.Flight.Class.Type == Class).ToList();
        if(price != null)
            tempTickets = tempTickets.Where(ticket => ticket.Flight.Class.Price == price).ToList();
        return tempTickets;

    }
}
