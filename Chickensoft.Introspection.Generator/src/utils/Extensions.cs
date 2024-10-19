namespace Chickensoft.Introspection.Generator.Utils;

using Microsoft.CodeAnalysis.CSharp.Syntax;

public static class Extensions {
  public static bool IsNullable(this TypeSyntax type) {
    return type is NullableTypeSyntax || (
      type is GenericNameSyntax generic &&
      generic.Identifier.ValueText == "Nullable"
    );
  }

  public static TypeSyntax UnwrapNullable(this TypeSyntax type) {
    return type switch {
      NullableTypeSyntax nullable => nullable.ElementType,
      GenericNameSyntax generic
        when generic.Identifier.ValueText == "Nullable" =>
          generic.TypeArgumentList.Arguments.First(),
      _ => type
    };
  }
}
