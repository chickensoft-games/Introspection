#pragma warning disable
#nullable enable
namespace Chickensoft.Introspection.Generator.Tests.TestCases;

using Chickensoft.Introspection;
using Chickensoft.Introspection.Generator.Tests.TestUtils;

partial class MyContainerClass {
  partial record class MyModel : Chickensoft.Introspection.IIntrospective, Chickensoft.Introspection.IIdentifiable, IMyMixin, IMySecondMixin {
    public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
    
    public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(MyModel))).Metatype;
    
    public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
      public System.Type Type => typeof(MyModel);
      public bool HasInitProperties { get; } = false;
      
      public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
        new Chickensoft.Introspection.PropertyMetadata(
          Name: "Age",
          IsInit: false,
          IsRequired: false,
          Getter: (object obj) => ((MyModel)obj).Age,
          Setter: (object obj, object? value) => ((MyModel)obj).Age = (int)value,
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
        ), 
        new Chickensoft.Introspection.PropertyMetadata(
          Name: "Name",
          IsInit: false,
          IsRequired: false,
          Getter: (object obj) => ((MyModel)obj).Name,
          Setter: (object obj, object? value) => ((MyModel)obj).Name = (string)value!,
          GenericType: new GenericType(
            OpenType: typeof(string),
            ClosedType: typeof(string),
            Arguments: System.Array.Empty<GenericType>(),
            GenericTypeGetter: receiver => receiver.Receive<string>(),
            GenericTypeGetter2: default
          ),
          Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
            [typeof(TagAttribute)] = new System.Attribute[] {
              new TagAttribute("name")
            }
          }
        )
      };
      
      public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
        [typeof(IdAttribute)] = new System.Attribute[] {
          new IdAttribute("my_model")
        }, 
        [typeof(MetaAttribute)] = new System.Attribute[] {
          new MetaAttribute(typeof(IMyMixin), typeof(IMySecondMixin))
        }
      };
      
      public System.Collections.Generic.IReadOnlyList<System.Type> Mixins { get; } = new System.Collections.Generic.List<System.Type>() {
        typeof(IMyMixin), 
        typeof(IMySecondMixin)
      };
      
      public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Action<object>> MixinHandlers { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Action<object>>() {
        [typeof(IMyMixin)] = (obj) => ((IMyMixin)obj).Handler(), 
        [typeof(IMySecondMixin)] = (obj) => ((IMySecondMixin)obj).Handler()
      };
      
      
      public object Construct(System.Collections.Generic.IReadOnlyDictionary<string, object?>? args = null) {
        return new MyModel();
      }
      public override bool Equals(object obj) => true;
      public override int GetHashCode() => base.GetHashCode();
    }
  }
}
#nullable restore
#pragma warning restore
