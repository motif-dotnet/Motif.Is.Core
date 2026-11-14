using System.Globalization;

namespace Motif.Is;

internal static class Formatter
{
    internal static string Show(object? item) => item switch
    {
        null => "null",
        bool b => b ? "true" : "false",
        string s => $"\"{s}\"",
        char c => $"'{c}'",
        decimal d => d.ToString(CultureInfo.InvariantCulture),
        _ when Sequence.TryGetItems(item, out var items) =>
            $"[{string.Join(", ", items.Select(Show))}]",
        _ => $"{item}",
    };
}
