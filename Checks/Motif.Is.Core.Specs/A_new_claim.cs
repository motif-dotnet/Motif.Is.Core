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

public sealed class with_a_word_in_its_expectation
{
    [Fact]
    public void shows_it_in_quotes()
    {
        var drink = "milk";

        Check.That(() => drink.IsOneOf(["tea", "cup"]))
            .Throws<Expected>()
            .Message.Is(
                "`drink` to be one of [\"tea\", \"cup\"]\n" +
                "but it's \"milk\".");
    }
}

public sealed class with_a_word_as_its_found
{
    [Fact]
    public void shows_it_in_quotes_not_as_a_phrase()
    {
        var drink = "milk";

        Check.That(() => drink.IsShorterThan(3))
            .Throws<Expected>()
            .Message.Is("`drink` to be shorter than 3\nbut it's \"milk\".");
    }
}

public sealed class with_a_number_in_its_found
{
    [Fact]
    public void writes_it_the_same_in_any_culture()
    {
        double[] ratios = [2, 3];

        using (Culture.Set("fr-FR")) // writes a comma for the decimal point
            Check.That(() => ratios.HasAverage(0.5))
                .Throws<Expected>()
                .Message.Is(
                    "`ratios` to have an average of 0.5\n" +
                    "but its average is 2.5.");
    }
}

public sealed class with_a_type_in_its_expectation
{
    [Fact]
    public void shows_its_name()
    {
        object count = 3;

        Check.That(() => count.IsOfType<string>())
            .Throws<Expected>()
            .Message.Is(
                "`count` to be of type String\n" +
                "but it's of type Int32.");
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

    public static void IsOneOf<T>(
        this T found,
        T[] options,
        [CallerArgumentExpression(nameof(found))] string subject = "") =>
        Claim.That(
            subject,
            options.Contains(found),
            $"to be one of {options}",
            found: found);

    public static void IsShorterThan(
        this string found,
        int length,
        [CallerArgumentExpression(nameof(found))] string subject = "") =>
        Claim.That(
            subject,
            found.Length < length,
            $"to be shorter than {length}",
            found: found);

    public static void HasAverage(
        this IEnumerable<double> items,
        double average,
        [CallerArgumentExpression(nameof(items))] string subject = "")
    {
        var found = items.Average();

        Claim.That(
            subject,
            found == average,
            $"to have an average of {average}",
            found: $"its average is {found}");
    }

    public static void IsOfType<T>(
        this object found,
        [CallerArgumentExpression(nameof(found))] string subject = "") =>
        Claim.That(
            subject,
            found is T,
            $"to be of type {typeof(T)}",
            found: $"it's of type {found.GetType()}");
}
