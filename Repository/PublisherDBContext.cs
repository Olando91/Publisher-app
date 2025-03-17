﻿using Domain.ArtistAggregate;
using Domain.AuthorAggregate;
using Domain.BookAggregate;
using Domain.CoverAggregate;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class PublisherDBContext : DbContext
{
    //tilføj -Project REPOPROJECT -StartupProject APIPROJECT når der skrives EF kommandoer
    public PublisherDBContext(DbContextOptions<PublisherDBContext> options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Cover> Covers { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Book> Books { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PublisherDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
