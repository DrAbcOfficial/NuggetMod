using NuggetMod.Enum.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for the Flags enumeration (entity flags)
/// </summary>
public class FlagsTests
{
    [Fact]
    public void Flags_ShouldBeFlagsEnum()
    {
        // Arrange
        var enumType = typeof(Flags);
        var flagsAttribute = enumType.GetCustomAttributes(typeof(FlagsAttribute), false);

        // Assert
        flagsAttribute.Should().HaveCount(1);
    }

    [Theory]
    [InlineData(Flags.Fly, 1 << 0)]
    [InlineData(Flags.Swim, 1 << 1)]
    [InlineData(Flags.Conveyor, 1 << 2)]
    [InlineData(Flags.Client, 1 << 3)]
    [InlineData(Flags.InWater, 1 << 4)]
    [InlineData(Flags.Monster, 1 << 5)]
    [InlineData(Flags.Godmode, 1 << 6)]
    [InlineData(Flags.NoTarget, 1 << 7)]
    [InlineData(Flags.SkipLocalhost, 1 << 8)]
    [InlineData(Flags.OnGround, 1 << 9)]
    [InlineData(Flags.PartialGround, 1 << 10)]
    [InlineData(Flags.WaterJump, 1 << 11)]
    [InlineData(Flags.Frozen, 1 << 12)]
    [InlineData(Flags.FakeClient, 1 << 13)]
    [InlineData(Flags.Ducking, 1 << 14)]
    [InlineData(Flags.Float, 1 << 15)]
    [InlineData(Flags.Graphed, 1 << 16)]
    [InlineData(Flags.ImmuneWater, 1 << 17)]
    [InlineData(Flags.ImmuneSlime, 1 << 18)]
    [InlineData(Flags.ImmuneLava, 1 << 19)]
    [InlineData(Flags.Proxy, 1 << 20)]
    [InlineData(Flags.AlwaysThink, 1 << 21)]
    [InlineData(Flags.BaseVelocity, 1 << 22)]
    [InlineData(Flags.MonsterClip, 1 << 23)]
    [InlineData(Flags.OnTrain, 1 << 24)]
    [InlineData(Flags.WorldBrush, 1 << 25)]
    [InlineData(Flags.Spectator, 1 << 26)]
    [InlineData(Flags.CustomEntity, 1 << 29)]
    [InlineData(Flags.KillMe, 1 << 30)]
    [InlineData(Flags.Dormant, 1 << 31)]
    public void Flags_ShouldHaveCorrectBitValues(Flags flag, int expectedValue)
    {
        // Assert
        ((int)flag).Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(Flags.Fly | Flags.Swim, true)]
    [InlineData(Flags.Client | Flags.OnGround | Flags.Ducking, true)]
    [InlineData(Flags.Monster | Flags.Graphed, true)]
    public void Flags_ShouldSupportBitwiseCombination(Flags combinedFlags, bool shouldBeValid)
    {
        // Assert
        shouldBeValid.Should().BeTrue();
        combinedFlags.Should().NotBe(0);
    }

    [Fact]
    public void Flags_PlayerState_ShouldBeCombinable()
    {
        // Arrange
        var playerOnGround = Flags.Client | Flags.OnGround;
        var playerDucking = Flags.Client | Flags.OnGround | Flags.Ducking;
        var playerInWater = Flags.Client | Flags.InWater | Flags.Swim;

        // Assert
        playerOnGround.Should().HaveFlag(Flags.Client);
        playerOnGround.Should().HaveFlag(Flags.OnGround);
        playerDucking.Should().HaveFlag(Flags.Ducking);
        playerInWater.Should().HaveFlag(Flags.Swim);
    }

    [Fact]
    public void Flags_MonsterState_ShouldBeCombinable()
    {
        // Arrange
        var monsterFlying = Flags.Monster | Flags.Fly;
        var monsterSwimming = Flags.Monster | Flags.Swim;
        var monsterGodmode = Flags.Monster | Flags.Godmode;

        // Assert
        monsterFlying.Should().HaveFlag(Flags.Monster);
        monsterFlying.Should().HaveFlag(Flags.Fly);
        monsterSwimming.Should().HaveFlag(Flags.Swim);
        monsterGodmode.Should().HaveFlag(Flags.Godmode);
    }

    [Fact]
    public void Flags_HasFlag_ShouldWorkCorrectly()
    {
        // Arrange
        var flags = Flags.Client | Flags.OnGround | Flags.Ducking;

        // Assert
        flags.HasFlag(Flags.Client).Should().BeTrue();
        flags.HasFlag(Flags.OnGround).Should().BeTrue();
        flags.HasFlag(Flags.Ducking).Should().BeTrue();
        flags.HasFlag(Flags.Monster).Should().BeFalse();
        flags.HasFlag(Flags.Fly).Should().BeFalse();
    }

    [Fact]
    public void Flags_CanRemoveFlag()
    {
        // Arrange
        var flags = Flags.Client | Flags.OnGround | Flags.Ducking;

        // Act
        flags &= ~Flags.Ducking;

        // Assert
        flags.Should().NotHaveFlag(Flags.Ducking);
        flags.Should().HaveFlag(Flags.Client);
        flags.Should().HaveFlag(Flags.OnGround);
    }

    [Theory]
    [InlineData(0)]  // No flags set
    [InlineData(int.MaxValue)]  // Many flags set
    public void Flags_ShouldHandleEdgeCases(int value)
    {
        // Arrange
        var flags = (Flags)value;

        // Assert - should not throw
        flags.Invoking(f => f.ToString()).Should().NotThrow();
    }
}
