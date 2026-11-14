using AwesomeAssertions;

namespace A_claim;

public sealed class that_is_false
{
    // BOOTSTRAP: AwesomeAssertions, not the core, because every other spec
    // relies on a false claim throwing.
    [Fact]
    public void throws_Expected()
    {
        var count = 3;

        var claim = () => count.Is(4);

        claim.Should().Throw<Expected>();
    }
}
