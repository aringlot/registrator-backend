using Autofac;
using Autofac.Integration.WebApi;
using Registrator.Filters;
using Registrator.Web.Core.WebApi;

namespace Registrator.DependencyInjection
{
    public class FilterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizationFilter>()
                .AsWebApiAuthorizationFilterFor<ApiUserControllerBase>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
