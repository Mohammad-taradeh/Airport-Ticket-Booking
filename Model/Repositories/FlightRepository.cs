using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csvService.csvReaders;

namespace AirportTicketBooking.Model.Repositories;
public class FlightRepository : IRepository<Flight>
{
    private static List<Flight> _flights = ReadFlightsFromFile();

    public static List<Flight> GetAllFlights() => _flights;
  
    public static List<Flight> ReadFlightsFromFile()
    {
        CsvFlightReader reader = new CsvFlightReader();
        return reader.Read();
    }
    public static void WriteFlightsToFile()
    {
        CsvFlightReader writer = new();
        writer.Write(_flights);
    }

    public Flight? Delete(Flight item)
    {
        bool isExist = _flights.Where(flight => flight.Id == item.Id).Any();
        if (isExist)
            return null;
        _flights.Remove(item);
        return item;
    }

    public Flight? FindById(long id) => _flights.SingleOrDefault(flight => flight.Id == id);

    public List<Flight>? GetAll() => _flights;

    public Flight? Save(Flight item)
    {
        bool isExist = _flights.Where(flight => flight.Id == item.Id).Any();
        if (isExist) 
            return null;
        _flights.Add(item);
        return item;
    }

    public Flight? Update(long oldID, Flight newItem)
    {
        Flight? oldFlight = FindById(oldID);
        if (oldFlight is null)
            return null;
        bool isNewExist = FindById(newItem.Id) != null;
        if(isNewExist)
            return null;
        _flights.Remove(oldFlight);
        _flights.Add(newItem);
        return newItem;
    }
}
