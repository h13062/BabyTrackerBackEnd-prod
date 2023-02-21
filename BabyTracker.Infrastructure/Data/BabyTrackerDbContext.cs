using BabyTracker.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BabyTracker.Infrastructure.Data
{
    public class BabyTrackerDbContext : IdentityDbContext<IdentityUser>
    {
        public BabyTrackerDbContext(DbContextOptions<BabyTrackerDbContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Remove the token tables
            builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens");
            builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins");
            builder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims");
            builder.Entity<IdentityRole>().ToTable("AspNetRoles");
            builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles");
            builder.Entity<IdentityUser>().ToTable("AspNetUsers");
        }

        public DbSet<Baby> Babys { get; set; }

        public DbSet<BabySitter> BabySitters { get; set; }

        public DbSet<Parent> Parents { get; set; }
        
        public DbSet<SleepActivity> SleepActivities { get; set; }

        public DbSet<PlayActivity> PlayActivities { get; set; }

        public DbSet<EatActivity> EatActivities { get; set; }

    }
}
