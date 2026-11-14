namespace A_decimal;

public sealed class in_a_failure
{
    [Theory]
    [InlineData("fr-FR")] // writes a comma for the decimal point
    [InlineData("sv-SE")] // and also a minus sign, not a hyphen
    public void reads_as_written_in_any_culture(string culture)
    {
        var total = -12.50m;

        using (Culture.Set(culture))
            Check.That(() => total.Is(3.00m))
                .Throws<Expected>()
                .Message.Is("`total` to be 3.00\nbut it's -12.50.");
    }
}
