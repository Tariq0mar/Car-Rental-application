namespace CarRentalApplication.DB.Exceptions;

public class NotFoundException<T> : Exception
{
    public NotFoundException(int id)
        : base($"{typeof(T).Name} with key {id} was not found.")
    {
    }
}