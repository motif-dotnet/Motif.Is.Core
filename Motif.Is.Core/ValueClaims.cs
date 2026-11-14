using System.Runtime.CompilerServices;

namespace Motif.Is;

/// <summary>
/// Claims about values, as extensions on the value:
/// <c>order.Total.Is(11.25m)</c>.
/// </summary>
public static class ValueClaims
{
    public static void Is<T>(
        this T value,
        T other,
        [CallerArgumentExpression(nameof(value))] string subject = "")
    {
        if (!Equals(value, other))
            throw new Expected(
                $"`{subject}` to be {other}\nbut it's {value}.");
    }
}
