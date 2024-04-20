using Coffee.Dtos.User;
using Coffee.Models;

namespace Coffee.Mappers;

public static class UserMappers
{
    public static UserDto ToDto(this User entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            HiredSince = entity.HiredSince,
            Avatar = entity.Avatar,
            MeetingsCount = entity.MeetingsCount,
            Name = entity.Name,
            Surname = entity.Surname,
            Patronymic = entity.Patronymic,
            Position = entity.Position,
            Hobbies = entity.Hobbies,
            Pets = entity.Pets,
            Coffee = entity.Coffee,
            Telegram = entity.Telegram,
            Vk = entity.Vk,
            PhoneNumber = entity.PhoneNumber
        };
    }

    public static User ToUser(this CreateUserRequestDto dto)
    {
        return new User
        {
            HiredSince = dto.HiredSince,
            MeetingsCount = dto.MeetingsCount,
            Name = dto.Name,
            Surname = dto.Surname,
            Patronymic = dto.Patronymic,
            Position = dto.Position,
            Hobbies = dto.Hobbies,
            Pets = dto.Pets,
            Coffee = dto.Coffee,
            Telegram = dto.Telegram,
            Vk = dto.Vk,
            PhoneNumber = dto.PhoneNumber
        };
    }
}
