namespace Motif.Is;

public sealed class Snippet
{
    private readonly Action run;
    private readonly string subject;

    internal Snippet(Action run, string subject)
    {
        this.run = run;
        this.subject = subject;
    }

    public TException Throws<TException>() where TException : Exception
    {
        try
        {
            run();
        }
        catch (TException exception)
        {
            return exception;
        }

        throw new Expected(
            subject,
            expectation: $"to throw {typeof(TException).Name}",
            found: "it didn't throw at all");
    }
}
