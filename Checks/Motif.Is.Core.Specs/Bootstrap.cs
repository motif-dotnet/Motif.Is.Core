using AwesomeAssertions;

// Bootstrap specs use AwesomeAssertions, not the core, because every other
// spec relies on what they prove.

namespace Bootstrap;

public sealed class A_claim_that_is_false
{
    [Fact]
    public void throws_Expected()
    {
        var count = 3;

        var claim = () => count.Is(4);

        claim.Should().Throw<Expected>();
    }
}

public sealed class Code_claimed_to_throw_that_throws
{
    [Fact]
    public void hands_back_what_it_threw()
    {
        var exception = new InvalidOperationException();

        var handedBack =
            Check.That(() => throw exception).Throws<InvalidOperationException>();

        handedBack.Should().BeSameAs(exception);
    }
}
