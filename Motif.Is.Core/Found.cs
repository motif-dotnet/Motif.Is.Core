using System.Runtime.CompilerServices;
using System.Text;

namespace Motif.Is;

/// <summary>
/// What a claim found, as a phrase of its own in place of "it's …". Each
/// hole in a <c>$"…"</c> is written as the core writes what it claims and
/// finds.
/// </summary>
// No conversion from a plain string, unlike Expectation's: a string passed as
// found is what was found, so it reads in quotes.
[InterpolatedStringHandler]
public sealed class Found
{
    private readonly StringBuilder text;

    public Found(int literalLength, int formattedCount) =>
        text = new(literalLength);

    public void AppendLiteral(string literal) => text.Append(literal);

    public void AppendFormatted<T>(T item) =>
        text.Append(Formatter.Show(item));

    public override string ToString() => text.ToString();
}
