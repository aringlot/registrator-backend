using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Registrator.DependencyInjection;

namespace Registrator
{
    public class Bootstrapper
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterWebApiModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterModule<DefaultModule>();
            builder.RegisterModule<FilterModule>();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}