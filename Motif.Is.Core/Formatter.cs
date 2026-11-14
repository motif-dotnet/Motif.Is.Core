using System.Globalization;

namespace Motif.Is;

// Writes a claimed or found thing the same on any machine, so a failure reads
// the same locally and in CI.
internal static class Formatter
{
    private const string Date = "yyyy-MM-dd";

    // A fraction of a second shows only when it isn't zero, with as many
    // digits as it needs, so two different times never read the same.
    private const string Time = "HH:mm:ss.FFFFFFF";

    internal static string Show(object? item) => item switch
    {
        null => "null",
        bool b => b ? "true" : "false",
        string s => $"\"{s}\"",
        char c => $"'{c}'",
        DateOnly d => Write(d, Date),
        TimeOnly t => Write(t, Time),
        DateTime d => Write(d, $"{Date} {Time}"),
        DateTimeOffset d => Write(d, $"{Date} {Time}zzz"),
        _ when Sequence.TryGetItems(item, out var items) =>
            $"[{string.Join(", ", items.Select(Show))}]",
        // Without a format of its own, a number reads as it's written in code.
        IFormattable f => f.ToString(null, CultureInfo.InvariantCulture),
        _ => $"{item}",
    };

    private static string Write(IFormattable item, string format) =>
        item.ToString(format, CultureInfo.InvariantCulture);
}
