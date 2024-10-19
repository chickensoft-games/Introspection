#pragma warning disable
#nullable enable
namespace BaseClasses.A.B.DeeplyNamespaced;

using Chickensoft.Introspection;

partial class Container {
  partial class Container2 {
    partial class DeeplyNestedBaseClass : Chickensoft.Introspection.IIntrospective {
      [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
      public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
      
      [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
      public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(DeeplyNestedBaseClass))).Metatype;
      
      public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public System.Type Type => typeof(DeeplyNestedBaseClass);
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public bool HasInitProperties { get; } = true;
        
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
          new Chickensoft.Introspection.PropertyMetadata(
            Name: "DeepName",
            IsInit: true,
            IsRequired: true,
            HasDefaultValue: false,
            Getter: static (object obj) => ((DeeplyNestedBaseClass)obj).DeepName,
            Setter: null,
            TypeNode: new Chickensoft.Introspection.TypeNode(
              OpenType: typeof(string),
              ClosedType: typeof(string),
              IsNullable: false,
              Arguments: System.Array.Empty<TypeNode>(),
              GenericTypeGetter: static receiver => receiver.Receive<string>(),
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
          args = args ?? throw new System.ArgumentNullException(nameof(args), "Constructing DeeplyNestedBaseClass requires init args.");
          return new DeeplyNestedBaseClass() {
            DeepName = args.ContainsKey("DeepName") ? (string)args["DeepName"] : default(string)!
          };
        }
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public override bool Equals(object obj) => true;
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public override int GetHashCode() => base.GetHashCode();
      }
    }
  }
}
#nullable restore
#pragma warning restore
