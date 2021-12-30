using Dapper;
using Microsoft.Data.SqlClient;
using RentersLife.Core.Data;
using RentersLife.Core.Models;
using System.Linq;

namespace RentersLife.Core.Repository
{
    public interface IAccountRepository
    {
        Account GetAccountByEmail(string email);
    }

    public class AccountRepository : IAccountRepository
    {
        public Account GetAccountByEmail(string email)
        {
            Account account = new Account();           
            using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
            {
                connection.Open();
                account = connection.Query<Account>(@"SELCT * FROM Accounts WHERE Email = @Email", 
                    new { Email = email }).FirstOrDefault();

            }

            return account;
        }
    }
}
