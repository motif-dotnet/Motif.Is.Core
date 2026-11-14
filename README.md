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

## How it's built

This repo is meant as an example of how Motif code is written. What's worth copying:

- **Specs first.** Each change starts with specs, seen failing, then the narrowest code that makes them pass. The steps are in [motif/memory.md](motif/memory.md).
- **Spec names that read as propositions**, across namespace, class and method: `A_sequence.in_a_failure.reads_as_its_items`. Read together, they say what the code does.
- **Specs as examples.** Apart from a few bootstrap specs, they're written with the core itself, so each one shows how it reads in use. The failure gallery fails on purpose, to show what each failure looks like.
- **Decisions with their reasons**, and what was turned down, in [decisions.md](decisions.md).
- **One set of words**, in code and docs alike, kept in [motif/glossary.md](motif/glossary.md) with the words to avoid.
- **The coding guidelines** from [Motif Memory](https://github.com/motif-dotnet/Motif.Memory/tree/main/Content/Guidelines): plain names in the domain's words, comments that say why, each piece of knowledge defined once, and lines of up to 80 columns.

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
