Rules for anyone working on the Motif.Is.Core repo, on top of the [README](README.md), the [glossary](glossary.md) and [decisions.md](../decisions.md).

### Hard Rules
- Build each change specs first, in this order:
  1. Write the specs in the codebase: names that read as propositions (decision 5), and bodies written in the core (decision 15). Propositions noticed along the way, but not yet written, wait in a list of next specs, as proposed names.
  2. If the code they call doesn't exist yet, add just enough to build, with no behaviour.
  3. The owner reviews them in the codebase, as call-site examples, and sees them fail, for the right reason: with a failure that reads well, not some other exception. Add a spec to the failure gallery for each new kind of failure.
  4. Make them pass with the narrowest code that does, without changing them. If a spec seems wrong, take it back to the owner. If a new spec would pass without new code, the code had already gone further than its specs.
- The spec names are the list of what the code does. Read together, they should say it; if they don't, a spec is missing or misnamed. There's no behaviour checklist: the spec names stand in for it, wherever a role mentions one.
- Keep the public API to what [decisions.md](../decisions.md) agrees. A new public type or member needs a decision first: adding later is safe, taking away isn't.
