using AutoMapper;
using RentersLife.Core.Models;
using RentersLife.Core.Repository;
using RentersLife.ViewModels;
using System;
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
            AccountViewModel accountView = null;

            try
            {
                Account newAccount = _mapper.Map<Account>(registrationView);
                newAccount.Password = BC.HashPassword(registrationView.Password);

                var account = _accountRepository.CreateAccount(newAccount);
                accountView = _mapper.Map<AccountViewModel>(account);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw;
            }

            return accountView;
        }

        public AccountViewModel Authenicate(LoginViewModel loginView)
        {
            AccountViewModel accountView = null;

            try
            {
                var account = _accountRepository.GetAccountByEmail(loginView.Email);

                if (account == null)
                    return null;
                else if (!BC.Verify(loginView.Password, account.Password))
                    return null;

                accountView = _mapper.Map<AccountViewModel>(account);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }

            return accountView;
        }
    }
}
