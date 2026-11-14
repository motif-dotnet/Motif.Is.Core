using System.Globalization;
using System.Runtime.CompilerServices;

namespace Motif.Is;

public static class Claims
{
    public static void Is<T>(
        this T found,
        T claimed,
        [CallerArgumentExpression(nameof(found))] string subject = "")
    {
        if (!Equals(found, claimed))
            throw new Expected(
                subject,
                expectation: $"to be {Show(claimed)}",
                found: $"it's {Show(found)}");
    }

    private static string Show(object? item) => item switch
    {
        null => "null",
        bool b => b ? "true" : "false",
        decimal d => d.ToString(CultureInfo.InvariantCulture),
        _ => $"{item}",
    };
}
