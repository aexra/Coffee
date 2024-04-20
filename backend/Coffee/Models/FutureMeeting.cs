namespace Coffee.Models;

public class FutureMeeting
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public short Duration { get; set; }
    public User? User1 { get; set; }
    public User? User2 { get; set; }
}