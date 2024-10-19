namespace Chickensoft.Introspection.Generator.Utils;

using Microsoft.CodeAnalysis.CSharp.Syntax;

public static class Extensions {
  public static bool IsNullable(this TypeSyntax type) {
    return type is NullableTypeSyntax || (
      type is GenericNameSyntax generic &&
      generic.Identifier.ValueText == "Nullable"
    );
  }
}
