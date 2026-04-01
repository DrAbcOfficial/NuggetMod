using NuggetMod.Enum.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for the ForceType enumeration
/// </summary>
public class ForceTypeTests
{
    [Theory]
    [InlineData(ForceType.ExactFile, 0)]
    [InlineData(ForceType.ModelSameBounds, 1)]
    [InlineData(ForceType.ModelSpecifyBounds, 2)]
    [InlineData(ForceType.ModelSpecifyBoundsIfAvailable, 3)]
    public void ForceType_ShouldHaveCorrectIntegerValue(ForceType type, int expectedValue)
    {
        // Assert
        ((int)type).Should().Be(expectedValue);
    }

    [Fact]
    public void ForceType_ExactFile_ShouldBeDefault()
    {
        // Arrange & Act
        ForceType defaultValue = default;

        // Assert
        defaultValue.Should().Be(ForceType.ExactFile);
    }
}
