﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(PublisherDBContext))]
    partial class PublisherDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistCover", b =>
                {
                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoverId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtistId", "CoverId");

                    b.HasIndex("CoverId");

                    b.ToTable("ArtistCovers", (string)null);
                });

            modelBuilder.Entity("Domain.ArtistAggregate.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)")
                        .HasColumnName("LastName");

                    b.HasKey("Id");

                    b.ToTable("Artists", (string)null);
                });

            modelBuilder.Entity("Domain.AuthorAggregate.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)")
                        .HasColumnName("LastName");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Domain.BookAggregate.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BasePrice")
                        .HasColumnType("int")
                        .HasColumnName("BasePrice");

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("date")
                        .HasColumnName("PublishDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Domain.CoverAggregate.Cover", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DesignIdea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DesignIdea");

                    b.Property<bool>("DigitalOnly")
                        .HasColumnType("bit")
                        .HasColumnName("DigitalOnly");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("Covers", (string)null);
                });

            modelBuilder.Entity("ArtistCover", b =>
                {
                    b.HasOne("Domain.ArtistAggregate.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.CoverAggregate.Cover", null)
                        .WithMany()
                        .HasForeignKey("CoverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.BookAggregate.Book", b =>
                {
                    b.HasOne("Domain.AuthorAggregate.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Domain.CoverAggregate.Cover", b =>
                {
                    b.HasOne("Domain.BookAggregate.Book", "Book")
                        .WithOne("Cover")
                        .HasForeignKey("Domain.CoverAggregate.Cover", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Domain.AuthorAggregate.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Domain.BookAggregate.Book", b =>
                {
                    b.Navigation("Cover");
                });
#pragma warning restore 612, 618
        }
    }
}
