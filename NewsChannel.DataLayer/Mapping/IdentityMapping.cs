using Microsoft.EntityFrameworkCore;
using NewsChannel.DomainClasses.Identity;

namespace NewsChannel.DataLayer.Mapping
{
    public static class IdentityMapping
    {
        public static void AddCustomIdentityMappings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("AppUser");
            modelBuilder.Entity<User>().ToTable("AppRole");
            modelBuilder.Entity<UserRole>().ToTable("AppUserRole");
            modelBuilder.Entity<RoleClaim>().ToTable("AppRoleClaim");
            modelBuilder.Entity<UserClaim>().ToTable("AppUserClaim");

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(d => d.Users)
                .HasForeignKey(t => t.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(d => d.Roles)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<RoleClaim>()
                .HasOne(x => x.Role)
                .WithMany(d => d.Claims)
                .HasForeignKey(t => t.RoleId);

            modelBuilder.Entity<UserClaim>()
                .HasOne(x => x.User)
                .WithMany(d => d.Claims)
                .HasForeignKey(t => t.UserId);
        }
    }
}