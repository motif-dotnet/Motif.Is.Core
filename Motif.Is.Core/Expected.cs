namespace Motif;

/// <summary>
/// Thrown when a claim is false. Test runners print an exception's full type
/// name before its message, so the name starts the failure's sentence.
/// </summary>
public sealed class Expected : Exception
{
    internal Expected(string subject, string expectation, string found)
        : base($"`{subject}` {expectation}\nbut {found}.")
    {
    }
}
