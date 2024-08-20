namespace Chickensoft.Introspection.Generator.Tests.TestCases;

[Meta]
public abstract partial record SetOnlyProperty {
  // No getter.
  public string Value { set { } }
}
