using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsChannel.DomainClasses.Business;
namespace NewsChannel.DataLayer.Mapping
{
    public class LikeMapping : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
             builder.HasKey (x => x.Id);

            builder
                .HasOne (x => x.News)
                .WithMany (d => d.Likes)
                .HasForeignKey (c => c.NewsId);
        }
    }
}