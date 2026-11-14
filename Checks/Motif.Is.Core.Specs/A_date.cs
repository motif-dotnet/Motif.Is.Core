namespace A_date;

public sealed class in_a_failure
{
    [Theory]
    [InlineData("en-US")] // writes the month first
    [InlineData("fr-FR")] // and the day first
    public void reads_in_ISO_order(string culture)
    {
        var due = new DateOnly(2026, 11, 14);
        var sent = new DateTime(2026, 11, 14, 15, 49, 0);
        var seen = new DateTimeOffset(sent, TimeSpan.FromHours(1));

        using (Culture.Set(culture))
        {
            Check.That(() => due.Is(due.AddDays(1)))
                .Throws<Expected>()
                .Message.Is("`due` to be 2026-11-15\nbut it's 2026-11-14.");
            Check.That(() => sent.Is(sent.AddHours(1)))
                .Throws<Expected>()
                .Message.Is(
                    "`sent` to be 2026-11-14 16:49:00\n" +
                    "but it's 2026-11-14 15:49:00.");
            Check.That(() => seen.Is(seen.AddHours(1)))
                .Throws<Expected>()
                .Message.Is(
                    "`seen` to be 2026-11-14 16:49:00+01:00\n" +
                    "but it's 2026-11-14 15:49:00+01:00.");
        }
    }
}
