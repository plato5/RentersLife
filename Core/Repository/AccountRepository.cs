using Dapper;
using Microsoft.Data.SqlClient;
using RentersLife.Core.Data;
using RentersLife.Core.Models;
using System.Linq;

namespace RentersLife.Core.Repository
{
    public interface IAccountRepository
    {
        Account GetAccountByUserName(string userName);
    }

    public class AccountRepository : IAccountRepository
    {
        public Account GetAccountByUserName(string userName)
        {
            Account account = new Account();           
            using (var connection = new SqlConnection(DBConnection.Instance.GetConnectionString()))
            {
                connection.Open();
                account = connection.Query<Account>(@"SELCT * FROM Accounts WHERE UserName = @UserName", 
                    new { UserName = userName }).FirstOrDefault();

            }

            return account;
        }
    }
}
