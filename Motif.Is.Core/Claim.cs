namespace Motif.Is;

public static class Claim
{
    public static void That(
        string subject, bool holds, string expectation, object? found)
    {
        if (!holds)
            throw new Expected(
                subject, expectation, found: $"it's {Formatter.Show(found)}");
    }

    public static void That(
        string subject, bool holds, string expectation, string found)
    {
        if (!holds)
            throw new Expected(subject, expectation, found);
    }
}
