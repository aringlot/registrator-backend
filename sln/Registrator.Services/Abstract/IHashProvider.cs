namespace Registrator.Services.Abstract
{
    public interface IHashProvider
    {
        string BuildMd5Hash(string source);
    }
}
