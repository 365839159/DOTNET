using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreSample.Entitys.BookEntity
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.AuthorName).IsRequired().HasMaxLength(20).IsUnicode(true);

        }
    }
}
