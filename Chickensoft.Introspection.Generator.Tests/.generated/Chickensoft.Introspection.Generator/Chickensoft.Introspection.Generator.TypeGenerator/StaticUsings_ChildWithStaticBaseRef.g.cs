#pragma warning disable
#nullable enable
namespace StaticUsings;

using Chickensoft.Introspection;
using static OtherNamespace.Altogether.A;

partial class ChildWithStaticBaseRef : Chickensoft.Introspection.IIntrospective {
  [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
  public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
  
  [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
  public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(ChildWithStaticBaseRef))).Metatype;
  
  public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Type Type => typeof(ChildWithStaticBaseRef);
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public bool HasInitProperties { get; } = true;
    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
    };
    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
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
      args = args ?? throw new System.ArgumentNullException(nameof(args), "Constructing ChildWithStaticBaseRef requires init args.");
      return new ChildWithStaticBaseRef() {
        Identifier = args.ContainsKey("Identifier") ? (string)args["Identifier"] : default(string)!
      };
    }
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public override bool Equals(object obj) => true;
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public override int GetHashCode() => base.GetHashCode();
  }
}
#nullable restore
#pragma warning restore
