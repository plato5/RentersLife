using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentersLife.Core.ViewModels;
using System;

namespace RentersLife.Utilities
{
    public class AuthorizationCheck : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {           
            var user = context.HttpContext.Session.Get<AccountViewModel>(context.HttpContext.Session.Id);
            if (user == null)
            {               
                context.Result = new RedirectResult("/Error/Index");
            }
        }       
    }
}
