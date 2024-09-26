using AirportTicketBooking.Model.Classes;
using System.Runtime.CompilerServices;

namespace AirportTicketBooking.Model.Repositories;

public static class UserRepository
{
    private static List<User> _users;
    public static List<User> GetAllUsers()
    {
        _users = ReadUsersFromFile();
        return _users;
    }
    public static List<User> ReadUsersFromFile()
    {
        //TODO
        //Just for testing
        return new List<User>()
        {
            new User(){Name = "Mohammad", Email = "201160@ppu.edu.ps", Password = "123", Role = Utils.UserRole.ADMIN},
            new User(){Name = "Ahmad", Email = "201161ppu.edu.ps", Password = "456", Role = Utils.UserRole.PASSENGER},
            new User(){Name = "Ibrahim", Email = "201162@ppu.edu.ps", Password = "789", Role = Utils.UserRole.PASSENGER}
        }
    }
}
