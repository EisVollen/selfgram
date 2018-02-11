using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Selfgram.Objects.Objects;
using Selfgram.Objects.Objects.Account;
using Selfgram.Objects.Objects.Core;

namespace Selfgram.Objects.Context
{
    public class SelfgramContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public SelfgramContext(DbContextOptions<SelfgramContext> options)
            : base(options)
        {
        }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}