#pragma warning disable
#nullable enable
namespace Chickensoft.Introspection.Generator.Tests.TestCases;

using Chickensoft.Introspection;
using Chickensoft.Introspection.Generator.Tests.TestUtils;
using System;
using static System.Console;
using System.Text;
using JSON = System.Text.Json;

partial class MyType : Chickensoft.Introspection.IIntrospective, Chickensoft.Introspection.IIdentifiable {
  public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
  
  public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(MyType))).Metatype;
  
  public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
    public System.Type Type => typeof(MyType);
    public bool HasInitProperties { get; } = false;
    
    public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "MyProperty",
        IsInit: false,
        IsRequired: false,
        Getter: (object obj) => ((MyType)obj).MyProperty,
        Setter: (object obj, object? value) => ((MyType)obj).MyProperty = (string)value!,
        GenericType: new GenericType(
          OpenType: typeof(string),
          ClosedType: typeof(string),
          Arguments: System.Array.Empty<GenericType>(),
          GenericTypeGetter: receiver => receiver.Receive<string>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(JunkAttribute)] = new System.Attribute[] {
            new JunkAttribute(), 
            new JunkAttribute()
          }, 
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("my_property")
          }
        }
      ), 
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "NoAttributeSoNoMetadata",
        IsInit: false,
        IsRequired: false,
        Getter: (object obj) => ((MyType)obj).NoAttributeSoNoMetadata,
        Setter: (object obj, object? _) => { },
        GenericType: new GenericType(
          OpenType: typeof(int),
          ClosedType: typeof(int),
          Arguments: System.Array.Empty<GenericType>(),
          GenericTypeGetter: receiver => receiver.Receive<int>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
        }
      ), 
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "OptionalFloat",
        IsInit: false,
        IsRequired: false,
        Getter: (object obj) => ((MyType)obj).OptionalFloat,
        Setter: (object obj, object? value) => ((MyType)obj).OptionalFloat = (Nullable<float>)value,
        GenericType: new GenericType(
          OpenType: typeof(Nullable<>),
          ClosedType: typeof(Nullable<float>),
          Arguments: new GenericType[] {
              new GenericType(
                OpenType: typeof(float),
                ClosedType: typeof(float),
                Arguments: System.Array.Empty<GenericType>(),
                GenericTypeGetter: receiver => receiver.Receive<float>(),
                GenericTypeGetter2: default
              )
          },
          GenericTypeGetter: receiver => receiver.Receive<Nullable<float>>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("optional_float")
          }
        }
      ), 
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "OptionalInt",
        IsInit: false,
        IsRequired: false,
        Getter: (object obj) => ((MyType)obj).OptionalInt,
        Setter: (object obj, object? value) => ((MyType)obj).OptionalInt = (int)value,
        GenericType: new GenericType(
          OpenType: typeof(int),
          ClosedType: typeof(int),
          Arguments: System.Array.Empty<GenericType>(),
          GenericTypeGetter: receiver => receiver.Receive<int>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("optional_int")
          }
        }
      )
    };
    
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
      [typeof(IdAttribute)] = new System.Attribute[] {
        new IdAttribute("my_type")
      }, 
      [typeof(JunkAttribute)] = new System.Attribute[] {
        new JunkAttribute(), 
        new JunkAttribute()
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
      return new MyType();
    }
    public override bool Equals(object obj) => true;
    public override int GetHashCode() => base.GetHashCode();
  }
}
#nullable restore
#pragma warning restore
