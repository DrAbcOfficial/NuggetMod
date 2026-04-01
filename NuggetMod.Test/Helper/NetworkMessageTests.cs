using NuggetMod.Helper;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Helper;

/// <summary>
/// Tests for the NetworkMessage class
/// These tests verify the class structure without actual engine calls
/// </summary>
public class NetworkMessageTests
{
    [Fact]
    public void NetworkMessage_Class_ShouldExist()
    {
        // Arrange & Act
        var type = typeof(NetworkMessage);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
    }

    [Fact]
    public void NetworkMessage_ShouldBeConstructible_WithMultipleConstructors()
    {
        // This test verifies the constructor signatures exist
        // Actual testing requires engine context
        var type = typeof(NetworkMessage);
        var constructors = type.GetConstructors();

        // Assert - should have 4 constructors
        constructors.Should().HaveCount(4);
    }

    [Fact]
    public void NetworkMessage_ShouldHaveWriteMethods()
    {
        // Arrange
        var type = typeof(NetworkMessage);

        // Act
        var methods = type.GetMethods();

        // Assert
        methods.Should().Contain(m => m.Name == "WriteByte");
        methods.Should().Contain(m => m.Name == "WriteChar");
        methods.Should().Contain(m => m.Name == "WriteShort");
        methods.Should().Contain(m => m.Name == "WriteLong");
        methods.Should().Contain(m => m.Name == "WriteAngle");
        methods.Should().Contain(m => m.Name == "WriteCoord");
        methods.Should().Contain(m => m.Name == "WriteString");
        methods.Should().Contain(m => m.Name == "WriteEntity");
        methods.Should().Contain(m => m.Name == "WriteFloat");
        methods.Should().Contain(m => m.Name == "WriteVector");
    }

    [Fact]
    public void NetworkMessage_ShouldHaveSendMethod()
    {
        // Arrange
        var type = typeof(NetworkMessage);

        // Act
        var sendMethod = type.GetMethod("Send");

        // Assert
        sendMethod.Should().NotBeNull();
    }

    [Fact]
    public void NetworkMessage_WriteMethods_ShouldReturnNetworkMessage()
    {
        // Arrange
        var type = typeof(NetworkMessage);
        var writeMethods = type.GetMethods()
            .Where(m => m.Name.StartsWith("Write") && m.ReturnType != typeof(void));

        // Assert
        foreach (var method in writeMethods)
        {
            method.ReturnType.Should().Be(typeof(NetworkMessage));
        }
    }
}
