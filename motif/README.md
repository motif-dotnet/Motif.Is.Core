# motif/

This repo uses the [Motif.NET](https://github.com/motif-dotnet) conventions. This folder holds their files, for people and coding agents alike.

| File | What it is | Who changes it |
|---|---|---|
| [memory.md](memory.md) | The repo's memory: rules for anyone working on it, read by agents that use a Motif Memory and by anyone else | People and agents, by hand, with the owner's OK |
| [glossary.md](glossary.md) | The project's terms: what each word means, and which words to avoid | People and agents, by hand |

## For coding agents

1. **Read [memory.md](memory.md) and [glossary.md](glossary.md) first.** Use the glossary's terms in code, comments, docs and messages, and don't use the words it lists under **Avoid**. When you introduce a new concept, add an entry for it marked *proposed* in the same change. When something is renamed, rename its entry and move the old name to **Avoid**.
2. **Read [../decisions.md](../decisions.md)** for what's been decided and why, so you don't undo choices made on purpose.

## In this repo

Motif.Is.Core is a library, not an app, so there's no sketch, plan or diagrams here: Motif's sketch describes ports, adapters and external systems, and a library has almost none of those. Whether Motif's tools should cover a library is an open question ([motif-dotnet/.github#24](https://github.com/motif-dotnet/.github/issues/24)).
