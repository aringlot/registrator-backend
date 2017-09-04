using Registrator.Models;

namespace Registrator.Services.Abstract
{
    public interface ITokenService
    {
        string CreateTokenByUser(User user);
        User GetUserByToken(string token);
    }
}
