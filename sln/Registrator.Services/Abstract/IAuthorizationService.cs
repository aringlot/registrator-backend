namespace Registrator.Services.Abstract
{
    public interface IAuthorizationService
    {
        string Authorize(string login, string password);

        bool IsAuthorized(string token);
    }
}
