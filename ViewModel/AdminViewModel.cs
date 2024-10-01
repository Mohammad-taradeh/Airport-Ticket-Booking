using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;

public class AdminViewModel
{
    private User _admin;
    //private static List<Flight> _flights = FlightRepository.GetAllFlights();
    private  static TicketRepository _ticketRepository = new TicketRepository();
    private List<Ticket>? _tickets = _ticketRepository.GetAll().ToList();
    public AdminViewModel(User admin)
    {
        this._admin = admin;
    }
    //public List<Ticket>? FillterFlights(
    //    double? price,
    //    String? departureCountrie,
    //    String? destinationCountrie,
    //    TimeSpan? date,
    //    Airport? departureAirport,
    //    Airport? destinationAirport,
    //    FlightClassType? Class)
    //{
    //    var tempTickets = _tickets;
    //    if (tempTickets is null || !tempTickets.Any())
    //        return null;
    //    if (departureCountrie != null)
    //        tempTickets = tempTickets.Where(ticket => ticket.Flight == (Country)Enum.Parse(typeof(Country), departureCountrie)).ToList();
    //    if (destinationCountrie != null)
    //        tempTickets = tempTickets.Where(ticket => ticket.Flight.DestinationCountry == (Country)Enum.Parse(typeof(Country), destinationCountrie)).ToList();
    //    if (date != null)
    //        tempTickets = tempTickets.Where(ticket => ticket.Time >= date).ToList();
    //    if (departureAirport != null)
    //        tempTickets = tempTickets.Where(ticket => ticket.DepartureAirport == departureAirport).ToList();
    //    if (destinationAirport != null)
    //        tempTickets = tempTickets.Where(ticket => ticket.DestinationAirport == destinationAirport).ToList();
    //    if (Class != null)
    //        tempTickets = tempTickets.Where(ticket => ticket.Flight.Class.Type == Class).ToList();
    //    if(price != null)
    //        tempTickets = tempTickets.Where(ticket => ticket.Flight.Class.Price == price).ToList();
    //    return tempTickets;

    //}
}
