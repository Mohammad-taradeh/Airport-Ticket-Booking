using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csv_service.Csv_Readers;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;
public class PassengerViewModel
{
    public User Passenger { get; init; }
    private FlightRepository _flightRepository;
    private TicketRepository _ticketRepository;

    public PassengerViewModel(User user)
    {
        Passenger = user;
        _ticketRepository = new TicketRepository();
        _flightRepository = new FlightRepository();
    }
    public List<Ticket>? ViewBookings() => _ticketRepository.FindByUser(Passenger.Id);
    public Flight? FindFlightByID(long id) => _flightRepository.FindById(id);
    public Ticket? CancelTicket(Ticket? ticket, long? ticketId)
    {
        if (ticketId is null && ticket is not null)
        {
            return _ticketRepository.Delete(ticket);
        }
        if (ticketId is not null && ticket is null)
        {
            var ticketToRemove = _ticketRepository.FindById((long)ticketId);
            if (ticketToRemove is null)
                return null;
            return _ticketRepository.Delete(ticketToRemove);
        }
        return null;
    }

    public Ticket? BookFlight(long flightID)
    {
        var _flight = _flightRepository.FindById(flightID);
        if (_flight == null)
            return null;
        else
        {  
            if (_flight.AvailableSeats <= 0)
            {
                Console.WriteLine("Sorry: No empty seats.");
                return null;
            }

            else
            {
                Ticket ticket = new()
                {
                    Flight = _flight.Id,
                    Passenger = Passenger.Id,
                    DepartureAirport = _flight.DepartureAirport,
                    DestinationAirport = _flight.DestinationAirport,
                    Time = _flight.Time

                };
                _flight.AvailableSeats -= 1;
                return _ticketRepository.Save(ticket);
                
            }

        }
    }
    
    public void UpdateBooking(long oldTicketId, Ticket newTicket)
    {
        Ticket? oldTicket = _ticketRepository.FindById(oldTicketId);
        if (oldTicket is null)
        {
            Console.WriteLine("you don't have ticket with this id to update.");
            return;
        }
        else
        {
            if (_ticketRepository.Update(oldTicketId, newTicket) is not null)
                Console.WriteLine("Ticket updated successfully");
            else Console.WriteLine("Failed to update your ticket.");
        }
    }
    
    public List<Flight>? FillterFlights(Flight? search)
    {
        var tempFlights = _flightRepository.GetAll();
        if (tempFlights is null || search is null)
            return null;
        if (search?.DepartureCountry != Country.NULL)
            tempFlights = tempFlights.Where(flight => flight.DepartureCountry == search?.DepartureCountry).ToList();
        if (search?.DestinationCountry != Country.NULL)
            tempFlights = tempFlights.Where(flight => flight.DestinationCountry == search?.DestinationCountry).ToList();
        if (search?.Time != null)
            tempFlights = tempFlights.Where(flight => flight.Time >= search.Time).ToList();
        //Equality Comparer
        if (search?.DepartureAirport != Airport.NULL)
            tempFlights = tempFlights.Where(flight => flight.DepartureAirport == search?.DepartureAirport).ToList();
        if (search?.DestinationAirport != Airport.NULL)
            tempFlights = tempFlights.Where(flight => flight.DestinationAirport == search?.DestinationAirport).ToList();
        if (search?.Class != FlightClassType.NULL)
            tempFlights = tempFlights.Where(flight => flight.Class == search?.Class).ToList();
        if(search?.Price != double.MaxValue)
            tempFlights = tempFlights.Where(flight => flight.Price >= search?.Price).ToList();
        return tempFlights;

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
