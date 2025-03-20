using Domain.AuthorAggregate;
using Domain.AuthorAggregate.ValueObjects;
using Domain.BookAggregate.ValueObjects;
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
}
