using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Model.Classes;
public class User
{
    private static long _id = 0;

    public long Id { get; init; } = ++_id;
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    
    public UserRole Role { get; init; }

    public User()
    {
        Name = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        Role = default;

    }
    public User(string name, string email, string password, UserRole role)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public override string ToString()
    {
        return $"{Name}\n" +
            $"Your email: {Email}\n" +
            $"Your role: {Role}\n";
    }
}

