namespace CarRentalApplication.DB.Exceptions;

public class BadRequestException<T> : Exception
{
    public BadRequestException() 
        : base($"{typeof(T).Name} request is invalid.")
    {
    }
}