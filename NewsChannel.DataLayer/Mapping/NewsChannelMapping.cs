using Microsoft.EntityFrameworkCore;
namespace NewsChannel.DataLayer.Mapping
{
    public static class NewsChannelMapping
    {
        public static void AddCustomNewsChannelMappings(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMarkMapping());
            modelBuilder.ApplyConfiguration(new LikeMapping());
            modelBuilder.ApplyConfiguration(new NewsCategoryMapping());
            modelBuilder.ApplyConfiguration(new NewsTagMapping());
            modelBuilder.ApplyConfiguration(new VisitMapping());
        }

    }
}