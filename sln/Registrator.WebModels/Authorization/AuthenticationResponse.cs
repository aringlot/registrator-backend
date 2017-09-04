using Registrator.WebModels.Core;

namespace Registrator.WebModels.Authorization
{
    public class AuthenticationResponse : ResponseBase
    {
        public string Token { get; set; }
    }
}
