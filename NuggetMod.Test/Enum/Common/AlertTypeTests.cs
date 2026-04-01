using NuggetMod.Enum.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for the AlertType enumeration
/// </summary>
public class AlertTypeTests
{
    [Theory]
    [InlineData(AlertType.Notice, 0)]
    [InlineData(AlertType.Console, 1)]
    [InlineData(AlertType.DeveloperConsole, 2)]
    [InlineData(AlertType.Warning, 3)]
    [InlineData(AlertType.Error, 4)]
    [InlineData(AlertType.Logged, 5)]
    public void AlertType_ShouldHaveCorrectIntegerValue(AlertType alert, int expectedValue)
    {
        // Assert
        ((int)alert).Should().Be(expectedValue);
    }

    [Fact]
    public void AlertType_Notice_ShouldBeDefault()
    {
        // Arrange & Act
        AlertType defaultValue = default;

        // Assert
        defaultValue.Should().Be(AlertType.Notice);
    }

    [Fact]
    public void AlertType_ShouldRepresentSeverityLevels()
    {
        // Arrange
        var severityOrder = new[]
        {
            AlertType.Notice,
            AlertType.Console,
            AlertType.DeveloperConsole,
            AlertType.Warning,
            AlertType.Error,
            AlertType.Logged
        };

        // Assert - each subsequent type has higher or equal value
        for (int i = 1; i < severityOrder.Length; i++)
        {
            ((int)severityOrder[i]).Should().BeGreaterThanOrEqualTo((int)severityOrder[i - 1]);
        }
    }

    [Theory]
    [InlineData(AlertType.Error, true)]
    [InlineData(AlertType.Warning, true)]
    [InlineData(AlertType.Notice, false)]
    public void AlertType_CanIdentifyErrorLevels(AlertType alert, bool isErrorOrWarning)
    {
        // Act
        bool isCritical = alert == AlertType.Error || alert == AlertType.Warning;

        // Assert
        isCritical.Should().Be(isErrorOrWarning);
    }
}
