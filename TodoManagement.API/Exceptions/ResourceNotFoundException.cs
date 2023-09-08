namespace TodoManagement.API.Exceptions;

public class ResourceNotFoundException : DomainException
{
    public ResourceNotFoundException(string? message) : base(message, 404)
    {
    }
}