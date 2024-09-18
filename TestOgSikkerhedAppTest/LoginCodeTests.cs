using Bunit;
using Bunit.TestDoubles;
using TestOgSikkerhedApp.Components.Pages;

namespace TestOgSikkerhedTest;

public class LoginCodeTests
{
  

    [Fact]
    public void LoginUser_ShouldAuthenticateValidUser_OnSuccess()
    {
        // Arrange
        using var ctx = new TestContext();
        var authorization = ctx.AddTestAuthorization();
        authorization.SetAuthorized("email@email.com", AuthorizationState.Authorized);

        // Act
        var cut = ctx.RenderComponent<Home>();
        var isAuthenticated = cut.Instance.IsAuthenticated;

        // Assert
        Assert.True(isAuthenticated);
    }

    [Fact]
    public void LoginUser_ShouldNotAuthenticate_WhenInvalidUser()
    {
        // Arrange
        using var ctx = new TestContext();
        var authorization = ctx.AddTestAuthorization();
        authorization.SetNotAuthorized();

        // Act
        var cut = ctx.RenderComponent<Home>();
        var isAuthenticated = cut.Instance.IsAuthenticated;

        // Assert
        Assert.False(isAuthenticated);
    }

    [Fact]
    public void LoginUser_ShouldAssignRole_WhenUserIsAdmin()
    {
        // Arrange
        using var ctx = new TestContext();
        var authorization = ctx.AddTestAuthorization();
        authorization.SetAuthorized("email@email.com", AuthorizationState.Authorized);
        authorization.SetRoles("Admin");

        // Act
        var cut = ctx.RenderComponent<Home>();
        var isAuthenticated = cut.Instance.IsAuthenticated;
        var isAdmin = cut.Instance.IsAdmin;

        // Assert
        Assert.True(isAuthenticated);
        Assert.True(isAdmin);
    }
}