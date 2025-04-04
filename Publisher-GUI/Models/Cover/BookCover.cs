﻿using Publisher_GUI.Models.Artist;

namespace Publisher_GUI.Models.Cover;

public class BookCover
{
    public Guid Id { get; set; }
    public string DesignIdea { get; set; }
    public bool DigitalOnly { get; set; }
    public string Image { get; private set; }
    public List<CoverArtist> Artists { get; set; }

    public BookCover()
    {
        Image = SetImage();
    }

    private string SetImage()
    {
        var images = new[]
        {
            "Images/Cover1.jpg",
            "Images/Cover2.jpg",
            "Images/Cover3.jpg",
            "Images/Cover4.jpg",
            "Images/Cover5.jpg",
            "Images/Cover6.jpg",
        };

        var random = new Random();

        return images[random.Next(images.Length)];
    }
}
