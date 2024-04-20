using Coffee.Dtos.Room;
using Coffee.Models;

namespace Coffee.Mappers;

public static class RoomMapper
{
    public static RoomDto ToDto(this Room entity)
    {
        return new RoomDto
        {
            Id = entity.Id,
            User1 = entity.User1,
            User2 = entity.User2,
        };
    }

    public static Room ToEntity(this CreateRoomRequestDto dto)
    {
        return new Room
        {
            User1 = dto.User1,
            User2 = dto.User2,
        };
    }
}
