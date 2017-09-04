using Registrator.WebModels.User;

namespace Registrator.Web.Core.WebApi
{
    public abstract class ApiUserControllerBase : ApiControllerBase
    {
        protected readonly IUserContext UserContext;

        public ApiUserControllerBase(IUserContext userContext)
        {
            UserContext = userContext;
        }
    }
}
