namespace A_bool;

public sealed class in_a_failure
{
    [Fact]
    public void reads_in_lower_case()
    {
        var placed = false;

        Check.That(() => placed.Is(true))
            .Throws<Expected>()
            .Message.Is("`placed` to be true\nbut it's false.");
    }
}
