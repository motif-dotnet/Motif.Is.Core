namespace A_sequence;

public sealed class claimed_to_have_the_same_items
{
    [Fact]
    public void holds_whatever_the_collection_types()
    {
        IEnumerable<int> counts = new List<int> { 3, 4 };

        counts.Is([3, 4]);
    }
}

public sealed class of_sequences_claimed_to_have_the_same_items
{
    [Fact]
    public void holds()
    {
        List<int>[] rows = [[1, 2], [3]];

        rows.Is([[1, 2], [3]]);
    }
}

public sealed class in_a_failure
{
    [Fact]
    public void reads_as_its_items()
    {
        List<int> counts = [3, 4];

        Check.That(() => counts.Is([3, 5]))
            .Throws<Expected>()
            .Message.Is("`counts` to be [3, 5]\nbut it's [3, 4].");
    }

    [Fact]
    public void reads_as_its_items_all_the_way_down()
    {
        List<int>[] rows = [[1, 2], [3]];

        Check.That(() => rows.Is([[1, 2], [4]]))
            .Throws<Expected>()
            .Message.Is("`rows` to be [[1, 2], [4]]\nbut it's [[1, 2], [3]].");
    }
}
