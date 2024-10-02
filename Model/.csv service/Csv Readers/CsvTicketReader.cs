using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csv_service.Class_map;
using CsvHelper;
using System.Globalization;

namespace AirportTicketBooking.Model.csv_service.Csv_Readers;

public class CsvTicketReader: ICsvReader<Ticket>
{
    public List<Ticket> Read()
    {
        using (var streamReader = new StreamReader(@"C:\Users\Lenovo\source\repos\AirportTicketBookingSolution\data\tickets.csv>"))
        {
            using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                csvReader.Context.RegisterClassMap<TicketClassMap>();
                return csvReader.GetRecords<Ticket>().ToList();
            }
        }
    }

    public bool Write(List<Ticket> data)
    {
        throw new NotImplementedException();
    }
}
