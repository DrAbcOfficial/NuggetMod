using NuggetMod.Enum.Metamod;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Metamod;

/// <summary>
/// Tests for the InterfaceVersion enumeration
/// </summary>
public class InterfaceVersionTests
{
    [Theory]
    [InlineData(InterfaceVersion.V1, "V1")]
    [InlineData(InterfaceVersion.V2, "V2")]
    [InlineData(InterfaceVersion.V3, "V3")]
    [InlineData(InterfaceVersion.V4, "V4")]
    [InlineData(InterfaceVersion.V5, "V5")]
    [InlineData(InterfaceVersion.V5_1, "V5_1")]
    [InlineData(InterfaceVersion.V5_2, "V5_2")]
    [InlineData(InterfaceVersion.V5_3, "V5_3")]
    [InlineData(InterfaceVersion.V5_4, "V5_4")]
    [InlineData(InterfaceVersion.V5_5, "V5_5")]
    [InlineData(InterfaceVersion.V5_10, "V5_10")]
    [InlineData(InterfaceVersion.V5_13, "V5_13")]
    [InlineData(InterfaceVersion.V5_16, "V5_16")]
    public void InterfaceVersion_ShouldHaveCorrectName(InterfaceVersion version, string expectedName)
    {
        // Assert
        version.ToString().Should().Be(expectedName);
    }

    [Fact]
    public void InterfaceVersion_V1_ShouldBeDefault()
    {
        // Arrange & Act
        InterfaceVersion defaultValue = default;

        // Assert
        defaultValue.Should().Be(InterfaceVersion.V1);
    }

    [Fact]
    public void InterfaceVersion_ShouldHaveAllVersions()
    {
        // Arrange
        var versions = System.Enum.GetValues<InterfaceVersion>();

        // Assert - should have multiple versions
        versions.Should().HaveCountGreaterThan(10);
    }

    [Fact]
    public void InterfaceVersion_Latest_ShouldBe_V5_16()
    {
        // Arrange
        var versions = System.Enum.GetValues<InterfaceVersion>();

        // Assert
        versions.Max().Should().Be(InterfaceVersion.V5_16);
    }

    [Theory]
    [InlineData(InterfaceVersion.V5, InterfaceVersion.V5_10, true)]
    [InlineData(InterfaceVersion.V5_16, InterfaceVersion.V1, false)]
    [InlineData(InterfaceVersion.V5_6, InterfaceVersion.V5_6, false)]
    public void InterfaceVersion_ShouldSupportComparison(InterfaceVersion v1, InterfaceVersion v2, bool v1LessThanV2)
    {
        // Act
        bool result = v1 < v2;

        // Assert
        result.Should().Be(v1LessThanV2);
    }
}
