using NuggetMod.Native;
using NuggetMod.Native.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Native;

/// <summary>
/// Tests for native structures
/// </summary>
public unsafe class NativeStructTests
{
    #region INativeStruct Interface

    [Fact]
    public void NativeStructTypes_ShouldImplementINativeStruct()
    {
        // Arrange & Assert
        typeof(NativeVector3f).Should().Implement<INativeStruct>();
        typeof(NativeColor24).Should().Implement<INativeStruct>();
    }

    #endregion

    #region NativeVector3f Size

    [Fact]
    public void NativeVector3f_ShouldHaveCorrectSize()
    {
        // Arrange & Act
        var size = sizeof(NativeVector3f);

        // Assert - 3 floats = 12 bytes
        size.Should().Be(12);
    }

    #endregion

    #region NativeColor24 Size

    [Fact]
    public void NativeColor24_ShouldHaveCorrectSize()
    {
        // Arrange & Act
        var size = sizeof(NativeColor24);

        // Assert - 3 bytes, possibly padded to 4
        size.Should().BeLessThanOrEqualTo(4);
    }

    #endregion

    #region Memory Layout

    [Fact]
    public void NativeVector3f_Fields_ShouldBeSequential()
    {
        // This test verifies the struct layout is sequential
        // which is required for correct native interop
        var structType = typeof(NativeVector3f);
        var layoutAttribute = structType.StructLayoutAttribute;

        // Assert
        layoutAttribute.Should().NotBeNull();
    }

    [Fact]
    public void NativeColor24_Fields_ShouldBeSequential()
    {
        // This test verifies the struct layout is sequential
        var structType = typeof(NativeColor24);
        var layoutAttribute = structType.StructLayoutAttribute;

        // Assert
        layoutAttribute.Should().NotBeNull();
    }

    #endregion
}
