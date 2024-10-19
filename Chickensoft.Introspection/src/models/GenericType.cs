namespace Chickensoft.Introspection;

using System;

/// <summary>
/// Type representation.
/// </summary>
/// <param name="OpenType">Open generic type, if generic. Otherwise the same
/// as <see cref="ClosedType"/>.</param>
/// <param name="ClosedType">Closed generic type, if generic. Otherwise just the
/// plain type.</param>
/// <param name="IsNullable">True if the type is nullable.</param>
/// <param name="Arguments">Type arguments, if any.</param>
/// <param name="GenericTypeGetter">Action which invokes the generic type
/// receiver with the type.</param>
/// <param name="GenericTypeGetter2">Action which invokes the generic type
/// receiver with its two child type arguments, if present. Obviously only
/// applies to types with exactly two type parameters.</param>
public record GenericType(
  Type OpenType,
  Type ClosedType,
  bool IsNullable,
  GenericType[] Arguments,
  Action<ITypeReceiver> GenericTypeGetter,
  Action<ITypeReceiver2>? GenericTypeGetter2
);
