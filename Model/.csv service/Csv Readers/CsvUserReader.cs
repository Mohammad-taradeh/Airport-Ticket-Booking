using CsvHelper;
using System.Globalization;
using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csv_service.Class_map;
namespace AirportTicketBooking.Model.csv_service;

public class CsvUserReader : ICsvReader<User>
{
    List<User> ICsvReader<User>.Read()
    {
        using (var streamReader = new StreamReader(@"C:\Users\Lenovo\source\repos\AirportTicketBookingSolution\data\users.csv>"))
        {
            using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                csvReader.Context.RegisterClassMap<UserClassMap>();
               return csvReader.GetRecords<User>().ToList();
            }
        }
    }

    bool ICsvReader<User>.Write(List<User> data)
    {
        throw new NotImplementedException();
    }
}
