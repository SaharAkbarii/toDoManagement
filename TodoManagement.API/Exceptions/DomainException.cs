namespace TodoManagement.API.Exceptions;

public class DomainException : Exception
{
    public DomainException(string? message, int code) : base(message)
    {
        Code = code;
    }

    public int Code {get; set;}
}
