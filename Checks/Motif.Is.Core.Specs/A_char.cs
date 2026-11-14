namespace A_char;

public sealed class in_a_failure
{
    [Fact]
    public void reads_in_single_quotes()
    {
        var grade = 'B';

        Check.That(() => grade.Is('A'))
            .Throws<Expected>()
            .Message.Is("`grade` to be 'A'\nbut it's 'B'.");
    }
}
