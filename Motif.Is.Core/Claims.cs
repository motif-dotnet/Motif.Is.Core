using System.Runtime.CompilerServices;

namespace Motif.Is;

public static class Claims
{
    public static void Is<T>(
        this T found,
        T claimed,
        [CallerArgumentExpression(nameof(found))] string subject = "")
    {
        if (!Equals(found, claimed))
            throw new Expected(subject, $"to be {claimed}", $"it's {found}");
    }
}
