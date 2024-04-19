namespace Coffee.Models;

public class Meeting
{
    public ulong Id
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
