namespace Motif.Is;

public static class Claim
{
    public static void That(
        string subject, bool holds, Expectation expectation, object? found) =>
        That(subject, holds, expectation, found: $"it's {found}");

    public static void That(
        string subject, bool holds, Expectation expectation, Found found)
    {
        if (!holds)
            throw new Expected(new Failure(
                new Subject(subject), expectation, found));
    }
}
