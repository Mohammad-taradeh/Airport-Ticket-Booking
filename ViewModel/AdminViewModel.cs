using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csv_service.Csv_Readers;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;

public class AdminViewModel
{
    private User _admin;
    private TicketRepository _ticketRepository;
    private FlightRepository _flightRepository;
    public AdminViewModel(User admin)
    {
        this._admin = admin;
        _ticketRepository = new();
        _flightRepository = new();
    }
    public List<Flight>? AllFlights() => _flightRepository.GetAll();
    public List<Ticket>? AllBookings() => _ticketRepository.GetAll();
    public List<Ticket>? FillterBookings(Ticket? search)
    {
        var tempTickets = _ticketRepository.GetAll();

        if (tempTickets is null || search is null)
            return null;

        if (search?.Id != long.MaxValue)
            tempTickets = tempTickets.Where(ticket => ticket.Id == search?.Id).ToList();

        if (search?.Passenger != long.MaxValue)
            tempTickets = tempTickets.Where(ticket => ticket.Passenger == search?.Passenger).ToList();

        if (search?.Flight != long.MaxValue)
            tempTickets = tempTickets.Where(ticket => ticket.Flight == search?.Flight).ToList();

        if (search?.DepartureAirport != Airport.NULL)
            tempTickets = tempTickets.Where(ticket => ticket.DepartureAirport == search?.DepartureAirport).ToList();

        if (search?.DestinationAirport != Airport.NULL)
            tempTickets = tempTickets.Where(ticket => ticket.DestinationAirport == search?.DestinationAirport).ToList();

        if (search?.Time != null)
            tempTickets = tempTickets.Where(ticket => ticket.Time >= search.Time).ToList();

        return tempTickets;

    }
    public List<Flight>? UploadFlights()
    {
        FlightRepository.ReadFlightsFromFile();
        return _flightRepository.GetAll();
    }
    public void SaveAll()
    {
        CsvFlightReader flightReader = new();
        CsvTicketReader ticketReader = new();
        List<Flight>? allFlights = _flightRepository.GetAll();
        List<Ticket>? allTickets = _ticketRepository.GetAll();
        if (allFlights != null && allTickets != null)
        {
            flightReader.Write(allFlights);
            ticketReader.Write(allTickets);
            Console.WriteLine("Changes saved.");
        }
        else
            Console.WriteLine("Nothing to save.");
    }
}
