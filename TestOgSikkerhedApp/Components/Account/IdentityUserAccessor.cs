using Microsoft.AspNetCore.Identity;
using TestOgSikkerhedApp.Data;

namespace TestOgSikkerhedApp.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<ToDoModel> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<ToDoModel> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
