namespace Motif.Is;

// What a claim is about, as it's written in the spec.
internal sealed class Subject
{
    private const string Lambda = "() =>";

    private readonly string text;

    internal Subject(string text) => this.text = text;

    // A snippet's subject is its body, without the lambda's leading arrow,
    // which may end a line of its own.
    internal static Subject OfSnippet(string text) =>
        new(text.StartsWith(Lambda, StringComparison.Ordinal)
            ? text[Lambda.Length..].TrimStart()
            : text);

    public override string ToString() => $"`{OneLine()}`";

    // A subject written over several lines reads as it would on one, so the
    // failure keeps its two lines: no space before a line that starts with a
    // dot, one space before any other.
    private string OneLine()
    {
        var line = "";

        foreach (var part in text.Split('\n').Select(part => part.Trim()))
            if (part != "")
                line += line == "" || part.StartsWith('.') ? part : $" {part}";

        return line;
    }
}
