namespace A_string;

public sealed class in_a_failure
{
    [Fact]
    public void reads_whole()
    {
        var word = "tea";

        Check.That(() => word.Is("cup"))
            .Throws<Expected>()
            .Message.Is("`word` to be cup\nbut it's tea.");
    }
}
