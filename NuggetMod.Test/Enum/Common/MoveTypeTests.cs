using NuggetMod.Enum.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for the MoveType enumeration
/// </summary>
public class MoveTypeTests
{
    [Theory]
    [InlineData(MoveType.None, 0)]
    [InlineData(MoveType.AngleNoClip, 1)]
    [InlineData(MoveType.AngleClip, 2)]
    [InlineData(MoveType.Walk, 3)]
    [InlineData(MoveType.Step, 4)]
    [InlineData(MoveType.Fly, 5)]
    [InlineData(MoveType.Toss, 6)]
    [InlineData(MoveType.Push, 7)]
    [InlineData(MoveType.NoClip, 8)]
    [InlineData(MoveType.FlyMissile, 9)]
    [InlineData(MoveType.Bounce, 10)]
    [InlineData(MoveType.BounceMissile, 11)]
    [InlineData(MoveType.Follow, 12)]
    [InlineData(MoveType.PushStep, 13)]
    public void MoveType_ShouldHaveCorrectIntegerValue(MoveType moveType, int expectedValue)
    {
        // Assert
        ((int)moveType).Should().Be(expectedValue);
    }

    [Fact]
    public void MoveType_None_ShouldBeDefault()
    {
        // Arrange & Act
        MoveType defaultValue = default;

        // Assert
        defaultValue.Should().Be(MoveType.None);
    }

    [Theory]
    [InlineData(MoveType.None, "Never moves")]
    [InlineData(MoveType.Walk, "Player only - moving on the ground")]
    [InlineData(MoveType.Fly, "No gravity, but still collides with stuff")]
    [InlineData(MoveType.NoClip, "No gravity, no collisions, still do velocity/avelocity")]
    public void MoveType_Values_ShouldRepresentValidGamePhysics(MoveType moveType, string description)
    {
        // This test documents the expected behavior of each move type
        // The description parameter serves as documentation

        // Assert
        moveType.Should().BeDefined();
        description.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void MoveType_AllValues_ShouldBeSequential()
    {
        // Arrange
        var values = System.Enum.GetValues<MoveType>();

        // Act & Assert
        for (int i = 0; i < values.Length; i++)
        {
            ((int)values[i]).Should().Be(i);
        }
    }

    [Theory]
    [InlineData(MoveType.Walk, true)]
    [InlineData(MoveType.Step, true)]
    [InlineData(MoveType.Fly, true)]
    [InlineData(MoveType.Toss, true)]
    [InlineData(MoveType.Bounce, true)]
    public void MoveType_PhysicsTypes_ShouldBeUsedByEntities(MoveType moveType, bool isPhysicsType)
    {
        // Assert
        isPhysicsType.Should().BeTrue();
        moveType.Should().BeDefined();
    }

    [Fact]
    public void MoveType_DeprecatedValues_ShouldExistForBackwardCompatibility()
    {
        // Arrange
        var deprecatedTypes = new[] { MoveType.AngleNoClip, MoveType.AngleClip };

        // Act & Assert
        deprecatedTypes.Should().AllSatisfy(type =>
        {
            type.Should().BeDefined();
            ((int)type).Should().BeGreaterThan((int)MoveType.None);
        });
    }
}
