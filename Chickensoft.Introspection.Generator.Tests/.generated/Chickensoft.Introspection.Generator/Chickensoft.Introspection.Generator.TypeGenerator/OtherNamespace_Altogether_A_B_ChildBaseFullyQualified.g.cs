﻿#pragma warning disable
#nullable enable
namespace OtherNamespace.Altogether;

using Chickensoft.Introspection;

partial class A {
  partial class B {
    partial class ChildBaseFullyQualified : Chickensoft.Introspection.IIntrospective {
      public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
      
      public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(ChildBaseFullyQualified))).Metatype;
      
      public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
        public System.Type Type => typeof(ChildBaseFullyQualified);
        public bool HasInitProperties { get; } = true;
        
        public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
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
          args = args ?? throw new System.ArgumentNullException(nameof(args), "Constructing ChildBaseFullyQualified requires init args.");
          return new ChildBaseFullyQualified() {
            Identifier = args.ContainsKey("Identifier") ? (string)args["Identifier"] : default!
          };
        }
        public override bool Equals(object obj) => true;
        public override int GetHashCode() => base.GetHashCode();
      }
    }
  }
}
#nullable restore
#pragma warning restore