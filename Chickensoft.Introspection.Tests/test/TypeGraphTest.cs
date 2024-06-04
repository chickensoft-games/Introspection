namespace Chickensoft.Introspection.Tests;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Chickensoft.Introspection;
using Moq;
using Shouldly;
using Xunit;

public partial class TypeGraphTest {
  [Meta, Id("test_model")]
  public partial class Model {
    public string Name { get; } = "model";
  }

  [Meta, Id("test_model_subtype_a")]
  public partial class SubtypeA : Model {

    [Meta, Id("test_model_subtype_b")]
    public partial class SubtypeB : SubtypeA { }
  }

  [Meta, Id("test_model_subtype_c")]
  public partial class SubtypeC : Model { }

  [Meta]
  public partial class NoSubtypes { }

  [Fact]
  public void GetIdentifiableType() =>
    Types.Graph.GetIdentifiableType("test_model").ShouldBe(typeof(Model));

  [Fact]
  public void HasMetadata() =>
    Types.Graph.HasMetadata(typeof(Model)).ShouldBeTrue();

  [Fact]
  public void GetMetadata() {
    Types.Graph.GetMetadata(typeof(Model)).ShouldNotBeNull();
    Types.Graph.GetMetadata(typeof(object)).ShouldBeNull();
  }

  [Fact]
  public void GetSubtypes() {
    Types.Graph.GetSubtypes(typeof(Model))
      .ShouldBe([
        typeof(SubtypeA),
        typeof(SubtypeC),
      ], ignoreOrder: true);
    Types.Graph.GetSubtypes(typeof(ObsoleteAttribute)).ShouldBeEmpty();
  }

  [Fact]
  public void GetProperties() {
    var props = Types.Graph.GetProperties(typeof(Model)).ToList();
    props.Count.ShouldBe(1);
    props[0].Name.ShouldBe("Name");

    Types.Graph.GetProperties(typeof(ObsoleteAttribute)).ShouldBeEmpty();
  }

  [Fact]
  public void GetAttribute() {
    var attr = Types.Graph.GetAttribute<MetaAttribute>(typeof(Model));
    attr.ShouldNotBeNull();

    Types.Graph.GetAttribute<TagAttribute>(typeof(Exception))
      .ShouldBeNull();
  }

  [Fact]
  public void AddCustomType() {
    Types.Graph.AddCustomType(
      typeof(ObsoleteAttribute),
      "ObsoleteAttribute",
      (r) => r.Receive<ObsoleteAttribute>(),
      () => new ObsoleteAttribute(),
      "obsolete_attribute",
      1
    );

    Types.Graph.GetMetadata(typeof(ObsoleteAttribute)).ShouldNotBeNull();

    Should.Throw<DuplicateNameException>(() =>
      Types.Graph.AddCustomType(
        typeof(ObsoleteAttribute),
        "ObsoleteAttribute",
        (r) => r.Receive<ObsoleteAttribute>(),
        () => new ObsoleteAttribute(),
        "obsolete_attribute",
        1
      )
    );
  }
}

public class TypeGraphAncestryTest {
  public class Ancestor;
  public class Parent : Ancestor;
  public class Child : Parent;

  public class AncestorSibling;
  public class ParentCousin : AncestorSibling;
  public class ChildCousin : ParentCousin;

  private static readonly Dictionary<Type, ITypeMetadata> _visibleTypes = new() {
    [typeof(Ancestor)] = new Mock<ITypeMetadata>().Object,
    [typeof(Parent)] = new Mock<ITypeMetadata>().Object,
    [typeof(Child)] = new Mock<ITypeMetadata>().Object,
    [typeof(AncestorSibling)] = new Mock<ITypeMetadata>().Object,
    [typeof(ParentCousin)] = new Mock<ITypeMetadata>().Object,
    [typeof(ChildCousin)] = new Mock<ITypeMetadata>().Object,
  };
  private readonly Mock<ITypeRegistry> _registry;

  public TypeGraphAncestryTest() {
    _registry = new Mock<ITypeRegistry>();
  }

  [Fact]
  public void GetDescendantSubtypes() {
    _registry.Setup(reg => reg.VisibleTypes).Returns(_visibleTypes);

    Types.Graph.Register(_registry.Object);

    var ancestorDescendants =
      Types.Graph.GetDescendantSubtypes(typeof(Ancestor));

    ancestorDescendants.ShouldBe([
        typeof(Parent),
        typeof(Child),
      ], ignoreOrder: true
    );

    // Should be the exact same object reference since a repeated lookup is
    // cached.
    Types.Graph.GetDescendantSubtypes(typeof(Ancestor))
      .ShouldBeSameAs(ancestorDescendants);

    Types.Graph.GetDescendantSubtypes(typeof(Parent))
      .ShouldBe([
        typeof(Child),
      ], ignoreOrder: true
    );

    Types.Graph.GetDescendantSubtypes(typeof(Child)).ShouldBeEmpty();

    Types.Graph.GetDescendantSubtypes(typeof(AncestorSibling))
      .ShouldBe([
        typeof(ParentCousin),
        typeof(ChildCousin),
      ], ignoreOrder: true
    );

    Types.Graph.GetDescendantSubtypes(typeof(ParentCousin))
      .ShouldBe([
        typeof(ChildCousin),
      ], ignoreOrder: true
    );

    Types.Graph.GetDescendantSubtypes(typeof(ChildCousin)).ShouldBeEmpty();
  }

  [Fact]
  public void ObjectWithoutBaseTypeIsNonIssue() {
    // When looking up a type that has no base type — i.e., typeof(object)) —
    // we want to make sure we don't crash.
    _registry
      .Setup(reg => reg.VisibleTypes)
      .Returns(new Dictionary<Type, ITypeMetadata> {
        [typeof(TypeGraphAncestryTest)] = new Mock<ITypeMetadata>().Object,
      });

    Types.InternalGraph.Reset();
    Types.Graph.Register(_registry.Object);

    Types.Graph
    .GetDescendantSubtypes(typeof(TypeGraphAncestryTest))
    .ShouldBeEmpty();
  }
}


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public class TagAttribute : Attribute {
  public string Name { get; }

  public TagAttribute(string name) {
    Name = name;
  }
}

public partial class TypeGraphMemberMetadataTest {
  [Meta, Tag("model")]
  public partial class Model {
    public string? Name { get; init; }
    [Tag("age")]
    public required int Age { get; init; }
  }

  [Meta, Tag("child")]
  public partial class ChildModel : Model {
    public string? ChildName { get; init; }
  }

  [Fact]
  public void ComputesPropertyMetadataForDerivedTypes() {
    var props = Types.Graph.GetProperties(typeof(ChildModel)).ToList();

    // Props are in alphabetical order for stable & predictable orderings.

    props[0].Name.ShouldBe("Age");
    props[0]
      .Attributes[typeof(TagAttribute)].Single()
      .ShouldBeOfType<TagAttribute>().Name.ShouldBe("age");

    props[1].Name.ShouldBe("ChildName");

    props[2].Name.ShouldBe("Name");
  }
}

public partial class TypeGraphVersionTest {
  [Meta, Id("version_test_model")]
  public abstract partial class Model;

  [Meta, Version(1)]
  public partial class Model1 : Model;

  [Meta, Version(2)]
  public partial class Model2 : Model;

  [Meta, Version(3)]
  public partial class Model3 : Model;

  [Fact]
  public void GetLatestVersion() {
    Types.Graph.GetLatestVersion("version_test_model").ShouldBe(3);
    Types.Graph.GetLatestVersion("unknown").ShouldBeNull();
  }

  [Fact]
  public void GetIdentifiableTypeByVersion() {
    Types.Graph.GetIdentifiableType("version_test_model", 1)
      .ShouldBe(typeof(Model1));
    Types.Graph.GetIdentifiableType("version_test_model", 2)
      .ShouldBe(typeof(Model2));
    Types.Graph.GetIdentifiableType("version_test_model", 3)
      .ShouldBe(typeof(Model3));
    Types.Graph.GetIdentifiableType("version_test_model", 4)
      .ShouldBeNull();
  }
}

public partial class EmptyMetatypeTest {
  [Fact]
  public void Initializes() {
    var metatype = new TypeGraph.EmptyMetatype(typeof(object));

    metatype.Type.ShouldBe(typeof(object));
    metatype.HasInitProperties.ShouldBeFalse();
    metatype.Properties.ShouldBeEmpty();
    metatype.Attributes.ShouldBeEmpty();
    metatype.Mixins.ShouldBeEmpty();
    metatype.MixinHandlers.ShouldBeEmpty();

    Should.Throw<NotImplementedException>(() => metatype.Construct());

    metatype.Equals(new TypeGraph.EmptyMetatype(typeof(object))).ShouldBeTrue();
    metatype.GetHashCode().ShouldBeOfType<int>();
  }
}
