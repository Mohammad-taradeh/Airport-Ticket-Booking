using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Model.Repositories;

public static class FlightRepository
{
    private static List<Flight> _flights = [];

    public static List<Flight> GetAllFlights()
    {
        ReadFlightsFromFile();

        return _flights;
    }

    public static void ReadFlightsFromFile()
    {
        _flights = new List<Flight>()
        {
            new Flight() { DepartureAirport = Airport.QueenAliaInternationalAirport, DestinationAirport = Airport.QueenAliaInternationalAirport, Time = DateTime.Now.AddDays(1),
                Class = new FlightClass() { Type = FlightClassType.Business, Seats = 10, Price = 500} }
        };
    }
}
