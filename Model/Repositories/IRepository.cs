namespace AirportTicketBooking.Model.Repositories;

public interface IRepository<T> where T : class
{
    public abstract T? Save(T item);
    public abstract T? Delete(T item);
    public abstract T? FindById(long id);
    public abstract T? Update(long oldID, T newItem);
    public abstract List<T>? GetAll();

}
