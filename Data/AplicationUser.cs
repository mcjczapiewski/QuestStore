using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestStore.Data
{
    public class AplicationUser : IdentityUser
    {
        public string Nickname { get; set; }

        public DateTime CarierStartedDate { get; set; }

        public string Status { get; set; }
    }
}
