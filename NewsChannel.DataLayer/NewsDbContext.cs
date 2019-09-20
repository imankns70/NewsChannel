using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsChannel.DataLayer.Mapping;
using NewsChannel.DomainClasses.Business;
using NewsChannel.DomainClasses.Identity;


namespace NewsChannel.DataLayer {
    public class NewsDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, IdentityUserLogin<int>, RoleClaim, IdentityUserToken<int>>
    {

        public NewsDbContext (DbContextOptions options) : base (options) {

        }
        protected override void OnModelCreating (ModelBuilder builder) {
           
            base.OnModelCreating (builder);
            builder.AddCustomIdentityMappings();
            builder.AddCustomNewsChannelMappings();
            //builder.Entity<News>().Property(x=>x.PublishDateTime)
            //.HasDefaultValueSql("CONVERT(datetime,GetDate())");
            builder.Entity<Video>().Property(x=>x.PublishDateTime)
            .HasDefaultValueSql("CONVERT(datetime,GetDate())");
            builder.Entity<User>().Property(x => x.RegisterDateTime)
                .HasDefaultValueSql("CONVERT(datetime,GetDate())");
            builder.Entity<User>().Property(x => x.IsActive)
                .HasDefaultValueSql("1");
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<BookMark> BookMarks { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<NewsImage> NewsImages { get; set; }
        public virtual DbSet<NewsLetter> NewsLetters { get; set; }
        public virtual DbSet<NewsTag> NewsTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
    }
}