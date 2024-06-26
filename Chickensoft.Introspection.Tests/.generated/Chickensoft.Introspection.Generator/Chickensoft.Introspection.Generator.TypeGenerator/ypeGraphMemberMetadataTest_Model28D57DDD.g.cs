﻿#pragma warning disable
#nullable enable
namespace Chickensoft.Introspection.Tests;

using Chickensoft.Introspection;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;

partial class TypeGraphMemberMetadataTest {
  partial class Model : Chickensoft.Introspection.IIntrospective {
    public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
    
    public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(Model))).Metatype;
    
    public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
      public System.Type Type => typeof(Model);
      public bool HasInitProperties { get; } = true;
      
      public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
        new Chickensoft.Introspection.PropertyMetadata(
          Name: "Age",
          IsInit: true,
          IsRequired: true,
          Getter: (object obj) => ((Model)obj).Age,
          Setter: (object obj, object? value) => throw new System.InvalidOperationException("Property Age on Model is init-only."),
          GenericType: new GenericType(
            OpenType: typeof(int),
            ClosedType: typeof(int),
            Arguments: System.Array.Empty<GenericType>(),
            GenericTypeGetter: receiver => receiver.Receive<int>(),
            GenericTypeGetter2: default
          ),
          Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
            [typeof(TagAttribute)] = new System.Attribute[] {
              new TagAttribute("age")
            }
          }
        ), 
        new Chickensoft.Introspection.PropertyMetadata(
          Name: "Name",
          IsInit: true,
          IsRequired: false,
          Getter: (object obj) => ((Model)obj).Name,
          Setter: (object obj, object? value) => throw new System.InvalidOperationException("Property Name on Model is init-only."),
          GenericType: new GenericType(
            OpenType: typeof(string),
            ClosedType: typeof(string),
            Arguments: System.Array.Empty<GenericType>(),
            GenericTypeGetter: receiver => receiver.Receive<string>(),
            GenericTypeGetter2: default
          ),
          Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          }
        )
      };
      
      public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
        [typeof(MetaAttribute)] = new System.Attribute[] {
          new MetaAttribute()
        }, 
        [typeof(TagAttribute)] = new System.Attribute[] {
          new TagAttribute("model")
        }
      };
      
      public System.Collections.Generic.IReadOnlyList<System.Type> Mixins { get; } = new System.Collections.Generic.List<System.Type>() {
      };
      
      public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Action<object>> MixinHandlers { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Action<object>>() {
      };
      
      
      public object Construct(System.Collections.Generic.IReadOnlyDictionary<string, object?>? args = null) {
        args = args ?? throw new System.ArgumentNullException(nameof(args), "Constructing Model requires init args.");
        return new Model() {
          Age = args.ContainsKey("Age") ? (int)args["Age"] : default!, 
          Name = args.ContainsKey("Name") ? (string)args["Name"] : default!
        };
      }
      public override bool Equals(object obj) => true;
      public override int GetHashCode() => base.GetHashCode();
    }
  }
}
#nullable restore
#pragma warning restore
