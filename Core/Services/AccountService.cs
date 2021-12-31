using AutoMapper;
using RentersLife.Core.Models;
using RentersLife.Core.Repository;
using RentersLife.ViewModels;
using BC = BCrypt.Net.BCrypt;

namespace RentersLife.Core.Services
{

    public interface IAccountService
    {
        AccountViewModel Authenicate(LoginViewModel account);
        AccountViewModel Register(RegistrationViewModel registrationView);
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

        public AccountViewModel Register(RegistrationViewModel registrationView)
        {
            Account newAccount = _mapper.Map<Account>(registrationView);
            newAccount.Password = BC.HashPassword(registrationView.Password);

            var account = _accountRepository.CreateAccount(newAccount);

            var accountView = _mapper.Map<AccountViewModel>(account);
            return accountView;
        }

        public AccountViewModel Authenicate(LoginViewModel loginView)
        {
            var account = _accountRepository.GetAccountByEmail(loginView.Email);

            if (account == null)
                return null;
            else if (!BC.Verify(loginView.Password, account.Password))
                return null;

            var accountView = _mapper.Map<AccountViewModel>(account);                       

            return accountView;
        }
    }
}
