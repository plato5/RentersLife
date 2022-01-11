using RentersLife.Core.Models.Types;

namespace RentersLife.ViewModels
{
    public class RegistrationViewModel
    {            
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public AccountType AccounType { get; set; }

       // AddressViewModel Address { get; set; }
    }
}
