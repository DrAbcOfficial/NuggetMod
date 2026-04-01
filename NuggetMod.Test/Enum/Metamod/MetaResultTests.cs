using NuggetMod.Enum.Metamod;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Metamod;

/// <summary>
/// Tests for the MetaResult enumeration
/// </summary>
public class MetaResultTests
{
    [Theory]
    [InlineData(MetaResult.UnSet, 0)]
    [InlineData(MetaResult.Ignored, 1)]
    [InlineData(MetaResult.Handled, 2)]
    [InlineData(MetaResult.Override, 3)]
    [InlineData(MetaResult.SuperCEDE, 4)]
    public void MetaResult_ShouldHaveCorrectIntegerValue(MetaResult result, int expectedValue)
    {
        // Assert
        ((int)result).Should().Be(expectedValue);
    }

    [Fact]
    public void MetaResult_UnSet_ShouldBeDefault()
    {
        // Arrange & Act
        MetaResult defaultValue = default;

        // Assert
        defaultValue.Should().Be(MetaResult.UnSet);
    }

    [Fact]
    public void MetaResult_OrderShouldRepresentPriority()
    {
        // The order is crucial - greater/less comparisons are made
        // Higher values typically mean higher priority/control

        // Arrange
        var results = new[]
        {
            MetaResult.UnSet,
            MetaResult.Ignored,
            MetaResult.Handled,
            MetaResult.Override,
            MetaResult.SuperCEDE
        };

        // Assert
        for (int i = 1; i < results.Length; i++)
        {
            ((int)results[i]).Should().BeGreaterThan((int)results[i - 1]);
        }
    }

    [Theory]
    [InlineData(MetaResult.UnSet, false)]
    [InlineData(MetaResult.Ignored, false)]
    [InlineData(MetaResult.Handled, true)]
    [InlineData(MetaResult.Override, true)]
    [InlineData(MetaResult.SuperCEDE, true)]
    public void MetaResult_CanDetermineIfPluginHandledResult(MetaResult result, bool wasHandled)
    {
        // Act
        bool pluginHandled = result >= MetaResult.Handled;

        // Assert
        pluginHandled.Should().Be(wasHandled);
    }

    [Fact]
    public void MetaResult_SuperCEDE_ShouldHaveHighestPriority()
    {
        // Arrange
        var allResults = System.Enum.GetValues<MetaResult>();

        // Assert
        MetaResult.SuperCEDE.Should().Be(allResults.Max());
    }

    [Theory]
    [InlineData(MetaResult.Override, true)]  // Call real, use mine
    [InlineData(MetaResult.SuperCEDE, false)] // Skip real, use mine
    public void MetaResult_CanDetermineIfRealFunctionShouldBeCalled(MetaResult result, bool shouldCallReal)
    {
        // Act
        bool callRealFunction = result == MetaResult.Override;

        // Assert
        callRealFunction.Should().Be(shouldCallReal);
    }
}
