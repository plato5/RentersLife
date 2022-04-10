using AutoMapper;
using RentersLife.Core.ViewModels;

namespace RentersLife.Core.MappingConfigurations
{
    public class RenterProfile : Profile
    {
        public RenterProfile()
        {
            CreateMap<RentersLife.Core.Models.RenterProfile, RenterProfileViewModel>();
            CreateMap<RenterProfileViewModel, RentersLife.Core.Models.RenterProfile>();
        }
    }
}
