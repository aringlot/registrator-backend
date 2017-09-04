using Registrator.Models;
using Registrator.Services.Abstract;
using System;
using System.Collections.Generic;

namespace Registrator.Services.Concrete
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly Dictionary<string, string> _loginTable;
        private readonly ITokenService _tokenService;

        public AuthorizationService(ITokenService tokenService)
        {
            _loginTable = new Dictionary<string, string>
            {
                { "test", "12345"},
                { "test1", "1234"}
            };

            _tokenService = tokenService;
        }

        public string Authorize(string login, string password)
        {
            if (!_loginTable.ContainsKey(login) || _loginTable[login] != password)
            {
                return null;
            }

            return _tokenService.CreateTokenByUser(new User { Login = login });
        }

        public bool IsAuthorized(string token)
        {
            return _tokenService.GetUserByToken(token) != null;
        }
    }
}
