using Dapper;
using Microsoft.Data.SqlClient;
using RentersLife.Core.Data;
using RentersLife.Core.Models;
using System;
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
