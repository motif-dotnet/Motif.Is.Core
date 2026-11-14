namespace A_snippet_claimed_to_throw;

public sealed class that_does_not_throw
{
    [Fact]
    public void throws_Expected_saying_so()
    {
        var count = 3;
        var incrementing = Check.That(() => count++);

        Check.That(() => incrementing.Throws<OverflowException>())
            .Throws<Expected>()
            .Message.Is(
                "`count++` to throw OverflowException\n" +
                "but it didn't throw at all.");
    }
}

public sealed class with_a_lambda_inside
{
    [Fact]
    public void appears_in_the_failure_as_written()
    {
        var count = 3;
        var incrementing = Check.That(() => Parallel.Invoke(() => count++));

        Check.That(() => incrementing.Throws<OverflowException>())
            .Throws<Expected>()
            .Message.Is(
                "`Parallel.Invoke(() => count++)` to throw OverflowException\n" +
                "but it didn't throw at all.");
    }
}

public sealed class over_several_lines
{
    [Fact]
    public void appears_in_the_failure_on_one_line()
    {
        var count = 3;
        var incrementing = Check.That(() =>
            count++);

        Check.That(() => incrementing.Throws<OverflowException>())
            .Throws<Expected>()
            .Message.Is(
                "`count++` to throw OverflowException\n" +
                "but it didn't throw at all.");
    }
}

public sealed class that_throws_something_else
{
    [Fact]
    public void throws_Expected_saying_what()
    {
        var parsing = Check.That(() => int.Parse("abc"));

        Check.That(() => parsing.Throws<ArgumentException>())
            .Throws<Expected>()
            .Message.Is(
                "`int.Parse(\"abc\")` to throw ArgumentException\n" +
                "but it threw FormatException.");
    }

    [Fact]
    public void keeps_what_it_threw_as_the_inner_exception()
    {
        var thrown = new FormatException();
        var parsing = Check.That(() => throw thrown);

        Check.That(() => parsing.Throws<ArgumentException>())
            .Throws<Expected>()
            .InnerException.Is(thrown);
    }
}

public sealed class a_base_type
{
    [Fact]
    public void holds_when_it_throws_a_subtype()
    {
        Check.That(() => throw new ArgumentNullException())
            .Throws<ArgumentException>();
    }
}
