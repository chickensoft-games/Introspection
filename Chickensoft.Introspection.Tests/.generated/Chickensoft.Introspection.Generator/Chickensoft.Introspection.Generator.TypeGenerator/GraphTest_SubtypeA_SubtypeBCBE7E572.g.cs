#pragma warning disable
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

partial class TypeGraphTest {
  partial class SubtypeA {
    partial class SubtypeB : Chickensoft.Introspection.IIntrospective, Chickensoft.Introspection.IIdentifiable {
      public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
      
      public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(SubtypeB))).Metatype;
      
      public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
        public System.Type Type => typeof(SubtypeB);
        public bool HasInitProperties { get; } = false;
        
        public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
        };
        
        public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(IdAttribute)] = new System.Attribute[] {
            new IdAttribute("test_model_subtype_b")
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
          return new SubtypeB();
        }
        public override bool Equals(object obj) => true;
        public override int GetHashCode() => base.GetHashCode();
      }
    }
  }
}
#nullable restore
#pragma warning restore
