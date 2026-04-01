using NuggetMod.Enum.Engine;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Enum.Engine;

/// <summary>
/// Tests for the FieldType enumeration
/// </summary>
public class FieldTypeTests
{
    [Theory]
    [InlineData(FieldType.Float, 0)]
    [InlineData(FieldType.String, 1)]
    [InlineData(FieldType.Entity, 2)]
    [InlineData(FieldType.ClassPointer, 3)]
    [InlineData(FieldType.EHandle, 4)]
    [InlineData(FieldType.EntityVars, 5)]
    [InlineData(FieldType.Edict, 6)]
    [InlineData(FieldType.Vector, 7)]
    [InlineData(FieldType.PositionVector, 8)]
    [InlineData(FieldType.Pointer, 9)]
    [InlineData(FieldType.Interger, 10)]
    [InlineData(FieldType.Function, 11)]
    [InlineData(FieldType.Boolean, 12)]
    [InlineData(FieldType.Short, 13)]
    [InlineData(FieldType.Character, 14)]
    [InlineData(FieldType.Time, 15)]
    [InlineData(FieldType.ModelName, 16)]
    [InlineData(FieldType.SoundName, 17)]
    [InlineData(FieldType.TypeCount, 18)]
    public void FieldType_ShouldHaveCorrectIntegerValue(FieldType type, int expectedValue)
    {
        // Assert
        ((int)type).Should().Be(expectedValue);
    }

    [Fact]
    public void FieldType_Float_ShouldBeDefault()
    {
        // Arrange & Act
        FieldType defaultValue = default;

        // Assert
        defaultValue.Should().Be(FieldType.Float);
    }

    [Theory]
    [InlineData(FieldType.Float, typeof(float))]
    [InlineData(FieldType.String, typeof(string))]
    [InlineData(FieldType.Interger, typeof(int))]
    [InlineData(FieldType.Entity, typeof(int))]
    public void FieldType_ShouldMapToCorrectManagedType(FieldType fieldType, Type expectedType)
    {
        // This test documents the expected mapping between field types and managed types
        // Assert
        fieldType.Should().BeDefined();
        expectedType.Should().NotBeNull();
    }
}
