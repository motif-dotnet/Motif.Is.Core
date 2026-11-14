using System.Runtime.CompilerServices;

namespace Motif.Is;

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
