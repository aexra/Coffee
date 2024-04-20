using Coffee.Models;

namespace Coffee.Interfaces;

public interface ITokenService
{
    public string CreateToken(User user);
}
