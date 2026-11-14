using System.Text.RegularExpressions;

namespace Motif.Is;

// How a subject, taken as its source text, reads in a failure.
internal static partial class Subject
{
    // A snippet's subject is its body, without the lambda's leading arrow,
    // which may end a line of its own.
    internal static string OfSnippet(string text) => Lambda().Replace(text, "");

    // In backticks, and on one line, so the failure keeps its two lines: no
    // space before a line that starts with a dot, one space before any other.
    internal static string InFailure(string text) =>
        $"`{LineBreak().Replace(text, Join)}`";

    private static string Join(Match line) =>
        line.Groups["dot"].Success ? "." : " ";

    [GeneratedRegex(@"^\(\)\s*=>\s*")]
    private static partial Regex Lambda();

    [GeneratedRegex(@"\s*\n\s*(?<dot>\.)?")]
    private static partial Regex LineBreak();
}
