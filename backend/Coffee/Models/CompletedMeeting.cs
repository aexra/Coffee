using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Coffee.Models;

public class CompletedMeeting
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public short Duration { get; set; }
    public User? User1 { get; set; }
    public User? User2 { get; set; }
    public bool Success {get; set;}
    public User? Canceller { get; set; }
    //public string ImagesString { get; set; } = string.Empty;

    //[Ignore]
    //public List<Guid> ImagesIds => ImagesString.Split(',').Select(Guid.Parse).ToList();

    [TextBlob(nameof(ImagesBlobbed))]
    public List<Image> Images { get; set; } = [];
    public string? ImagesBlobbed { get; set; }
}
