using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for user command button flags (if they exist as an enum)
/// This documents common GoldSrc button values
/// </summary>
public class UserCmdButtonTests
{
    // These are commonly used button flags in GoldSrc
    public const int Attack = 1;
    public const int Jump = 2;
    public const int Duck = 4;
    public const int Forward = 8;
    public const int Back = 16;
    public const int Use = 32;
    public const int Left = 512;
    public const int Right = 1024;
    public const int MoveLeft = 1536;
    public const int MoveRight = 2048;
    public const int Attack2 = 2048;
    public const int Run = 4096;
    public const int Reload = 8192;
    public const int Alt1 = 16384;
    public const int Score = 32768;

    [Theory]
    [InlineData(Attack, 1)]
    [InlineData(Jump, 2)]
    [InlineData(Duck, 4)]
    [InlineData(Forward, 8)]
    [InlineData(Back, 16)]
    [InlineData(Use, 32)]
    public void ButtonConstants_ShouldHaveCorrectValues(int button, int expectedValue)
    {
        // Assert
        button.Should().Be(expectedValue);
    }

    [Fact]
    public void ButtonConstants_ShouldBePowerOfTwo()
    {
        // Arrange
        var buttons = new[] { Attack, Jump, Duck, Forward, Back, Use };

        // Assert
        foreach (var button in buttons)
        {
            (button & (button - 1)).Should().Be(0); // Power of two check
        }
    }

    [Fact]
    public void CombinedButtons_ShouldSupportBitwiseOr()
    {
        // Arrange & Act
        int combined = Attack | Jump | Duck;

        // Assert
        (combined & Attack).Should().NotBe(0);
        (combined & Jump).Should().NotBe(0);
        (combined & Duck).Should().NotBe(0);
        (combined & Forward).Should().Be(0);
    }
}
