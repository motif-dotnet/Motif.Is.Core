namespace Motif;

// xUnit v3 counts an exception as a false claim, not an error, when it
// implements an interface of this name from any namespace, so the name keeps
// the I that the core's other names drop (decision 3).
internal interface IAssertionException
{
}
