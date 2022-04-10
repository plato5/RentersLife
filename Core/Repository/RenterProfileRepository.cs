using Dapper;
using Microsoft.Data.SqlClient;
using RentersLife.Core.Data;
using RentersLife.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentersLife.Core.Repository
{
    public interface IRenterProfileRepository
    {
        List<RenterProfile> GetRenterProfiles(int accountId);
        RenterProfile GetRenterProfile(int accountId, int profileId);

        void CreateRenterProfile(int accountId, RenterProfile profile);
        void EditRenterProfile(int accountId, RenterProfile profile);
    }


    public class RenterProfileRepository : IRenterProfileRepository
    {
        public void CreateRenterProfile(int accountId, RenterProfile profile)
        {
            try
            {
                using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
                {
                    connection.Open();
                    connection.Execute(@"INSERT INTO RenterProfile (AccountId, Email, FirstName, MiddleName, LastName, Phone, DateOfBirth, 
                                                                    SSN, HasBeenEvicted, CommitedFelony, PerformBackgroundCheck, ProvideIdentity, 
                                                                    ProvideProofOfIncome, GrossIncome, CompanyName, CompanyEmail, CompanyPhone, 
                                                                    CanContact, RelationshipToRenter, SecondaryEmail, SecondaryPhone, PetName, 
                                                                    PetAge, PetBreed, Line1, Line2, City, State, PostalCode, Country, Telephone, Fax, Comment)
                        VALUES(@AccountId, @Email, @FirstName, @MiddleName, @LastName, @Phone, @DateOfBirth, @SSN, @HasBeenEvicted, 
                                        @CommitedFelony, @PerformBackgroundCheck, @ProvideIdentity, @ProvideProofOfIncome, @GrossIncome, @CompanyName, 
                                        @CompanyEmail, @CompanyPhone, @CanContact, @RelationshipToRenter, @SecondaryEmail, @SecondaryPhone, @PetName, 
                                        @PetAge, @PetBreed, @Line1, @Line2, @City, @State, @PostalCode, @Country, @Telephone, @Fax, @Comment)",
                            new
                            {
                                AccountId = profile.AccountId,
                                Email = profile.Email,
                                FirstName = profile.FirstName,
                                MiddleName = profile.MiddleName,
                                LastName = profile.LastName,
                                Phone = profile.Phone,
                                DateOfBirth = profile.DateOfBirth,
                                SSN = profile.SSN,
                                HasBeenEvicted = profile.HasBeenEvicted,
                                CommitedFelony = profile.CommitedFelony,
                                PerformBackgroundCheck = profile.PerformBackgroundCheck,
                                ProvideIdentity = profile.ProvideIdentity,
                                ProvideProofOfIncome = profile.ProvideProofOfIncome,
                                GrossIncome = profile.GrossIncome,
                                CompanyName = profile.CompanyName,
                                CompanyEmail = profile.CompanyEmail,
                                CompanyPhone = profile.CompanyPhone,
                                CanContact = profile.CanContact,
                                RelationshipToRenter = profile.RelationshipToRenter,
                                SecondaryEmail = profile.SecondaryEmail,
                                SecondaryPhone = profile.SecondaryPhone,
                                PetName = profile.PetName,
                                PetAge = profile.PetAge,
                                PetBreed = profile.PetBreed,
                                Line1 = profile.Line1,
                                Line2 = profile.Line2,
                                City = profile.City,
                                State = profile.State,
                                PostalCode = profile.PostalCode,
                                Country = profile.Country,
                                Telephone = profile.Telephone,
                                Fax = profile.Fax,
                                Comment = profile.Comment
                            });
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public void EditRenterProfile(int accountId, RenterProfile profile)
        {
            throw new NotImplementedException();
        }

        public List<RenterProfile> GetRenterProfiles(int accountId)
        {
            List<RenterProfile> renterProfiles = new List<RenterProfile>();

            try
            {
                using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
                {
                    connection.Open();
                    renterProfiles = connection.Query<RenterProfile>(@"SELECT * FROM RenterProfile WHERE AccountId = @AccountId",
                        new { AccountId = accountId }).AsList<RenterProfile>();

                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }


            return renterProfiles;
        }

        public RenterProfile GetRenterProfile(int accountId, int profileId)
        {
            RenterProfile profile = new RenterProfile();

            try
            {
                using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
                {
                    connection.Open();
                    profile = connection.Query<RenterProfile>(@"SELECT * FROM RenterProfile WHERE AccountId = @AccountId AND Id = @Id",
                        new { Id = profileId, AccountId = accountId }).FirstOrDefault();

                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            return profile;
        }
    }
}
