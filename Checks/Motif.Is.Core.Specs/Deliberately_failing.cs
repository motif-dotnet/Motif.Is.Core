namespace Deliberately_failing;

// Every spec here fails on purpose, to show what failures look like in a
// test runner. CI leaves them out: dotnet test --filter "Kind!=FailureGallery"

[Trait("Kind", "FailureGallery")]
public sealed class claims
{
    [Fact]
    public void Is()
    {
        var count = 3;

        count.Is(4);
    }

    [Fact]
    public void Throws_when_nothing_is_thrown()
    {
        var count = 3;

        Check.That(() => count++).Throws<OverflowException>();
    }
}
