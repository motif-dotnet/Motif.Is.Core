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
        var expectation = $"to throw {typeof(TException).Name}";

        try
        {
            run();
        }
        catch (TException exception)
        {
            return exception;
        }
        catch (Exception other)
        {
            throw new Expected(
                subject,
                expectation,
                found: $"it threw {other.GetType().Name}",
                thrown: other);
        }

        throw new Expected(
            subject,
            expectation,
            found: "it didn't throw at all");
    }
}
