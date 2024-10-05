using AirportTicketBooking.Model.Classes;
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
        //ID
        Console.WriteLine("Enter the Ticket ID you want or leave it empty.");
        var IDInput = Console.ReadLine();
        long _ID = long.MaxValue;
        if (!String.IsNullOrEmpty(IDInput) && long.TryParse(IDInput, out var ID))
            _ID = ID;
        else
            Console.WriteLine("Empty Input");
        Console.WriteLine();
        //Flight
        Console.WriteLine("Enter the Flight ID you want or leave it empty.");
        var flightInput = Console.ReadLine();
        long _flightID = long.MaxValue;
        if (!String.IsNullOrEmpty(flightInput) && long.TryParse(flightInput, out var flightID))
            _flightID = flightID;
        else
            Console.WriteLine("Empty Input");
        Console.WriteLine();
        //passenger
        Console.WriteLine("Enter the Passenger ID you want or leave it empty.");
        var passengerInput = Console.ReadLine();
        long _passengerID = long.MaxValue;
        if (!String.IsNullOrEmpty(passengerInput) && long.TryParse(passengerInput, out var passengerID))
            _passengerID = passengerID;
        else
            Console.WriteLine("Empty Input");
        //departure airport
        Console.WriteLine("Enter the Departure Airport you want or leave it empty.");
        var departureAirportInput = Console.ReadLine();
        Airport _departureAirport = Airport.NULL;
        if (!String.IsNullOrEmpty(departureAirportInput) && Enum.TryParse(typeof(Airport),
            departureAirportInput, true,
            out var departureAirport))
            _departureAirport = (Airport)departureAirport;
        else
            Console.WriteLine("Empty Input");
        Console.WriteLine();

        //destination airport
        Console.WriteLine("Enter the Destination Airport you want or leave it empty.");
        var destinationAirportInput = Console.ReadLine();
        Airport _destinationAirport = Airport.NULL;
        if (!String.IsNullOrEmpty(destinationAirportInput) && Enum.TryParse(typeof(Airport),
            destinationAirportInput, true,
            out var destinationAirport))
            _destinationAirport = (Airport)destinationAirport;
        else
            Console.WriteLine("Empty Input");
        Console.WriteLine();

        //date
        Console.WriteLine("Enter the Ticket date or leave it empty.");
        var dateInput = Console.ReadLine();
        TimeSpan _date = TimeSpan.MinValue;
        if (!String.IsNullOrEmpty(dateInput) && TimeSpan.TryParse(dateInput, out var date))
            _date = date;
        else
            Console.WriteLine("Empty Input");
        Ticket ticketSearchOpeions = new()
        {
            Id = _ID,
            Flight = _flightID,
            Passenger = _passengerID,
            DepartureAirport = _departureAirport,
            DestinationAirport = _destinationAirport,
            Time = _date
        };
        var result = _adminViewModel.FillterBookings(ticketSearchOpeions);

        if (result is null || !result.Any())
        {
            Console.WriteLine("Sorry: No results match you need.");
            return;
        }
        StringBuilder sb = new();
        foreach (var ticket in result)
        {
            sb.AppendLine(ticket.ToString());
        }
        Console.WriteLine("How about these:");
        Console.WriteLine(sb.ToString());
        Console.WriteLine();

    }
}

