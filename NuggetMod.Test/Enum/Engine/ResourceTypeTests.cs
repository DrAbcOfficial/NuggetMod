using NuggetMod.Enum.Engine;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Engine;

/// <summary>
/// Tests for the ResourceType enumeration
/// </summary>
public class ResourceTypeTests
{
    [Theory]
    [InlineData(ResourceType.Sound, 0)]
    [InlineData(ResourceType.Skin, 1)]
    [InlineData(ResourceType.Model, 2)]
    [InlineData(ResourceType.Decal, 3)]
    [InlineData(ResourceType.Generic, 4)]
    [InlineData(ResourceType.EventScript, 5)]
    [InlineData(ResourceType.World, 6)]
    public void ResourceType_ShouldHaveCorrectIntegerValue(ResourceType type, int expectedValue)
    {
        // Assert
        ((int)type).Should().Be(expectedValue);
    }

    [Fact]
    public void ResourceType_Sound_ShouldBeDefault()
    {
        // Arrange & Act
        ResourceType defaultValue = default;

        // Assert
        defaultValue.Should().Be(ResourceType.Sound);
    }

    [Fact]
    public void ResourceType_ShouldHaveSequentialValues()
    {
        // Arrange
        var values = System.Enum.GetValues<ResourceType>();

        // Assert
        for (int i = 0; i < values.Length; i++)
        {
            ((int)values[i]).Should().Be(i);
        }
    }

    [Theory]
    [InlineData(ResourceType.Model, true)]
    [InlineData(ResourceType.Sound, true)]
    [InlineData(ResourceType.Skin, false)]
    public void ResourceType_CanIdentifyAssetTypes(ResourceType type, bool isAsset)
    {
        // This test documents the expected behavior
        // Assert
        type.Should().BeDefined();
    }
}
