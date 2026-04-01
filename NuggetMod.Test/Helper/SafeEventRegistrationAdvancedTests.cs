using NuggetMod.Helper;
using NuggetMod.Interface.Events;
using Xunit;
using FluentAssertions;

namespace NuggetMod.Test.Helper;

/// <summary>
/// Advanced tests for SafeEventRegistration including validation and conflict detection.
/// </summary>
public class SafeEventRegistrationAdvancedTests
{
    public SafeEventRegistrationAdvancedTests()
    {
        // Ensure clean state before each test
        SafeEventRegistration.UnregisterAll();
    }

    [Fact]
    public void ValidateRegistration_WithNoConflicts_ShouldReturnCanRegister()
    {
        // Arrange
        var builder = new EventRegistrationBuilder()
            .WithEntityApi(new DLLEvents());

        // Act
        var result = SafeEventRegistration.ValidateRegistration(builder);

        // Assert
        result.CanRegister.Should().BeTrue();
        result.HasConflicts.Should().BeFalse();
        result.ConflictingTypes.Should().BeEmpty();
    }

    [Fact]
    public void ValidateRegistration_WithConflicts_ShouldReturnCannotRegister()
    {
        // Arrange
        var builder1 = new EventRegistrationBuilder()
            .WithEntityApi(new DLLEvents());
        SafeEventRegistration.Register(builder1);

        var builder2 = new EventRegistrationBuilder()
            .WithEntityApi(new DLLEvents());

        // Act
        var result = SafeEventRegistration.ValidateRegistration(builder2);

        // Assert
        result.CanRegister.Should().BeFalse();
        result.HasConflicts.Should().BeTrue();
        result.ConflictingTypes.Should().ContainSingle();
    }

    [Fact]
    public void TryRegister_WithNoConflicts_ShouldReturnTrue()
    {
        // Arrange
        var builder = new EventRegistrationBuilder()
            .WithEntityApi(new DLLEvents());

        // Act
        var result = SafeEventRegistration.TryRegister(builder);

        // Assert
        result.Should().BeTrue();
        SafeEventRegistration.IsRegistered(EventRegistrationType.EntityApi).Should().BeTrue();
    }

    [Fact]
    public void TryRegister_WithConflicts_ShouldReturnFalse()
    {
        // Arrange
        var builder1 = new EventRegistrationBuilder()
            .WithEntityApi(new DLLEvents());
        SafeEventRegistration.Register(builder1);

        var builder2 = new EventRegistrationBuilder()
            .WithEntityApi(new DLLEvents());

        // Act
        var result = SafeEventRegistration.TryRegister(builder2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetRegisteredTypes_AfterRegistration_ShouldReturnRegisteredTypes()
    {
        // Arrange
        var builder = new EventRegistrationBuilder()
            .WithEntityApi(new DLLEvents())
            .WithEngineFunctions(new EngineEvents());
        SafeEventRegistration.Register(builder);

        // Act
        var registeredTypes = SafeEventRegistration.GetRegisteredTypes();

        // Assert
        registeredTypes.Should().HaveCount(2);
        registeredTypes.Should().Contain(EventRegistrationType.EntityApi);
        registeredTypes.Should().Contain(EventRegistrationType.EngineFunctions);
    }

    [Fact]
    public void GetRegisteredTypes_WhenEmpty_ShouldReturnEmpty()
    {
        // Act
        var registeredTypes = SafeEventRegistration.GetRegisteredTypes();

        // Assert
        registeredTypes.Should().BeEmpty();
    }

    [Fact]
    public void EnsureDelegatesPinned_ShouldReturnCountOfPinnedHandlers()
    {
        // Arrange
        var builder = new EventRegistrationBuilder()
            .WithEntityApi(new DLLEvents())
            .WithEngineFunctions(new EngineEvents());

        // Act
        var count = SafeEventRegistration.EnsureDelegatesPinned(builder);

        // Assert
        count.Should().Be(2);
    }

    [Fact]
    public void FullLifecycle_RegisterThenUnregisterAll_ShouldCleanUp()
    {
        // Arrange
        var builder = new EventRegistrationBuilder()
            .WithEntityApi(new DLLEvents())
            .WithEntityApiPost(new DLLEvents())
            .WithEngineFunctions(new EngineEvents());

        // Act
        SafeEventRegistration.Register(builder);
        SafeEventRegistration.IsRegistered(EventRegistrationType.EntityApi).Should().BeTrue();
        SafeEventRegistration.IsRegistered(EventRegistrationType.EntityApiPost).Should().BeTrue();
        SafeEventRegistration.IsRegistered(EventRegistrationType.EngineFunctions).Should().BeTrue();

        SafeEventRegistration.UnregisterAll();

        // Assert
        SafeEventRegistration.IsRegistered(EventRegistrationType.EntityApi).Should().BeFalse();
        SafeEventRegistration.IsRegistered(EventRegistrationType.EntityApiPost).Should().BeFalse();
        SafeEventRegistration.IsRegistered(EventRegistrationType.EngineFunctions).Should().BeFalse();
        SafeEventRegistration.GetRegisteredTypes().Should().BeEmpty();
    }

    [Fact]
    public void MultipleRegistrations_OfDifferentTypes_ShouldSucceed()
    {
        // Arrange & Act
        var builder1 = new EventRegistrationBuilder()
            .WithEntityApi(new DLLEvents());
        SafeEventRegistration.Register(builder1);

        var builder2 = new EventRegistrationBuilder()
            .WithEngineFunctions(new EngineEvents());
        SafeEventRegistration.Register(builder2);

        // Assert
        SafeEventRegistration.IsRegistered(EventRegistrationType.EntityApi).Should().BeTrue();
        SafeEventRegistration.IsRegistered(EventRegistrationType.EngineFunctions).Should().BeTrue();
    }
}
