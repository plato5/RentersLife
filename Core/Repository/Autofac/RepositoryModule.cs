using Autofac;

namespace RentersLife.Core.Repository.Autofac
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<ManagerProfileRepository>().As<IManagerProfileRepository>();
            builder.RegisterType<RenterProfileRepository>().As<IRenterProfileRepository>();
        }
    }
}
