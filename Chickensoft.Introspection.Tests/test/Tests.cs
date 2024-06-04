namespace Chickensoft.Introspection.Tests;

using System.Reflection;
using Godot;
using Chickensoft.GoDotTest;

public partial class Tests : Node2D {
  public override void _Ready() => CallDeferred(MethodName.RunTests);

  public void RunTests() =>
    GoTest.RunTests(Assembly.GetExecutingAssembly(), this);
}
