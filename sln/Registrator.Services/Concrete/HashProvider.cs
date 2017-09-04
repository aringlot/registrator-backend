using System.Security.Cryptography;
using System.Text;
using Registrator.Services.Abstract;

namespace Registrator.Services.Concrete
{
    public class HashProvider : IHashProvider
    {
        public string BuildMd5Hash(string source)
        {
            return Encoding.UTF8.GetString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(source)));
        }
    }
}
