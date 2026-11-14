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
