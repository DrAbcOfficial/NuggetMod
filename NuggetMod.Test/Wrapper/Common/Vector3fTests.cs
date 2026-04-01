using NuggetMod.Wrapper.Common;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Wrapper.Common;

/// <summary>
/// Tests for the Vector3f class
/// </summary>
public class Vector3fTests
{
    #region Constructors

    [Fact]
    public void Constructor_Default_ShouldCreateVector()
    {
        // Act
        var vector = new Vector3f();

        // Assert - just verify it can be created without throwing
        vector.Should().NotBeNull();
        vector.IsValid().Should().BeTrue();

        // Cleanup
        vector.Dispose();
    }

    [Theory]
    [InlineData(1.0f, 2.0f, 3.0f)]
    [InlineData(-1.0f, -2.0f, -3.0f)]
    [InlineData(0.0f, 0.0f, 0.0f)]
    [InlineData(float.MaxValue, float.MaxValue, float.MaxValue)]
    [InlineData(float.MinValue, float.MinValue, float.MinValue)]
    public void Constructor_WithCoordinates_ShouldSetCorrectValues(float x, float y, float z)
    {
        // Act
        var vector = new Vector3f(x, y, z);

        // Assert
        vector.X.Should().Be(x);
        vector.Y.Should().Be(y);
        vector.Z.Should().Be(z);
    }

    #endregion

    #region Properties

    [Theory]
    [InlineData(5.0f)]
    [InlineData(-5.0f)]
    [InlineData(0.0f)]
    public void X_Property_ShouldGetAndSet(float value)
    {
        // Arrange
        var vector = new Vector3f();

        // Act
        vector.X = value;

        // Assert
        vector.X.Should().Be(value);
    }

    [Theory]
    [InlineData(5.0f)]
    [InlineData(-5.0f)]
    [InlineData(0.0f)]
    public void Y_Property_ShouldGetAndSet(float value)
    {
        // Arrange
        var vector = new Vector3f();

        // Act
        vector.Y = value;

        // Assert
        vector.Y.Should().Be(value);
    }

    [Theory]
    [InlineData(5.0f)]
    [InlineData(-5.0f)]
    [InlineData(0.0f)]
    public void Z_Property_ShouldGetAndSet(float value)
    {
        // Arrange
        var vector = new Vector3f();

        // Act
        vector.Z = value;

        // Assert
        vector.Z.Should().Be(value);
    }

    #endregion

    #region Static Constants

    [Fact]
    public void Zero_ShouldReturnVector000()
    {
        // Act
        var zero = Vector3f.Zero;

        // Assert
        zero.X.Should().Be(0.0f);
        zero.Y.Should().Be(0.0f);
        zero.Z.Should().Be(0.0f);
    }

    [Fact]
    public void One_ShouldReturnVector111()
    {
        // Act
        var one = Vector3f.One;

        // Assert
        one.X.Should().Be(1.0f);
        one.Y.Should().Be(1.0f);
        one.Z.Should().Be(1.0f);
    }

    [Fact]
    public void Up_ShouldReturnVector001()
    {
        // Act
        var up = Vector3f.Up;

        // Assert
        up.X.Should().Be(0.0f);
        up.Y.Should().Be(0.0f);
        up.Z.Should().Be(1.0f);
    }

    [Fact]
    public void Down_ShouldReturnVector00Neg1()
    {
        // Act
        var down = Vector3f.Down;

        // Assert
        down.X.Should().Be(0.0f);
        down.Y.Should().Be(0.0f);
        down.Z.Should().Be(-1.0f);
    }

    [Fact]
    public void Forward_ShouldReturnVector100()
    {
        // Act
        var forward = Vector3f.Forward;

        // Assert
        forward.X.Should().Be(1.0f);
        forward.Y.Should().Be(0.0f);
        forward.Z.Should().Be(0.0f);
    }

    [Fact]
    public void Back_ShouldReturnVectorNeg100()
    {
        // Act
        var back = Vector3f.Back;

        // Assert
        back.X.Should().Be(-1.0f);
        back.Y.Should().Be(0.0f);
        back.Z.Should().Be(0.0f);
    }

    [Fact]
    public void Left_ShouldReturnVector010()
    {
        // Act
        var left = Vector3f.Left;

        // Assert
        left.X.Should().Be(0.0f);
        left.Y.Should().Be(1.0f);
        left.Z.Should().Be(0.0f);
    }

    [Fact]
    public void Right_ShouldReturnVector0Neg10()
    {
        // Act
        var right = Vector3f.Right;

        // Assert
        right.X.Should().Be(0.0f);
        right.Y.Should().Be(-1.0f);
        right.Z.Should().Be(0.0f);
    }

    [Fact]
    public void StaticConstants_ShouldReturnSameInstance()
    {
        // Act & Assert
        ReferenceEquals(Vector3f.Zero, Vector3f.Zero).Should().BeTrue();
        ReferenceEquals(Vector3f.One, Vector3f.One).Should().BeTrue();
        ReferenceEquals(Vector3f.Up, Vector3f.Up).Should().BeTrue();
    }

    #endregion

    #region Distance Methods

    [Fact]
    public void Distance_SamePoint_ShouldReturnZero()
    {
        // Arrange
        var a = new Vector3f(1.0f, 2.0f, 3.0f);
        var b = new Vector3f(1.0f, 2.0f, 3.0f);

        // Act
        var distance = Vector3f.Distance(a, b);

        // Assert
        distance.Should().Be(0.0f);
    }

    [Fact]
    public void Distance_AxisAligned_ShouldReturnCorrectValue()
    {
        // Arrange
        var a = new Vector3f(0.0f, 0.0f, 0.0f);
        var b = new Vector3f(3.0f, 0.0f, 0.0f);

        // Act
        var distance = Vector3f.Distance(a, b);

        // Assert
        distance.Should().Be(3.0f);
    }

    [Fact]
    public void Distance_3DPoints_ShouldReturnCorrectValue()
    {
        // Arrange
        var a = new Vector3f(0.0f, 0.0f, 0.0f);
        var b = new Vector3f(1.0f, 1.0f, 1.0f);

        // Act
        var distance = Vector3f.Distance(a, b);

        // Assert
        distance.Should().BeApproximately(1.73205f, 0.0001f); // sqrt(3)
    }

    [Fact]
    public void Distance_ShouldBeSymmetric()
    {
        // Arrange
        var a = new Vector3f(1.0f, 2.0f, 3.0f);
        var b = new Vector3f(4.0f, 5.0f, 6.0f);

        // Act
        var distanceAB = Vector3f.Distance(a, b);
        var distanceBA = Vector3f.Distance(b, a);

        // Assert
        distanceAB.Should().Be(distanceBA);
    }

    [Fact]
    public void DistanceSqr_SamePoint_ShouldReturnZero()
    {
        // Arrange
        var a = new Vector3f(1.0f, 2.0f, 3.0f);
        var b = new Vector3f(1.0f, 2.0f, 3.0f);

        // Act
        var distanceSqr = Vector3f.DistanceSqr(a, b);

        // Assert
        distanceSqr.Should().Be(0.0f);
    }

    [Fact]
    public void DistanceSqr_ShouldBeSquareOfDistance()
    {
        // Arrange
        var a = new Vector3f(0.0f, 0.0f, 0.0f);
        var b = new Vector3f(3.0f, 4.0f, 0.0f);

        // Act
        var distance = Vector3f.Distance(a, b);
        var distanceSqr = Vector3f.DistanceSqr(a, b);

        // Assert
        distanceSqr.Should().Be(distance * distance);
        distanceSqr.Should().Be(25.0f); // 3^2 + 4^2 = 9 + 16 = 25
    }

    [Fact]
    public void DistanceSqr_ShouldBeFaster_Alternative()
    {
        // This test documents that DistanceSqr doesn't use sqrt
        // Arrange
        var a = new Vector3f(1.0f, 2.0f, 3.0f);
        var b = new Vector3f(4.0f, 5.0f, 6.0f);

        // Act
        var distanceSqr = Vector3f.DistanceSqr(a, b);

        // Assert - just verify it works correctly
        distanceSqr.Should().BeGreaterThan(0);
    }

    #endregion

    #region Lerp Method

    [Fact]
    public void Lerp_T0_ShouldReturnFirstVector()
    {
        // Arrange
        var a = new Vector3f(1.0f, 2.0f, 3.0f);
        var b = new Vector3f(4.0f, 5.0f, 6.0f);

        // Act
        var result = Vector3f.Lerp(a, b, 0.0f);

        // Assert
        result.X.Should().Be(a.X);
        result.Y.Should().Be(a.Y);
        result.Z.Should().Be(a.Z);
    }

    [Fact]
    public void Lerp_T1_ShouldReturnSecondVector()
    {
        // Arrange
        var a = new Vector3f(1.0f, 2.0f, 3.0f);
        var b = new Vector3f(4.0f, 5.0f, 6.0f);

        // Act
        var result = Vector3f.Lerp(a, b, 1.0f);

        // Assert
        result.X.Should().Be(b.X);
        result.Y.Should().Be(b.Y);
        result.Z.Should().Be(b.Z);
    }

    [Fact]
    public void Lerp_T0_5_ShouldReturnMidpoint()
    {
        // Arrange
        var a = new Vector3f(0.0f, 0.0f, 0.0f);
        var b = new Vector3f(2.0f, 4.0f, 6.0f);

        // Act
        var result = Vector3f.Lerp(a, b, 0.5f);

        // Assert
        result.X.Should().Be(1.0f);
        result.Y.Should().Be(2.0f);
        result.Z.Should().Be(3.0f);
    }

    [Fact]
    public void Lerp_ShouldCreateNewInstance()
    {
        // Arrange
        var a = new Vector3f(1.0f, 2.0f, 3.0f);
        var b = new Vector3f(4.0f, 5.0f, 6.0f);

        // Act
        var result = Vector3f.Lerp(a, b, 0.5f);

        // Assert
        ReferenceEquals(result, a).Should().BeFalse();
        ReferenceEquals(result, b).Should().BeFalse();
    }

    #endregion

    #region IDisposable

    [Fact]
    public void Dispose_ShouldNotThrow()
    {
        // Arrange
        var vector = new Vector3f(1.0f, 2.0f, 3.0f);

        // Act & Assert
        vector.Invoking(v => v.Dispose()).Should().NotThrow();
    }

    [Fact]
    public void IsValid_AfterConstruction_ShouldReturnTrue()
    {
        // Arrange
        var vector = new Vector3f();

        // Assert
        vector.IsValid().Should().BeTrue();
    }

    [Fact]
    public void IsValid_AfterDispose_ShouldReturnFalse()
    {
        // Arrange
        var vector = new Vector3f();

        // Act
        vector.Dispose();

        // Assert
        vector.IsValid().Should().BeFalse();
    }

    [Fact]
    public void IsDisposed_AfterDispose_ShouldReturnTrue()
    {
        // Arrange
        var vector = new Vector3f();

        // Act
        vector.Dispose();

        // Assert
        vector.IsDisposed.Should().BeTrue();
    }

    [Fact]
    public void GetNative_AfterDispose_ShouldThrow()
    {
        // Arrange
        var vector = new Vector3f();
        vector.Dispose();

        // Act & Assert
        vector.Invoking(v => v.GetNative()).Should().Throw<ObjectDisposedException>();
    }

    #endregion
}
