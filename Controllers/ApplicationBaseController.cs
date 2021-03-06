﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QuestStore.Models;
using System.Linq;
using System.Security.Claims;

namespace QuestStore.Controllers
{
    public class ApplicationBaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new horizonp_questcredentialsContext();
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var user = context.Users.SingleOrDefault(u => u.CredentialsId == currentUserId);
                    ViewData["LoggedUserBalance"] = context.Wallet.FirstOrDefault(m => m.UserId == user.UserId)?.Balance ?? 0;
                    ViewData.Add("UserLogin", user?.Gender);
                }
            }
            base.OnActionExecuted(filterContext);
        }
        public ApplicationBaseController()
        { }
    }
}
