using AwesomeAssertions;

// Bootstrap specs use AwesomeAssertions, not the core, because every other
// spec relies on what they prove.

namespace Bootstrap.Code_claimed_to_throw;

public sealed class that_throws
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
