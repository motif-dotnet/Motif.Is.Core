using System.Runtime.CompilerServices;

namespace Motif.Is;

// Later: a subject is passed around as a string, but rules for how it reads
// are gathering: here a snippet's "() => " is dropped, and Expected puts it
// in backticks. If a subject over several lines gets a rule of its own, a
// type for the subject may be worth it.
public static class Check
{
    private const string Lambda = "() => ";

    public static Snippet That(
        Action snippet,
        [CallerArgumentExpression(nameof(snippet))] string subject = "") =>
        new(snippet, subject.StartsWith(Lambda, StringComparison.Ordinal)
            ? subject[Lambda.Length..]
            : subject);
}
