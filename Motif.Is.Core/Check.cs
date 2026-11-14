using System.Runtime.CompilerServices;

namespace Motif.Is;

public static class Check
{
    public static Code That(
        Action code,
        [CallerArgumentExpression(nameof(code))] string subject = "") =>
        new(code, subject.Replace("() => ", ""));
}
