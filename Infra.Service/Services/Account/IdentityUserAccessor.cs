using Microsoft.AspNetCore.Identity;
using Domain.Entities.Concrates;
using Microsoft.AspNetCore.Http;

namespace Services.Account
{
    public sealed class IdentityUserAccessor(UserManager<AppUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<AppUser> GetRequiredUserAsync(HttpContext context)
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
