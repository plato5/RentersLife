using RentersLife.Core.Models.Types;

namespace RentersLife.Core.ViewModels
{
    public class RegistrationViewModel
    {            
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public AccountType AccountType { get; set; }

       // AddressViewModel Address { get; set; }
    }
}
