namespace Motif.Is;

public static class Claim
{
    public static void That(
        string subject, bool holds, Expectation expectation, object? found)
    {
        if (!holds)
            throw new Expected(
                subject, $"{expectation}", $"it's {Formatter.Show(found)}");
    }

    public static void That(
        string subject, bool holds, Expectation expectation, Found found)
    {
        if (!holds)
            throw new Expected(subject, $"{expectation}", $"{found}");
    }
}
