Rules for anyone working on the Motif.Is.Core repo, on top of the [README](README.md), the [glossary](glossary.md) and [decisions.md](../decisions.md).

### Hard Rules
- Build each change specs first, in this order:
  1. Write the specs: names that read as propositions (decision 5), and their bodies, written in the core (decision 15).
  2. The owner reviews them as call-site examples, before any code exists.
  3. Run them to show they fail for the right reason: with a failure that reads well, not some other exception. Add a spec to the failure gallery for each new kind of failure.
  4. Make them pass without changing them. If a spec seems wrong, take it back to the owner rather than changing it.
- The spec names are the list of what the code does. Read together, they should say it; if they don't, a spec is missing or misnamed.
- Keep the public API to what [decisions.md](../decisions.md) agrees. A new public type or member needs a decision first: adding later is safe, taking away isn't.
