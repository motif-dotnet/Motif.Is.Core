using System.Collections;

namespace Motif.Is;

// Later: Sequence, Comparison and Formatter each ask what a claimed or found
// thing is, which hints at an object for it that knows whether it has items,
// when it's the same as another, and how it reads. Claim.That, the formatter's
// second user, should show its shape.
internal static class Sequence
{
    // A string has items too, its characters, but compares and reads whole.
    internal static bool TryGetItems(object? candidate, out object?[] items)
    {
        if (candidate is IEnumerable sequence and not string)
        {
            items = [.. sequence.Cast<object?>()];
            return true;
        }

        items = [];
        return false;
    }
}
