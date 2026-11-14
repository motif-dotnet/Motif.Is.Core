using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Motif.Is;

// Later: a subject is passed around as a string, but rules for how it reads
// are gathering: here a snippet's "() => " is dropped, and Expected puts it
// in backticks. If a subject over several lines gets a rule of its own, a
// type for the subject may be worth it.
public static partial class Check
{
    public static Snippet That(
        Action snippet,
        [CallerArgumentExpression(nameof(snippet))] string subject = "") =>
        new(snippet, Lambda().Replace(subject, ""));

    // Only the leading one, which may end a line of its own.
    [GeneratedRegex(@"^\(\)\s*=>\s*")]
    private static partial Regex Lambda();
}
