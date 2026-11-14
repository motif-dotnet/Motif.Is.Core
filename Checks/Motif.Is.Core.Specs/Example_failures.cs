namespace Example_failures;

// Every spec here fails on purpose, to show what its failure looks like in a
// test runner. CI leaves them out: dotnet test --filter "Kind!=FailureGallery"

[Trait("Kind", "FailureGallery")]
public sealed class Is
{
    [Fact]
    public void when_false()
    {
        var count = 3;

        count.Is(4);
    }

    [Fact]
    public void when_sequences_differ()
    {
        List<int>[] rows = [[1, 2], [3]];

        rows.Is([[1, 2], [4]]);
    }
}

[Trait("Kind", "FailureGallery")]
public sealed class Throws
{
    [Fact]
    public void when_nothing_is_thrown()
    {
        var count = 3;

        Check.That(() => count++).Throws<OverflowException>();
    }

    [Fact]
    public void when_something_else_is_thrown()
    {
        Check.That(() => int.Parse("abc")).Throws<ArgumentException>();
    }
}
