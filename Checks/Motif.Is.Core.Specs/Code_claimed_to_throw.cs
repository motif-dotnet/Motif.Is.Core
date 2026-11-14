using AwesomeAssertions;

namespace Code_claimed_to_throw;

public sealed class that_throws
{
    // BOOTSTRAP: AwesomeAssertions, not the core, because every spec of a
    // false claim relies on Throws catching.
    [Fact]
    public void hands_back_what_it_threw()
    {
        var exception = new InvalidOperationException();

        var handedBack =
            Check.That(() => throw exception).Throws<InvalidOperationException>();

        handedBack.Should().BeSameAs(exception);
    }
}

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
                "`count++` to throw OverflowException\nbut it threw nothing.");
    }
}
