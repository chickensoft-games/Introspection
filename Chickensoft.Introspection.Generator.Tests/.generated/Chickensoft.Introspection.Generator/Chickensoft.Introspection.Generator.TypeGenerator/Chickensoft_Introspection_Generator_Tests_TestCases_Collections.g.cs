﻿#pragma warning disable
#nullable enable
namespace Chickensoft.Introspection.Generator.Tests.TestCases;

using Chickensoft.Introspection.Generator.Tests.TestUtils;
using System.Collections.Generic;

partial class Collections : Chickensoft.Introspection.IIntrospective {
  public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
  
  public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(Collections))).Metatype;
  
  public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
    public System.Type Type => typeof(Collections);
    public bool HasInitProperties { get; } = false;
    
    public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "NestedCollections",
        IsInit: false,
        IsRequired: false,
        Getter: (object obj) => ((Collections)obj).NestedCollections,
        Setter: (object obj, object? _) => { },
        GenericType: new GenericType(
          OpenType: typeof(Dictionary<,>),
          ClosedType: typeof(Dictionary<List<string>, List<List<int>>>),
          Arguments: new GenericType[] {
              new GenericType(
                OpenType: typeof(List<>),
                ClosedType: typeof(List<string>),
                Arguments: new GenericType[] {
                    new GenericType(
                      OpenType: typeof(string),
                      ClosedType: typeof(string),
                      Arguments: System.Array.Empty<GenericType>(),
                      GenericTypeGetter: receiver => receiver.Receive<string>(),
                      GenericTypeGetter2: default
                    )
                },
                GenericTypeGetter: receiver => receiver.Receive<List<string>>(),
                GenericTypeGetter2: default
              ), 
              new GenericType(
                OpenType: typeof(List<>),
                ClosedType: typeof(List<List<int>>),
                Arguments: new GenericType[] {
                    new GenericType(
                      OpenType: typeof(List<>),
                      ClosedType: typeof(List<int>),
                      Arguments: new GenericType[] {
                          new GenericType(
                            OpenType: typeof(int),
                            ClosedType: typeof(int),
                            Arguments: System.Array.Empty<GenericType>(),
                            GenericTypeGetter: receiver => receiver.Receive<int>(),
                            GenericTypeGetter2: default
                          )
                      },
                      GenericTypeGetter: receiver => receiver.Receive<List<int>>(),
                      GenericTypeGetter2: default
                    )
                },
                GenericTypeGetter: receiver => receiver.Receive<List<List<int>>>(),
                GenericTypeGetter2: default
              )
          },
          GenericTypeGetter: receiver => receiver.Receive<Dictionary<List<string>, List<List<int>>>>(),
          GenericTypeGetter2: receiver => receiver.Receive<List<string>, List<List<int>>>()
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("nested_collections")
          }
        }
      )
    };
    
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
      [typeof(MetaAttribute)] = new System.Attribute[] {
        new MetaAttribute()
      }
    };
    
    public System.Collections.Generic.IReadOnlyList<System.Type> Mixins { get; } = new System.Collections.Generic.List<System.Type>() {
    };
    
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Action<object>> MixinHandlers { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Action<object>>() {
    };
    
    
    public object Construct(System.Collections.Generic.IReadOnlyDictionary<string, object?>? args = null) {
      return new Collections();
    }
    public override bool Equals(object obj) => true;
    public override int GetHashCode() => base.GetHashCode();
  }
}
#nullable restore
#pragma warning restore
