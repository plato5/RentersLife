using Dapper;
using Microsoft.Data.SqlClient;
using RentersLife.Core.Data;
using RentersLife.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentersLife.Core.Repository
{
    public interface IManagerProfileRepository
    {
        List<ManagerProfile> GetManagerProfiles(int accountId);
        ManagerProfile GetManagerProfile(int accountId, int profileId);
    }

    public class ManagerProfileRepository : IManagerProfileRepository
    {
        public ManagerProfile GetManagerProfile(int accountId, int profileId)
        {
            ManagerProfile profile = new ManagerProfile();

            try
            {
                using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
                {
                    connection.Open();
                    profile = connection.Query<ManagerProfile>(@"SELECT * FROM ManagerProfiles WHERE AccountId = @AccountId AND Id = @Id",
                        new { Id = profileId, AccountId = accountId }).FirstOrDefault();

                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            return profile;
        }

        public List<ManagerProfile> GetManagerProfiles(int accountId)
        {
            List<ManagerProfile> managerProfiles = new List<ManagerProfile>();

            try
            {
                using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
                {
                    connection.Open();
                    managerProfiles = connection.Query<ManagerProfile>(@"SELECT * FROM ManagerProfiles WHERE AccountId = @AccountId",
                        new { AccountId = accountId }).AsList<ManagerProfile>();

                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }


            return managerProfiles;
        }
    }
}
