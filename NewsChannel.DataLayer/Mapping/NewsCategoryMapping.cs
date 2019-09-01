using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsChannel.DomainClasses.Business;
namespace NewsChannel.DataLayer.Mapping
{
    public class NewsCategoryMapping : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
              builder.HasKey (x => new { x.NewsId, x.CategoryId });

            builder
                .HasOne (x => x.News)
                .WithMany (d => d.NewsCategories)
                .HasForeignKey (c => c.NewsId);

            builder
                .HasOne (x => x.Category)
                .WithMany (d => d.NewsCategories)
                .HasForeignKey (c => c.CategoryId);
        }
    }
}