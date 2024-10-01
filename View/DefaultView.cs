using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.ViewModel;

namespace AirportTicketBooking.View;

public static class DefaultView
{
    private static List<User> users = UserRepository.GetAllUsers();
    public static void Login(string email, string password)
    {
        try
        {
            var authenticatedUser = users.FirstOrDefault(user => user.Email == email && user.Password == password);
            if (authenticatedUser == null)
            {
                Console.WriteLine("Failed to login.");
            }
            else if (authenticatedUser.Role == Utils.UserRole.ADMIN)
            {
                //admin view display feature.
                AdminView.admin = authenticatedUser;
                AdminViewModel avm = new(authenticatedUser);
                AdminView.adminViewModel = avm;
                AdminView.DisplayChoices();
            }
            else
            {
                PassengerView._user = authenticatedUser;
                PassengerViewModel.passenger = authenticatedUser;
                PassengerView.DisplayFeatures();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
