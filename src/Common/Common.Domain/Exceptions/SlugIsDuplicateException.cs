namespace Common.Domain.Exceptions;

public class SlugIsDuplicateException : BaseDomainException
{
    public SlugIsDuplicateException() : base("slug تکراری است")
    {
    }

    public SlugIsDuplicateException(string message) : base(message)
    {
    }
}