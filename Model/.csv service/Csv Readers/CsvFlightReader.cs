using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csv_service.Class_map;
using CsvHelper;
using System.Globalization;

namespace AirportTicketBooking.Model.csv_service.Csv_Readers;

public class CsvFlightReader : ICsvReader<Flight>
{
    public List<Flight> Read()
    {
        using var streamReader = new StreamReader(Path.Combine(Environment.CurrentDirectory, $"flights.csv"));
        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
        csvReader.Context.RegisterClassMap<FlightClassMap>();
        return csvReader.GetRecords<Flight>().ToList();
    }

    public bool Write(List<Flight> data)
    {
        var flightsCsvPath = Path.Combine(Environment.CurrentDirectory, $"flights.csv");
        using var streamWriter = new StreamWriter(flightsCsvPath);
        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        csvWriter.Context.RegisterClassMap<FlightClassMap>();
        csvWriter.WriteRecord(data);
        return true;
    }
}
