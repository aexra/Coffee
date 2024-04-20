using Coffee.Models;

namespace Coffee.Interfaces;

public interface ITokenService
{
    public Task<string> CreateToken(User user);
}
