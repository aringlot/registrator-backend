using Registrator.Web.Core.WebApi;
using Registrator.WebModels.User;

namespace Registrator.Controllers.WebApi
{
    public class UserController : ApiUserControllerBase
    {
        public UserController(IUserContext userContext) : base(userContext)
        {
        }

        public UserInfoResponse Get()
        {
            return new UserInfoResponse { Login = UserContext.User.Login };
        }
    }
}