using NuggetMod.Enum.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for the PrintType enumeration
/// </summary>
public class PrintTypeTests
{
    [Theory]
    [InlineData(PrintType.Console, 0)]
    [InlineData(PrintType.Center, 1)]
    [InlineData(PrintType.Chat, 2)]
    public void PrintType_ShouldHaveCorrectIntegerValue(PrintType type, int expectedValue)
    {
        // Assert
        ((int)type).Should().Be(expectedValue);
    }

    [Fact]
    public void PrintType_Console_ShouldBeDefault()
    {
        // Arrange & Act
        PrintType defaultValue = default;

        // Assert
        defaultValue.Should().Be(PrintType.Console);
    }

    [Fact]
    public void PrintType_ShouldRepresentAllOutputChannels()
    {
        // Arrange
        var types = System.Enum.GetValues<PrintType>();

        // Assert
        types.Should().Contain(PrintType.Console);
        types.Should().Contain(PrintType.Center);
        types.Should().Contain(PrintType.Chat);
    }
}
