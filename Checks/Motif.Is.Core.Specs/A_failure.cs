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
