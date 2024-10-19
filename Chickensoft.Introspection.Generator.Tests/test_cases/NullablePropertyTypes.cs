namespace Chickensoft.Introspection.Generator.Tests.TestCases;

using System;
using System.Collections.Generic;
using Chickensoft.Introspection;
using Chickensoft.Introspection.Generator.Tests.TestUtils;

public struct GenericStruct<T> {
  public T Value { get; set; }
}

[Meta]
public partial class NullablePropertyTypes {
  [Tag("name")]
  public string? Name { get; set; }

  [Tag("age")]
  public int? Age { get; set; }

  // All types are nullable (except dictionary keys int and string)
  [Tag("map")]
  public Dictionary<int, Dictionary<string, List<object?>?>?>? Map { get; set; }

#pragma warning disable IDE0001
  [Tag("map_verbose")]
  public Nullable<GenericStruct<Nullable<GenericStruct<int?>>>> Nullables { get; set; }
#pragma warning restore IDE0001
}
