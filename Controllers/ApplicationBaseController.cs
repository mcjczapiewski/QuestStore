using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using QuestStore.Data;
using QuestStore.Models;
using Microsoft.AspNetCore.Identity;

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
                    ViewData.Add("UserLogin", user?.Gender);
                }
            }
            base.OnActionExecuted(filterContext);
        }
        public ApplicationBaseController()
        {}
    }
}
