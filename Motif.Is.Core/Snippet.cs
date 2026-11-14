namespace Motif.Is;

public sealed class Snippet
{
    private readonly Action run;
    private readonly Subject subject;

    internal Snippet(Action run, Subject subject)
    {
        this.run = run;
        this.subject = subject;
    }

    // Not made with Claim.That, as Is is: it hands back what was thrown, and
    // keeps anything else thrown as the inner exception, which Claim.That
    // can't. How a claim about a snippet is made waits for a second one,
    // such as Motif.Is's exact-type claim.
    public TException Throws<TException>() where TException : Exception
    {
        Expectation expectation = $"to throw {typeof(TException)}";

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
                new Failure(
                    subject,
                    expectation,
                    found: $"it threw {other.GetType()}"),
                thrown: other);
        }

        throw new Expected(
            new Failure(
                subject,
                expectation,
                found: $"it didn't throw at all"));
    }
}
