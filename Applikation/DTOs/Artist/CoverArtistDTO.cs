﻿namespace Applikation.DTOs.Artist;

public record CoverArtistDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
