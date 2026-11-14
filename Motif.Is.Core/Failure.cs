namespace Motif.Is;

// What a false claim reads as: its subject and expectation, then what was
// found. The core keeps no other record of a claim (decision 7).
internal sealed class Failure
{
    private readonly Subject subject;
    private readonly Expectation expectation;
    private readonly Found found;

    internal Failure(Subject subject, Expectation expectation, Found found)
    {
        this.subject = subject;
        this.expectation = expectation;
        this.found = found;
    }

    // Ends with a full stop, unless what was found already ends with one.
    public override string ToString() =>
        $"{subject} {expectation}\nbut {found}" +
        ($"{found}".EndsWith('.') ? "" : ".");
}
