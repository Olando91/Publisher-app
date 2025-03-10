using Domain.AuthorAggregate;
using Domain.AuthorAggregate.ValueObjects;
using Domain.Common;
using Domain.CoverAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        ConfigureAuthorTable(builder);
        ConfigureBookTable(builder);
    }

    private void ConfigureAuthorTable(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
            id => id.Value,
            value => AuthorId.Create(value));

        builder.Property(a => a.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(75)
            .HasConversion(
            FirstName => FirstName.Value,
            value => FirstName.Create(value));

        builder.Property(a => a.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(75)
            .HasConversion(
            LastName => LastName.Value,
            value => LastName.Create(value));

    }

    private void ConfigureBookTable(EntityTypeBuilder<Author> builder)
    {
        builder.OwnsMany(a => a.Books, b =>
        {
            b.ToTable("Books");
            b.WithOwner().HasForeignKey("AuthorId");

            b.Property(b => b.Id)
            .ValueGeneratedNever()
            .HasColumnName("Id")
            .HasConversion(
                id => id.Value,
                value => BookId.Create(value));

            b.Property(b => b.Title)
            .HasColumnName("Title")
            .HasConversion(
                title => title.Value,
                value => Title.Create(value));

            b.Property(b => b.PublishDate)
            .HasColumnName("PublishDate")
            .HasConversion(
                date => date.Value,
                value => PublishDate.Create(value));

            b.Property(b => b.BasePrice)
            .HasColumnName("BasePrice")
            .HasConversion(
                price => price.Value,
                value => BasePrice.Create(value));

            b.Property(b => b.AuthorId)
            .HasColumnName("AuthorId")
            .HasConversion(
                authorId => authorId.Value,
                value => AuthorId.Create(value));

            b.Property(b => b.CoverId)
            .HasColumnName("CoverId")
            .HasConversion(
                coverId => coverId.Value,
                value => CoverId.Create(value));
        });
    }
}
