namespace A_time;

public sealed class in_a_failure
{
    [Fact]
    public void reads_the_same_in_any_culture()
    {
        var opens = new TimeOnly(15, 49);

        using (Culture.Set("en-US")) // writes 3:49 PM
            Check.That(() => opens.Is(opens.AddHours(1)))
                .Throws<Expected>()
                .Message.Is("`opens` to be 16:49:00\nbut it's 15:49:00.");
    }

    [Fact]
    public void shows_fractions_of_a_second_only_when_not_zero()
    {
        var opens = new TimeOnly(15, 49);

        Check.That(() => opens.Is(opens.Add(TimeSpan.FromMilliseconds(250))))
            .Throws<Expected>()
            .Message.Is("`opens` to be 15:49:00.25\nbut it's 15:49:00.");
    }
}
