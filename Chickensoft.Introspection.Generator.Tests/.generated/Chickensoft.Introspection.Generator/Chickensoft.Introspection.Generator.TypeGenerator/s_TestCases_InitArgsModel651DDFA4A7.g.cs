#pragma warning disable
#nullable enable
namespace Chickensoft.Introspection.Generator.Tests.TestCases;

using Chickensoft.Introspection;
using Chickensoft.Introspection.Generator.Tests.TestUtils;

partial class InitArgsModel : Chickensoft.Introspection.IIntrospective, Chickensoft.Introspection.IIdentifiable {
  [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
  public Chickensoft.Introspection.MixinBlackboard MixinState { get; } = new();
  
  [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
  public Chickensoft.Introspection.IMetatype Metatype => ((Chickensoft.Introspection.IIntrospectiveTypeMetadata)Chickensoft.Introspection.Types.Graph.GetMetadata(typeof(InitArgsModel))).Metatype;
  
  public class MetatypeMetadata : Chickensoft.Introspection.IMetatype {
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Type Type => typeof(InitArgsModel);
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public bool HasInitProperties { get; } = true;
    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Collections.Generic.IReadOnlyList<Chickensoft.Introspection.PropertyMetadata> Properties { get; } = new System.Collections.Generic.List<Chickensoft.Introspection.PropertyMetadata>() {
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "Address",
        IsInit: false,
        IsRequired: false,
        HasDefaultValue: false,
        Getter: static (object obj) => ((InitArgsModel)obj).Address,
        Setter: static (object obj, object? value) => ((InitArgsModel)obj).Address = (string?)value,
        TypeNode: new Chickensoft.Introspection.TypeNode(
          OpenType: typeof(string),
          ClosedType: typeof(string),
          IsNullable: true,
          Arguments: System.Array.Empty<TypeNode>(),
          GenericTypeGetter: static receiver => receiver.Receive<string?>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("address")
          }
        }
      ), 
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "Age",
        IsInit: true,
        IsRequired: true,
        HasDefaultValue: false,
        Getter: static (object obj) => ((InitArgsModel)obj).Age,
        Setter: null,
        TypeNode: new Chickensoft.Introspection.TypeNode(
          OpenType: typeof(int),
          ClosedType: typeof(int),
          IsNullable: false,
          Arguments: System.Array.Empty<TypeNode>(),
          GenericTypeGetter: static receiver => receiver.Receive<int>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("age")
          }
        }
      ), 
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "Description",
        IsInit: true,
        IsRequired: false,
        HasDefaultValue: false,
        Getter: static (object obj) => ((InitArgsModel)obj).Description,
        Setter: null,
        TypeNode: new Chickensoft.Introspection.TypeNode(
          OpenType: typeof(string),
          ClosedType: typeof(string),
          IsNullable: true,
          Arguments: System.Array.Empty<TypeNode>(),
          GenericTypeGetter: static receiver => receiver.Receive<string?>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("description")
          }
        }
      ), 
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "HasAttended",
        IsInit: true,
        IsRequired: false,
        HasDefaultValue: true,
        Getter: static (object obj) => ((InitArgsModel)obj).HasAttended,
        Setter: null,
        TypeNode: new Chickensoft.Introspection.TypeNode(
          OpenType: typeof(InitArgsEnum),
          ClosedType: typeof(InitArgsEnum),
          IsNullable: false,
          Arguments: System.Array.Empty<TypeNode>(),
          GenericTypeGetter: static receiver => receiver.Receive<InitArgsEnum>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("has_attended")
          }
        }
      ), 
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "IsAttending",
        IsInit: false,
        IsRequired: false,
        HasDefaultValue: true,
        Getter: static (object obj) => ((InitArgsModel)obj).IsAttending,
        Setter: static (object obj, object? value) => ((InitArgsModel)obj).IsAttending = (InitArgsEnum)value!,
        TypeNode: new Chickensoft.Introspection.TypeNode(
          OpenType: typeof(InitArgsEnum),
          ClosedType: typeof(InitArgsEnum),
          IsNullable: false,
          Arguments: System.Array.Empty<TypeNode>(),
          GenericTypeGetter: static receiver => receiver.Receive<InitArgsEnum>(),
          GenericTypeGetter2: default
        ),
        Attributes: new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("is_attending")
          }
        }
      ), 
      new Chickensoft.Introspection.PropertyMetadata(
        Name: "Name",
        IsInit: true,
        IsRequired: true,
        HasDefaultValue: false,
        Getter: static (object obj) => ((InitArgsModel)obj).Name,
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
          [typeof(TagAttribute)] = new System.Attribute[] {
            new TagAttribute("name")
          }
        }
      )
    };
    
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public System.Collections.Generic.IReadOnlyDictionary<System.Type, System.Attribute[]> Attributes { get; } = new System.Collections.Generic.Dictionary<System.Type, System.Attribute[]>() {
      [typeof(IdAttribute)] = new System.Attribute[] {
        new IdAttribute("init_args_model")
      }, 
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
      args = args ?? throw new System.ArgumentNullException(nameof(args), "Constructing InitArgsModel requires init args.");
      return new InitArgsModel() {
        Age = args.ContainsKey("Age") ? (int)args["Age"] : default(int)!, 
        Description = args.ContainsKey("Description") ? (string?)args["Description"] : default(string?), 
        HasAttended = args.ContainsKey("HasAttended") ? (InitArgsEnum)args["HasAttended"] : InitArgsEnum.No, 
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
