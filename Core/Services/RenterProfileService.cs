using AutoMapper;
using RentersLife.Core.Models;
using RentersLife.Core.Repository;
using RentersLife.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace RentersLife.Core.Services
{
    public interface IRenterProfileService
    {
        List<RenterProfileViewModel> GetRenterProfiles(int accountId);
        RenterProfileViewModel GetRenterProfile(int accountId, int profileId);
        void CreateRenterProfile(int accountId, RenterProfileViewModel profile);
        void EditRenterProfile(int accountId, RenterProfileViewModel profile);
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

        public void CreateRenterProfile(int accountId, RenterProfileViewModel profile)
        {
            try
            {
                var newProfile = _mapper.Map<RenterProfileViewModel, RenterProfile>(profile);
                _renterProfileRepository.CreateRenterProfile(accountId, newProfile);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void EditRenterProfile(int accountId, RenterProfileViewModel profile)
        {
            throw new System.NotImplementedException();
        }

        public RenterProfileViewModel GetRenterProfile(int accountId, int profileId)
        {
            throw new System.NotImplementedException();
        }

        public List<RenterProfileViewModel> GetRenterProfiles(int accountId)
        {
            List<RenterProfileViewModel> renterProfiles = new List<RenterProfileViewModel>();

            try
            {
                var profiles = _renterProfileRepository.GetRenterProfiles(accountId);
                renterProfiles = _mapper.Map<List<RenterProfile>, List<RenterProfileViewModel>>(profiles);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }

            return renterProfiles;
        }
    }
}
