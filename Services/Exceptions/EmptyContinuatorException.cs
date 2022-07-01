namespace Services.Exceptions;

public class EmptyContinuatorException : Exception
{
    public EmptyContinuatorException(): base("Producer return empty continuator") { }
}