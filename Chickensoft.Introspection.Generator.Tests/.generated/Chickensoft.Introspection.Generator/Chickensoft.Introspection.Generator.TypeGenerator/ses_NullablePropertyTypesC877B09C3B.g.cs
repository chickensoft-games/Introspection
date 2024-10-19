#pragma warning disable
#nullable enable
namespace Chickensoft.Introspection.Generator.Tests.TestCases;

using Chickensoft.Introspection;
using Chickensoft.Introspection.Generator.Tests.TestUtils;
using System.Collections.Generic;

partial class NullablePropertyTypes : Chickensoft.Introspection.IIntrospective {
  [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
  public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
  
  [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
  public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(NullablePropertyTypes))).Metatype;
  
  public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Type Type => typeof(NullablePropertyTypes);
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public bool HasInitProperties { get; } = false;
    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "Age",
        IsInit: false,
        IsRequired: false,
        HasDefaultValue: false,
        Getter: static (object obj) => ((NullablePropertyTypes)obj).Age,
        Setter: static (object obj, object? value) => ((NullablePropertyTypes)obj).Age = (int?)value,
        GenericType: new GenericType(
          OpenType: typeof(int),
          ClosedType: typeof(int),
          IsNullable: true,
          Arguments: System.Array.Empty<GenericType>(),
          GenericTypeGetter: static receiver => receiver.Receive<int?>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("age")
          }
        }
      ), 
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "Map",
        IsInit: false,
        IsRequired: false,
        HasDefaultValue: false,
        Getter: static (object obj) => ((NullablePropertyTypes)obj).Map,
        Setter: static (object obj, object? value) => ((NullablePropertyTypes)obj).Map = (Dictionary<int, Dictionary<string, List<object?>?>?>?)value,
        GenericType: new GenericType(
          OpenType: typeof(Dictionary<,>),
          ClosedType: typeof(Dictionary<int, Dictionary<string, List<object?>?>?>),
          IsNullable: true,
          Arguments: new GenericType[] {
              new GenericType(
                OpenType: typeof(int),
                ClosedType: typeof(int),
                IsNullable: false,
                Arguments: System.Array.Empty<GenericType>(),
                GenericTypeGetter: static receiver => receiver.Receive<int>(),
                GenericTypeGetter2: default
              ), 
              new GenericType(
                OpenType: typeof(Dictionary<,>),
                ClosedType: typeof(Dictionary<string, List<object?>?>),
                IsNullable: true,
                Arguments: new GenericType[] {
                    new GenericType(
                      OpenType: typeof(string),
                      ClosedType: typeof(string),
                      IsNullable: false,
                      Arguments: System.Array.Empty<GenericType>(),
                      GenericTypeGetter: static receiver => receiver.Receive<string>(),
                      GenericTypeGetter2: default
                    ), 
                    new GenericType(
                      OpenType: typeof(List<>),
                      ClosedType: typeof(List<object?>),
                      IsNullable: true,
                      Arguments: new GenericType[] {
                          new GenericType(
                            OpenType: typeof(object),
                            ClosedType: typeof(object),
                            IsNullable: true,
                            Arguments: System.Array.Empty<GenericType>(),
                            GenericTypeGetter: static receiver => receiver.Receive<object?>(),
                            GenericTypeGetter2: default
                          )
                      },
                      GenericTypeGetter: static receiver => receiver.Receive<List<object?>?>(),
                      GenericTypeGetter2: default
                    )
                },
                GenericTypeGetter: static receiver => receiver.Receive<Dictionary<string, List<object?>?>?>(),
                GenericTypeGetter2: static receiver => receiver.Receive<string, List<object?>?>()
              )
          },
          GenericTypeGetter: static receiver => receiver.Receive<Dictionary<int, Dictionary<string, List<object?>?>?>?>(),
          GenericTypeGetter2: static receiver => receiver.Receive<int, Dictionary<string, List<object?>?>?>()
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("map")
          }
        }
      ), 
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "Name",
        IsInit: false,
        IsRequired: false,
        HasDefaultValue: false,
        Getter: static (object obj) => ((NullablePropertyTypes)obj).Name,
        Setter: static (object obj, object? value) => ((NullablePropertyTypes)obj).Name = (string?)value,
        GenericType: new GenericType(
          OpenType: typeof(string),
          ClosedType: typeof(string),
          IsNullable: true,
          Arguments: System.Array.Empty<GenericType>(),
          GenericTypeGetter: static receiver => receiver.Receive<string?>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("name")
          }
        }
      )
    };
    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
      [typeof(MetaAttribute)] = new System.Attribute[] {
        new MetaAttribute()
      }
    };
    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Collections.Generic.IReadOnlyList<System.Type> Mixins { get; } = new System.Collections.Generic.List<System.Type>() {
    };
    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Action<object>> MixinHandlers { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Action<object>>() {
    };
    
    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public object Construct(System.Collections.Generic.IReadOnlyDictionary<string, object?>? args = null) {
      return new NullablePropertyTypes();
    }
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public override bool Equals(object obj) => true;
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public override int GetHashCode() => base.GetHashCode();
  }
}
#nullable restore
#pragma warning restore
