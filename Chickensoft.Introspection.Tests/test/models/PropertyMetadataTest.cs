namespace Chickensoft.Introspection.Tests.Models;

using Shouldly;
using Xunit;

public class PropertyMetadataTest {
  [Fact]
  public void Initializes() {
    var property = new PropertyMetadata(
      Name: "Name",
      IsInit: false,
      IsRequired: false,
      HasDefaultValue: false,
      Getter: _ => "Value",
      Setter: (_, _) => { },
      TypeNode: new TypeNode(typeof(string), typeof(string), false, [], _ => { }, _ => { }),
      Attributes: []
    );

    property.ShouldBeOfType<PropertyMetadata>();
  }
}
