using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

using Autofac.Integration.WebApi;

using Registrator.Services.Abstract;
using Registrator.WebModels.User;

namespace Registrator.Filters
{
    public class AuthorizationFilter : IAutofacAuthorizationFilter
    {
        private readonly ITokenService _tokenService;
        private readonly IUserContext _userContext;

        public AuthorizationFilter(ITokenService tokenService, 
            IUserContext userContext)
        {
            _tokenService = tokenService;
            _userContext = userContext;
        }

        public Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                var authHeader = actionContext.Request.Headers.Authorization;

                var user = _tokenService.GetUserByToken(authHeader.Parameter);

                _userContext.User = user;

                if(user == null)
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
            }

            return Task.FromResult(0);
        }
    }
}
