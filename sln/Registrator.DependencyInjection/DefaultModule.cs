using Autofac;
using Registrator.Services.Abstract;
using Registrator.Services.Concrete;
using Registrator.WebModels.User;

namespace Registrator.DependencyInjection
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>().InstancePerLifetimeScope();
            builder.RegisterType<HashProvider>().As<IHashProvider>().SingleInstance();
            builder.RegisterType<TokenService>().As<ITokenService>().SingleInstance();
            builder.RegisterType<UserContext>().As<IUserContext>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
