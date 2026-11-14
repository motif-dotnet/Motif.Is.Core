namespace Motif.Is;

internal static class Comparison
{
    // Item by item, so a list is the same as an array with the same items.
    internal static bool Same(object? found, object? claimed) =>
        Sequence.TryGetItems(found, out var foundItems)
        && Sequence.TryGetItems(claimed, out var claimedItems)
            ? SameItems(foundItems, claimedItems)
            : Equals(found, claimed);

    private static bool SameItems(object?[] found, object?[] claimed) =>
        found.Length == claimed.Length
        && found.Zip(claimed).All(pair => Same(pair.First, pair.Second));
}
