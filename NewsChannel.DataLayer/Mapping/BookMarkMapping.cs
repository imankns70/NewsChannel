using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsChannel.DomainClasses.Business;

namespace NewsChannel.DataLayer.Mapping {
    public class BookMarkMapping : IEntityTypeConfiguration<BookMark> {
        public void Configure (EntityTypeBuilder<BookMark> builder) {
            builder.HasKey (x => new { x.NewsId, x.UserId });

            builder
                .HasOne (x => x.News)
                .WithMany (d => d.BookMarks)
                .HasForeignKey (c => c.NewsId);

            builder
                .HasOne (x => x.User)
                .WithMany (d => d.BookMarks)
                .HasForeignKey (c => c.UserId);
        }
    }
}