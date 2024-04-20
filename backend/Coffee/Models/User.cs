using Microsoft.AspNetCore.Identity;

namespace Coffee.Models;

public class User : IdentityUser
{
    public DateOnly?    HiredSince      { get; set; }
    public Image?       Avatar          { get; set; }
    public uint         MeetingsCount   { get; set; }
    public string?      Name            { get; set; }
    public string?      Surname         { get; set; }
    public string?      Patronymic      { get; set; }
    public string?      Position        { get; set; }
    public string?      Hobbies         { get; set; }
    public string?      Pets            { get; set; }
    public string?      Coffee          { get; set; }
    public string?      Telegram        { get; set; }
    public string?      Vk              { get; set; }
}