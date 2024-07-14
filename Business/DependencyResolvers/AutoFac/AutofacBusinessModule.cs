using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Repositories;

namespace Business.DependencyResolvers.AutoFac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerDependency();
        builder.RegisterType<UserOperationClaimRepository>().As<IUserOperationClaimRepository>().InstancePerLifetimeScope();
        builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();
        builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
        builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerDependency();

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
               .AsImplementedInterfaces()
               .EnableInterfaceInterceptors(new ProxyGenerationOptions
               {
                   Selector = new AspectInterceptorSelector()
               })
               .InstancePerDependency();
    }
}

