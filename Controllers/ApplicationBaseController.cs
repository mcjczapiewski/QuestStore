using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QuestStore.Data;
using QuestStore.Models;

namespace QuestStore.Controllers
{
    public class ApplicationBaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new horizonp_ccqueststoreContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.Email == username);
                    ViewData.Add("UserLogin", user?.Login);
                }
            }
            base.OnActionExecuted(filterContext);
        }
        public ApplicationBaseController()
        {}
    }
}
