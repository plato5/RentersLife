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
        void CreateManagerProfile(int accountId, ManagerProfile profile);
        void EditManagerProfile(int accountId, ManagerProfile profile);
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

        public void CreateManagerProfile(int accountId, ManagerProfile profile)
        {
            try
            {
                using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
                {
                    connection.Open();
                    connection.Execute(@"INSERT INTO ManagerProfiles (AccountId, PropertyName, PropertyDescription, Line1, Line2, City, State, PostalCode, Country, Telephone, Fax, Price, Bedrooms, Bathrooms)
                        VALUES(@AccountId, @PropertyName, @PropertyDescription, @Line1, @Line2, @City, 
                                @State, @State, @PostalCode, @Country, @Telephone, @Fax, @Price, @Bedrooms, @Bathrooms)",
                            new
                            {
                                AccountId = profile.AccountId,
                                PropertyName = profile.PropertyName,
                                PropertyDescription = profile.PropertyDescription,
                                Line1 = profile.Line1,
                                Line2 = profile.Line2,
                                City = profile.City,
                                State = profile.State,
                                PostalCode = profile.PostalCode,
                                Country = profile.Country,
                                Telephone = profile.Telephone,
                                Fax = profile.Fax,
                                Price = profile.Price,
                                Bedrooms = profile.Bedrooms,
                                Bathrooms = profile.Bathrooms
                            });
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public void EditManagerProfile(int accountId, ManagerProfile profile)
        {
            try
            {
                using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
                {
                    connection.Open();
                    connection.Execute(@"UPDATE ManagerProfiles
                                        SET AccountId = @AccountId, PropertyName = @PropertyName, 
                                        PropertyDescription = @PropertyDescription, Line1 = @Line1, Line2 = @Line2, 
                                        City = @City, State = @State, PostalCode = @PostalCode, 
                                        Country = @Country, Telephone = @Telephone, Fax = @Fax, Price = @Price, 
                                        Bedrooms = @Bedrooms, Bathrooms = @Bathrooms
                                        WHERE AccountId = @AccountId AND Id = @Id",
                            new
                            {
                                Id = profile.Id,
                                AccountId = profile.AccountId,
                                PropertyName = profile.PropertyName,
                                PropertyDescription = profile.PropertyDescription,
                                Line1 = profile.Line1,
                                Line2 = profile.Line2,
                                City = profile.City,
                                State = profile.State,
                                PostalCode = profile.PostalCode,
                                Country = profile.Country,
                                Telephone = profile.Telephone,
                                Fax = profile.Fax,
                                Price = profile.Price,
                                Bedrooms = profile.Bedrooms,
                                Bathrooms = profile.Bathrooms
                            });
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
