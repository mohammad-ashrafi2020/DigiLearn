namespace Common.Domain.Exceptions;

public class InvalidPhoneNumberException : BaseDomainException
{
    public InvalidPhoneNumberException()
    {
        
    }

    public InvalidPhoneNumberException(string message):base(message)
    {
        
    }
}