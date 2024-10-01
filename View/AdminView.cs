using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Utils;
using AirportTicketBooking.ViewModel;

namespace AirportTicketBooking.View;

public static class AdminView
{
    public static User? admin;
    public static AdminViewModel? adminViewModel;

    public static void DisplayChoices()
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
            Console.WriteLine("1.Filter Bookings.");
            Console.WriteLine("2.Upload Flights");
            Console.WriteLine("3.Exit");

            var input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input) && Enum.TryParse(input, true, out AdminOptions choice))
            {
                switch (choice)
                {
                    case AdminOptions.FILTER_BOOKINGS:
                        DisplayFilterBookings();
                        break;
                    case AdminOptions.UPLOAD_FLIGHTS:
                        DisplayUploadFlights();
                        break;
                    case AdminOptions.EXIT:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong input.");
                        break;

                }

            }

        }
    }
    public static void DisplayFilterBookings()
    {
        //adminViewModel.FillterFlights();

    }
    public static void DisplayUploadFlights()
    {
    }
}
