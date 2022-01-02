using Dapper;
using Microsoft.Data.SqlClient;
using RentersLife.Core.Data;
using RentersLife.Core.Models;
using System;
using System.Linq;

namespace RentersLife.Core.Repository
{
    public interface IAccountRepository
    {
        Account GetAccountByEmail(string email);
        Account CreateAccount(Account account);
    }

    public class AccountRepository : IAccountRepository
    {
        public Account CreateAccount(Account account)
        {
            Account newAccount = new Account();

            try
            {
                using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
                {
                    connection.Open();
                    connection.Execute(@"INSERT INTO Account(Password, PasswordHash, Email, FirstName, MiddleName, LastName)
                        VALUES(@Password, @PasswordHash, @Email, @FirstName, @MiddleName, @LastName)",
                            new
                            {
                                Password = account.Password,
                                PasswordHash = account.PasswordHash,
                                Email = account.Email,
                                FirstName = account.FirstName,
                                MiddleName = account.MiddleName,
                                LastName = account.LastName
                            });
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            return GetAccountByEmail(account.Email);
        }

        public Account GetAccountByEmail(string email)
        {
            Account account = new Account();

            try
            {
                using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
                {
                    connection.Open();
                    account = connection.Query<Account>(@"SELECT * FROM Account WHERE Email = @Email",
                        new { Email = email }).FirstOrDefault();

                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            return account;
        }
    }
}
