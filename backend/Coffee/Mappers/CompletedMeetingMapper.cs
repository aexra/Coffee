using Coffee.Dtos.CompletedMeeting;
using Coffee.Models;

namespace Coffee.Mappers;

public static class CompletedMeetingMapper
{
    public static CompletedMeetingDto ToDto(this CompletedMeeting entity)
    {
        return new CompletedMeetingDto
        {
            Id = entity.Id,
            Date = entity.Date,
            Duration = entity.Duration,
            User1 = entity.User1,
            User2 = entity.User2,
            Success = entity.Success,
            Canceller = entity.Canceller,
            Images = entity.Images,
        };
    }

    public static CompletedMeeting ToEntity(this CreateCompletedMeetingRequestDto dto)
    {
        return new CompletedMeeting
        {
            Date = dto.Date,
            Duration = dto.Duration,
            User1 = dto.User1,
            User2 = dto.User2,
            Success = dto.Success,
            Canceller = dto.Canceller,
            Images = dto.Images,
            ImagesBlobbed = dto.ImagesBlobbed,
        };
    }
}
