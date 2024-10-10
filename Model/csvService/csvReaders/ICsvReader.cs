namespace AirportTicketBooking.Model.csvService;

public interface ICsvReader<T> where T : class
{
    public List<T> Read();
    public bool Write(List<T> data);
}
