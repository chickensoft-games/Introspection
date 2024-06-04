#pragma warning disable
#nullable enable
namespace Chickensoft.Introspection.Generator.Tests.TestCases;

using Chickensoft.Introspection;
using Chickensoft.Introspection.Generator.Tests.TestUtils;

partial class DerivedModel : Chickensoft.Introspection.IIntrospective {
  public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
  
  public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(DerivedModel))).Metatype;
  
  public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
    public System.Type Type => typeof(DerivedModel);
    public bool HasInitProperties { get; } = false;
    
    public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "Age",
        IsInit: false,
        IsRequired: false,
        Getter: (object obj) => ((DerivedModel)obj).Age,
        Setter: (object obj, object? value) => ((DerivedModel)obj).Age = (int)value!,
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
      return new DerivedModel();
    }
    public override bool Equals(object obj) => true;
    public override int GetHashCode() => base.GetHashCode();
  }
}
#nullable restore
#pragma warning restore
