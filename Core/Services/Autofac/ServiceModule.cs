using Autofac;

namespace RentersLife.Core.Services.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>().As<IAccountService>();
        }
    }
}
