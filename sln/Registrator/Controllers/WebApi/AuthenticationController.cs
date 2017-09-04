using Registrator.Services.Abstract;
using Registrator.Web.Core.WebApi;
using Registrator.WebModels.Authorization;
using Registrator.WebModels.Extensions;

namespace Registrator.Controllers.WebApi
{
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthenticationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public AuthenticationResponse Post(AuthenticationRequest request)
        {
            var token = _authorizationService.Authorize(request.Login, request.Password);
            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationResponse().AddModelError("Login", 1, "Not authorized");
            }
            
            return new AuthenticationResponse { Token = token };
        }
    }
}