namespace Core.CrossCuttingConcerns.Exceptions;

public class RegistrationFailedException : Exception
{
    public RegistrationFailedException(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public IEnumerable<string> Errors { get; }
}