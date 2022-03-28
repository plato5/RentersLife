using AutoMapper;
using RentersLife.Core.Repository;

namespace RentersLife.Core.Services
{
    public interface IRenterProfileService
    {

    }


    public class RenterProfileService : IRenterProfileService
    {
        private readonly IMapper _mapper;
        private readonly IRenterProfileRepository _renterProfileRepository;

        public RenterProfileService(IMapper mapper, IRenterProfileRepository renterProfileRepository)
        {
            _mapper = mapper;
            _renterProfileRepository = renterProfileRepository;
        }
    }
}
