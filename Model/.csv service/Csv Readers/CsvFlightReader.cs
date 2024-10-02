using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csv_service.Class_map;
using CsvHelper;
using System.Globalization;

namespace AirportTicketBooking.Model.csv_service.Csv_Readers;

public class CsvFlightReader : ICsvReader<Flight>
{
    public List<Flight> Read()
    {
        using (var streamReader = new StreamReader(@"C:\Users\Lenovo\source\repos\AirportTicketBookingSolution\data\flights.csv>"))
        {
            using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                csvReader.Context.RegisterClassMap<FlightClassMap>();
                return csvReader.GetRecords<Flight>().ToList();
            }
        }
    }

    public bool Write(List<Flight> data)
    {
        throw new NotImplementedException();
    }
}
