using System.Runtime.CompilerServices;
using System.Text;

namespace Motif.Is;

/// <summary>
/// What a claim expects, as it reads after "Expected" in a failure. Each
/// hole in a <c>$"…"</c> is written as the core writes what it claims and
/// finds.
/// </summary>
[InterpolatedStringHandler]
public sealed class Expectation
{
    private readonly StringBuilder text;

    public Expectation(int literalLength, int formattedCount) =>
        text = new(literalLength);

    private Expectation(string text) => this.text = new(text);

    // An expectation with nothing to fill in is a plain string.
    public static implicit operator Expectation(string text) => new(text);

    public void AppendLiteral(string literal) => text.Append(literal);

    public void AppendFormatted<T>(T item) =>
        text.Append(Formatter.Show(item));

    public override string ToString() => text.ToString();
}
