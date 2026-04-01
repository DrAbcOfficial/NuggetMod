using NuggetMod.Enum.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for the DeadFlag enumeration
/// </summary>
public class DeadFlagTests
{
    [Theory]
    [InlineData(DeadFlag.No, 0)]
    [InlineData(DeadFlag.Dying, 1)]
    [InlineData(DeadFlag.Dead, 2)]
    [InlineData(DeadFlag.Respawnable, 3)]
    [InlineData(DeadFlag.DiscardBody, 4)]
    public void DeadFlag_ShouldHaveCorrectIntegerValue(DeadFlag flag, int expectedValue)
    {
        // Assert
        ((int)flag).Should().Be(expectedValue);
    }

    [Fact]
    public void DeadFlag_No_ShouldBeDefault()
    {
        // Arrange & Act
        DeadFlag defaultValue = default;

        // Assert
        defaultValue.Should().Be(DeadFlag.No);
    }

    [Fact]
    public void DeadFlag_ShouldRepresentPlayerLifeCycle()
    {
        // Arrange
        var lifeCycle = new[]
        {
            DeadFlag.No,
            DeadFlag.Dying,
            DeadFlag.Dead,
            DeadFlag.Respawnable,
            DeadFlag.DiscardBody
        };

        // Assert
        lifeCycle.Should().BeInAscendingOrder();
        for (int i = 0; i < lifeCycle.Length; i++)
        {
            ((int)lifeCycle[i]).Should().Be(i);
        }
    }

    [Theory]
    [InlineData(DeadFlag.No, true)]   // Alive
    [InlineData(DeadFlag.Dying, false)] // Not alive
    [InlineData(DeadFlag.Dead, false)]  // Not alive
    [InlineData(DeadFlag.Respawnable, false)] // Not alive yet
    public void DeadFlag_CanDetermineIfPlayerIsAlive(DeadFlag flag, bool expectedAlive)
    {
        // Act
        bool isAlive = flag == DeadFlag.No;

        // Assert
        isAlive.Should().Be(expectedAlive);
    }
}
