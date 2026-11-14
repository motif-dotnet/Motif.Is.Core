using System.Globalization;

namespace A_decimal;

public sealed class in_a_failure
{
    [Fact]
    public void reads_as_written_in_any_culture()
    {
        var total = 12.50m;
        var culture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = new CultureInfo("fr-FR");

        try
        {
            Check.That(() => total.Is(3.00m))
                .Throws<Expected>()
                .Message.Is("`total` to be 3.00\nbut it's 12.50.");
        }
        finally
        {
            CultureInfo.CurrentCulture = culture;
        }
    }
}
