namespace Chickensoft.Introspection.Generator.Models;

using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Linq;
using Chickensoft.Introspection.Generator.Utils;

/// <summary>
/// Represents a property on a metatype. Properties are opt-in and persisted.
/// </summary>
/// <param name="Name">Name of the </param>
/// <param name="HasGetter">True if the property has a getter.</param>
/// <param name="HasSetter">True if the property has a setter.</param>
/// <param name="IsNullable">True if the property is nullable.</param>
/// <param name="DefaultValueExpression">Expression to use as the default
/// value.</param>
/// <param name="TypeNode">Type of the </param>
/// <param name="Attributes">Attributes applied to the </param>
public sealed record DeclaredProperty(
  string Name,
  bool HasGetter,
  bool HasSetter,
  bool IsInit,
  bool IsRequired,
  bool IsNullable,
  string? DefaultValueExpression,
  TypeNode TypeNode,
  ImmutableArray<DeclaredAttribute> Attributes
) {
  public void Write(IndentedTextWriter writer, string typeSimpleNameClosed) {
    writer.WriteLine($"new {Constants.PROPERTY_METADATA}(");
    writer.Indent++;

    var propertyValue = "value" + (IsNullable ? "" : "!");

    var getter = HasGetter
      ? $"static (object obj) => (({typeSimpleNameClosed})obj).{Name}"
      : "null";

    var type = TypeNode.ClosedType;

    var setter = HasSetter
      ? (
        IsInit
          ? "null"
          : $"static (object obj, object? value) => " +
            $"(({typeSimpleNameClosed})obj)" +
            $".{Name} = ({type}){propertyValue}"
      )
      : "null";

    writer.WriteLine($"Name: \"{Name}\",");
    writer.WriteLine($"IsInit: {(IsInit ? "true" : "false")},");
    writer.WriteLine($"IsRequired: {(IsRequired ? "true" : "false")},");
    writer.WriteLine(
      $"HasDefaultValue: {(DefaultValueExpression is not null ? "true" : "false")},"
    );
    writer.WriteLine($"Getter: {getter},");
    writer.WriteLine($"Setter: {setter},");
    writer.Write("TypeNode: ");
    TypeNode.Write(writer);
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
    HasGetter == other.HasGetter &&
    HasSetter == other.HasSetter &&
    IsInit == other.IsInit &&
    IsRequired == other.IsRequired &&
    IsNullable == other.IsNullable &&
    DefaultValueExpression == other.DefaultValueExpression &&
    TypeNode.Equals(other.TypeNode) &&
    Attributes.SequenceEqual(other.Attributes);

  public override int GetHashCode() => HashCode.Combine(
    Name,
    HasGetter,
    HasSetter,
    IsInit,
    IsRequired,
    IsNullable,
    DefaultValueExpression,
    TypeNode,
    Attributes
  );
}
