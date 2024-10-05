using CsvHelper;
using System.Globalization;
using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csv_service.Class_map;

namespace AirportTicketBooking.Model.csv_service.Csv_Readers;

public class CsvUserReader : ICsvReader<User>
{
    public List<User> Read()
    {
        Console.WriteLine($"{Environment.CurrentDirectory} read");
        using var streamReader = new StreamReader(Path.Combine(Environment.CurrentDirectory, $"users.csv"));
        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
        csvReader.Context.RegisterClassMap<UserClassMap>();
        return csvReader.GetRecords<User>().ToList();
    }

    public bool Write(List<User> data)
    {
        Console.WriteLine($"{ Environment.CurrentDirectory} write");
        var usersCsvPath = Path.Combine(Environment.CurrentDirectory, $"users.csv");
        using var streamWriter = new StreamWriter(usersCsvPath);
        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        csvWriter.Context.RegisterClassMap<UserClassMap>();
        csvWriter.WriteRecord(data);
        return true;
    }
}
