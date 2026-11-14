using System.Text.RegularExpressions;

namespace Motif;

/// <summary>
/// Thrown when a claim is false. Test runners print an exception's full type
/// name before its message, so the name starts the failure's sentence.
/// </summary>
public sealed partial class Expected : Exception, IAssertionException
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
        $"`{OneLine(subject)}` {expectation}\nbut {found}.";

    // A subject written over several lines reads as it would on one, so the
    // failure keeps its two lines: no space before a line that starts with a
    // dot, one space before any other.
    private static string OneLine(string subject) =>
        LineBreak().Replace(
            subject, line => line.Groups["dot"].Success ? "." : " ");

    [GeneratedRegex(@"\s*\n\s*(?<dot>\.)?")]
    private static partial Regex LineBreak();
}
