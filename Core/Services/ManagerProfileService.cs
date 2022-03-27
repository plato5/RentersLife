using AutoMapper;
using RentersLife.Core.Models;
using RentersLife.Core.Repository;
using RentersLife.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace RentersLife.Core.Services
{
    public interface IManagerProfileService
    {
        List<ManagerProfileViewModel> GetManagerProfiles(int accountId);
        ManagerProfileViewModel GetManagerProfile(int accountId, int profileId);
    }

    public class ManagerProfileService : IManagerProfileService
    {
        private readonly IMapper _mapper;
        private readonly IManagerProfileRepository _managerProfileRepository;

        public ManagerProfileService(IMapper mapper, IManagerProfileRepository managerProfileRepository)
        {
            _mapper = mapper;
            _managerProfileRepository = managerProfileRepository;
        }

        public ManagerProfileViewModel GetManagerProfile(int accountId, int profileId)
        {
            ManagerProfileViewModel managerProfile = new ManagerProfileViewModel();

            try
            {
                var profile = _managerProfileRepository.GetManagerProfile(accountId, profileId);
                managerProfile = _mapper.Map<ManagerProfile, ManagerProfileViewModel>(profile);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }

            return managerProfile;
        }

        public List<ManagerProfileViewModel> GetManagerProfiles(int accountId)
        {
            List<ManagerProfileViewModel> managerProfiles = new List<ManagerProfileViewModel>();

            try
            {
                var profiles = _managerProfileRepository.GetManagerProfiles(accountId);
                managerProfiles = _mapper.Map<List<ManagerProfile>, List<ManagerProfileViewModel>>(profiles);                                  
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }

            return managerProfiles;

        }
    }
}
