namespace Coffee.Dtos.Room;

public class RoomDto
{
    public ulong Id
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
