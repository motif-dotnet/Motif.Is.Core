# Glossary

The words this project uses, and what they mean. People and agents use these terms in code, docs, issues and discussion, and avoid the words listed under **Avoid**. A new concept gets an entry, marked *proposed*, in the same change that introduces it. An entry with no status is agreed.

The format is described in the [Motif Glossary design note](https://github.com/motif-dotnet/.github/blob/main/design/glossary.md). Motif.Is.Core is a library with no sketch, so no entry has a **Sketch** field, and almost every term is a *domain concept*. The terms come from [Motif.Is](https://github.com/motif-dotnet/Motif.Is)'s glossary, and are all *proposed* here until the code uses them.

## Bootstrap spec

One of the few specs written with plain xUnit `Assert` rather than the core, marked `// BOOTSTRAP`. Together they prove that a false claim throws and that `Throws` catches, which every other spec relies on.

- **Kind:** domain concept
- **Status:** proposed
- **See also:** [Self-hosted](#self-hosted)

## Claim

What a spec states about a subject: that it is a value, or that code throws an exception. A claim either holds or is false. Claims about values are extensions on the value; claims about code go through `Check.That`. New claims are made with `Claim.That`.

- **Kind:** domain concept
- **Status:** proposed
- **Avoid:** assertion (except when comparing with other libraries), should
- **In code:** `Claim.That`
- **See also:** [Subject](#subject)

## Code

Code that a spec makes a claim about, given to `Check.That` as a lambda: `Check.That(() => order.Place())`.

- **Kind:** domain concept
- **Status:** proposed
- **Avoid:** action (it's an `Action` in C#, but not in prose)
- **In code:** `Check.That`

## Expectation

A claim as it reads after "Expected" in a failure: *to be*, *to throw*.

- **Kind:** domain concept
- **Status:** proposed
- **See also:** [Failure](#failure)

## Expected

The exception thrown when a claim is false. Test runners print its full type name, `Motif.Expected`, before the message, so the name starts the failure's sentence.

- **Kind:** domain concept
- **Status:** proposed
- **In code:** `Motif.Expected`

## Failure

The message of a false claim: the subject and its expectation, then what was found. ``Motif.Expected : `order.Placed` to be true`` / `but it's false.`

- **Kind:** domain concept
- **Status:** proposed
- **Avoid:** error (an error is a spec that breaks, not a claim that's false)
- **See also:** [Found](#found)

## Found

What was there instead of what was claimed, as a phrase that follows "but": *it's 7.00*, *it threw nothing*.

- **Kind:** domain concept
- **Status:** proposed
- **Avoid:** actual

## Holds

Said of a claim that is true.

- **Kind:** domain concept
- **Status:** proposed
- **Avoid:** passes (a spec passes; a claim holds)

## Motif.Is.Core

This library: the small, stable core that Motif.Is is built on. Its namespace is `Motif.Is`.

- **Kind:** system
- **Status:** proposed
- **Avoid:** Isly

## Proposition

A claim kept as structure (subject, claim, expectation, value, whether it holds, and what was found), from which its failure is made. Internal to the core for now.

- **Kind:** domain concept
- **Status:** proposed

## Self-hosted

Said of the core's own specs: they're written in the core, apart from the bootstrap specs.

- **Kind:** domain concept
- **Status:** proposed
- **See also:** [Bootstrap spec](#bootstrap-spec)

## Spec

An automated check of what the code does, named as a proposition across namespace, class and method.

- **Kind:** domain concept
- **Status:** proposed
- **Avoid:** test (except for test runners and frameworks), unit test
- **See also:** [Claim](#claim)

## Subject

What a claim is about, as written in the spec: `order.Total`, `order.Place()`. Taken from the source text by `CallerArgumentExpression`.

- **Kind:** domain concept
- **Status:** proposed

## Value

The claim's object, shown as text: the 11.25 in "is 11.25".

- **Kind:** domain concept
- **Status:** proposed
- **Avoid:** expected value
