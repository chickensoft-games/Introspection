#pragma warning disable
#nullable enable
namespace Chickensoft.Introspection.Tests;

using Shouldly;
using System;
using Xunit;

partial class MyTypeWithAMixin : Chickensoft.Introspection.IIntrospective, IMixin1, IMixin2 {
  public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
  
  public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(MyTypeWithAMixin))).Metatype;
  
  public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
    public System.Type Type => typeof(MyTypeWithAMixin);
    public bool HasInitProperties { get; } = false;
    
    public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
    };
    
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
      [typeof(MetaAttribute)] = new System.Attribute[] {
        new MetaAttribute(typeof(IMixin1), typeof(IMixin2))
      }
    };
    
    public System.Collections.Generic.IReadOnlyList<System.Type> Mixins { get; } = new System.Collections.Generic.List<System.Type>() {
      typeof(IMixin1), 
      typeof(IMixin2)
    };
    
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Action<object>> MixinHandlers { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Action<object>>() {
      [typeof(IMixin1)] = (obj) => ((IMixin1)obj).Handler(), 
      [typeof(IMixin2)] = (obj) => ((IMixin2)obj).Handler()
    };
    
    
    public object Construct(System.Collections.Generic.IReadOnlyDictionary<string, object?>? args = null) {
      return new MyTypeWithAMixin();
    }
    public override bool Equals(object obj) => true;
    public override int GetHashCode() => base.GetHashCode();
  }
}
#nullable restore
#pragma warning restore
