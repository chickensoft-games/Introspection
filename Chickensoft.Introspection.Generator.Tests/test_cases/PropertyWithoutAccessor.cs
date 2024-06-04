namespace Chickensoft.Introspection.Generator.Tests.TestCases;

[Meta]
public abstract partial record PropertyModel {
  // No accessor list.
  public string Value => "Hello, introspection.";
}
