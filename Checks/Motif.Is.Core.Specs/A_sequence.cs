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
