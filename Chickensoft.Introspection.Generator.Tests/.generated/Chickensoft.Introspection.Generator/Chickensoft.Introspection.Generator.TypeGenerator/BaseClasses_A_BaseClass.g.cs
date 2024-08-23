#pragma warning disable
#nullable enable
namespace BaseClasses.A;

using Chickensoft.Introspection;

partial class BaseClass : Chickensoft.Introspection.IIntrospective {
  [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
  public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
  
  [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
  public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(BaseClass))).Metatype;
  
  public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Type Type => typeof(BaseClass);
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public bool HasInitProperties { get; } = true;
    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "Name",
        IsInit: true,
        IsRequired: true,
        Getter: (object obj) => ((BaseClass)obj).Name,
        Setter: null,
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
      args = args ?? throw new System.ArgumentNullException(nameof(args), "Constructing BaseClass requires init args.");
      return new BaseClass() {
        Name = args.ContainsKey("Name") ? (string)args["Name"] : default(string)!
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
