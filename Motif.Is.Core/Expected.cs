namespace Motif;

/// <summary>
/// Thrown when a claim is false. Test runners print an exception's full type
/// name before its message, so the name starts the failure's sentence.
/// </summary>
public sealed class Expected : Exception, IAssertionException
{
    internal Expected(string subject, string expectation, string found)
        : base(Sentence(subject, expectation, found))
    {
    }

    internal Expected(
        string subject, string expectation, string found, Exception thrown)
        : base(Sentence(subject, expectation, found), thrown)
    {
    }

    private static string Sentence(
        string subject, string expectation, string found) =>
        $"`{subject}` {expectation}\nbut {found}.";
}
