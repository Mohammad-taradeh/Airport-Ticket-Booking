using AirportTicketBooking.Model.Classes;
using CsvHelper.Configuration;

namespace AirportTicketBooking.Model.csvService.classMap;

public class TicketClassMap: ClassMap<Ticket>
{
    public TicketClassMap()
    {
        Map(ticket => ticket.Id).Name("id");
        Map(ticket => ticket.Passenger).Name("passenger_id");
        Map(ticket => ticket.Flight).Name("flight_id");
        Map(ticket => ticket.DepartureAirport).Name("departure_airport");
        Map(ticket => ticket.DestinationAirport).Name("destination_airport");
        Map(ticket => ticket.Time).Name("at");
    }
}
