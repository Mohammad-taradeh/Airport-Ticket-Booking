using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.View;

namespace AirportTicketBooking.ViewModel;

public static class DefaultViewModel
{
    private static List<User> users = UserRepository.GetAllUsers();
    public static void Login(String email, String password)
    {
        try
        {
            var authenticatedUser =  users.FirstOrDefault(user => user.Email == email && user.Password == password);
            if (authenticatedUser == null) {
                Console.WriteLine("Failed to login.");
            }
            else if(authenticatedUser.Role == Utils.UserRole.ADMIN)
            {
                //admin view display feature.
            }
            else
            {
                PassengerView._user = authenticatedUser;
                PassengerViewModel.passenger = authenticatedUser;
                PassengerView.DisplayFeatures();
            }
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
