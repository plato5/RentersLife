using AutoMapper;
using RentersLife.Core.Models;
using RentersLife.Core.Repository;
using RentersLife.ViewModels;

namespace RentersLife.Core.Services
{

    public interface IAccountService
    {
        AccountViewModel ValidateAccount(LoginViewModel account);
        AccountViewModel CreateAccount(RegistrationViewModel registrationView);
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, IMapper mapper) 
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public AccountViewModel CreateAccount(RegistrationViewModel registrationView)
        {
            Account newAcount = _mapper.Map<Account>(registrationView);
            var account = _accountRepository.CreateAccount(newAcount);

            var accountView = _mapper.Map<AccountViewModel>(account);
            return accountView;
        }

        public AccountViewModel ValidateAccount(LoginViewModel loginView)
        {
            var account = _accountRepository.GetAccountByEmail(loginView.Email);

            // password decryption
            // check for valid password

            var accountView = _mapper.Map<AccountViewModel>(account);                       

            return accountView;
        }
    }
}
