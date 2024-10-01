using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Utils;
using AirportTicketBooking.ViewModel;
using System.Text;

namespace AirportTicketBooking.View;

public static class PassengerView
{
    public static User _user;
    public static void DisplayFeatures()
    {
        //Console.Clear();
        bool exit = false;
        while (exit != true)
        {
            Console.WriteLine($"Hello {_user.Name}, what are you going to do :)");
            Console.WriteLine("1.View Booking.");
            Console.WriteLine("2.Book Flight");
            Console.WriteLine("3.Cancel Booking.");
            Console.WriteLine("4.Update Booking.");
            Console.WriteLine("5.Filter Flights");
            Console.WriteLine("6.Exit");

            var input = Console.ReadLine();
            if(!String.IsNullOrEmpty(input) && Enum.TryParse(input, true, out PassengerFeatures choice))
            {
                switch (choice)
                {
                    case PassengerFeatures.VIEW_BOOKING:
                        DisplayViewBooking();
                        break;
                    case PassengerFeatures.BOOK_FLIGHT:
                        DisplayBookTicket();
                        break;
                    case PassengerFeatures.CANCEL_BO0KING:
                        DisplayCancelBooking();
                        break;
                    case PassengerFeatures.UPDATE_BOOKING:
                        DisplayUpdateBooking();
                        break;
                    case PassengerFeatures.FILTER_FLIGHTS:
                        DisplayFilterFlights();
                        break;
                    case PassengerFeatures.EXIT:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong input.");
                        break;

                }
            
            }
            
        }
    }
    public static void DisplayBookTicket()
    {
        Console.WriteLine("Enter the flight ID you want to book:");
        var flightIDInput = Console.ReadLine();
        if(String.IsNullOrEmpty(flightIDInput) || (!long.TryParse(flightIDInput, out var flightID))) 
        {
            Console.WriteLine("Invalid flight ID.");
            return;
        }
        var result = PassengerViewModel.BookFlight(flightID);
        if(result is not null)
        {
            Console.WriteLine(result.ToString());
            Console.WriteLine("Ticket Booked successfully.");
        }
        else
        {
            Console.WriteLine("Failed Booking the ticket.");
        }
    }
    public static void DisplayViewBooking()
    {
        List<Ticket>? bookings = PassengerViewModel.ViewBookings();
        if(bookings is null || !bookings.Any())
            Console.WriteLine("You don't have any Bookings.");
        else 
        {
            StringBuilder sb = new();
            foreach (Ticket ticket in bookings)
            { 
                sb.AppendLine(ticket.ToString());
                sb.AppendLine("****************");
            }
            sb.AppendLine();
            Console.WriteLine(sb.ToString());
        }
    }
    public static void DisplayCancelBooking() 
    {
        if (!_user.Tickets().Any() || _user.Tickets() is null) {
            Console.WriteLine("You don't have any Bookings to cancle.");
            return;
        }
        Console.WriteLine("Enter the id of the tecket you need to cancle:");
        var ticketID = Console.ReadLine();
        var boockings = PassengerViewModel.ViewBookings();
        if(!String.IsNullOrEmpty(ticketID) && long.TryParse(ticketID, out var ID))
        {
            var deletedBooking = PassengerViewModel.CancelTicket(null,ID);
            if(deletedBooking != null)
            {
                Console.WriteLine(deletedBooking.ToString());
                Console.WriteLine($"The Booking with the ID: {ID} has been deleted");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"There's no Booking with the ID: {ID}");
                Console.WriteLine();
            }
                
        }
        //Todo: cancel be creating new ticket
     
    }
    public static void DisplayUpdateBooking() 
    {
        Console.WriteLine("Enter the id of the ticket to update");
        var ticketID = Console.ReadLine();
        if(String.IsNullOrEmpty(ticketID) || !long.TryParse(ticketID, out var ID))
        {
            Console.WriteLine($"Invalid input: {ticketID}");
            return;
        }
        Console.WriteLine("Here are the abalibale flights:");
        var flights = PassengerViewModel.FillterFlights(null, null, null, null, null, null, null);
        if(flights.Any() )
        {
            StringBuilder sb = new();
            foreach( var _flight in flights )
            {
                sb.AppendLine(_flight.ToString());
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("There are no abalibale flights.");
            return;
        }
        Console.WriteLine("Enter the Flight id:");
        var validFlightID = long.TryParse(Console.ReadLine(), out var flightID);
        if(!validFlightID)
        {
            Console.WriteLine("invalid id format.");
            return;
        }
        var flight = PassengerViewModel.FindFlightByID(flightID);
        if(flight == null)
        {
            Console.WriteLine($"There are no flights with ID: {flightID}");
            return;
        }
        Ticket ticket = new() { Flight = flight.Id,
            Passenger = _user.Id,
            DepartureAirport = flight.DepartureAirport,
            DestinationAirport = flight.DestinationAirport,
            Time = flight.Time
        };
        PassengerViewModel.UpdateBooking(ID, ticket);

    }
    public static void DisplayFilterFlights()
    {
        //price
        Console.WriteLine("Enter the start price you want or leave it empty.");
        var priceInput = Console.ReadLine();
        double? _price = null;
        if (!String.IsNullOrEmpty(priceInput) && double.TryParse(priceInput, out var price))
            _price = price;
        else
            Console.WriteLine("Empty Input");
        Console.WriteLine();
        //departure country
        Console.WriteLine("Enter the Departure country you want or leave it empty.");
        var departureCountryInput = Console.ReadLine();
        Country? _departureCountry = null;
        if (!String.IsNullOrEmpty(departureCountryInput) && Enum.TryParse(typeof(Country),
            departureCountryInput,true,
            out var departureCountry))
            _departureCountry = (Country)departureCountry;
        else
            Console.WriteLine("Empty Input");
        Console.WriteLine();
        //destination country
        Console.WriteLine("Enter the Destination country you want or leave it empty.");
        var destinationCountryInput = Console.ReadLine();
        Country? _destinationCountry = null;
        if (!String.IsNullOrEmpty(destinationCountryInput) && Enum.TryParse(typeof(Country),
            departureCountryInput, true,
            out var destinationCountry))
            _destinationCountry = (Country)destinationCountry;
        else
            Console.WriteLine("Empty Input");
        Console.WriteLine();
        //departure airport
        Console.WriteLine("Enter the Departure Airport you want or leave it empty.");
        var departureAirportInput = Console.ReadLine();
        Airport? _departureAirport = null;
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
        Airport? _destinationAirport = null;
        if (!String.IsNullOrEmpty(destinationAirportInput) && Enum.TryParse(typeof(Airport),
            destinationAirportInput, true,
            out var destinationAirport))
            _destinationAirport = (Airport)destinationAirport;
        else
            Console.WriteLine("Empty Input");
        Console.WriteLine();

        //class -> type
        Console.WriteLine("Enter the Flight Class you want or leave it empty.");
        var flightClassInput = Console.ReadLine();
        FlightClassType? _flightClass = null;
        if (!String.IsNullOrEmpty(flightClassInput) && Enum.TryParse(typeof(FlightClassType),
            flightClassInput, true,
            out var flightClass))
            _flightClass = (FlightClassType)flightClass;
        else
            Console.WriteLine("Empty Input");
        //date
        Console.WriteLine("Enter the Flight data you want or leave it empty.");
        var dateInput = Console.ReadLine();
        DateTime? _date = null;
        if (!String.IsNullOrEmpty(dateInput) && DateTime.TryParse(dateInput, out var date))
            _date = date;
        else
            Console.WriteLine("Empty Input");
        var result = PassengerViewModel.FillterFlights(_price,
            _departureCountry,
            _destinationCountry,
            _date,
            _departureAirport,
            _destinationAirport,
            _flightClass);

        if(!result.Any())
        { 
            Console.WriteLine("Sorry: No results match you need.");
            return;
        }
        StringBuilder sb = new();
        foreach (var flight in result)
        { 
            sb.AppendLine(flight.ToString());
        }
        Console.WriteLine("How about these:");
        Console.WriteLine(sb.ToString());

    }
}
