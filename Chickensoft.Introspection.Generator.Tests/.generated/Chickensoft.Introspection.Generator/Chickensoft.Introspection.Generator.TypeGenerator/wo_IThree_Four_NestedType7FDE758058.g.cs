﻿#pragma warning disable
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
          public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
          
          public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(NestedType))).Metatype;
          
          public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
            public System.Type Type => typeof(NestedType);
            public bool HasInitProperties { get; } = false;
            
            public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
              new Chickensoft.Introspection.PropertyMetadata(
                Name: "MyProperty",
                IsInit: false,
                IsRequired: false,
                Getter: (object obj) => ((NestedType)obj).MyProperty,
                Setter: (object obj, object? value) => ((NestedType)obj).MyProperty = (string)value!,
                GenericType: new GenericType(
                  OpenType: typeof(string),
                  ClosedType: typeof(string),
                  Arguments: System.Array.Empty<GenericType>(),
                  GenericTypeGetter: receiver => receiver.Receive<string>(),
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
                Getter: (object obj) => ((NestedType)obj).OptionalFloat,
                Setter: (object obj, object? value) => ((NestedType)obj).OptionalFloat = (float)value,
                GenericType: new GenericType(
                  OpenType: typeof(float),
                  ClosedType: typeof(float),
                  Arguments: System.Array.Empty<GenericType>(),
                  GenericTypeGetter: receiver => receiver.Receive<float>(),
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
                Getter: (object obj) => ((NestedType)obj).OptionalInt,
                Setter: (object obj, object? value) => ((NestedType)obj).OptionalInt = (int)value,
                GenericType: new GenericType(
                  OpenType: typeof(int),
                  ClosedType: typeof(int),
                  Arguments: System.Array.Empty<GenericType>(),
                  GenericTypeGetter: receiver => receiver.Receive<int>(),
                  GenericTypeGetter2: default
                ),
                Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
                  [typeof(TagAttribute)] = new System.Attribute[] {
                    new TagAttribute("optional_int")
                  }
                }
              )
            };
            
            public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
              [typeof(IdAttribute)] = new System.Attribute[] {
                new IdAttribute("nested_type")
              }, 
              [typeof(MetaAttribute)] = new System.Attribute[] {
                new MetaAttribute()
              }
            };
            
            public System.Collections.Generic.IReadOnlyList<System.Type> Mixins { get; } = new System.Collections.Generic.List<System.Type>() {
            };
            
            public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Action<object>> MixinHandlers { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Action<object>>() {
            };
            
            
            public object Construct(System.Collections.Generic.IReadOnlyDictionary<string, object?>? args = null) {
              return new NestedType();
            }
            public override bool Equals(object obj) => true;
            public override int GetHashCode() => base.GetHashCode();
          }
        }
      }
    }
  }
}
#nullable restore
#pragma warning restore