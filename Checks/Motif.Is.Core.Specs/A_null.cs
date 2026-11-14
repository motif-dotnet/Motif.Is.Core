namespace A_null;

public sealed class in_a_failure
{
    [Theory]
    [InlineData(null, 5, "`discount` to be 5\nbut it's null.")]
    [InlineData(5, null, "`discount` to be null\nbut it's 5.")]
    public void reads_as_null(int? discount, int? claimed, string failure)
    {
        Check.That(() => discount.Is(claimed))
            .Throws<Expected>()
            .Message.Is(failure);
    }
}
