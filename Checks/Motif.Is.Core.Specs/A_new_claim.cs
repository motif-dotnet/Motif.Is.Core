using System.Runtime.CompilerServices;

namespace A_new_claim;

public sealed class that_is_true
{
    [Fact]
    public void holds()
    {
        var count = 4;

        count.IsEven();
    }
}

public sealed class that_is_false
{
    [Fact]
    public void throws_Expected_saying_what_it_found()
    {
        var count = 3;

        Check.That(() => count.IsEven())
            .Throws<Expected>()
            .Message.Is("`count` to be even\nbut it's 3.");
    }
}

public sealed class with_its_own_found
{
    [Fact]
    public void throws_Expected_saying_it()
    {
        List<string> drinks = ["tea", "coffee"];

        Check.That(() => drinks.HasCount(3))
            .Throws<Expected>()
            .Message.Is("`drinks` to have 3 items\nbut it has 2 items.");
    }
}

// Claims as someone building on the core would write them.
internal static class NewClaims
{
    public static void IsEven(
        this int found,
        [CallerArgumentExpression(nameof(found))] string subject = "") =>
        Claim.That(subject, found % 2 == 0, "to be even", found: found);

    public static void HasCount<T>(
        this IEnumerable<T> items,
        int count,
        [CallerArgumentExpression(nameof(items))] string subject = "")
    {
        var found = items.Count();

        Claim.That(
            subject,
            found == count,
            $"to have {count} items",
            found: $"it has {found} items");
    }
}
