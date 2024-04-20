using System.ComponentModel.DataAnnotations;

namespace Coffee.Dtos.Account;

public class RegisterDto
{
    [Required]
    public string? UserName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public DateOnly? HiredSince
    {
        get; set;
    }
    public string? Name
    {
        get; set;
    }
    public string? Surname
    {
        get; set;
    }
    public string? Patronymic
    {
        get; set;
    }
    public string? Position
    {
        get; set;
    }
    public string? Hobbies
    {
        get; set;
    }
    public string? Pets
    {
        get; set;
    }
    public string? Coffee
    {
        get; set;
    }
    public string? Telegram
    {
        get; set;
    }
    public string? Vk
    {
        get; set;
    }
}
