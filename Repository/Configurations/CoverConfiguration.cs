using Domain.ArtistAggregate;
using Domain.BookAggregate.ValueObjects;
using Domain.CoverAggregate;
using Domain.CoverAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class CoverConfiguration : IEntityTypeConfiguration<Cover>
{
    public void Configure(EntityTypeBuilder<Cover> builder)
    {
        ConfigureCoverTable(builder);
        ConfigureArtistCoverTable(builder);
    }

    private void ConfigureCoverTable(EntityTypeBuilder<Cover> builder)
    {
        builder.ToTable("Covers");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(
            id => id.Value,
            value => CoverId.Create(value));

        builder.Property(c => c.DesignIdea)
            .HasColumnName("DesignIdea")
            .HasConversion(
            di => di.Value,
            value => DesignIdea.Create(value));

        builder.Property(c => c.DigitalOnly)
            .HasColumnName("DigitalOnly")
            .HasConversion(
            dOnly => dOnly.Value,
            value => DigitalOnly.Create(value));

        builder.HasOne(c => c.Book)
            .WithOne(b => b.Cover)
            .HasForeignKey<Cover>(c => c.BookId)
            .OnDelete(DeleteBehavior.Cascade);

    }

    public void ConfigureArtistCoverTable(EntityTypeBuilder<Cover> builder)
    {
        builder.HasMany(a => a.Artists)
            .WithMany(c => c.Covers)
            .UsingEntity<Dictionary<string, object>>(
            "ArtistCover",
            j => j.HasOne<Artist>().WithMany().HasForeignKey("ArtistId"),
            j => j.HasOne<Cover>().WithMany().HasForeignKey("CoverId"),
            j =>
            {
                j.HasKey("ArtistId", "CoverId");
                j.ToTable("ArtistCovers");
            }
        );
    }
}
