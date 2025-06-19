namespace CarRentalApplication.DB.Exceptions;

public class BadRequestException<T> : Exception
{
    public BadRequestException(string message) 
        : base($"{typeof(T).Name} request is invalid. \n {message}")
    {
    }
}