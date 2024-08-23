namespace Chickensoft.Introspection.Generator.Tests.TestCases;

using Chickensoft.Introspection;
using Chickensoft.Introspection.Generator.Tests.TestUtils;



[Meta, Id("init_args_model")]
public partial class InitArgsModel {
  public enum InitArgsEnum {
    No = -1,
    Undecided = 0,
    Yes = 1,
  }

  [Tag("name")]
  public required string Name { get; init; }

  [Tag("age")]
  public required int Age { get; init; }

  [Tag("description")]
  public string? Description { get; init; }

  [Tag("address")]
  public string? Address { get; set; } // not init

  // Init/set enum with default value
  [Tag("is_attending")]
  public InitArgsEnum IsAttending { get; set; } = InitArgsEnum.Yes;

  // Init enum with default value
  [Tag("has_attended")]
  public InitArgsEnum HasAttended { get; init; } = InitArgsEnum.No;
}
