using System.Collections;
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
        if (!Same(found, claimed))
            throw new Expected(
                subject,
                expectation: $"to be {Show(claimed)}",
                found: $"it's {Show(found)}");
    }

    private static bool Same(object? found, object? claimed) =>
        found is IEnumerable foundItems && claimed is IEnumerable claimedItems
            ? SameItems(
                [.. foundItems.Cast<object?>()],
                [.. claimedItems.Cast<object?>()])
            : Equals(found, claimed);

    private static bool SameItems(object?[] found, object?[] claimed) =>
        found.Length == claimed.Length
        && found.Zip(claimed).All(pair => Same(pair.First, pair.Second));

    private static string Show(object? item) => item switch
    {
        null => "null",
        bool b => b ? "true" : "false",
        decimal d => d.ToString(CultureInfo.InvariantCulture),
        string s => s,
        IEnumerable items =>
            $"[{string.Join(", ", items.Cast<object?>().Select(Show))}]",
        _ => $"{item}",
    };
}
