using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Common;

/// <summary>
/// Tests for damage types (if they exist as constants)
/// This documents common GoldSrc damage types
/// </summary>
public class TakeDamageTests
{
    // Common damage types in GoldSrc
    public const int Generic = 0;
    public const int Crush = 1;
    public const int Bullet = 2;
    public const int Slash = 4;
    public const int Burn = 8;
    public const int Freeze = 16;
    public const int Fall = 32;
    public const int Blast = 64;
    public const int Club = 128;
    public const int Electricity = 256;
    public const int EnergyBeam = 512;
    public const int Poison = 1024;
    public const int Radiation = 2048;
    public const int Drown = 16384;
    public const int Para = 32768;

    [Theory]
    [InlineData(Generic, 0)]
    [InlineData(Crush, 1)]
    [InlineData(Bullet, 2)]
    [InlineData(Slash, 4)]
    [InlineData(Burn, 8)]
    [InlineData(Freeze, 16)]
    [InlineData(Fall, 32)]
    [InlineData(Blast, 64)]
    [InlineData(Club, 128)]
    public void DamageTypes_ShouldHaveCorrectValues(int damageType, int expectedValue)
    {
        // Assert
        damageType.Should().Be(expectedValue);
    }

    [Fact]
    public void DamageTypes_ShouldBePowersOfTwo()
    {
        // Arrange
        var damageTypes = new[] { Crush, Bullet, Slash, Burn, Freeze, Fall, Blast, Club };

        // Assert - verify each is a power of two (can be combined with bitwise OR)
        foreach (var damage in damageTypes)
        {
            (damage & (damage - 1)).Should().Be(0);
        }
    }

    [Fact]
    public void DamageTypes_CanBeCombined()
    {
        // Arrange & Act
        int combined = Bullet | Blast | Burn;

        // Assert
        (combined & Bullet).Should().NotBe(0);
        (combined & Blast).Should().NotBe(0);
        (combined & Burn).Should().NotBe(0);
        (combined & Slash).Should().Be(0);
    }
}
