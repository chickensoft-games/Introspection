namespace Chickensoft.Introspection.Generator.Tests.Models;

using System.Collections.Immutable;
using Chickensoft.Introspection.Generator.Models;
using Shouldly;
using Xunit;

public class DeclaredPropertyTest {
  [Fact]
  public void Equality() {
    var prop = new DeclaredProperty(
      Name: "Name",
      HasGetter: true,
      HasSetter: true,
      IsInit: false,
      IsRequired: false,
      IsNullable: false,
      DefaultValueExpression: null,
      TypeNode: new TypeNode(
        "System.String", false, Children: ImmutableArray<TypeNode>.Empty
      ),
      Attributes: ImmutableArray<DeclaredAttribute>.Empty
    );

    prop.GetHashCode().ShouldBeOfType<int>();

    prop.Equals(null).ShouldBeFalse();

    prop.ShouldBe(
      new DeclaredProperty(
        Name: "Name",
        HasGetter: true,
        HasSetter: true,
        IsInit: false,
        IsRequired: false,
        IsNullable: false,
        DefaultValueExpression: null,
        TypeNode: new TypeNode(
          "System.String", false, Children: ImmutableArray<TypeNode>.Empty
        ),
        Attributes: ImmutableArray<DeclaredAttribute>.Empty
      )
    );

    new DeclaredProperty(
      Name: "Name",
      HasGetter: true,
      HasSetter: true,
      IsInit: false,
      IsRequired: false,
      IsNullable: false,
      DefaultValueExpression: null,
      TypeNode: new TypeNode(
        "System.String", false, Children: ImmutableArray<TypeNode>.Empty
      ),
      Attributes: new DeclaredAttribute[] {
        new("", ImmutableArray<string>.Empty, ImmutableArray<string>.Empty)
      }.ToImmutableArray()
    ).ShouldNotBe(
      new DeclaredProperty(
        Name: "Name",
        HasGetter: true,
        HasSetter: true,
        IsInit: false,
        IsRequired: false,
        IsNullable: false,
        DefaultValueExpression: null,
        TypeNode: new TypeNode(
          "System.String", false, Children: ImmutableArray<TypeNode>.Empty
        ),
        Attributes: ImmutableArray<DeclaredAttribute>.Empty
      )
    );
  }
}
