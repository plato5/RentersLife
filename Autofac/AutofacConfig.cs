using Autofac;
using RentersLife.Core.Repository.Autofac;
using RentersLife.Core.Services.Autofac;

namespace RentersLife.Autofac
{
    public class AutofacConfig
    {
        public static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
