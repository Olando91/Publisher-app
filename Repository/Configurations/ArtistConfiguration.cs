using Domain.ArtistAggregate;
using Domain.ArtistAggregate.ValueObjects;
using Domain.Common;
using Domain.CoverAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        ConfigureArtistTable(builder);
        ConfigureArtistCoverTable(builder);
    }

    private void ConfigureArtistTable(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("Artists");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
            id => id.Value,
            value => ArtistId.Create(value));

        builder.Property(a => a.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(75)
            .HasConversion(
            firstName => firstName.Value,
            value => FirstName.Create(value));

        builder.Property(a => a.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(75)
            .HasConversion(
            lastName => lastName.Value,
            value => LastName.Create(value));
    }

    private void ConfigureArtistCoverTable(EntityTypeBuilder<Artist> builder)
    {
        builder.HasMany(a => a.Covers)
            .WithMany(c => c.Artists)
            .UsingEntity<Dictionary<string, object>>(
            "ArtistCover",
            j => j.HasOne<Cover>().WithMany().HasForeignKey("CoverId"),
            j => j.HasOne<Artist>().WithMany().HasForeignKey("ArtistId"),
            j =>
            {
                j.HasKey("ArtistId", "CoverId");
                j.ToTable("ArtistCovers");
            }
        );
    }
}
