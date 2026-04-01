using NuggetMod.Wrapper;
using NuggetMod.Native.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Wrapper;

/// <summary>
/// Tests for the BaseNativeWrapper class
/// </summary>
public class BaseNativeWrapperTests
{
    // Concrete implementation for testing - only uses public constructor
    private class TestWrapper : BaseNativeWrapper<NativeVector3f>
    {
        public TestWrapper() : base() { }
    }

    [Fact]
    public void Constructor_Default_ShouldAllocateMemory()
    {
        // Act
        var wrapper = new TestWrapper();

        // Assert
        wrapper.Should().NotBeNull();
        wrapper.IsValid().Should().BeTrue();
        wrapper.IsDisposed.Should().BeFalse();
    }

    [Fact]
    public void Dispose_ShouldReleaseMemory()
    {
        // Arrange
        var wrapper = new TestWrapper();

        // Act
        wrapper.Dispose();

        // Assert
        wrapper.IsValid().Should().BeFalse();
        wrapper.IsDisposed.Should().BeTrue();
    }

    [Fact]
    public void Dispose_CalledTwice_ShouldNotThrow()
    {
        // Arrange
        var wrapper = new TestWrapper();
        wrapper.Dispose();

        // Act & Assert
        wrapper.Invoking(w => w.Dispose()).Should().NotThrow();
    }

    [Fact]
    public void GetNative_WhenValid_ShouldReturnPointer()
    {
        // Arrange
        var wrapper = new TestWrapper();

        // Act
        var ptr = wrapper.GetNative();

        // Assert
        ptr.Should().NotBe(nint.Zero);
    }

    [Fact]
    public void GetNative_WhenDisposed_ShouldThrow()
    {
        // Arrange
        var wrapper = new TestWrapper();
        wrapper.Dispose();

        // Act & Assert
        wrapper.Invoking(w => w.GetNative()).Should().Throw<ObjectDisposedException>();
    }

    [Fact]
    public void IsValid_DisposedWrapper_ShouldReturnFalse()
    {
        // Arrange
        var wrapper = new TestWrapper();

        // Act
        wrapper.Dispose();

        // Assert
        wrapper.IsValid().Should().BeFalse();
    }

    [Fact]
    public void UsingStatement_ShouldAutoDispose()
    {
        // Arrange
        TestWrapper? wrapper = null;

        // Act
        using (wrapper = new TestWrapper())
        {
            wrapper.IsValid().Should().BeTrue();
        }

        // Assert
        wrapper.IsDisposed.Should().BeTrue();
    }
}
