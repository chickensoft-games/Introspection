namespace Chickensoft.Introspection.Generator.Tests.TestCases;

using System.IO;
using Result = (int, string);

public static class UsingAmbiguity {
  // make sure tuple aliases don't interfere with using imports
  public static Result DoSomething() => (1, "Hello");

  public static void DoSomethingWithADisposable() {
    // make sure using statements don't interfere with using imports
    using var stream = new MemoryStream();
  }
}
