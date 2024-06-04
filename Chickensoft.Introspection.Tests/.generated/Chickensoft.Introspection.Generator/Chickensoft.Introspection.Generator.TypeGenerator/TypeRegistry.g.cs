﻿#pragma warning disable
#nullable enable
public partial class TypeRegistry : Chickensoft.Introspection.ITypeRegistry {
  public static Chickensoft.Introspection.ITypeRegistry Instance { get; } = new TypeRegistry();
  
  public System.Collections.Generic.IReadOnlyDictionary<System.Type, Chickensoft.Introspection.ITypeMetadata> VisibleTypes { get; } = new System.Collections.Generic.Dictionary<System.Type, Chickensoft.Introspection.ITypeMetadata>() {
      [typeof(Chickensoft.Introspection.Tests.Attributes.IdAttributeTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("IdAttributeTest", (r) => r.Receive<Chickensoft.Introspection.Tests.Attributes.IdAttributeTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.Attributes.IdAttributeTest>()), 
      [typeof(Chickensoft.Introspection.Tests.Attributes.MetaAttributeTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("MetaAttributeTest", (r) => r.Receive<Chickensoft.Introspection.Tests.Attributes.MetaAttributeTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.Attributes.MetaAttributeTest>()), 
      [typeof(Chickensoft.Introspection.Tests.Attributes.MixinAttributeTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("MixinAttributeTest", (r) => r.Receive<Chickensoft.Introspection.Tests.Attributes.MixinAttributeTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.Attributes.MixinAttributeTest>()), 
      [typeof(Chickensoft.Introspection.Tests.Attributes.VersionAttributeTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("VersionAttributeTest", (r) => r.Receive<Chickensoft.Introspection.Tests.Attributes.VersionAttributeTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.Attributes.VersionAttributeTest>()), 
      [typeof(Chickensoft.Introspection.Tests.EmptyMetatypeTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("EmptyMetatypeTest", (r) => r.Receive<Chickensoft.Introspection.Tests.EmptyMetatypeTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.EmptyMetatypeTest>()), 
      [typeof(Chickensoft.Introspection.Tests.IIntrospectiveTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("IIntrospectiveTest", (r) => r.Receive<Chickensoft.Introspection.Tests.IIntrospectiveTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.IIntrospectiveTest>()), 
      [typeof(Chickensoft.Introspection.Tests.MetaAttributeTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("MetaAttributeTest", (r) => r.Receive<Chickensoft.Introspection.Tests.MetaAttributeTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.MetaAttributeTest>()), 
      [typeof(Chickensoft.Introspection.Tests.Models.GenericTypeTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("GenericTypeTest", (r) => r.Receive<Chickensoft.Introspection.Tests.Models.GenericTypeTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.Models.GenericTypeTest>()), 
      [typeof(Chickensoft.Introspection.Tests.Models.MixinBlackboardTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("MixinBlackboardTest", (r) => r.Receive<Chickensoft.Introspection.Tests.Models.MixinBlackboardTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.Models.MixinBlackboardTest>()), 
      [typeof(Chickensoft.Introspection.Tests.Models.PropertyMetadataTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("PropertyMetadataTest", (r) => r.Receive<Chickensoft.Introspection.Tests.Models.PropertyMetadataTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.Models.PropertyMetadataTest>()), 
      [typeof(Chickensoft.Introspection.Tests.Models.TypeMetadataTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("TypeMetadataTest", (r) => r.Receive<Chickensoft.Introspection.Tests.Models.TypeMetadataTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.Models.TypeMetadataTest>()), 
      [typeof(Chickensoft.Introspection.Tests.MyTypeWithAMixin)] = new Chickensoft.Introspection.IntrospectiveTypeMetadata("MyTypeWithAMixin", (r) => r.Receive<Chickensoft.Introspection.Tests.MyTypeWithAMixin>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.MyTypeWithAMixin>(), new Chickensoft.Introspection.Tests.MyTypeWithAMixin.MetatypeMetadata(), 1), 
      [typeof(Chickensoft.Introspection.Tests.TagAttribute)] = new Chickensoft.Introspection.ConcreteTypeMetadata("TagAttribute", (r) => r.Receive<Chickensoft.Introspection.Tests.TagAttribute>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TagAttribute>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphAncestryTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("TypeGraphAncestryTest", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphAncestryTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphAncestryTest>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphAncestryTest.Ancestor)] = new Chickensoft.Introspection.ConcreteTypeMetadata("Ancestor", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.Ancestor>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.Ancestor>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphAncestryTest.AncestorSibling)] = new Chickensoft.Introspection.ConcreteTypeMetadata("AncestorSibling", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.AncestorSibling>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.AncestorSibling>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphAncestryTest.Child)] = new Chickensoft.Introspection.ConcreteTypeMetadata("Child", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.Child>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.Child>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphAncestryTest.ChildCousin)] = new Chickensoft.Introspection.ConcreteTypeMetadata("ChildCousin", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.ChildCousin>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.ChildCousin>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphAncestryTest.Parent)] = new Chickensoft.Introspection.ConcreteTypeMetadata("Parent", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.Parent>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.Parent>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphAncestryTest.ParentCousin)] = new Chickensoft.Introspection.ConcreteTypeMetadata("ParentCousin", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.ParentCousin>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphAncestryTest.ParentCousin>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("TypeGraphMemberMetadataTest", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest.ChildModel)] = new Chickensoft.Introspection.IntrospectiveTypeMetadata("ChildModel", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest.ChildModel>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest.ChildModel>(), new Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest.ChildModel.MetatypeMetadata(), 1), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest.Model)] = new Chickensoft.Introspection.IntrospectiveTypeMetadata("Model", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest.Model>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest.Model>(), new Chickensoft.Introspection.Tests.TypeGraphMemberMetadataTest.Model.MetatypeMetadata(), 1), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("TypeGraphTest", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphTest>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphTest.Model)] = new Chickensoft.Introspection.IdentifiableTypeMetadata("Model", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphTest.Model>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphTest.Model>(), new Chickensoft.Introspection.Tests.TypeGraphTest.Model.MetatypeMetadata(), "test_model", 1), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphTest.NoSubtypes)] = new Chickensoft.Introspection.IntrospectiveTypeMetadata("NoSubtypes", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphTest.NoSubtypes>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphTest.NoSubtypes>(), new Chickensoft.Introspection.Tests.TypeGraphTest.NoSubtypes.MetatypeMetadata(), 1), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeA)] = new Chickensoft.Introspection.IdentifiableTypeMetadata("SubtypeA", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeA>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeA>(), new Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeA.MetatypeMetadata(), "test_model_subtype_a", 1), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeA.SubtypeB)] = new Chickensoft.Introspection.IdentifiableTypeMetadata("SubtypeB", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeA.SubtypeB>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeA.SubtypeB>(), new Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeA.SubtypeB.MetatypeMetadata(), "test_model_subtype_b", 1), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeC)] = new Chickensoft.Introspection.IdentifiableTypeMetadata("SubtypeC", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeC>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeC>(), new Chickensoft.Introspection.Tests.TypeGraphTest.SubtypeC.MetatypeMetadata(), "test_model_subtype_c", 1), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphVersionTest)] = new Chickensoft.Introspection.ConcreteTypeMetadata("TypeGraphVersionTest", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphVersionTest>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphVersionTest>()), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model)] = new Chickensoft.Introspection.AbstractIdentifiableTypeMetadata("Model", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model>(), new Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model.MetatypeMetadata(), "version_test_model"), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model1)] = new Chickensoft.Introspection.IntrospectiveTypeMetadata("Model1", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model1>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model1>(), new Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model1.MetatypeMetadata(), 1), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model2)] = new Chickensoft.Introspection.IntrospectiveTypeMetadata("Model2", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model2>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model2>(), new Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model2.MetatypeMetadata(), 2), 
      [typeof(Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model3)] = new Chickensoft.Introspection.IntrospectiveTypeMetadata("Model3", (r) => r.Receive<Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model3>(), () => System.Activator.CreateInstance<Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model3>(), new Chickensoft.Introspection.Tests.TypeGraphVersionTest.Model3.MetatypeMetadata(), 3)
  };
  
  [System.Runtime.CompilerServices.ModuleInitializer]
  internal static void Initialize() => Chickensoft.Introspection.Types.Graph.Register(TypeRegistry.Instance);
}

#nullable restore
#pragma warning restore
