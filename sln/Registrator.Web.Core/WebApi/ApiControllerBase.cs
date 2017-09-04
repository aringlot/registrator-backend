using System.Web.Http;
using System.Web.Http.Cors;

namespace Registrator.Web.Core.WebApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiControllerBase : ApiController
    {
    }
}