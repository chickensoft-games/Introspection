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
  partial class ChildModel : Chickensoft.Introspection.IIntrospective {
    public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
    
    public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(ChildModel))).Metatype;
    
    public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
      public System.Type Type => typeof(ChildModel);
      public bool HasInitProperties { get; } = true;
      
      public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
        new Chickensoft.Introspection.PropertyMetadata(
          Name: "ChildName",
          IsInit: true,
          IsRequired: false,
          Getter: (object obj) => ((ChildModel)obj).ChildName,
          Setter: (object obj, object? value) => throw new System.InvalidOperationException("Property ChildName on ChildModel is init-only."),
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
          new TagAttribute("child")
        }
      };
      
      public System.Collections.Generic.IReadOnlyList<System.Type> Mixins { get; } = new System.Collections.Generic.List<System.Type>() {
      };
      
      public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Action<object>> MixinHandlers { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Action<object>>() {
      };
      
      
      public object Construct(System.Collections.Generic.IReadOnlyDictionary<string, object?>? args = null) {
        args = args ?? throw new System.ArgumentNullException(nameof(args), "Constructing ChildModel requires init args.");
        return new ChildModel() {
          Age = args.ContainsKey("Age") ? (int)args["Age"] : default!, 
          ChildName = args.ContainsKey("ChildName") ? (string)args["ChildName"] : default!, 
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
