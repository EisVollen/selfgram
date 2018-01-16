using Microsoft.EntityFrameworkCore;
using Selfgram.Model.Objects;

namespace Selfgram.Model.Context
{
    public class SelfgramContext: DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Likes> Likes { get; set; }

        public SelfgramContext(DbContextOptions<SelfgramContext> options) : base(options) { }
    }
}