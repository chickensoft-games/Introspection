#pragma warning disable
#nullable enable
namespace Chickensoft.Introspection.Generator.Tests.TestCases;

partial class SomeType : Chickensoft.Introspection.IIntrospective, ISomeMixin {
  public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
  
  public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(SomeType))).Metatype;
  
  public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
    public System.Type Type => typeof(SomeType);
    public bool HasInitProperties { get; } = false;
    
    public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
    };
    
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
      [typeof(MetaAttribute)] = new System.Attribute[] {
        new MetaAttribute(typeof(ISomeMixin))
      }
    };
    
    public System.Collections.Generic.IReadOnlyList<System.Type> Mixins { get; } = new System.Collections.Generic.List<System.Type>() {
      typeof(ISomeMixin)
    };
    
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Action<object>> MixinHandlers { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Action<object>>() {
      [typeof(ISomeMixin)] = (obj) => ((ISomeMixin)obj).Handler()
    };
    
    
    public object Construct(System.Collections.Generic.IReadOnlyDictionary<string, object?>? args = null) {
      return new SomeType();
    }
    public override bool Equals(object obj) => true;
    public override int GetHashCode() => base.GetHashCode();
  }
}
#nullable restore
#pragma warning restore
