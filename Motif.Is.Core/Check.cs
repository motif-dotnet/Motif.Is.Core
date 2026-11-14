using System.Runtime.CompilerServices;

namespace Motif.Is;

/// <summary>
/// Claims about code:
/// <c>Check.That(() => order.Place()).Throws&lt;InvalidOperationException&gt;()</c>.
/// </summary>
public static class Check
{
    public static Code That(
        Action code,
        [CallerArgumentExpression(nameof(code))] string subject = "") =>
        new(code, subject.Replace("() => ", ""));
}

/// <summary>
/// Code that a spec makes a claim about.
/// </summary>
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
