namespace Chickensoft.Introspection.Generator.Tests.Models;

using System.Collections.Generic;
using Chickensoft.Introspection.Generator.Models;
using Shouldly;
using Xunit;

public class DeclaredTypeRegistryTest
{
  [Fact]
  public void Equality()
  {
    var registry = new DeclaredTypeRegistry(
      globalUsings: [],
      scopeTree: new ScopeTree([], new Dictionary<string, DeclaredType>()),
      allTypes: [],
      visibleTypes: []
    );

    registry.GetHashCode().ShouldBeOfType<int>();

    registry.Equals(null).ShouldBeFalse();

    registry.ShouldBe(
      new DeclaredTypeRegistry(
        globalUsings: [],
        scopeTree: new ScopeTree(
          [], new Dictionary<string, DeclaredType>()
        ),
        allTypes: [],
        visibleTypes: []
      )
    );

    new DeclaredTypeRegistry(
      globalUsings: [],
      scopeTree: new ScopeTree([], new Dictionary<string, DeclaredType>()),
      allTypes: [],
      visibleTypes: []
    ).ShouldNotBe(
      new DeclaredTypeRegistry(
        globalUsings: [],
        scopeTree: new ScopeTree(
          [], new Dictionary<string, DeclaredType>()
        ),
        allTypes: [],
        visibleTypes:
        [
          new(
            Reference: new TypeReference(
              "a",
              Construction: Construction.Class,
              IsPartial: false,
              TypeParameters: []
            ),
            SyntaxLocation: Microsoft.CodeAnalysis.Location.None,
            Location: new TypeLocation(
              Namespaces: [],
              ContainingTypes: []
            ),
            BaseType: null,
            Usings: [],
            Kind: DeclaredTypeKind.ConcreteType,
            IsStatic: false,
            IsPublicOrInternal: true,
            Properties: [],
            Attributes: [],
            Mixins: []
          )
        ]
      )
    );
  }
}
