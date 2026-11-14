namespace Motif.Is;

public sealed class Code
{
    private readonly Action code;
    private readonly string subject;

    internal Code(Action code, string subject)
    {
        this.code = code;
        this.subject = subject;
    }

    public TException Throws<TException>() where TException : Exception
    {
        try
        {
            code();
        }
        catch (TException exception)
        {
            return exception;
        }

        throw new Expected(
            subject, $"to throw {typeof(TException).Name}", "it threw nothing");
    }
}
