using System.Runtime.CompilerServices;

namespace Motif.Is;

public static class Check
{
    public static Snippet That(
        Action snippet,
        [CallerArgumentExpression(nameof(snippet))] string subject = "") =>
        new(snippet, subject.StartsWith("() => ") ? subject[6..] : subject);
}
