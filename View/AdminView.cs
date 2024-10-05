using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.csv_service.Csv_Readers;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.Utils;
using AirportTicketBooking.ViewModel;
using System.Text;

namespace AirportTicketBooking.View;

public class AdminView
{
    public static User? admin;
    public AdminViewModel _adminViewModel;

    public AdminView(User _admin)
    {
        admin = _admin;
        _adminViewModel = new AdminViewModel(_admin);
    }
    public void DisplayChoices()
    {
        bool exit = false;
        while (exit != true)
        {
            if(admin is null)
            {
                Console.WriteLine("You need to log in first.");
                return;
            }
            Console.WriteLine($"Hello Admin: {admin?.Name}, what are you going to do :)");
            Console.WriteLine("1.Display flights.");
            Console.WriteLine("2.Display Bookings");
            Console.WriteLine("3.Search Booking.");
            Console.WriteLine("4.Upload Flights");
            Console.WriteLine("5.Exit");

            var input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input) && Enum.TryParse(input, true, out AdminOptions choice))
            {
                switch (choice)
                {
                    case AdminOptions.DISPLAY_FLIGHTS:
                        DisplayFlights();
                        break;
                    case AdminOptions.DISPLAY_BOOKINGS:
                        DisplayBookings();
                        break;
                    case AdminOptions.SEARCH_BOOKING:
                        DisplaySearchBooking();
                        break;
                    case AdminOptions.UPLOAD_FLIGHTS:
                        DisplayUploadFlights();
                        break;
                    case AdminOptions.EXIT:
                        _adminViewModel.SaveAll();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong input.");
                        break;

                }

            }

        }
    }
    public void DisplayBookings()
    {
        var tickets = _adminViewModel.AllBookings();
        if(tickets == null || !tickets.Any())
        {
            Console.WriteLine("There are no Bookings not.");
            return;
        }
        foreach(var ticket in tickets)
        {
            Console.WriteLine(ticket.ToString());
            Console.WriteLine();
        }
        Console.WriteLine();

    }
    public void DisplayFlights()
    {
        var _flights = _adminViewModel.AllFlights();
        if (_flights == null || !_flights.Any())
        {
            Console.WriteLine("There are no Flighs now.");
            return;
        }
        foreach(var flight in _flights)
        {
            Console.WriteLine(flight.ToString());
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public void DisplayUploadFlights()
    {
        Console.WriteLine("Are you sure you want to Batch flight:");
        var choice = Console.ReadLine() ?? String.Empty;
        if (!choice.Equals("y", StringComparison.OrdinalIgnoreCase) || !choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Mission canceled.");
            return;
        }
        var flights = _adminViewModel.UploadFlights();
        if(flights == null)
        {
            Console.WriteLine("No Flights found.");
            return;
        }
        foreach(var flight in flights)
        {
            Console.WriteLine(flight.ToString());
        }
        
    }
    public void DisplaySearchBooking()
    {

    }
}
