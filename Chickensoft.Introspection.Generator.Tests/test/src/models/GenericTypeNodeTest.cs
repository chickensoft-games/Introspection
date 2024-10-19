namespace Chickensoft.Introspection.Generator.Tests.Models;

using System.Collections.Immutable;
using Chickensoft.Introspection.Generator.Models;
using Shouldly;
using Xunit;

public class TypeNodeTest {
  [Fact]
  public void Equality() {
    var node = new TypeNode(
      "Type", false, ImmutableArray<TypeNode>.Empty
    );

    node.Equals(null).ShouldBeFalse();
  }
}
