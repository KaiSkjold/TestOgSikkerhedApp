using Bunit;
using Bunit.TestDoubles;
using TestOgSikkerhedApp.Components.Pages;

namespace TestOgSikkerhedTest;

public class LoginViewTests
{
    // TODO Currently, to run these tests it is neccessary to remove det dependency injection usermanager
    // and the method CreateUserRolesAsync(string user, string role)
    //private UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>();

    [Fact]
    public void LoginUser_ShouldAuthenticateValidUser_OnSuccess()
    {
        // Arrange
        using var ctx = new TestContext();
        var authorization = ctx.AddTestAuthorization();
        authorization.SetAuthorized("email@email.com", AuthorizationState.Authorized);

        // Act
        var cut = ctx.RenderComponent<Home>();

        // Assert
        cut.MarkupMatches("<p>You are logged in</p>");
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

        // Assert
        cut.MarkupMatches("<p>You are NOT logged in</p>");
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

        // Assert
        cut.MarkupMatches("<p>You are logged in</p><p>You are Admin</p>");
    }
}