using System.Globalization;

// Runs a spec's claims in another culture, and puts the old one back after.
internal sealed class Culture : IDisposable
{
    private readonly CultureInfo previous = CultureInfo.CurrentCulture;

    private Culture(string name) =>
        CultureInfo.CurrentCulture = new CultureInfo(name);

    public static Culture Set(string name) => new(name);

    public void Dispose() => CultureInfo.CurrentCulture = previous;
}
