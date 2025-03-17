using Domain.BookAggregate;
using Domain.BookAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        ConfigureBookTable(builder);
    }

    private void ConfigureBookTable(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedNever()
            .HasConversion(
            id => id.Value,
            value => BookId.Create(value));

        builder.Property(b => b.Title)
            .HasColumnName("Title")
            .HasConversion(
            title => title.Value,
            value => Title.Create(value));

        builder.Property(b => b.PublishDate)
            .HasColumnName("PublishDate")
            .HasConversion(
            pd => pd.Value,
            value => PublishDate.Create(value));

        builder.Property(b => b.BasePrice)
            .HasColumnName("BasePrice")
            .HasConversion(
            bp => bp.Value,
            value => BasePrice.Create(value));

        builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
