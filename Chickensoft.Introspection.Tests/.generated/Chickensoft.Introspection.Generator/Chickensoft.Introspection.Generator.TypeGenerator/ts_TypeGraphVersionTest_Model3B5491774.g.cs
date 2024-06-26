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

partial class TypeGraphVersionTest {
  partial class Model3 : Chickensoft.Introspection.IIntrospective {
    public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
    
    public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(Model3))).Metatype;
    
    public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
      public System.Type Type => typeof(Model3);
      public bool HasInitProperties { get; } = false;
      
      public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
      };
      
      public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
        [typeof(MetaAttribute)] = new System.Attribute[] {
          new MetaAttribute()
        }, 
        [typeof(VersionAttribute)] = new System.Attribute[] {
          new VersionAttribute(3)
        }
      };
      
      public System.Collections.Generic.IReadOnlyList<System.Type> Mixins { get; } = new System.Collections.Generic.List<System.Type>() {
      };
      
      public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Action<object>> MixinHandlers { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Action<object>>() {
      };
      
      
      public object Construct(System.Collections.Generic.IReadOnlyDictionary<string, object?>? args = null) {
        return new Model3();
      }
      public override bool Equals(object obj) => true;
      public override int GetHashCode() => base.GetHashCode();
    }
  }
}
#nullable restore
#pragma warning restore
