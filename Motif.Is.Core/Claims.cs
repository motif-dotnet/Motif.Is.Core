using System.Runtime.CompilerServices;

namespace Motif.Is;

public static class Claims
{
    public static void Is<T>(
        this T found,
        T claimed,
        [CallerArgumentExpression(nameof(found))] string subject = "") =>
        Claim.That(
            subject,
            Comparison.Same(found, claimed),
            $"to be {Formatter.Show(claimed)}",
            found: found);
}
