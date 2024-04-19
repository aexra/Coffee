namespace Coffee.Models;

public class User
{
    public ulong Id
    {
        get; set;
    }
    public string FIO { get; set; } = "";
    public string Coffee { get; set; } = "";
    public DateOnly BirthDate
    {
        get; set;
    }
    public DateOnly HiredSince
    {
        get; set;
    }
    public string JobTitle { get; set; } = "";
    public string Hobbies { get; set; } = "";
    public string Interests { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string TGID { get; set; } = "";
    public string Pets { get; set; } = "";
}
