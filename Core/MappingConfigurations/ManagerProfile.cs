using AutoMapper;
using RentersLife.Core.ViewModels;

namespace RentersLife.Core.MappingConfigurations
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<RentersLife.Core.Models.ManagerProfile, ManagerProfileViewModel>();
        }
    }
}
