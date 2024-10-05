using AirportTicketBooking.Model.Classes;
using CsvHelper.Configuration;

namespace AirportTicketBooking.Model.csv_service.Class_map;

public class UserClassMap: ClassMap<User>
{
	public UserClassMap()
	{
		Map(user => user.Id).Name("id");
        Map(user => user.Email).Name("email");
        Map(user => user.Password).Name("password");
        Map(user => user.Name).Name("name");
        Map(user => user.Role).Name("role");

    }
}
