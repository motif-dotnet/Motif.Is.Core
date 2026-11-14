using Motif.Is;

namespace Motif;

/// <summary>
/// Thrown when a claim is false. Test runners print an exception's full type
/// name before its message, so the name starts the failure's sentence.
/// </summary>
public sealed class Expected : Exception, IAssertionException
{
    internal Expected(Failure failure)
        : base($"{failure}")
    {
    }

    internal Expected(Failure failure, Exception thrown)
        : base($"{failure}", thrown)
    {
    }
}
