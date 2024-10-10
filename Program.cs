using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.View;
using AirportTicketBooking.ViewModel;
using AirportTicketBooking.Utils;

namespace TicketBooking;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("You need to login first:");
        Console.ReadLine();

        Console.WriteLine("Enter your email");
        var email = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        var password = Console.ReadLine();
        if(String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
        {
            Console.WriteLine("Invalid login credentials.");
            return;
        }  
        var authenticatedUser = UserRepository.Login(email, password);

        if (authenticatedUser == null)
        {
            Console.WriteLine("Failed to login.");
        }
        else if (authenticatedUser.Role == UserRole.ADMIN)
        {
            //admin view display feature.
            AdminView adminView = new(authenticatedUser);
            adminView.DisplayChoices();
        }
        else
        {
            PassengerView passengerView = new(authenticatedUser);
            passengerView.DisplayFeatures();
        }
    }
}
