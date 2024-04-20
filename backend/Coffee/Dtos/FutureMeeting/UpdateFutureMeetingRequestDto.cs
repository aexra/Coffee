namespace Coffee.Dtos.FutureMeeting;

public class UpdateFutureMeetingRequestDto
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
}
