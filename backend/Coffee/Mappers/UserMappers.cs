using Coffee.Dtos.User;
using Coffee.Models;

namespace Coffee.Mappers;

public static class UserMappers
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            HiredSince = user.HiredSince,
            Avatar = user.Avatar,
            MeetingsCount = user.MeetingsCount,
            Name = user.Name,
            Surname = user.Surname,
            Patronymic = user.Patronymic,
            Position = user.Position,
            Hobbies = user.Hobbies,
            Pets = user.Pets,
            Coffee = user.Coffee,
            Telegram = user.Telegram,
            Vk = user.Vk,
            PhoneNumber = user.PhoneNumber
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
