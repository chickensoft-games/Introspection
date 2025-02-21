# 🔮 Introspection

[![Chickensoft Badge][chickensoft-badge]][chickensoft-website] [![Discord][discord-badge]][discord] [![Read the docs][read-the-docs-badge]][docs] ![line coverage][line-coverage] ![branch coverage][branch-coverage]

Create mixins and generate metadata about types at build time to enable reflection in ahead-of-time (AOT) environments.

---

<p align="center">
<img alt="Chickensoft.Introspection" src="Chickensoft.Introspection/icon.png" width="200">
</p>

## 🥚 Installation

Find the latest version of the [Introspection] and [Introspection Generator] packages from nuget and add them to your C# project.

> [!WARNING]
> Introspection is compiled against the latest .NET 8 SDK. Because .NET 8 encompasses multiple versions of the [.NET compiler], compiling your project against an older version of .NET 8 may generate a `CS9057` warning to indicate a compiler-version mismatch. However, if the warning is ignored, less-tractable downstream compilation errors, or even runtime errors, may result. Therefore, we strongly recommend treating `CS9057` as an error to catch compiler versioning issues at the earliest opportunity.

```xml
<Project Sdk=...>
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    ...
    <!-- Catch compiler-mismatch issues -->
    <WarningsAsErrors>CS9057</WarningsAsErrors>
    ...
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Chickensoft.Introspection" Version=... />
    <PackageReference Include="Chickensoft.Introspection.Generator" Version=... PrivateAssets="all" OutputItemType="analyzer" />
  </ItemGroup>
</Project>
```

## 📙 Background

This is a metaprogramming tool that powers some of the other Chickensoft tools. Introspection exists to enable C# developers to get information about a type at runtime without needing reflection that wouldn't work or be guaranteed to work in all scenarios when compiling for ahead-of-time targets like iOS.

The introspection package provides the following features:

- ✅ Create a registry of all types visible from the global scope.
- ✅ Generate metadata about visible types.
- ✅ Track types by id and version.
- ✅ Allow types to implement and look up mixins.
- ✅ Compute and cache type hierarchies, attributes, and properties.
- ✅ Track generic types of properties in a way that enables convenient serialization in AOT environments.

You don't need to fully understand this package to make the most of it. In fact, you may never need to use it directly since you are more likely to encounter it as a dependency of one of the other Chickensoft tools:

- 💾 [Serialization] uses this tool to gather information about types at build-time to perform serialization and deserialization at runtime without having to resort to unsupported reflection techniques in AOT environments.
- 💉 [AutoInject] uses this tool to allow you to add mixins to classes at build-time and invoke their methods at runtime without reflection. It also leverages this to read attributes on types without having to use reflection.
- 💡 [LogicBlocks] uses this tool to look up possible states for a state machine so it can pre-allocate them at runtime without needing reflection.

The introspection generator is designed to be performant as a project grows. The generator only uses syntax information to generate metadata, rather than relying on the C# analyzer's symbol data, which can be very slow.

> [!NOTE]
> This tool exists because many reflection-based API's don't work (or aren't guaranteed to work reliably in all scenarios) when compiling for AOT targets (like iOS). Chickensoft is striving to create packages that work in AOT environments like iOS, as mobile games and apps are extremely widespread. For more information, read our [philosophy].

## 📄 Usage

### 🧘‍♀️ Introspective Types

Simply add the `[Meta]` attribute to a partial class or record that is visible from the global scope.

```csharp
using Chickensoft.Introspection;

[Meta]
public partial class MyType;

public partial class Container {
  // Nested types are supported, too.
  [Meta]
  public partial class MyType;
}
```

The generator will generate a [type registry] for your assembly that lists every type it can discover in the codebase, along with their generated metadata. Introspective types have much additional metadata compared to types without the `[Meta]` attribute.

The generated registry automatically registers types with the Introspection library's [type graph] using a [module initializer], so no action is needed on the developer's part. The module initializer registration process also performs some logic at runtime to resolve the type graph and cache the type hierarchy in a way that makes it performant to lookup. This preprocessing runs in roughly linear time and is negligible.

All introspective types must be a class or record, partial, visible from the global scope. Introspective types cannot be generic.

### 🪪 Identifiable Types

An introspective type can also be an identifiable type if it is given the `[Id]` attribute. Identifiable types get additional metadata generated about them, allowing them to be looked up by their identifier.

```csharp
  [Meta, Id("my_type")]
  public partial class MyType;
```

### ⤵️ The Type Graph

The type graph can be used to query information about types at runtime. If the type graph has to compute a query, the results are cached for all future queries. Most api's are simple O(1) lookups.

```csharp

// Get every type that is a valid subtype of Ancestor.
var allSubtypes = Types.Graph.GetDescendantSubtypes(typeof(Ancestor));

// Only get the types that directly inherit from Parent.
var subtypes = Types.Graph.GetSubtypes(typeof(Parent));

// Get generated metadata associated with a type.
if (Types.Graph.GetMetadata(typeof(Model)) is { } metadata) {
  // ...
}

// Get properties, including those from parent introspective types.
var properties = Types.Graph.GetProperties(typeof(Model));

// ...see the source for all possible type graph operations.
```

### 👯‍♀️ Versioning

All concrete introspective types have a simple integer version associated with them. By default, the version is `1`. You can use the `[Version]` attribute to denote the version of an introspective type.

```csharp
[Meta, Version(2)]
public partial class MyType;

// Or, multiple versions of the same identifiable type.

[Meta, Id("my_type")]
public abstract class MyType;

[Meta, Version(1)]
public class MyType1 : MyType;

[Meta, Version(2)]
public class MyType2 : MyType;

[Meta, Version(3)]
public class MyType3 : MyType;
```

During type registration, the type graph will "promote" introspective types which inherit from an identifiable type to an identifiable type themselves, sharing the same identifier as their parent or ancestor identifiable type. Promoted identifiable types must, however, have uniquely specified versions.

## 🔎 Metadata Types

The introspection generator differentiates between the following categories of types and constructs the appropriate metadata for the type, depending on which category it belongs to.

| Category                        | Metadata                            |
|---------------------------------|-------------------------------------|
| 🫥 Abstract or generic types    | `TypeMetadata`                      |
| 🪨 Non-generic, concrete types  | `ConcreteTypeMetadata`              |
| 👻 Abstract introspective types | `AbstractIntrospectiveTypeMetadata` |
| 🗿 Concrete introspective types | `IntrospectiveTypeMetadata`         |
| 🆔 Abstract identifiable types  | `AbstractIdentifiableTypeMetadata`  |
| 🪪 Concrete identifiable types  | `IdentifiableTypeMetadata`          |

You can check the type of metadata that a type has to understand what its capabilities are. Each type of metadata has different fields associated with it.

In addition to the metadata classes, each metadata class implements the appropriate interfaces:

| Metadata                    | Conforms To                                     |
|-----------------------------|-------------------------------------------------|
| `TypeMetadata`              | `ITypeMetadata`                                 |
| `ConcreteTypeMetadata`      | ..., `IClosedTypeMetadata`, `IConcreteMetadata` |
| `IntrospectiveTypeMetadata` | ..., `IConcreteIntrospectiveTypeMetadata`       |
| `IdentifiableTypeMetadata`  | ..., `IIdentifiableTypeMetadata`                |
| ... etc.                    |                                                 |

```csharp
public class MyTypeReceiver : ITypeReceiver {
  public void Receive<T>() {
    // Do whatever you want with the type as a generic parameter.
  }
}

var metadata = Types.Graph.GetMetadata(typeof(Model));

if (metadata is IClosedTypeMetadata closedMetadata) {
  // Closed types allow you to receive the type as a generic argument in
  // a TypeReceiver's Receive<T>() method.
  closedMetadata.GenericTypeGetter(new MyTypeReceiver())
}

if (metadata is IConcreteTypeMetadata concreteMetadata) {
  // Concrete types allow you to create a new instance of the type, if
  // it has a parameterless constructor.
  var instance = concreteMetadata.Factory();
}

if (metadata is IIntrospectiveTypeMetadata introMetadata) {
  // Introspective types provide a metatype instance which allows you to access
  // more information about that type, such as its properties and attributes.
  var metatype = introMetadata.Metatype;
}

if (metadata is IConcreteIntrospectiveTypeMetadata concreteIntroMetadata) {
  // Concrete introspective types have a version number.
  var version = concreteIntroMetadata.Version;
}

if (metadata is IIdentifiableTypeMetadata idMetadata) {
  // Identifiable types have an id.
  var id = idMetadata.Id;
}
```

## Δ Metatypes

The introspection generator generates additional metadata for introspective and identifiable types known as a "metatype." A type's metatype information can be accessed from its metadata.

```csharp
var metadata = Types.Graph.GetMetadata(typeof(Model));

if (metadata is IIntrospectiveTypeMetadata introMetadata) {
  var metatype = introMetadata.Metatype;

  foreach (var attribute in metatype.Attributes) {
    // Iterate the attributes on an introspective type.
  }

  foreach (var property in metatype.Properties) {
    // Iterate the properties of an introspective type.
    if (property.Setter is { } setter) {
      // We can set the value of the property.
      setter(obj, value);
    }

    // etc.
  }
}
```

Metatype data provides information about a specific type, its properties, and attributes. The type graph combines metatype information with its understanding of the type hierarchy to enable you to fetch all properties of an introspective type, including those it inherited from other introspective types. Metatypes will only contain information about the type itself, not anything it inherits from.

To see all of the information that a metatype exposes, please see the [Metatype interface definition][metatype].

## 🎛️ Mixins

The introspection generator allows you to create mixins to add additional functionality to the type they are applied to. Unlike [default interface method implementations], mixins are able to add _[instance state]_ via a [blackboard]. Every introspective type has a `MixinState` blackboard which allows mixins to add instance data to the type they are applied to.

Additionally, mixins must implement a single handler method. An introspective type's `Metatype` has a `Mixins` property containing a list of mixin types that were applied to it. Additionally, a `MixinHandler` table is provided which maps the mixin type to a closure which invokes the mixin's handler.

Introspective type instances can also cast themselves to `IIntrospective` to invoke a given mixin easily.

```csharp
// Declare a mixin
[Mixin]
public interface IMyMixin : IMixin<IMyMixin> {
  void IMixin<IMyMixin>.Handler() { }
}

// Use a mixin
[Meta(typeof(Mixin))]
public partial class MyModel {

  // Use mixins
  public void MyMethod() {
    // Call all applied mixin handlers
    (this as IIntrospective).InvokeMixins();

    // Call a specific mixin handler
    (this as IIntrospective).InvokeMixin(typeof(IMyMixin));
  }
}
```

---

🐣 Package generated from a 🐤 Chickensoft Template — <https://chickensoft.games>

[chickensoft-badge]: https://raw.githubusercontent.com/chickensoft-games/chickensoft_site/main/static/img/badges/chickensoft_badge.svg
[chickensoft-website]: https://chickensoft.games
[philosophy]: https://chickensoft.games/philosophy
[discord-badge]: https://raw.githubusercontent.com/chickensoft-games/chickensoft_site/main/static/img/badges/discord_badge.svg
[discord]: https://discord.gg/gSjaPgMmYW
[read-the-docs-badge]: https://raw.githubusercontent.com/chickensoft-games/chickensoft_site/main/static/img/badges/read_the_docs_badge.svg
[docs]: https://chickensoft.games/docs/
[line-coverage]: Chickensoft.Introspection.Tests/badges/line_coverage.svg
[branch-coverage]: Chickensoft.Introspection.Tests/badges/branch_coverage.svg

[Introspection]: https://www.nuget.org/packages/Chickensoft.Introspection
[Introspection Generator]: https://www.nuget.org/packages/Chickensoft.Introspection.Generator
[Serialization]: https://github.com/chickensoft-games/Serialization
[AutoInject]: https://github.com/chickensoft-games/AutoInject
[LogicBlocks]: https://github.com/chickensoft-games/LogicBlocks
[type registry]: Chickensoft.Introspection.Generator.Tests/.generated/Chickensoft.Introspection.Generator/Chickensoft.Introspection.Generator.TypeGenerator/TypeRegistry.g.cs
[type graph]: Chickensoft.Introspection/src/TypeGraph.cs
[module initializer]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/module-initializers
[default interface method implementations]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods
[instance state]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods#detailed-design
[blackboard]: https://github.com/chickensoft-games/Collections?tab=readme-ov-file#blackboard
[metatype]: Chickensoft.Introspection/src/types/IMetatype.cs
[.NET compiler]: https://github.com/dotnet/roslyn/blob/main/docs/wiki/NuGet-packages.md
