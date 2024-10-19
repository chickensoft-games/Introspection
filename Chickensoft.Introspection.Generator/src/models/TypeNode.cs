namespace Chickensoft.Introspection.Generator.Models;

using System;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Linq;
using Chickensoft.Introspection.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;


// Not to be confused with the type resolution tree node, which has to do with
// where types are. This represents a generic type as a hierarchy of all the
// types that comprise it.
public sealed record TypeNode(
  string Type,
  bool IsNullable,
  ImmutableArray<TypeNode> Children
) {
  /// <summary>
  /// Name of the type, including any generic type arguments — i.e., the closed
  /// generic type.
  /// </summary>
  public string ClosedType => Type + TypeReference.GetGenerics(
    Children.Select(child => child.ClosedType).ToImmutableArray()
  ) + Q;

  public string OpenType =>
    Type + TypeReference.GetOpenGenerics(Children.Length) + Q;

  private string Q => IsNullable ? "?" : "";

  /// <summary>
  /// Recursively constructs a generic type node from a generic name syntax.
  /// </summary>
  /// <param name="typeSyntax">Generic name syntax.</param>
  /// <returns>Generic type node tree.</returns>
  public static TypeNode Create(
    TypeSyntax typeSyntax, bool isNullable
  ) {
    isNullable = isNullable || typeSyntax.IsNullable();
    typeSyntax = typeSyntax.UnwrapNullable();

    if (typeSyntax is not GenericNameSyntax genericNameSyntax) {
      return new TypeNode(
        typeSyntax.NormalizeWhitespace().ToString(),
        IsNullable: isNullable,
        Children: ImmutableArray<TypeNode>.Empty
      );
    }

    var type = genericNameSyntax.Identifier.NormalizeWhitespace().ToString();

    var children = genericNameSyntax.TypeArgumentList.Arguments
      .Select(arg => {
        typeSyntax = typeSyntax.UnwrapNullable();
        isNullable = arg.IsNullable();

        return Create(arg, isNullable);
      })
      .ToImmutableArray();

    return new TypeNode(type, isNullable, children);
  }

  public void Write(IndentedTextWriter writer) {
    writer.WriteLine("new Chickensoft.Introspection.TypeNode(");
    writer.Indent++;
    writer.WriteLine($"OpenType: typeof({OpenType.TrimEnd('?')}),");
    writer.WriteLine($"ClosedType: typeof({ClosedType.TrimEnd('?')}),");
    writer.WriteLine($"IsNullable: {(IsNullable ? "true" : "false")},");

    if (Children.Length > 0) {
      writer.WriteLine("Arguments: new TypeNode[] {");
      writer.Indent++;

      writer.WriteCommaSeparatedList(
        Children,
        child => child.Write(writer),
        multiline: true
      );

      writer.Indent--;
      writer.WriteLine("},");
    }
    else {
      writer.WriteLine("Arguments: System.Array.Empty<TypeNode>(),");
    }

    writer.WriteLine(
      "GenericTypeGetter: static receiver => " +
      $"receiver.Receive<{ClosedType}>(),"
    );
    if (Children.Length >= 2) {
      writer.WriteLine(
        "GenericTypeGetter2: static receiver => " +
        $"receiver.Receive<{Children[0].ClosedType}, {Children[1].ClosedType}>()"
      );
    }
    else {
      writer.WriteLine("GenericTypeGetter2: default");
    }
    writer.Indent--;
    writer.Write(")");
  }

  public bool Equals(TypeNode? other) =>
    other is not null &&
    Type == other.Type &&
    IsNullable == other.IsNullable &&
    Children.SequenceEqual(other.Children);

  public override int GetHashCode() => HashCode.Combine(
    Type,
    IsNullable,
    Children
  );
}
