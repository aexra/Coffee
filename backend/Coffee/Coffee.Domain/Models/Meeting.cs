namespace Coffee.Domain.Models;

public class Meeting
{
    public Guid Id
    {
        get; set;
    }
    public DateOnly Date
    {
        get; set;
    }
    public ulong User1
    {
        get; set;
    }
    public ulong User2
    {
        get; set;
    }
}
