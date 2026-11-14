using AwesomeAssertions;

// Bootstrap specs use AwesomeAssertions, not the core, because every other
// spec relies on what they prove.

namespace Bootstrap.A_claim;

public sealed class that_is_false
{
    [Fact]
    public void throws_Expected()
    {
        var count = 3;

        var claim = () => count.Is(4);

        claim.Should().Throw<Expected>();
    }
}
