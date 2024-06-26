namespace Chickensoft.Introspection.Generator.Models;

using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Linq;
using Chickensoft.Introspection.Generator.Utils;

/// <summary>
/// Represents a property on a metatype. Properties are opt-in and persisted.
/// </summary>
/// <param name="Name">Name of the </param>
/// <param name="HasSetter">True if the property has a setter.</param>
/// <param name="IsNullable">True if the property is nullable.</param>
/// <param name="GenericType">Type of the </param>
/// <param name="Attributes">Attributes applied to the </param>
public sealed record DeclaredProperty(
  string Name,
  bool HasSetter,
  bool IsInit,
  bool IsRequired,
  bool IsNullable,
  GenericTypeNode GenericType,
  ImmutableArray<DeclaredAttribute> Attributes
) {
  public void Write(IndentedTextWriter writer, string typeSimpleNameClosed) {
    writer.WriteLine($"new {Constants.PROPERTY_METADATA}(");
    writer.Indent++;

    var propertyValue = "value" + (IsNullable ? "" : "!");

    var setter = HasSetter
      ? (
        IsInit
          ? "null"
          : $"(object obj, object? value) => (({typeSimpleNameClosed})obj)" +
          $".{Name} = ({GenericType.ClosedType}){propertyValue}"
      )
      : "null";

    writer.WriteLine($"Name: \"{Name}\",");
    writer.WriteLine($"IsInit: {(IsInit ? "true" : "false")},");
    writer.WriteLine($"IsRequired: {(IsRequired ? "true" : "false")},");
    writer.WriteLine(
      $"Getter: (object obj) => (({typeSimpleNameClosed})obj).{Name},"
    );
    writer.WriteLine($"Setter: {setter},");
    writer.Write("GenericType: ");
    GenericType.Write(writer);
    writer.WriteLine(",");
    writer.WriteLine(
      "Attributes: new System.Collections.Generic.Dictionary" +
      "<System.Type, System.Attribute[]>() {"
    );

    DeclaredAttribute.WriteAttributeMap(writer, Attributes);

    writer.WriteLine("}");

    writer.Indent--;

    writer.Write(")");
  }

  public bool Equals(DeclaredProperty? other) =>
    other is not null &&
    Name == other.Name &&
    HasSetter == other.HasSetter &&
    IsInit == other.IsInit &&
    IsNullable == other.IsNullable &&
    GenericType.Equals(other.GenericType) &&
    Attributes.SequenceEqual(other.Attributes);

  public override int GetHashCode() => HashCode.Combine(
    Name,
    HasSetter,
    IsInit,
    IsNullable,
    GenericType,
    Attributes
  );
}
