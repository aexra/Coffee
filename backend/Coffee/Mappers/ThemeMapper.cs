using Coffee.Dtos.Theme;
using Coffee.Models;

namespace Coffee.Mappers;

public static class ThemeMapper
{
    public static ThemeDto ToDto(this Theme entity)
    {
        return new ThemeDto
        {
            Id = entity.Id,
            Description = entity.Description,
        };
    }

    public static Theme ToTheme(this CreateThemeRequestDto dto)
    {
        return new Theme
        {
            Description = dto.Description,
        };
    }
}
