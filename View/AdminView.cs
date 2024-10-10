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
        var isExist = false;
        while (isExist != true)
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
                        isExist = true;
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
    private T? ReadValue<T>(Type type, String name)
    {
        Console.WriteLine($"Enter the {name}, or leave it empty.");
        var input = Console.ReadLine();
        if (String.IsNullOrEmpty(input))
        {
            Console.WriteLine("Empty input");
            return default;
        }
        return (T) Convert.ChangeType(input, type);
    }
    public void DisplaySearchBooking()
    {
        var x = ReadValue<double>(typeof(double), "price");
        //ID
        var ID = ReadValue<long>(typeof(long), "ID");
        var _ID = long.MaxValue;
        if(ID != default)
            _ID = ID;
        Console.WriteLine();
        //Flight
        var flightID = ReadValue<long>(typeof(long), "Flight_ID");
        var _flightID = long.MaxValue;
        if(flightID != default)
            _flightID = flightID;
        Console.WriteLine();
        //passenger
        var passengerID = ReadValue<long>(typeof(long), "Passenger_ID");
        var _passengerID = long.MaxValue;
        if (passengerID != default)
            _passengerID = passengerID;
        Console.WriteLine();
        //departure airport
        var _departureAirport = ReadValue<Airport>(typeof(Airport), "Departure Airport");
        Console.WriteLine();

        //destination airport
        var _destinationAirport = ReadValue<Airport>(typeof(Airport), "Destination Airport");
        Console.WriteLine();

        //date
        var date = ReadValue<TimeSpan>(typeof(TimeSpan), "Time");
        TimeSpan _date = TimeSpan.MinValue;
        if (date != default)
            _date = date;
        Console.WriteLine();
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
        Console.WriteLine("How about these:");
        foreach (var ticket in result)
        {
            Console.WriteLine(ticket.ToString());
        }
        Console.WriteLine();

    }
}

