# Motif.Is.Core

The small, stable core of **[Motif.Is](https://github.com/motif-dotnet/Motif.Is)**, in the **[Motif.NET](https://github.com/motif-dotnet)** suite. Specs state facts, not what things *should* be:

```csharp
order.Total.Is(11.25m);
Check.That(() => order.Place()).Throws<InvalidOperationException>();
```

A false claim fails with a sentence:

```
Motif.Expected : `order.Total` to be 11.25
but it's 7.00.
```

The core has two claims, `Is` and `Throws`, and one way to make your own, which they use too:

```csharp
public static void IsTrue(this bool found,
    [CallerArgumentExpression(nameof(found))] string subject = "")
    => Claim.That(subject, holds: found, expectation: "to be true", found: found);
```

Motif.Is builds its other claims on the core in that way. Specs say `using Motif.Is;` whichever of the two they use.

## Status

**Trial, not yet in use.** The first slice is in: `Is` for single things and for sequences, and `Throws`, with failures that read as sentences. No release has gone to a Motif repo's feed yet, and Motif.Is isn't built on it yet. Not on NuGet: early releases go to Motif's own repos through a local feed, and nuget.org comes once the API has stood up to real use.

The project's terms are in [motif/glossary.md](motif/glossary.md).

## Build and run

You need the .NET 10 SDK.

```
dotnet test --filter "Kind!=FailureGallery"   # the specs
dotnet test --filter "Kind=FailureGallery"    # the failure gallery: every spec fails, on purpose
```

## Contributing

Bug reports, suggestions and pull requests are welcome; [CONTRIBUTING.md](https://github.com/motif-dotnet/.github/blob/main/CONTRIBUTING.md) says how. For ideas and questions, start a thread in [Discussions](https://github.com/motif-dotnet/.github/discussions).

## License

MIT, see [LICENSE](LICENSE).
