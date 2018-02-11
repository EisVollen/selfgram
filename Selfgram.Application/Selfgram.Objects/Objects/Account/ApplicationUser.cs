using System;
using Microsoft.AspNetCore.Identity;

namespace Selfgram.Objects.Objects.Account
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
