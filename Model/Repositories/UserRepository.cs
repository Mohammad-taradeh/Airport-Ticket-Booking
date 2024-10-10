using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csvService.csvReaders;

namespace AirportTicketBooking.Model.Repositories;
public static class UserRepository
{

    private static List<User> _users = ReadUsersFromFile();
    public static List<User> GetAllUsers()
    {
        return _users;
    }
    public static List<User> ReadUsersFromFile()
    {
        CsvUserReader reader = new();
        return reader.Read();
    }
    public static void WriteUsersToFile()
    {
        CsvUserReader writer = new();
        writer.Write(_users);
    }
    public static User? Login(string email, string password)
    {
        try
        { 
            return _users.SingleOrDefault(user => user.Email == email && user.Password == password);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
