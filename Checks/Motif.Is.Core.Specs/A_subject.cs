namespace A_subject;

public sealed class claimed_to_be_what_it_is
{
    [Fact]
    public void holds()
    {
        var count = 3;

        count.Is(3);
    }
}

public sealed class claimed_to_be_null
{
    [Fact]
    public void holds_when_it_is()
    {
        int? discount = null;

        discount.Is(null);
    }
}

public sealed class claimed_to_be_something_else
{
    [Theory]
    [InlineData(3, 4, "`count` to be 4\nbut it's 3.")]
    [InlineData(7, 2, "`count` to be 2\nbut it's 7.")]
    public void throws_Expected_saying_what_it_is(
        int count, int claimed, string failure)
    {
        Check.That(() => count.Is(claimed))
            .Throws<Expected>()
            .Message.Is(failure);
    }

    [Fact]
    public void appears_in_the_failure_as_written()
    {
        var word = "tea";

        Check.That(() => word.Length.Is(4))
            .Throws<Expected>()
            .Message.Is("`word.Length` to be 4\nbut it's 3.");
    }
}
