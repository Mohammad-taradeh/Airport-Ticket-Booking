using AirportTicketBooking.Model.Classes;
using CsvHelper.Configuration;

namespace AirportTicketBooking.Model.csvService.classMap;

public class FlightClassMap: ClassMap<Flight>
{
    public FlightClassMap()
    {
        Map(flight => flight.Id).Name("id");
        Map(flight => flight.DepartureAirport).Name("departure_airport");
        Map(flight => flight.DestinationAirport).Name("destination_airport");
        Map(flight => flight.DepartureCountry).Name("departure_country");
        Map(flight => flight.DestinationCountry).Name("destination_country");
        Map(flight => flight.Time).Name("at");
        Map(flight => flight.Class).Name("class");
        Map(flight => flight.Price).Name("price");
        Map(flight => flight.AvailableSeats).Name("empty_seats");
    }
}
