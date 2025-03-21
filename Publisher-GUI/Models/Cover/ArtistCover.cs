using Publisher_GUI.Models.Book;

namespace Publisher_GUI.Models.Cover;

public class ArtistCover
{
    public Guid Id { get; set; }
    public string DesignIdea { get; set; }
    public bool DigitalOnly { get; set; }
    public CoverBook Book { get; set; }
    public string Image { get; set; }

    public ArtistCover()
    {
        Image = SetImage();
    }

    public ArtistCover(Guid id, string desingIdea, bool digitalOnly, CoverBook book)
    {
        Id = id;
        DesignIdea = desingIdea;
        DigitalOnly = digitalOnly;
        Book = book;
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
