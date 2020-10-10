using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestStore.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Nickname { get; set; }

        public DateTime CarrierStartedDate { get; set; }

        public string Status { get; set; }
    }
}
