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
    public List<Image> Images { get; set; } = [];
}
