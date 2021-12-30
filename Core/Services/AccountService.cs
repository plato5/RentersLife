using RentersLife.Core.Repository;
using RentersLife.ViewModels;

namespace RentersLife.Core.Services
{

    public interface IAccountService
    {
        AccountViewModel ValidateAccount(AccountViewModel account);
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
        }

        public AccountViewModel ValidateAccount(AccountViewModel account)
        {
            var acnt = _accountRepository.GetAccountByUserName(account.UserName);

            // password decryption
            // check for valid password

            // TODO: Auto Mapper is next
            var acntView = new AccountViewModel
            {
                Id = acnt.Id,
                UserName = acnt.UserName,
                Password = acnt.Password,
                Email = acnt.Email
            };

            return acntView;
        }
    }
}
