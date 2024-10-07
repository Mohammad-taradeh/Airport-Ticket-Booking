using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csvService.classMap;
using CsvHelper;
using System.Globalization;

namespace AirportTicketBooking.Model.csvService.csvReaders;

public class CsvTicketReader: ICsvReader<Ticket>
{
    public List<Ticket> Read()
    {
        using var streamReader = new StreamReader(Path.Combine(Environment.CurrentDirectory, $"tickets.csv"));
        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
        csvReader.Context.RegisterClassMap<TicketClassMap>();
        return csvReader.GetRecords<Ticket>().ToList();
    }

    public bool Write(List<Ticket> data)
    {
        var ticketsCsvPath = Path.Combine(Environment.CurrentDirectory, $"tickets.csv");
        using var streamWriter = new StreamWriter(ticketsCsvPath);
        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        csvWriter.Context.RegisterClassMap<TicketClassMap>();
        csvWriter.WriteRecord(data);
        return true;
    }
}
