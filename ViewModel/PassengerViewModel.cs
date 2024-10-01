using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;

public class PassengerViewModel
{
    public User Passenger { get; init; }
    private List<Flight> _flights = FlightRepository.GetAllFlights();
    private TicketRepository _ticketRepository;
    //private List<Ticket> _tickets = _ticketRepository.FindByUser(passenger.Id);

    public PassengerViewModel(User user)
    {
        Passenger = user;
        _ticketRepository = new TicketRepository();
    }
    public List<Ticket>? ViewBookings()
    {
        return _ticketRepository.FindByUser(Passenger.Id);
    }
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
        var _flight = FindFlightByID(flightID);
        if (_flight == null)
            return null;
        else
        {  
            if (_flight.Class.Seats <= 0)
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
                _flight.Class.Seats -= 1;
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
    public Flight? FindFlightByID(long id)
    {
        return _flights.SingleOrDefault(flight => flight.Id == id);
    }
    public List<Flight> FillterFlights(double? price,
        Country? departureCountrie,
        Country? destinationCountrie,
        TimeSpan? date,
        Airport? departureAirport,
        Airport? destinationAirport,
        FlightClassType? Class)
    {
        var tempFlights = _flights;
        if (departureCountrie != null)
            tempFlights = tempFlights.Where(flight => flight.DepartureCountry == departureCountrie).ToList();
        if (destinationCountrie != null)
            tempFlights = tempFlights.Where(flight => flight.DestinationCountry == destinationCountrie).ToList();
        if (date != null)
            tempFlights = tempFlights.Where(flight => flight.Time >= date).ToList();
        //Equality Comparer
        if (departureAirport != null)
            tempFlights = tempFlights.Where(flight => flight.DepartureAirport == departureAirport).ToList();
        if (destinationAirport != null)
            tempFlights = tempFlights.Where(flight => flight.DestinationAirport == destinationAirport).ToList();
        if (Class != null)
            tempFlights = tempFlights.Where(flight => flight.Class.Type == Class).ToList();
        if(price != null)
            tempFlights = tempFlights.Where(flight => flight.Class.Price >= price).ToList();
        return tempFlights;

    }
}
