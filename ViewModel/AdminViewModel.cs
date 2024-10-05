using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csv_service.Csv_Readers;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;

public class AdminViewModel
{
    private User _admin;
    //private static List<Flight> _flights = FlightRepository.GetAllFlights();
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
    public List<Ticket>? FillterBookings(
        long? id,
        long? passengerID,
        long? flightID,
        Airport departureAirport,
        Airport destinationAirport,
        TimeSpan time
        )
    {
        var tempTickets = _ticketRepository.GetAll();
        if (tempTickets is null)
            return null;
        if (id != null)
            tempTickets = tempTickets.Where(ticket => ticket.Id == id).ToList();
        if (id != null)
            tempTickets = tempTickets.Where(ticket => ticket.Passenger == passengerID).ToList();
        if (id != null)
            tempTickets = tempTickets.Where(ticket => ticket.Flight == flightID).ToList();
        if (id != null)
            tempTickets = tempTickets.Where(ticket => ticket.DepartureAirport == departureAirport).ToList();
        if (id != null)
            tempTickets = tempTickets.Where(ticket => ticket.DestinationAirport == destinationAirport).ToList();
        if (id != null)
            tempTickets = tempTickets.Where(ticket => ticket.Time >= time).ToList();
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
