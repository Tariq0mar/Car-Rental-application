namespace CarRentalApplication.DB.Exceptions;

public class UnauthorizedException<T> : Exception
{ 
    public UnauthorizedException(string action) 
        : base($"{typeof(T).Name} is Unauthorized to perform {action}")
    {
    }
}