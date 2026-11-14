using System.Runtime.CompilerServices;

namespace Motif.Is;

public static class Claims
{
    public static void Is<T>(
        this T found,
        T claimed,
        [CallerArgumentExpression(nameof(found))] string subject = "")
    {
        if (!Comparison.Same(found, claimed))
            throw new Expected(
                subject,
                expectation: $"to be {Formatter.Show(claimed)}",
                found: $"it's {Formatter.Show(found)}");
    }
}
