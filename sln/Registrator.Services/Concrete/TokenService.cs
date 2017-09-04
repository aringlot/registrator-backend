using System;
using System.Collections.Concurrent;
using System.Linq;
using Registrator.Models;
using Registrator.Services.Abstract;

namespace Registrator.Services.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly ConcurrentDictionary<User, string> _userDictionary;

        public TokenService()
        {
            _userDictionary = new ConcurrentDictionary<User, string>();
        }

        public string CreateTokenByUser(User user)
        {
            var token = Guid.NewGuid().ToString();
            _userDictionary.AddOrUpdate(user, token, (u,t) => token);

            return token;
        }

        public User GetUserByToken(string token)
        {
            return _userDictionary.ToArray().FirstOrDefault(x => x.Value == token).Key;
        }
    }
}
