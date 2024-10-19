namespace Chickensoft.Introspection;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents property metadata on an introspective type.
/// </summary>
/// <param name="Name">Property name.</param>
/// <param name="IsInit">True if the property is init-only.</param>
/// <param name="IsRequired">True if the property is required.</param>
/// <param name="HasDefaultValue">True if the property has a default value.
/// </param>
/// <param name="Getter">Getter function.</param>
/// <param name="Setter">Setter function.</param>
/// <param name="TypeNode">If the property's type is a closed constructed
/// generic type, this will be the root node of a generic node tree that
/// provides access to the individual types comprising the closed constructed
/// type.</param>
/// <param name="Attributes">Map of attribute types to attribute
/// instances.</param>
public sealed record PropertyMetadata(
  string Name,
  bool IsInit,
  bool IsRequired,
  bool HasDefaultValue,
  Func<object, object?>? Getter,
  Action<object, object?>? Setter,
  TypeNode TypeNode,
  Dictionary<Type, Attribute[]> Attributes
);
