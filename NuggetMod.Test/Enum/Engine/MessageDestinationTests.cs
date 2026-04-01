using NuggetMod.Enum.Engine;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Engine;

/// <summary>
/// Tests for the MessageDestination enumeration
/// </summary>
public class MessageDestinationTests
{
    [Theory]
    [InlineData(MessageDestination.Broadcast, 0)]
    [InlineData(MessageDestination.One, 1)]
    [InlineData(MessageDestination.All, 2)]
    [InlineData(MessageDestination.Init, 3)]
    [InlineData(MessageDestination.PVS, 4)]
    [InlineData(MessageDestination.PAS, 5)]
    public void MessageDestination_ShouldHaveCorrectIntegerValue(MessageDestination dest, int expectedValue)
    {
        // Assert
        ((int)dest).Should().Be(expectedValue);
    }

    [Fact]
    public void MessageDestination_Broadcast_ShouldBeDefault()
    {
        // Arrange & Act
        MessageDestination defaultValue = default;

        // Assert
        defaultValue.Should().Be(MessageDestination.Broadcast);
    }

    [Fact]
    public void MessageDestination_ShouldHaveSequentialValues()
    {
        // Arrange
        var values = System.Enum.GetValues<MessageDestination>();

        // Assert
        for (int i = 0; i < values.Length; i++)
        {
            ((int)values[i]).Should().Be(i);
        }
    }

    [Theory]
    [InlineData(MessageDestination.Broadcast, true)]
    [InlineData(MessageDestination.All, true)]
    [InlineData(MessageDestination.One, false)]
    public void MessageDestination_CanIdentifyBroadcastTargets(MessageDestination dest, bool isBroadcast)
    {
        // Act
        bool broadcastsToAll = dest == MessageDestination.Broadcast || dest == MessageDestination.All;

        // Assert
        broadcastsToAll.Should().Be(isBroadcast);
    }

    [Theory]
    [InlineData(MessageDestination.PVS, true)]
    [InlineData(MessageDestination.PAS, true)]
    [InlineData(MessageDestination.Broadcast, false)]
    public void MessageDestination_CanIdentifyPotentiallyVisibleSet(MessageDestination dest, bool isPVS)
    {
        // Act
        bool isPotentiallyVisibleSet = dest == MessageDestination.PVS ||
                                       dest == MessageDestination.PAS;

        // Assert
        isPotentiallyVisibleSet.Should().Be(isPVS);
    }
}
