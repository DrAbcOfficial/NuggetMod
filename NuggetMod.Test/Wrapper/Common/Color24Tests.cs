using NuggetMod.Wrapper.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Wrapper.Common;

/// <summary>
/// Tests for the Color24 class
/// </summary>
public class Color24Tests
{
    #region Constructors

    [Fact]
    public void Constructor_Default_ShouldCreateColor()
    {
        // Act
        var color = new Color24();

        // Assert - just verify it can be created without throwing
        color.Should().NotBeNull();
        color.IsValid().Should().BeTrue();

        // Cleanup
        color.Dispose();
    }

    [Theory]
    [InlineData(255, 0, 0)]    // Red
    [InlineData(0, 255, 0)]    // Green
    [InlineData(0, 0, 255)]    // Blue
    [InlineData(255, 255, 255)] // White
    [InlineData(0, 0, 0)]      // Black
    [InlineData(128, 128, 128)] // Gray
    [InlineData(255, 255, 0)]   // Yellow
    [InlineData(255, 0, 255)]   // Magenta
    [InlineData(0, 255, 255)]   // Cyan
    public void Constructor_WithRGB_ShouldSetCorrectValues(byte r, byte g, byte b)
    {
        // Act
        var color = new Color24(r, g, b);

        // Assert
        color.R.Should().Be(r);
        color.G.Should().Be(g);
        color.B.Should().Be(b);
    }

    [Theory]
    [InlineData(0xFF0000, 255, 0, 0)]       // Red
    [InlineData(0x00FF00, 0, 255, 0)]       // Green
    [InlineData(0x0000FF, 0, 0, 255)]       // Blue
    [InlineData(0xFFFFFF, 255, 255, 255)]   // White
    [InlineData(0x000000, 0, 0, 0)]         // Black
    [InlineData(0x808080, 128, 128, 128)]   // Gray
    [InlineData(0xFFFF00, 255, 255, 0)]     // Yellow
    public void Constructor_WithPackedColor_ShouldUnpackCorrectly(int packedColor, byte expectedR, byte expectedG, byte expectedB)
    {
        // Act
        var color = new Color24(packedColor);

        // Assert
        color.R.Should().Be(expectedR);
        color.G.Should().Be(expectedG);
        color.B.Should().Be(expectedB);
    }

    #endregion

    #region Properties

    [Theory]
    [InlineData(0)]
    [InlineData(128)]
    [InlineData(255)]
    public void R_Property_ShouldGetAndSet(byte value)
    {
        // Arrange
        var color = new Color24();

        // Act
        color.R = value;

        // Assert
        color.R.Should().Be(value);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(128)]
    [InlineData(255)]
    public void G_Property_ShouldGetAndSet(byte value)
    {
        // Arrange
        var color = new Color24();

        // Act
        color.G = value;

        // Assert
        color.G.Should().Be(value);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(128)]
    [InlineData(255)]
    public void B_Property_ShouldGetAndSet(byte value)
    {
        // Arrange
        var color = new Color24();

        // Act
        color.B = value;

        // Assert
        color.B.Should().Be(value);
    }

    #endregion

    #region Common Colors

    [Fact]
    public void Color24_ShouldSupportPrimaryColors()
    {
        // Arrange
        var red = new Color24(255, 0, 0);
        var green = new Color24(0, 255, 0);
        var blue = new Color24(0, 0, 255);

        // Assert
        red.R.Should().Be(255);
        red.G.Should().Be(0);
        red.B.Should().Be(0);

        green.R.Should().Be(0);
        green.G.Should().Be(255);
        green.B.Should().Be(0);

        blue.R.Should().Be(0);
        blue.G.Should().Be(0);
        blue.B.Should().Be(255);
    }

    [Fact]
    public void Color24_ShouldSupportBlackAndWhite()
    {
        // Arrange
        var black = new Color24(0, 0, 0);
        var white = new Color24(255, 255, 255);

        // Assert
        black.R.Should().Be(0);
        black.G.Should().Be(0);
        black.B.Should().Be(0);

        white.R.Should().Be(255);
        white.G.Should().Be(255);
        white.B.Should().Be(255);
    }

    #endregion

    #region IDisposable

    [Fact]
    public void Dispose_ShouldNotThrow()
    {
        // Arrange
        var color = new Color24(255, 128, 64);

        // Act & Assert
        color.Invoking(c => c.Dispose()).Should().NotThrow();
    }

    [Fact]
    public void IsValid_AfterConstruction_ShouldReturnTrue()
    {
        // Arrange
        var color = new Color24();

        // Assert
        color.IsValid().Should().BeTrue();
    }

    [Fact]
    public void IsValid_AfterDispose_ShouldReturnFalse()
    {
        // Arrange
        var color = new Color24();

        // Act
        color.Dispose();

        // Assert
        color.IsValid().Should().BeFalse();
    }

    #endregion

    #region Color Packing

    [Fact]
    public void Constructor_PackedColor_UpperBytesShouldBeIgnored()
    {
        // Arrange - 0xFF in the upper byte should be ignored
        int packedWithAlpha = unchecked((int)0xFFFF0000); // ARGB with A=255

        // Act
        var color = new Color24(packedWithAlpha);

        // Assert - upper byte should be ignored
        color.R.Should().Be(255);
        color.G.Should().Be(0);
        color.B.Should().Be(0);
    }

    #endregion
}
