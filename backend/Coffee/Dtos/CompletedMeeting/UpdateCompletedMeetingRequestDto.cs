using SQLiteNetExtensions.Attributes;

namespace Coffee.Dtos.CompletedMeeting;

public class UpdateCompletedMeetingRequestDto
{
    public DateTime? Date
    {
        get; set;
    }
    public short Duration
    {
        get; set;
    }
    public Models.User? User1
    {
        get; set;
    }
    public Models.User? User2
    {
        get; set;
    }
    public bool Success
    {
        get; set;
    }
    public Models.User? Canceller
    {
        get; set;
    }

    [TextBlob(nameof(ImagesBlobbed))]
    public List<Models.Image> Images { get; set; } = [];
    public string? ImagesBlobbed
    {
        get; set;
    }
}
