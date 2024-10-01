using AirportTicketBooking.View;

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
        DefaultView.Login(email, password);
    }
}
