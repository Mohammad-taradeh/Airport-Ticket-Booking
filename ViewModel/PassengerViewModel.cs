using AirportTicketBooking.EqualityComparer;
using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;

public static class PassengerViewModel
{
    public static User passenger;
    private static List<Flight> _flights = FlightRepository.GetAllFlights();
    private static List<Ticket> _tickets = TicketRepository.GetAllTickets();
    private static TicketEqualityComparer _ticketEqualityComparer = new();
    /*public PassengerViewModel(User passenger)
    {
        this.passenger = passenger;
    }*/
    public static List<Ticket>? ViewBookings()
    {
        return passenger.Tickets();
    }
    public static Ticket? CancelTicket(Ticket? ticket, long? ticketId)
    {
        if (ticketId is null && ticket is not null)
        {
            var ticketExist = passenger.Tickets().Contains(ticket, _ticketEqualityComparer);
            if (!ticketExist)
                return null;
            return passenger.RemoveTicket(ticket);
        }
        if (ticketId is not null && ticket is null)
        {
            foreach (var tick in passenger.Tickets())
            {
                if (tick.Id == ticketId)
                {
                    return passenger.RemoveTicket(tick) is Ticket ? tick : null;
                }
            }
        }
        return null;
    }

    public static Ticket? BookFlight(long flightID)
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
                    Flight = _flight,
                    DepartureAirport = _flight.DepartureAirport,
                    DestinationAirport = _flight.DestinationAirport,
                    Time = _flight.Time

                };
                _flight.Class.Seats -= 1;
                passenger.BookTicket(ticket);
                return ticket;
            }

        }
    }
    
    public static void UpdateBooking(long oldTicketId, Ticket newTicket)
    {
        Ticket? oldTicket = _tickets.Find(ticket => ticket.Id == oldTicketId);
        if (oldTicket is null)
        {
            Console.WriteLine("you don't have ticket with this id to update.");
            return;
        }
        else
        {
            if (passenger.RemoveTicket(oldTicket) is not null && passenger.BookTicket(newTicket))
                Console.WriteLine("Ticket updated successfully");
            else Console.WriteLine("Failed to update your ticket.");
        }
    }
    public static Flight? FindFlightByID(long id)
    {
        return _flights.SingleOrDefault(flight => flight.Id == id);
    }
    public static List<Flight> FillterFlights(double? price,
        Country? departureCountrie,
        Country? destinationCountrie,
        DateTime? date,
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
