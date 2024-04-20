using Coffee.Dtos.FutureMeeting;
using Coffee.Models;

namespace Coffee.Mappers;

public static class FutureMeetingMapper
{
    public static FutureMeetingDto ToDto(this FutureMeeting entity)
    {
        return new FutureMeetingDto
        {
            Id = entity.Id,
            Date = entity.Date,
            Duration = entity.Duration,
            User1 = entity.User1,
            User2 = entity.User2,
        };
    }

    public static FutureMeeting ToEntity(this CreateFutureMeetingRequestDto dto)
    {
        return new FutureMeeting
        {
            Date = dto.Date,
            Duration = dto.Duration,
            User1 = dto.User1,
            User2 = dto.User2,
        };
    }
}
