namespace A_number;

public sealed class in_a_failure
{
    [Theory]
    [InlineData("fr-FR")] // writes a comma for the decimal point
    [InlineData("sv-SE")] // and also a minus sign, not a hyphen
    public void reads_the_same_in_any_culture(string culture)
    {
        var ratio = -2.5;
        var change = -3;

        using (Culture.Set(culture))
        {
            Check.That(() => ratio.Is(0.5))
                .Throws<Expected>()
                .Message.Is("`ratio` to be 0.5\nbut it's -2.5.");
            Check.That(() => change.Is(1))
                .Throws<Expected>()
                .Message.Is("`change` to be 1\nbut it's -3.");
        }
    }
}
