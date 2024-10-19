#pragma warning disable
#nullable enable
namespace Chickensoft.Introspection.Generator.Tests.TestCases;

using Chickensoft.Introspection;
using Chickensoft.Introspection.Generator.Tests.TestUtils;
using System;
using static System.Console;
using System.Text;
using JSON = System.Text.Json;

static partial class One {
  partial record struct Two {
    partial interface IThree {
      partial record class Four {
        partial class NestedType : Chickensoft.Introspection.IIntrospective, Chickensoft.Introspection.IIdentifiable {
          [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
          public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
          
          [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
          public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(NestedType))).Metatype;
          
          public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
            [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
            public System.Type Type => typeof(NestedType);
            [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
            public bool HasInitProperties { get; } = false;
            
            [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
            public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
              new Chickensoft.Introspection.PropertyMetadata(
                Name: "MyProperty",
                IsInit: false,
                IsRequired: false,
                HasDefaultValue: true,
                Getter: static (object obj) => ((NestedType)obj).MyProperty,
                Setter: static (object obj, object? value) => ((NestedType)obj).MyProperty = (string)value!,
                GenericType: new Chickensoft.Introspection.TypeNode(
                  OpenType: typeof(string),
                  ClosedType: typeof(string),
                  IsNullable: false,
                  Arguments: System.Array.Empty<TypeNode>(),
                  GenericTypeGetter: static receiver => receiver.Receive<string>(),
                  GenericTypeGetter2: default
                ),
                Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
                  [typeof(JunkAttribute)] = new System.Attribute[] {
                    new JunkAttribute(), 
                    new JunkAttribute()
                  }, 
                  [typeof(TagAttribute)] = new System.Attribute[] {
                    new TagAttribute("my_property")
                  }
                }
              ), 
              new Chickensoft.Introspection.PropertyMetadata(
                Name: "OptionalFloat",
                IsInit: false,
                IsRequired: false,
                HasDefaultValue: true,
                Getter: static (object obj) => ((NestedType)obj).OptionalFloat,
                Setter: static (object obj, object? value) => ((NestedType)obj).OptionalFloat = (float?)value,
                GenericType: new Chickensoft.Introspection.TypeNode(
                  OpenType: typeof(float),
                  ClosedType: typeof(float),
                  IsNullable: true,
                  Arguments: System.Array.Empty<TypeNode>(),
                  GenericTypeGetter: static receiver => receiver.Receive<float?>(),
                  GenericTypeGetter2: default
                ),
                Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
                  [typeof(TagAttribute)] = new System.Attribute[] {
                    new TagAttribute("optional_float")
                  }
                }
              ), 
              new Chickensoft.Introspection.PropertyMetadata(
                Name: "OptionalInt",
                IsInit: false,
                IsRequired: false,
                HasDefaultValue: true,
                Getter: static (object obj) => ((NestedType)obj).OptionalInt,
                Setter: static (object obj, object? value) => ((NestedType)obj).OptionalInt = (int?)value,
                GenericType: new Chickensoft.Introspection.TypeNode(
                  OpenType: typeof(int),
                  ClosedType: typeof(int),
                  IsNullable: true,
                  Arguments: System.Array.Empty<TypeNode>(),
                  GenericTypeGetter: static receiver => receiver.Receive<int?>(),
                  GenericTypeGetter2: default
                ),
                Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
                  [typeof(TagAttribute)] = new System.Attribute[] {
                    new TagAttribute("optional_int")
                  }
                }
              )
            };
            
            [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
            public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
              [typeof(IdAttribute)] = new System.Attribute[] {
                new IdAttribute("nested_type")
              }, 
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
              return new NestedType();
            }
            [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
            public override bool Equals(object obj) => true;
            [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
            public override int GetHashCode() => base.GetHashCode();
          }
        }
      }
    }
  }
}
#nullable restore
#pragma warning restore
