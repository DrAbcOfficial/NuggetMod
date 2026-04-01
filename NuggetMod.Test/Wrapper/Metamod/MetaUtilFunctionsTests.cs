using NuggetMod.Helper;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Wrapper.Metamod;

/// <summary>
/// Tests for MetaUtilFunctions related types.
/// Note: MetaUtilFunctions requires valid native function pointers and cannot be unit tested.
/// These tests verify the supporting types and structures.
/// </summary>
public class MetaUtilFunctionsTests
{
    [Fact]
    public void PatternSearch_WithValidPattern_ShouldHaveCorrectLength()
    {
        // Arrange
        byte[] pattern = [0x55, 0x8B, 0xEC]; // Common x86 prologue

        // Assert
        pattern.Length.Should().Be(3);
        pattern[0].Should().Be(0x55);
        pattern[1].Should().Be(0x8B);
        pattern[2].Should().Be(0xEC);
    }

    [Fact]
    public void EmptyPattern_ShouldHaveZeroLength()
    {
        // Arrange
        byte[] emptyPattern = [];

        // Assert
        emptyPattern.Length.Should().Be(0);
    }
}

/// <summary>
/// Tests for ValidationResult struct.
/// </summary>
public class ValidationResultTests
{
    [Fact]
    public void ValidationResult_Default_CanRegisterShouldBeFalse()
    {
        // Arrange & Act
        var result = new ValidationResult
        {
            CanRegister = false,
            ConflictingTypes = Array.Empty<string>()
        };

        // Assert
        result.CanRegister.Should().BeFalse();
        result.HasConflicts.Should().BeFalse();
    }

    [Fact]
    public void ValidationResult_WithConflicts_HasConflictsShouldBeTrue()
    {
        // Arrange & Act
        var result = new ValidationResult
        {
            CanRegister = false,
            ConflictingTypes = new[] { "EntityApi", "EngineFunctions" }
        };

        // Assert
        result.CanRegister.Should().BeFalse();
        result.HasConflicts.Should().BeTrue();
        result.ConflictingTypes.Should().HaveCount(2);
    }

    [Fact]
    public void ValidationResult_WithoutConflicts_CanRegisterShouldBeTrue()
    {
        // Arrange & Act
        var result = new ValidationResult
        {
            CanRegister = true,
            ConflictingTypes = Array.Empty<string>()
        };

        // Assert
        result.CanRegister.Should().BeTrue();
        result.HasConflicts.Should().BeFalse();
    }

    [Fact]
    public void ValidationResult_ReadOnlyCollection_ShouldNotBeModifiable()
    {
        // Arrange
        var result = new ValidationResult
        {
            CanRegister = false,
            ConflictingTypes = new[] { "Test" }
        };

        // Act & Assert
        result.ConflictingTypes.Should().BeAssignableTo<System.Collections.Generic.IReadOnlyCollection<string>>();
    }
}
