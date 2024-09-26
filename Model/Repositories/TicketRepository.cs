using AirportTicketBooking.Model.Classes;

namespace AirportTicketBooking.Model.Repositories;

public static class TicketRepository
{
    private static List<Ticket> _tickets = [];

    public static void ReadTicketsFromFile()
    {
        _tickets = new List<Ticket>()
        {
            new(){ Flight = new Flight { Class = new FlightClass(){Type = Utils.FlightClassType.Business, Price = 100,  Seats = 100},
        DepartureAirport = Utils.Airport.QueenAliaInternationalAirport,
        DestinationAirport = Utils.Airport.QueenAliaInternationalAirport,
        Time = DateTime.Now.AddMinutes(50)},
        DepartureAirport = Utils.Airport.QueenAliaInternationalAirport,
        DestinationAirport = Utils.Airport.QueenAliaInternationalAirport, Time = DateTime.Now .AddMinutes(50) } };
    }
    public static List<Ticket> GetAllTickets ()
    {
        ReadTicketsFromFile();
        return _tickets;
    }
}
