using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsChannel.DomainClasses.Business;
namespace NewsChannel.DataLayer.Mapping {
    public class NewsTagMapping : IEntityTypeConfiguration<NewsTag> {
        public void Configure (EntityTypeBuilder<NewsTag> builder) {
            builder.HasKey (x => new { x.NewsId, x.TagId });

            builder
                .HasOne (x => x.News)
                .WithMany (d => d.NewsTags)
                .HasForeignKey (c => c.NewsId);

            builder
                .HasOne (x => x.Tag)
                .WithMany (d => d.NewsTags)
                .HasForeignKey (c => c.TagId);
        }
    }
}