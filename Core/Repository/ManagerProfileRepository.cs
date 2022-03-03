using RentersLife.Core.Models;
using System.Collections.Generic;

namespace RentersLife.Core.Repository
{
    public interface IManagerProfileRepository
    {
        List<ManagerProfile> GetManagerProfiles(int accountId);
    }

    public class ManagerProfileRepository : IManagerProfileRepository
    {
        public List<ManagerProfile> GetManagerProfiles(int accountId)
        {
            throw new System.NotImplementedException();
        }
    }
}
