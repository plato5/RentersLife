using System;

namespace RentersLife.Core.ViewModels
{
    public class RenterProfileViewModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SSN { get; set; }
        public bool HasBeenEvicted { get; set; }
        public bool CommitedFelony { get; set; }
        public bool PerformBackgroundCheck { get; set; }
        public bool ProvideIdentity { get; set; }
        public bool ProvideProofOfIncome { get; set; }

        // Current Employment 
        public double GrossIncome { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public bool CanContact { get; set; }

        // Secondary Renter
        public string RelationshipToRenter { get; set; }
        public string SecondaryEmail { get; set; }
        public string SecondaryPhone { get; set; }

        // Pet
        public string PetName { get; set; }
        public int? PetAge { get; set; }
        public string PetBreed { get; set; }

        // Rental history
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Comment { get; set; }
    }
}
