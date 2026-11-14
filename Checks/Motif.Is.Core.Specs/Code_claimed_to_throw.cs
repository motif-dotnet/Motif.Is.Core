namespace Code_claimed_to_throw;

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
