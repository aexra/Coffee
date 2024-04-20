using Coffee.Dtos.Image;
using Coffee.Models;

namespace Coffee.Mappers;

public static class ImageMapper
{
    public static ImageDto ToDto(this Image entity)
    {
        return new ImageDto
        {
            Id = entity.Id,
            BytesString = entity.BytesString,
        };
    }

    public static Image ToEntity(this CreateImageRequestDto dto)
    {
        return new Image
        {
            BytesString = dto.BytesString,
        };
    }
}
