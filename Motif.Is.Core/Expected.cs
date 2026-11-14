namespace Motif;

/// <summary>
/// Thrown when a claim is false. Test runners print an exception's full type
/// name before its message, so the name starts the failure's sentence:
/// <c>Motif.Expected : `order.Placed` to be true</c>.
/// </summary>
public sealed class Expected : Exception
{
    internal Expected(string failure) : base(failure)
    {
    }
}
