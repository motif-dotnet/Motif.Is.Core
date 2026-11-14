using Xunit.Sdk;

namespace A_failure;

public sealed class in_xUnit
{
    [Fact]
    public void counts_as_an_assertion_not_an_error()
    {
        var count = 3;
        var failure = Check.That(() => count.Is(4)).Throws<Expected>();

        ExceptionUtility.ExtractMetadata(failure).Cause
            .Is(FailureCause.Assertion);
    }
}

public sealed class whose_found_ends_with_a_full_stop
{
    [Fact]
    public void adds_no_other()
    {
        var hour = 3;

        Check.That(() => Claim.That(
                "letter", false, "to be sent in the morning",
                found: $"it was sent at {hour} p.m."))
            .Throws<Expected>()
            .Message.Is(
                "`letter` to be sent in the morning\n" +
                "but it was sent at 3 p.m.");
    }
}
