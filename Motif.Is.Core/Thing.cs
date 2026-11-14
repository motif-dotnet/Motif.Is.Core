using System.Collections;
using System.Globalization;

namespace Motif.Is;

// Something claimed or found. It knows whether it has items, when it's the
// same as another, and how it reads, the same on any machine, so a failure
// reads the same locally and in CI.
internal sealed class Thing
{
    private const string Date = "yyyy-MM-dd";

    // A fraction of a second shows only when it isn't zero, with as many
    // digits as it needs, so two different times never read the same.
    private const string Time = "HH:mm:ss.FFFFFFF";

    private readonly object? item;
    private readonly bool hasItems;
    private readonly Thing[] items;

    internal Thing(object? item)
    {
        this.item = item;

        // A string has items too, its characters, but compares and reads
        // whole.
        if (item is IEnumerable sequence and not string)
        {
            hasItems = true;
            items = [.. sequence.Cast<object?>().Select(Read)];
        }
        else
            items = [];
    }

    // Item by item, so a list is the same as an array with the same items.
    internal bool IsSameAs(Thing other) =>
        hasItems && other.hasItems
            ? HasSameItemsAs(other)
            : Equals(item, other.item);

    public override string ToString() => item switch
    {
        null => "null",
        bool b => b ? "true" : "false",
        string s => $"\"{s}\"",
        char c => $"'{c}'",
        Type t => t.Name,
        DateOnly d => Write(d, Date),
        TimeOnly t => Write(t, Time),
        DateTime d => Write(d, $"{Date} {Time}"),
        DateTimeOffset d => Write(d, $"{Date} {Time}zzz"),
        _ when hasItems => $"[{string.Join(", ", items.AsEnumerable())}]",
        // Without a format of its own, a number reads as it's written in code.
        IFormattable f => f.ToString(null, CultureInfo.InvariantCulture),
        _ => $"{item}",
    };

    private bool HasSameItemsAs(Thing other) =>
        items.Length == other.items.Length
        && items.Zip(other.items).All(pair => pair.First.IsSameAs(pair.Second));

    private static Thing Read(object? item) => new(item);

    private static string Write(IFormattable item, string format) =>
        item.ToString(format, CultureInfo.InvariantCulture);
}
