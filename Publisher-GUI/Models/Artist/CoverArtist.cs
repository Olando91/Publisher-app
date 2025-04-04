﻿namespace Publisher_GUI.Models.Artist;

public class CoverArtist
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public CoverArtist()
    {        
    }

    public CoverArtist(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}
