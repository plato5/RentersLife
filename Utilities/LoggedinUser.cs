using Microsoft.AspNetCore.Http;
using RentersLife.Core.ViewModels;
using RentersLife.Utilities;

namespace RentersLife.Utilities
{
    public class LoggedinUser
    {
        public static AccountViewModel GetAccount(HttpContext context)
        {
            if (context == null)
                return null;

            return context.Session.Get<AccountViewModel>(context.Session.Id);   
            
        }
    }
}
