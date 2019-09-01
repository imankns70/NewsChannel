using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsChannel.DomainClasses.Business;

namespace NewsChannel.DataLayer.Mapping
{
    public class VisitMapping : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.HasKey(x=> new {x.NewsId,x.IpAddress});
            builder
                .HasOne(x => x.News)
                .WithMany(d => d.Visits)
                .HasForeignKey(c => c.NewsId);

        }
    }
}