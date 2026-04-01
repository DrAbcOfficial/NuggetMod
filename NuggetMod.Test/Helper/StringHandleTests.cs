using NuggetMod.Helper;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Helper;

/// <summary>
/// Tests for the StringHandle class
/// </summary>
public class StringHandleTests
{
    #region Class Structure

    [Fact]
    public void StringHandle_Type_ShouldExist()
    {
        // Arrange & Act
        var type = typeof(StringHandle);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
        type.IsSealed.Should().BeTrue();
    }

    [Fact]
    public void StringHandle_ShouldBeDisposable()
    {
        // Arrange & Act
        var type = typeof(StringHandle);

        // Assert
        type.Should().Implement<IDisposable>();
    }

    #endregion

    #region Constructors

    [Fact]
    public void StringHandle_ShouldHaveStringConstructor()
    {
        // Arrange
        var type = typeof(StringHandle);
        var constructors = type.GetConstructors();

        // Assert
        constructors.Should().Contain(c => c.GetParameters().Length == 1 &&
                                           c.GetParameters()[0].ParameterType == typeof(string));
    }

    #endregion

    #region Methods

    [Fact]
    public void StringHandle_ShouldHaveSetStringMethod()
    {
        // Arrange
        var type = typeof(StringHandle);
        var methods = type.GetMethods();

        // Assert
        methods.Should().Contain(m => m.Name == "SetString" &&
                                      m.GetParameters().Length == 1 &&
                                      m.GetParameters()[0].ParameterType == typeof(string));
    }

    [Fact]
    public void StringHandle_ShouldHaveToStringMethod()
    {
        // Arrange
        var type = typeof(StringHandle);
        var method = type.GetMethod("ToString");

        // Assert
        method.Should().NotBeNull();
    }

    #endregion
}
