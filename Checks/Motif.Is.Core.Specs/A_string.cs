namespace A_string;

public sealed class in_a_failure
{
    [Fact]
    public void reads_as_itself_not_as_its_characters()
    {
        var word = "tea";

        Check.That(() => word.Is("cup"))
            .Throws<Expected>()
            .Message.Is("`word` to be cup\nbut it's tea.");
    }
}
