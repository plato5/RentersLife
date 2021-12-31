using AutoMapper;
using RentersLife.Core.Models;
using RentersLife.ViewModels;

namespace RentersLife.Core.MappingConfigurations
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // maps to account model
            CreateMap<RegistrationViewModel, Account>();
            CreateMap<LoginViewModel, Account>();

            // maps from account model
            CreateMap<Account, AccountViewModel>();
        }
    }
}
